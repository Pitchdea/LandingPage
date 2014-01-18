using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace LandingPage
{
    public class SqlTool
    {
        private readonly MySqlConnection _connection;
        private const string ConnectionString = @"Server=localhost; Database=pitchdealanding;Uid=pitchdealanding;Pwd=fAcuc8up";

        public SqlTool()
        {
            _connection = new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Saves the email to database if it doesn't exist there yet.
        /// </summary>
        /// <param name="email">Email address to be added.</param>
        /// <returns>True if email was added, false if it already exists.</returns>
        public bool SaveIfNotExists(string email)
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

        /// <summary>
        /// Checks if the email is already in the database.
        /// </summary>
        /// <param name="email">Email to be checked</param>
        /// <returns>True if email found in database, false otherwise.</returns>
        private bool CheckExistence(string email)
        {
            _connection.Open();
            var command = new MySqlCommand(string.Format(@"select address from subsc_emails where address = '{0}';", email), _connection);
            var found = command.ExecuteScalar();
            _connection.Close();
            return found != null;
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
            //TODO: check for illegal characters, protection against SQL injection.
            _connection.Open();
            var query = string.Format("INSERT INTO contactform (name, email, message) VALUES ('{0}','{1}','{2}');", name, email, msg);
            var command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }

        public string FindEmailByHash(string hash)
        {
            _connection.Open();
            var command = new MySqlCommand(string.Format(@"select address from subsc_emails where hash = '{0}';", hash), _connection);
            var found = command.ExecuteScalar();
            _connection.Close();
            return found == null ? null : found.ToString();
        }
    }
}