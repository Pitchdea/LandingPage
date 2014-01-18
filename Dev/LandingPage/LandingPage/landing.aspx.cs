using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace LandingPage
{
    public partial class Landing : Page
    {
        private SqlTool _sqlTool;
        private EmailTool _emailTool;

        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlTool = new SqlTool();
            _emailTool = new EmailTool();
        }

        protected void subsc_button_Click(object sender, EventArgs e)
        {
            _emailTool.SendTestEmail();
            //if (!EmailValidator.Validate(subsc_email.Text))
            //{
            //    Response.Write("<script type='text/javascript'>alert('This is not a valid email.');</script>");
            //    return; //TODO: STYLED Front-end message to user.
            //}
            //Response.Write("<script type='text/javascript'>alert('Thank you for subscribing to Pitchdea!.');</script>");

            //var added = _sqlTool.SaveIfNotExists(subsc_email.Text.ToLower());

            //if (added)
            //{
            //    //TODO: send automatic email
            //}
        }

        protected void contact_form_button_click(object sender, EventArgs e)
        {
            if(!EmailValidator.Validate(contact_form_email.Text))
            {
                Response.Write("<script type='text/javascript'>alert('This is not a valid email.');</script>");
                return;
            }

            if(string.IsNullOrEmpty(contact_form_name.Text))
            {
                Response.Write("<script type='text/javascript'>alert('You need to input something into the name field.');</script>");
                return;
            } 

            if(string.IsNullOrEmpty(contact_form_message.Text))
            {
                Response.Write("<script type='text/javascript'>alert('You need to input a message.');</script>");
                return;
            } 
 
            Response.Write("<script type='text/javascript'>alert('Thank you or your message!');</script>");
            var saved = _sqlTool.SaveContactRequest(contact_form_name.Text, contact_form_email.Text, contact_form_message.Text);
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

    public class EmailTool
    {
        private readonly string _smtpHost;
        private readonly int _smtPort;
        private readonly string _emailTemplatePath;

        public EmailTool()
        {
            //var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");

            _smtpHost = config.AppSettings.Settings["Smtp.Host"].Value;
            _smtPort = int.Parse(config.AppSettings.Settings["Smtp.Port"].Value);
            _emailTemplatePath = config.AppSettings.Settings["Subscribe.EmailTemplatePath"].Value;

            Console.WriteLine(_smtpHost + _smtPort);
        }

        public void SendTestEmail()
        {
            var body = File.ReadAllText(_emailTemplatePath);

            var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@pitchdea.com"),
                    Subject = "Pitchdea thanks you for your subscription",
                    IsBodyHtml = true,
                    Body = body
                };
            mailMessage.To.Add(new MailAddress("tero.urponen@gmail.com"));

            var smtpClient = new SmtpClient
                {
                    UseDefaultCredentials = true,
                    Host = _smtpHost,
                    Port = _smtPort,
                    EnableSsl = false,
                };

            smtpClient.Send(mailMessage);
        }
    }
}