using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using log4net;

namespace LandingPage
{
    public class SqlTool
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(SqlTool));

        private readonly MySqlConnection _connection;
        private const string ConnectionString = @"Server=localhost; Database=pitchdealanding;Uid=pitchdealanding;Pwd=fAcuc8up";

        public SqlTool()
        {
            log4net.Config.XmlConfigurator.Configure();
            _connection = new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Saves the email to database if it doesn't exist there yet.
        /// </summary>
        /// <param name="email">Email address to be added.</param>
        /// <returns>True if email was added, false if it already exists.</returns>
        public bool SaveIfNotExists(string email)
        {
            try
            {
                if (CheckExistence(email))
                    return false;

                var shaHasher = SHA256.Create();
                var hashedBytes = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(email));
                var str = Convert.ToBase64String(hashedBytes).Replace("+","");

                _connection.Open();
                var query = "INSERT INTO subsc_emails (address, hash) VALUES ('"+email+"', '"+str+"');";
                var command = new MySqlCommand(query, _connection);
                command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in SaveIfNotExists, Email={0} \n Message: {1} \n {2}", email, e.Message, e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Checks if the email is already in the database.
        /// </summary>
        /// <param name="email">Email to be checked</param>
        /// <returns>True if email found in database, false otherwise.</returns>
        private bool CheckExistence(string email)
        {
            try
            {
                _connection.Open();
                var command = new MySqlCommand(string.Format(@"select address from subsc_emails where address = '{0}';", email), _connection);
                var found = command.ExecuteScalar();
                _connection.Close();
                return found != null;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in CheckExistence, Email={0} \n Message: {1} \n {2}", email, e.Message, e.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Saves a contact request to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SaveContactRequest(string name, string email, string msg)
        {
            try
            {
                //TODO: check for illegal characters, protection against SQL injection.
                _connection.Open();
                var query = string.Format("INSERT INTO contactform (name, email, message) VALUES ('{0}','{1}','{2}');", name, email, msg);
                var command = new MySqlCommand(query, _connection);
                command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in SaveContactRequest: \n Name={0} \n Email={1} \n Msg={2} \n Message: {3} \n {4}", name, email, msg, e.Message, e.StackTrace);
                return false;
            }
        }

        public string FindEmailByHash(string hash)
        {
            try
            {
                _connection.Open();
                var command = new MySqlCommand(string.Format(@"select address from subsc_emails where hash = '{0}';", hash), _connection);
                var found = command.ExecuteScalar();
                _connection.Close();
                return found == null ? "<not-found>" : found.ToString();
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in FindEmailByHash: \n Hash={0} \n Message: {1} \n {2}", hash, e.Message, e.StackTrace);
                return null;
            }
        }

        public string FindHashByEmail(string email)
        {
            try
            {
                _connection.Open();
                var command = new MySqlCommand(string.Format(@"select hash from subsc_emails where address = '{0}';", email), _connection);
                var found = command.ExecuteScalar();
                _connection.Close();
                return found == null ? "<not-found>" : found.ToString();
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in FindHashByEmail: \n Email={0} \n Message: {1} \n {2}", email, e.Message, e.StackTrace);
                return null;
            }
        }
        
        public bool RemoveSubscription(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) //Do not execute delete statement if email isn't valid.
                    return false;

                _connection.Open();
                var command = new MySqlCommand(string.Format(@"delete from subsc_emails where address = '{0}';", email), _connection);
                var affected = command.ExecuteNonQuery();
                _connection.Close();

                if (affected > 1)
                    throw new Exception("Deleted the same email twice.");

                return affected == 1;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in RemoveSubscription: \n Email={0} \n Message: {1} \n {2}", email, e.Message, e.StackTrace);
                return false;
            }
        }
    }
}