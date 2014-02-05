using System.Data;
using System.Web.UI.WebControls;
using System;
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
                return; 
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
}