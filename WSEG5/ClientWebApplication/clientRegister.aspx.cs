using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class clientRegister : System.Web.UI.Page
    {
        LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient obj =
            new LoginRegisterServiceReference.ClientLoginRegisterServiceSoapClient();
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error connecting db: " + ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("clientLogin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string clientName = txtClientName.Text;
                int age = Convert.ToInt32(txtAge.Text);
                string address = txtAddress.Text;
                string password = txtPassword.Text;
                string username = txtUsername.Text;
                string result = obj.RegisterClient
                    (clientName, age, address, password, username);

                if (result == "Registered successfully!")
                {
                    lblText.Text = "Registration successful!";
                    txtClientName.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
                else
                {
                    lblText.Text = "Failed to register: " + result;
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error: " + ex.Message;
            }
        }
    }
}