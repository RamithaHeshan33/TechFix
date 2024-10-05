<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewOrders.aspx.cs" Inherits="login.viewOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Orders</title>
    <link rel="stylesheet" href="css/manageProducts.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Orders</h1>
            <asp:GridView ID="ProductsGridView" runat="server" CssClass="gridview-container" AutoGenerateColumns="False" DataKeyNames="orderID"
                          OnRowEditing="ProductsGridView_RowEditing"
                          OnRowUpdating="ProductsGridView_RowUpdating"
                          OnRowDeleting="ProductsGridView_RowDeleting"
                          OnRowCancelingEdit="ProductsGridView_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="orderID" HeaderText="Order ID" ReadOnly="True" />
                    
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("productName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblProductQty" runat="server" Text='<%# Eval("productQty") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductQty" runat="server" Text='<%# Bind("productQty") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("username") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category ID">
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("categoryId") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryId" runat="server" Text='<%# Bind("categoryId") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
