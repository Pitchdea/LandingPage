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
        protected void Page_Load(object sender, EventArgs e)
        {
            var hash = Request.QueryString["ID"];
            var sqlTool = new SqlTool();
            var email = sqlTool.FindEmailByHash(hash);
            Email.Text = email;
        }
    }
}