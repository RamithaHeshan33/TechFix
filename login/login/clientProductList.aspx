<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientProductList.aspx.cs" Inherits="login.clientProductList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product List</title>
    <style>
        .card {
            border: 1px solid #ccc;
            border-radius: 20px;
            padding: 15px;
            margin: 10px;
            width: 300px;
            display: inline-block;
            vertical-align: top;
        }
        .in-stock {
            color: green;
            font-weight: bold;
        }
        .out-stock {
            color: red;
            font-weight: bold;
        }
        .price {
            font-size: 18px;
            font-weight: bold;
            color: #333;
        }
        #lblMessage {
            color: green;
            font-weight: bold;
            margin: 20px;
        }
    </style>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <h1>Product List</h1>

            <asp:Label ID="lblMessage" runat="server" Text="" Visible="False"></asp:Label>

            <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
    <ItemTemplate>
        <div class="card">
            <h3><%# Eval("productName") %></h3>
            <p><%# Eval("productDesc") %></p>
            <p class="price">Price: Rs.<%# Eval("productPrice") %></p>
            <p class='<%# Convert.ToInt32(Eval("productQty")) > 0 ? "in-stock" : "out-stock" %>'>
                <%# Convert.ToInt32(Eval("productQty")) > 0 ? "In Stock" : "Out of Stock" %>
            </p>

            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("productID") %>' CommandName="AddToCart" />
        </div>
    </ItemTemplate>
</asp:Repeater>


        </div>
    </form>
</body>
</html>
