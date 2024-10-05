<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categoryWebForm.aspx.cs" Inherits="login.categoryWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category Management</title>
    <link rel="stylesheet" href="css/products.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Category Management</h1>
        <div class="message-label">
            <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCategoryId" runat="server" Text="Category ID"></asp:Label>
            <asp:TextBox ID="txtCategoryID" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name"></asp:Label>
            <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
        </div>

        <div class="btn-container">
            <button type="submit" runat="server" onserverclick="addBtn_Click">Add Category</button>
            
        </div>
    </form>

    
</body>
</html>
