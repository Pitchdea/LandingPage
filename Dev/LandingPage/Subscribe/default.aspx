<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Subscribe._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/custom-bootstrap.css"/>
    <link rel="stylesheet" href="css/main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <section id="header">
            Pitchdea
        </section>
        <section id ="newsletter">
            <div class="container">
			    <div class="row">

				    <div class="col-md-6">
					    <p class="lead">Stay in the loop with our newsletter!</p>
				    </div>
				
				    <div class="col-md-6">

					    <!--////////// Newsletter Form //////////-->
						    <div class="input-group">
					     <%--     <input type="text" name="e-mail" id="e-mail" class="form-control input-hg">--%>
						      <asp:textbox runat="server" ID="subsc_email" CssClass="form-control input-hg" />
						      <span class="input-group-btn">
							    <asp:button runat="server" OnClick="subsc_button_Click" Text="Sign Up" ID="subsc_button" CssClass="btn btn-inverse btn-hg" />
						      </span>
						    </div><!-- /input-group -->
					    <!--////////// end of Newsletter Form ///////////-->

					    <div id="error-info">
						    <asp:label ID="subscmsg" CssClass="notif" runat="server"/>
					     </div><!-- Error notification for newsletter signup form -->

				    </div>

			    </div><!-- /row -->
		    </div><!-- /container -->
        </section>
    </form>
</body>
</html>
