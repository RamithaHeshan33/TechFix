<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productsWebForm.aspx.cs" Inherits="login.productsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Product List</h1>

        </div>

        <div>
            <asp:Label ID="lblProdName" runat="server" Text="Product Name" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtProdName" runat="server" Height="25" Width="180px"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblProdPrice" runat="server" Text="Product Price" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtProdPrice" runat="server" Height="25" Width="180px"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtProdQty" runat="server" Height="25" Width="180px" TextMode="Number"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblProdDesc" runat="server" Text="Product Description" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblSupplier" runat="server" Text="Supplier" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:DropDownList ID="dlSupplier" runat="server" Height="25" Width="180px"></asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="lblCategory" runat="server" Text="Category" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server" Height="25" Width="180px"></asp:DropDownList>
        </div>

        <asp:Button ID="addBtn" runat="server" Text="Add" OnClick="addBtn_Click" />
    </form>

    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>


</body>
</html>
