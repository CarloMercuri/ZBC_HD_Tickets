<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZBC_HD_Tickets.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="logo-header">
            <%--<label style ="margin-left: 44%;"class="indexTextStyle">ADMIN</label>--%>
            <img style="margin-left: 45%;" src="../Resources/Logos/logo_helpdesk_200.png" alt="Logo"/>
        </div>
        <div>
            <label style ="margin-left: 48%;" class="indexTextStyle">USER LOGIN</label>
        </div>
        <div class="loginBox">
            <label id="loginHeader">Login</label>
            <p>
            <div id="userPassDiv">
                <input runat="server" id="input_Username" type="username" class="infoInput" name="username" placeholder="Enter username..." required/><br>
                <input runat="server" id="input_Password" type="password" class="infoInput" name="password" placeholder="Enter password..." required/>
            </div>
            </p>            
            <asp:Button Text="Login" runat="server" id="btn_Submit" CssClass="infoButtonSubmit" />
        </div>
    </form>
</body>
</html>
