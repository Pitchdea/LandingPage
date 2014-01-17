using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace LandingPage
{
    public partial class Landing : Page
    {
        private SqlTool _tool;

        protected void Page_Load(object sender, EventArgs e)
        {
            _tool = new SqlTool();
        }

        protected void subsc_button_Click(object sender, EventArgs e)
        {
            if (!EmailValidator.Validate(subsc_email.Text))
            {
                return; //TODO: Front-end message to user.
            }
            //TODO: redirect and inform user of the result
            var added = _tool.SaveIfNotExists(subsc_email.Text.ToLower());
        }

        protected void contact_form_button_click(object sender, EventArgs e)
        {
            if(!EmailValidator.Validate(contact_form_email.Text))
                return; //TODO: Front-end message to user.

            if(string.IsNullOrEmpty(contact_form_name.Text))
                return; //TODO: Front-end message to user.

            if(string.IsNullOrEmpty(contact_form_message.Text))
                return; //TODO: Front-end message to user.

            //TODO: redirect and inform user of the result
            var saved = _tool.SaveContactRequest(contact_form_name.Text, contact_form_email.Text, contact_form_message.Text);
        }
    }

    public static class EmailValidator
    {
        //TODO: SQL injection
        //TODO: Other threats?

        public static bool Validate(string email)
        {
            if (email.Length > 150)
                return false;

            var regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }

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

            _connection.Open();
            var query = "INSERT INTO subsc_emails (address) VALUES ('"+email+"');";
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
    }
}