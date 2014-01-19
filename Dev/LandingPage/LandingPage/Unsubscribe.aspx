<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unsubscribe.aspx.cs" Inherits="LandingPage.Unsubscribe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unsubscribe the newsletter</title>
    <link href="css/main.css" rel="stylesheet"/>
</head>
<body>

    	<section id="header">

		<nav class="navbar navbar-fixed-top" role="navigation">

			<div class="navbar-inner">
				<div class="container">

					<button type="button" class="btn btn-navbar" data-toggle="collapse" data-target="#navigation"></button>

					<!-- Logo goes here - replace the image with your -->
					<a href="http://www.pitchdea.com" class="navbar-brand">PITCHDEA</a>


					<div class="collapse navbar-collapse main-nav" id="navigation">


						<ul class="nav pull-right">

							<!-- Menu items go here -->
							<li class="active"></li>                  
							
							
		
							<!-- If you want sub-menu items, do them like this
							<li>
								<ul>
								  <li><a href="#">Item 1</a></li>
								  <li><a href="#">Item 2</a></li>
								</ul>
							</li> 
							You just need to delete these comment lines -->
						</ul>

					</div><!-- /nav-collapse -->
				</div><!-- /container -->
			</div><!-- /navbar-inner -->
		</nav>

	</section>
    <section id="hero">
    <form id="UnsubscribeForm" runat="server">
    <div>
        <article style="padding:5%;">
            <h3>Are you sure you want to unsubscribe our newsletter?</h3> <br/>

            <h5><asp:Label runat="server" ID="Email"/></h5> <br/>
            
            <asp:Button runat="server" Text="Unsubscribe the newsletter" ID="Confirm_Button" OnClick="ConfirmUnsubscription"/> <br/>
            <asp:Label runat="server" ID="MessageField"/>
        </article>
    </div>
    </form>
    </section>
</body>
</html>
