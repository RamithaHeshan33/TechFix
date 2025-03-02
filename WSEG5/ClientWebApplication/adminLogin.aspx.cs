using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class adminLogin : System.Web.UI.Page
    {
        LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient admin =
            new LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isValidAdmin = admin.AdminLogin(TextBox1.Text, TextBox2.Text);

            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text))
            {
                Response.Write("<script>alert('Please fill in both username and password');</script>");
                return;
            }

            if (isValidAdmin)
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect("adminDashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Login error');</script>");
            }
        }
    }
}