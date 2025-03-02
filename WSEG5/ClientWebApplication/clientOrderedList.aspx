<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientOrderedList.aspx.cs" Inherits="ClientWebApplication.clientOrderedList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ordered List</title>
    <link rel="stylesheet" href="css/manageProducts.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Your Ordered Items</h1>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No orders found." CssClass="gridview-container">
                <Columns>
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:BoundField DataField="productQty" HeaderText="Quantity" />
                    <asp:BoundField DataField="productPrice" HeaderText="Price (Rs.)" DataFormatString="Rs. {0:N2}" />
                    <asp:BoundField DataField="totalPrice" HeaderText="Total Price (Rs.)" DataFormatString="Rs. {0:N2}" />
                    <asp:BoundField DataField="orderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
