<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboardWebForm.aspx.cs" Inherits="login.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Techfix Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet">
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 20px;
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 40px;
        }

        .dashboard-container {
            gap: 30px;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        .card {
            background-color: white;
            padding: 20px;
            border-radius: 12px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 420px;
            margin: 0 auto;
            transition: transform 0.3s ease-in-out;
        }

        .card:hover {
          transform: scale(1.05);
        }

        .card-img {
            width: 100%;
            height: auto;
            max-width: 380px;
            border-radius: 15px;
            margin-bottom: 20px;
        }

        .btn {
            margin-top: 10px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <h2>Welcome to Techfix Dashboard</h2>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <div class="card">
                <img src="add_product.jpeg" alt="Add Product" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button1" runat="server" Text="Add Products" OnClick="Button1_Click" />
                </div>
            </div>

            <div class="card">
                <img src="categories.jpg" alt="Add Category" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button2" runat="server" Text="Add Category" OnClick="Button2_Click" />
                </div>
            </div>

            <div class="card">
                <img src="categories.jpg" alt="Manage Products" class="card-img" />
                <div class="btn">
                    <asp:Button ID="Button3" runat="server" Text="Manage Products" />
                </div>
            </div>

            
        </div>
    </form>
</body>
</html>

