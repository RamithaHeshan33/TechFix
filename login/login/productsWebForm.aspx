<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productsWebForm.aspx.cs" Inherits="login.productsWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/products.css"/>
    <style>
        
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
