<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientRegister.aspx.cs" Inherits="ClientWebApplication.clientRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/logins.css" />
    <style>
        input[type="number"] {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 15px;
        }

        .message-label {
            color: #28a745;
            font-size: 16px;
            font-weight: 500;
            text-align: center;
            margin-top: 20px;
	    margin-bottom: 20px;
        }

    </style>

</head>
<body>
    <video autoplay="autoplay" muted="muted" loop="loop" id="backgroundVideo">
        <source src="img/login_background.mp4" type="video/mp4" />
    </video>
    <form id="form1" runat="server">
        
        <h1>Register Form</h1>
        <div class="message-label">
            <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label5" runat="server" Text="Name:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Age:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Address:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>

        <div class="form-actions">
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
            <asp:Button CssClass="btn-login" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </div>
    </form>
    
</body>
</html>
