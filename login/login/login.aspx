<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix</title>
    <link rel="stylesheet" href="login.css" />
    <style>
        

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
 
        </div>
        
        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="180px"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="180px" Height="35px"></asp:TextBox>
        </div>
        
        <input class="checkbox" type="checkbox" onchange="document.getElementById('TextBox2').type=this.checked? 'text': 'password'" />Show Password
        
        <div>
            <asp:Button CssClass="btn-login" Font-Size="Large" ID="Button1" runat="server" Text="Login" ForeColor="White" BackColor="#33CC33" Height="40px" Width="90px" OnClick="Button1_Click" />
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />
        </div>
    </form>
</body>
</html>
