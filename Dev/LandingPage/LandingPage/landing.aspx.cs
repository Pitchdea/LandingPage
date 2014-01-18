using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
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
            if (!EmailValidator.Validate(subsc_email.Text))
            {
                Response.Write("<script type='text/javascript'>alert('This is not a valid email.');</script>");
                return; //TODO: STYLED Front-end message to user.
            }
            var added = _sqlTool.SaveIfNotExists(subsc_email.Text.ToLower());

            if (added)
            {
                var hash = _sqlTool.FindHashByEmail(subsc_email.Text);
                _emailTool.SendSubsciptionEmail(hash, subsc_email.Text);
                Response.Write("<script type='text/javascript'>alert('Thank you for subscribing to Pitchdea!.');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('There already exists an active subscruption for this email!.');</script>");
            }
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

    public class EmailTool
    {
        private readonly string _smtpHost;
        private readonly int _smtPort;
        private readonly string _emailTemplatePath;

        public EmailTool()
        {
            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");

            _smtpHost = config.AppSettings.Settings["Smtp.Host"].Value;
            _smtPort = int.Parse(config.AppSettings.Settings["Smtp.Port"].Value);
            _emailTemplatePath = config.AppSettings.Settings["Subscribe.EmailTemplatePath"].Value;

            Console.WriteLine(_smtpHost + _smtPort);
        }

        public void SendSubsciptionEmail(string hash, string email)
        {
            var body = File.ReadAllText(_emailTemplatePath);
            body = body.Replace("#UnsubscribeHash#", hash);

            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@pitchdea.com"),
                Subject = "Pitchdea thanks you for your subscription",
                IsBodyHtml = true,
                Body = body
            };
            mailMessage.To.Add(new MailAddress(email));

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