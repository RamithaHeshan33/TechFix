<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientProductList.aspx.cs" Inherits="ClientWebApplication.clientProductList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product List</title>
    <link rel="stylesheet" href="css/clientProductsList.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <style>
        table {
            margin-left: 200px;
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

        #lblMessage {
            color: green;
            font-weight: bold;
            text-align: center;
            display: block;
            margin-top: 20px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <h1>Our Products</h1>
        <asp:Button ID="btnViewCart" runat="server" Text="View Cart" OnClick="btnViewCart_Click" CssClass="btn" />
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="lblMessage1"></asp:Label>
        <table>
            <tr>
                <td><h3>Select Category</h3></td>
                <td><asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddl"></asp:DropDownList> </td>
                <td><asp:Button ID="btnSearchByCat" runat="server" Text="Submit" CssClass="btnSearch" OnClick="btnSearchByCat_Click" /></td>
                <td> <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnSearch" OnClick="btnBack_Click" /> </td>
            </tr>
        </table>
        

        <div class="container">
            <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
                <ItemTemplate>
                    <div class="card">
                        <img src='<%# ResolveUrl(Eval("productImage").ToString()) %>' alt='<%# Eval("productName") %>' />
                        <h3><%# Eval("productName") %></h3>
                        <p><%# Eval("productDesc") %></p>
                        <p class="price">Price: Rs. <%# Eval("productPrice") %></p>
                        <p class='<%# Convert.ToInt32(Eval("productQty")) > 0 ? "in-stock" : "out-stock" %>'>
                            <%# Convert.ToInt32(Eval("productQty")) > 0 ? "In Stock" : "Out of Stock" %>
                        </p>

                        <div class="add-to-cart">
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity-input" Text="1"></asp:TextBox>
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn" CommandArgument='<%# Eval("productID") %>' CommandName="AddToCart" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
