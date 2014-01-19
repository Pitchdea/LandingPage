using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using log4net;

namespace LandingPage
{
    public partial class LandingPage : Page
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LandingPage));

        private SqlTool _sqlTool;
        private EmailTool _emailTool;

        protected void Page_Load(object sender, EventArgs e)
        {
            contmsg.Text = "";
            subscmsg.Text = "";

            log4net.Config.XmlConfigurator.Configure();
            _log.Debug("test");

            try
            {
                _sqlTool = new SqlTool();
                _emailTool = new EmailTool();
            }
            catch (Exception exception)
            {
                _log.ErrorFormat("Exception loading tools: {0} \n {1}", exception.Message, exception.StackTrace);
            }
        }

        protected void subsc_button_Click(object sender, EventArgs e)
        {
            if (!EmailValidator.Validate(subsc_email.Text))
            {
                subscmsg.Text="This is not a valid email.";
                return; //TODO: STYLED Front-end message to user.
            }
            var added = _sqlTool.SaveIfNotExists(subsc_email.Text.ToLower());

            if (added)
            {
                var hash = _sqlTool.FindHashByEmail(subsc_email.Text);

                if (hash == null)
                {
                    _log.ErrorFormat("Didn't find hash for email: {0}", subsc_email.Text);
                }

                _emailTool.SendSubsciptionEmail(hash, subsc_email.Text);
                subscmsg.Text = "Thank you for subscribing!";
                subsc_email.Text = string.Empty;
            }
            else
            {
                subscmsg.Text = "There already exists an active subscription with this email.";
            }
        }

        protected void contact_form_button_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(contact_form_name.Text))
            {
                contmsg.Text = "You need to input something into the name field."; ;
                return;
            } 

            if(!EmailValidator.Validate(contact_form_email.Text))
            {
                contmsg.Text = "The email needs to be valid.";
                return;
            }

            if(string.IsNullOrEmpty(contact_form_message.Text))
            {
                contmsg.Text = "You need to input a message.";
                return;
            }
            
            var saved = _sqlTool.SaveContactRequest(
                contact_form_name.Text, 
                contact_form_email.Text, 
                SqlInjectionScreening(contact_form_message.Text)
            );

            if (saved)
            {
                contmsg.Text = "Thank you for your message!";
                contact_form_email.Text = string.Empty;
                contact_form_name.Text = string.Empty;
                contact_form_message.Text = string.Empty;
            }
            else
            {
                contmsg.Text = "Oops! Something went wrong.";
            }
        }

        private string SqlInjectionScreening(string text)
        {
            return text
                .Replace("--", "_")
                .Replace(";--", "_")
                .Replace(";", "_")
                .Replace("/*", "_")
                .Replace("*/", "_")
                .Replace("@@", "_")
                .Replace("'", "''");
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
            var smtPortString = config.AppSettings.Settings["Smtp.Port"].Value;
            _emailTemplatePath = config.AppSettings.Settings["Subscribe.EmailTemplatePath"].Value;

            if (string.IsNullOrEmpty(_smtpHost))
                throw new Exception("couldn't read Smtp.Host from configuration file.");
            if (string.IsNullOrEmpty(smtPortString))
                throw new Exception("couldn't read Smtp.Host from configuration file.");
            if (string.IsNullOrEmpty(_emailTemplatePath))
                throw new Exception("couldn't read Subscribe.EmailTemplatePath from configuration file.");

            _smtPort = int.Parse(smtPortString);
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

            Task.Factory.StartNew(() =>
                {
                    var smtpClient = new SmtpClient
                        {
                            UseDefaultCredentials = true,
                            Host = _smtpHost,
                            Port = _smtPort,
                            EnableSsl = true,
                            Credentials = new NetworkCredential("no-reply@pitchdea.com", "sunESwu4")
                        };
                    smtpClient.Send(mailMessage);
                });
        }
    }
}