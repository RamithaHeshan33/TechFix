using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace login
{
    public partial class clientLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
            string loginquery = "SELECT COUNT(*) FROM ClientTable WHERE username=@username AND password=@password";

            // Create the command and add parameters
            SqlCommand cmd = new SqlCommand(loginquery, con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);

            try
            {
                con.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    // Store the username in session
                    Session["username"] = TextBox1.Text;

                    // Redirect to dashboard or manage products page
                    Response.Redirect("dashboardWebForm.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Login error');</script>");
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