using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandingPage
{
    public partial class Unsubscribe : Page
    {
        private SqlTool _sqlTool;
        private string _email;

        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            var hash = Request.QueryString["ID"];
            _sqlTool = new SqlTool();
            _email = _sqlTool.FindEmailByHash(hash);

            if (_email == null)
            {
                Confirm_Button.Enabled = false;
                MessageField.Text = "Oops! Something went wrong";
            }
            else if (_email == "<not-found>") //email was not found in our database
            {
                Confirm_Button.Enabled = false;
                MessageField.Text = "You have already canceled your subscription.";
            }
            else
            {
                Email.Text = _email;
            }
        }

        protected void ConfirmUnsubscription(object sender, EventArgs e)
        {
            _sqlTool.RemoveSubscription(_email);
            MessageField.Text = "Your email has been removed from our mailing list. We wont be disturbing you anymore.";
            Confirm_Button.Enabled = false;
        }
    }
}