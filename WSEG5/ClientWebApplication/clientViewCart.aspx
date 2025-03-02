<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientViewCart.aspx.cs" Inherits="ClientWebApplication.clientViewCart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Cart - TechFix</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/cart.css" />
    <style>
        .cart-container {
            width: 70%;
            margin: 50px auto;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .cart-grid {
            width: 100%;
            border-collapse: collapse;
            font-family: 'Roboto', sans-serif;
        }

        .cart-grid th, .cart-grid td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .cart-grid th {
            background-color: #f2f2f2;
        }

        .cart-grid td {
            font-size: 16px;
        }

        .total-price {
            font-weight: bold;
            font-size: 18px;
            text-align: right;
            padding: 15px 0;
        }

        .btn {
            margin-top: 30px;
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            font-size: 16px;
        }

        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cart-container">
            <h2>Your Cart</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="cart-grid" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("productQty") %>' Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="productPrice" HeaderText="Price (Per Unit)" DataFormatString="Rs. {0:N2}" />
                    <asp:BoundField DataField="totalPrice" HeaderText="Total Price" DataFormatString="Rs. {0:N2}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="UpdateQuantity" CommandArgument='<%# Eval("productID") %>' CssClass="btn" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteItem" CommandArgument='<%# Eval("productID") %>' CssClass="btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnProceed" runat="server" Text="Proceed" CssClass="btn" OnClick="btnProceed_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
