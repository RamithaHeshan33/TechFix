<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categoryWebForm.aspx.cs" Inherits="login.categoryWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Category List</h1>

        <div>
            <asp:Label ID="lblCategoryId" runat="server" Text="Category ID" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtCategoryID" runat="server" Height="25" Width="180px"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txtCategoryName" runat="server" Height="25" Width="180px"></asp:TextBox>
        </div>

        <asp:Button ID="addBtn" runat="server" Text="Add" OnClick="addBtn_Click" />
    </form>

    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
</body>
</html>
