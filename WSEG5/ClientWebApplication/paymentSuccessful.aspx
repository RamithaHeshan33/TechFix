<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentSuccessful.aspx.cs" Inherits="ClientWebApplication.paymentSuccessful" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Successful</title>
    <style>
        .container {
            text-align: center;
            margin-top: 100px;
        }
        .success-message {
            font-size: 24px;
            color: green;
            font-weight: bold;
        }
        .dashboard-button {
            margin-top: 20px;
        }
        .btn {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            font-size: 16px;
        }
        .btn:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="success-message">Your payment is Successful</div>
            <div class="dashboard-button">
                <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" CssClass="btn" OnClick="btnDashboard_Click" />
            </div>
        </div>
    </form>
</body>
</html>
