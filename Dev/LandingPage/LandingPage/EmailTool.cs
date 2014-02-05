using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using log4net;

namespace LandingPage
{
    public class EmailTool
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(SqlTool));

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
            try
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
                    try
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
                        _log.DebugFormat("Email successfully sent to {0}", email);
                    }
                    catch (Exception e)
                    {
                        _log.ErrorFormat("Exception in TASK SendSubsciptionEmail: \n Hash={0} \n Email={1} \n Message: {2} \n {3}", hash, email, e.Message, e.StackTrace);
                    }
                });
            }
            catch (Exception e)
            {
                _log.ErrorFormat("Exception in SendSubsciptionEmail: \n Hash={0} \n Email={1} \n Message: {2} \n {3}", hash, email, e.Message, e.StackTrace);
            }
        }
    }
}