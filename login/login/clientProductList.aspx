<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientProductList.aspx.cs" Inherits="login.clientProductList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product List</title>
    <link rel="stylesheet" href="css/clientProductList.css" />

    

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <h1>Our Products</h1>

        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="lblMessage"></asp:Label>

        <div class="container">
            <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
                <ItemTemplate>
                    <div class="card">
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
