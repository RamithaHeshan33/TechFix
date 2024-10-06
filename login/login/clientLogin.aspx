<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientLogin.aspx.cs" Inherits="login.clientLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix Login</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login Form</h1>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <input class="checkbox" type="checkbox" onchange="document.getElementById('TextBox2').type=this.checked? 'text': 'password'" />
            <label class="checkbox-label">Show Password</label>
        </div>

        <div class="form-actions">
            <asp:Button CssClass="btn-login" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
