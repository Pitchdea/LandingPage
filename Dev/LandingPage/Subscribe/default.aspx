<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Subscribe.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/custom-bootstrap.css"/>
    <link rel="stylesheet" href="css/main.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <section id="header" style="text-align: center;">
            <div style="display: inline-block;">
                <p class="brand">PITCHDEA</p>
                <p class="tagline">- where ideas evolve!</p>
            </div>
        </section>
        <section id ="newsletter">
            <div class="container">
                <div class="row" style="text-align: center;">
                    
				    <div>
					    <p class="lead">Sign up for closed <span style="color:#c0392b; font-weight: 400;">BETA</span>!</p>
				    </div>

                </div>
                
                <div class="row">
                    <div class="col-md-12">
                        <asp:CheckBox runat="server" Text="Subscribe for Pitchdea newsletter." ID="newsletter_check" Checked="True" CssClass="check"/>
                    </div>
                </div>

			    <div class="row">
				
				    <div class="col-md-12">

						    <div class="input-group">
						      <asp:textbox runat="server" ID="subsc_email" CssClass="form-control input-hg subs" placeholder="Email address"/>
						      <span class="input-group-btn">
							    <asp:button runat="server" OnClick="subsc_button_Click" Text="Sign up for BETA access" ID="subsc_button" CssClass="btn btn-inverse btn-hg subs" />
						      </span>
						    </div><!-- /input-group -->

				    </div>

			    </div><!-- /row -->
                <div class="row">
                    <asp:Label runat="server" ID="subscmsg" CssClass="msg"/>
                </div>
		    </div><!-- /container -->
        </section>
    </form>
</body>
</html>
