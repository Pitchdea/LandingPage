<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unsubscribe.aspx.cs" Inherits="LandingPage.Unsubscribe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unsubscribe the newsletter</title>
</head>
<body>
    <form id="UnsubscribeForm" runat="server">
    <div>
        Are you sure you want to unsubscribe our newsletter? <br/>
        <asp:Label runat="server" ID="Email"/> <br/>
        <asp:Button runat="server" Text="Unsubscribe the newsletter" ID="Confirm_Button" OnClick="ConfirmUnsubscription"/> <br/>
        <asp:Label runat="server" ID="MessageField"/>
    </div>
    </form>
</body>
</html>
