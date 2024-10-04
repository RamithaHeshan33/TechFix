<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productsWebForm.aspx.cs" Inherits="login.productsWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet">
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 20px;
        }

        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 30px;
        }

        form {
            max-width: 600px;
            margin: 0 auto;
            padding: 30px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        label {
            font-size: 16px;
            font-weight: 500;
            display: block;
            margin-bottom: 8px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        input[type="text"], input[type="number"], textarea, select {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        input[type="text"]:focus, input[type="number"]:focus, textarea:focus, select:focus {
            outline: none;
            border-color: #007bff;
        }

        textarea {
            height: 100px;
        }

        button {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            margin-top: 20px;
            transition: background-color 0.3s ease;
        }

        button:hover {
            background-color: #0056b3;
        }

        .message-label {
            color: #28a745;
            font-size: 16px;
            font-weight: 500;
            text-align: center;
            margin-top: 20px;
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
            <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            <asp:DropDownList ID="dlSupplier" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList>
        </div>

        <button type="submit" runat="server" onserverclick="addBtn_Click">Add Product</button>
    </form>

</body>
</html>
