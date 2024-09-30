using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace login
{
    public partial class categoryWebForm : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
                con.Open();
            }

            catch(Exception ex)
            {
                lblText.Text = "Error connecting db" + ex;
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("insert into CategoryTable values('" + txtCategoryID.Text + "', '" + txtCategoryName.Text + "');", con);

                // Execute the command and check if any rows were affected
                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Category added successfully!";
                }
                else
                {
                    lblText.Text = "Failed to add customer.";
                }
            }

            catch (Exception ex)
            {
                lblText.Text = "Error inserting data " + ex;
            }
        }
    }
}