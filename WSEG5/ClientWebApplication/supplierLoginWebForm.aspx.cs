using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClientWebApplication
{
    public partial class loginSupplierWebForm : System.Web.UI.Page
    {

        LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient supplier =
            new LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool isValidSupplier = supplier.SupplierLogin(TextBox1.Text, TextBox2.Text);

            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text))  {
                Response.Write("<script>alert('Please fill in both username and password');</script>");
                return;
            }

            if (isValidSupplier)
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect("supplierDashboardWebForm.aspx");
            }
            else
            {
                Response.Write("<script>alert('Login error');</script>");
            }
        }
    }
}