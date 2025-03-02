<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientProfile.aspx.cs" Inherits="ClientWebApplication.clientProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Profile - TechFix</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/profile.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <h2>Client Profile</h2>

            <div class="profile-details">
                <p><label>Username:</label> <asp:Label ID="lblUsername" runat="server"></asp:Label></p>
                <p><label>Password:</label> <asp:Label ID="lblPassword" runat="server"></asp:Label></p>
                <p><label>Name:</label> <asp:Label ID="lblName" runat="server"></asp:Label></p>
                <p><label>Age:</label> <asp:Label ID="lblAge" runat="server"></asp:Label></p>
                <p><label>Address:</label> <asp:Label ID="lblAddress" runat="server"></asp:Label></p>
            </div>

            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn-logout" />
        </div>
    </form>
</body>
</html>

