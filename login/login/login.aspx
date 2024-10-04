<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix Login</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet">
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        form {
            background-color: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            width: 100%;
        }

        h1 {
            text-align: center;
            color: #9900CC;
            margin-bottom: 30px;
            font-size: 28px;
            font-weight: 700;
        }

        label {
            font-size: 16px;
            font-weight: 500;
            margin-bottom: 10px;
            display: block;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        input[type="text"]:focus, input[type="password"]:focus {
            border-color: #007bff;
            outline: none;
        }

        .checkbox {
            margin-bottom: 20px;
        }

        .btn-login, .btn-cancel {
            display: inline-block;
            width: 45%;
            padding: 10px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            text-align: center;
        }

        .btn-login {
            background-color: #33CC33;
            color: white;
        }

        .btn-login:hover {
            background-color: #28a745;
        }

        .btn-cancel {
            background-color: #dc3545;
            color: white;
        }

        .btn-cancel:hover {
            background-color: #c82333;
        }

        .checkbox-label {
            margin-left: 5px;
            font-size: 14px;
        }

        .form-actions {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }
    </style>
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
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Text="Cancel" />
        </div>
    </form>
</body>
</html>
