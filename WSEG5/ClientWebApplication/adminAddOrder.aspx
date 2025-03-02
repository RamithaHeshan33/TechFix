<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminAddOrder.aspx.cs" Inherits="ClientWebApplication.adminAddOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/products.css"/>
</head>
<body>
    <h1>Add New Order</h1>
    <div class="message-label">
        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    </div>
    <form id="form1" runat="server">
        <div class="form-group">
            <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
            <asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
            <asp:TextBox ID="txtProdQty" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            <asp:DropDownList ID="dlSupplier" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList>
        </div>

        <button type="submit" runat="server" onserverclick="addBtn_Click">Add Order</button>
        <button type="submit" runat="server" onserverclick="backBtn_Click">Back</button>
    </form>
</body>
</html>
