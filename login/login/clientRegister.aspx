<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientRegister.aspx.cs" Inherits="login.clientRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/login.css" />
    <style>
        input[type="number"] {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 15px;
        }
    </style>

</head>
<body>
    
    <div class="message-label">
        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    </div>
    <form id="form1" runat="server">
        <h1>Register Form</h1>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label5" runat="server" Text="Name:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Age:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Address:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>

        <div class="form-actions">
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Text="Register" />
            <asp:Button CssClass="btn-login" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </div>
    </form>
    
</body>
</html>
