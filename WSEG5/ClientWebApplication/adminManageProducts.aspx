<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminManageProducts.aspx.cs" Inherits="ClientWebApplication.adminManageProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Products</title>
    <link rel="stylesheet" href="css/manageProducts.css" />

    <style>
        table {
            margin-left: 100px;
        }

        .ddl {
            padding: 5px;
            font-size: 16px;
            width: 200px;
        }

        .btnSearch {
            height: 30px;
            width: 60px;
            color: white;
            background-color: blue;
            border-radius: 5px;
        }

        .btnSearch:hover {
            transition: 1s;
            background-color: #0056b3;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Products</h1>
            <table>
                <tr>
                    <td> <asp:Label ID="lblMessage" runat="server" Text="" CssClass="lblMessage1"></asp:Label> </td>
                    <td><h3>Select Supplier</h3></td>
                    <td><asp:DropDownList ID="ddlSupplier" runat="server" CssClass="ddl"></asp:DropDownList> </td>
                    <td><asp:Button ID="btnSearchBySupp" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearchBySupp_Click" /></td>
                    <td> <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnSearch" OnClick="btnBack_Click"  /> </td>
                </tr>
            </table>
            <asp:GridView ID="ProductsGridView" runat="server" CssClass="gridview-container" AutoGenerateColumns="False" DataKeyNames="productID"
                          OnRowEditing="ProductsGridView_RowEditing"
                          OnRowUpdating="ProductsGridView_RowUpdating"
                          OnRowDeleting="ProductsGridView_RowDeleting"
                          OnRowCancelingEdit="ProductsGridView_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="Product ID" ReadOnly="True" />
                    
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("productName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Product Price">
                        <ItemTemplate>
                            <asp:Label ID="lblProductPrice" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductPrice" runat="server" Text='<%# Bind("productPrice") %>'></asp:TextBox>
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

                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="imgProductImage" runat="server" ImageUrl='<%# Eval("productImage") %>' Width="100px" Height="100px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductImage" runat="server" Text='<%# Bind("productImage") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Description">
                        <ItemTemplate>
                            <asp:Label ID="lblProductDesc" runat="server" Text='<%# Eval("productDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Bind("productDesc") %>'></asp:TextBox>
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
