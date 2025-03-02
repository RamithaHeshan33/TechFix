<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierProductAddWebForm.aspx.cs" Inherits="ClientWebApplication.supplierProductAddWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/products.css"/>
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            padding: 20px;
        }

        h1 {
            font-size: 28px;
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: 500;
        }

        .form-group input[type="text"],
        .form-group textarea,
        .form-group select {
            width: 100%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        button[type="submit"] {
            background-color: blue;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        button[type="submit"]:hover {
            background-color: #0056b3;
        }

        .form-group input[type="file"] {
            padding: 5px;
        }

        .message-label {
            text-align: center;
            color: green;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <h1>Add New Product</h1>
    <div class="message-label">
        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    </div>

    <form id="form1" runat="server">
        <div class="form-group">
            <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
            <asp:TextBox ID="txtProdQty" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdDesc" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdImage" runat="server" Text="Product Image"></asp:Label>
            <asp:FileUpload ID="fuProdImage" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            <asp:DropDownList ID="dlSupplier" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList>
        </div>

        <button type="submit" runat="server" onserverclick="addBtn_Click">Add Product</button>
        <button type="submit" runat="server" onserverclick="backBtn_Click">Back</button>
    </form>
</body>
</html>
