using System;
using System.Data.SqlClient;

namespace login
{
    public partial class clientRegister : System.Web.UI.Page
    {
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
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO ClientTable (clientName, age, address, password, username) VALUES (@clientName, @age, @address, @password, @username)", con);

                // Add parameters with the correct types
                cmd.Parameters.AddWithValue("@clientName", txtClientName.Text);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));  // Convert age to integer
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Registered successfully!";
                    txtClientName.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                }
                else
                {
                    lblText.Text = "Failed to add record.";
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();  // Close the connection
                }
            }
        }
    }
}
