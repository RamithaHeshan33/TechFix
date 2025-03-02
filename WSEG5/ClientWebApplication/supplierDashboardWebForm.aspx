<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierDashboardWebForm.aspx.cs" Inherits="ClientWebApplication.supplierDashboardWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/dashboards.css"/>

    <style>
        .logout {
            position: absolute;
            top: 10px;
            right: 10px;
            padding: 10px 20px;
            background-color: #f90f0f;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .logout:hover {
            background-color: #e02626;
        }
    </style>

</head>
<body>
    <h2>Welcome to Techfix Dashboard</h2>
    <button class="logout" runat="server" onserverclick="logoutBtn_Click">Logout</button>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <div class="card">
                <img src="img/add-item.png" alt="Add Product" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button1" runat="server" Text="Add Products" OnClick="Button1_Click" />
                </div>
            </div>

            <div class="card">
                <img src="img/checklist.png" alt="Add Category" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button2" runat="server" Text="View Orders" OnClick="Button2_Click" />
                </div>
            </div>

            <div class="card">
                <img src="img/feature.png" alt="Manage Products" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button3" runat="server" Text="Manage Products" OnClick="Button3_Click" />
                </div>
            </div>

            
        </div>
    </form>
</body>
</html>
