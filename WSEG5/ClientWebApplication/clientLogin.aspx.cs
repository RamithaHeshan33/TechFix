using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class clientLogin : System.Web.UI.Page
    {
        LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient obj =
            new LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TextBox1.Text;
                string password = TextBox2.Text;

                string result = obj.ClientLogin(username, password);

                if (result == "Login successful")
                {
                    Session["username"] = username;
                    Response.Redirect("clientDashboard.aspx");
                }
                else
                {
                    Response.Write("<script>alert('" + result + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("clientRegister.aspx");
        }
    }
}
