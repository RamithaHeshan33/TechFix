<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientDashboard.aspx.cs" Inherits="ClientWebApplication.clientDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Techfix Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/dashboards.css"/>
</head>
<body>
    <h2>Welcome to Techfix Dashboard</h2>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <div class="card">
                <img src="img/product.jpg" alt="Add Product" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button1" runat="server" Text="Buy Products" OnClick="Button1_Click" />
                </div>
            </div>

            <div class="card">
                <img src="img/User.png" alt="Add Category" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button2" runat="server" Text="View Profile" OnClick="Button2_Click" />
                </div>
            </div>

            <div class="card">
                <img src="img/list.jpg" alt="Manage Products" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button3" runat="server" Text="Ordered List" OnClick="Button3_Click" />
                </div>
            </div>

            
        </div>
    </form>
</body>
</html>
