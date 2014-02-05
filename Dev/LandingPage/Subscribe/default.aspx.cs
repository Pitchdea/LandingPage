using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandingPage;

namespace Subscribe
{
    public partial class Default : Page
    {
        private SqlTool _sqlTool;

        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlTool = new SqlTool("Server=localhost; Database=pitchdea_hansa;Uid=root;Pwd=root");
        }

        protected void subsc_button_Click(object sender, EventArgs e)
        {
            if (!EmailValidator.Validate(subsc_email.Text))
            {
                subscmsg.Text = "The given email is not valid.";
                return;
            }
            //var added = _sqlTool.SaveIfNotExists(subsc_email.Text.ToLower());

            //if (added)
            //{
            //    subscmsg.Text = "Thank you for signing up for the closed BETA!";
            //    subsc_email.Text = string.Empty;
            //}
            //else
            //{
            //    subscmsg.Text = "This email is already registered!";
            //}
        }
    }
}