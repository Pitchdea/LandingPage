using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandingPage;
using MySql.Data.MySqlClient;

namespace Subscribe
{
    public partial class Default : Page
    {
        private string _connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            _connectionString = "Server=localhost; Database=pitchdea_hansa;Uid=root;Pwd=root";
        }

        protected void subsc_button_Click(object sender, EventArgs e)
        {
            if (!EmailValidator.Validate(subsc_email.Text))
            {
                subscmsg.Text = "The given email is not valid.";
                return;
            }

            var connection = new MySqlConnection(_connectionString);
            connection.Open();

            var command1 = new MySqlCommand(string.Format(@"select email from subs where email = '{0}';", subsc_email.Text), connection);
            var found = command1.ExecuteScalar() != null;

            var added = false;

            if (!found)
            {
                var foo = newsletter_check.Checked ? 1 : 0;

                var query = "INSERT INTO subs (email, sub) VALUES ('" + subsc_email.Text + "', '" + foo + "');";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                added = true;
            }

            connection.Close();

            if (added)
            {
                subscmsg.Text = "Thank you for signing up for the closed BETA!";
                subsc_email.Text = string.Empty;
            }
            else
            {
                subscmsg.Text = "This email is already registered!";
            }
        }
    }
}