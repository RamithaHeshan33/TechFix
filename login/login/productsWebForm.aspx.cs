using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace login
{
    public partial class productsWebForm : System.Web.UI.Page
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
                // Convert the price and quantity to the correct data types
                decimal productPrice;
                int productQty;

                if (!decimal.TryParse(txtProdPrice.Text, out productPrice))
                {
                    lblText.Text = "Invalid product price.";
                    return;
                }

                if (!int.TryParse(txtProdQty.Text, out productQty))
                {
                    lblText.Text = "Invalid product quantity.";
                    return;
                }

                // Use parameters to avoid SQL injection and handle data types properly
                SqlCommand cmd = new SqlCommand("INSERT INTO ProductsTable (productName, productPrice, productQty, productDesc) VALUES (@productName, @productPrice, @productQty, @productDesc)", con);

                // Add parameters with the correct types
                cmd.Parameters.AddWithValue("@productName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", txtProdDesc.Text);

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Record added successfully!";
                    txtProdName.Text = "";
                    txtProdPrice.Text = "";
                    txtProdQty.Text = "";
                    txtProdDesc.Text = "";
                }
                else
                {
                    lblText.Text = "Failed to add Product.";
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error inserting data: " + ex.Message;
            }
            finally
            {
                con.Close(); // Always close the connection after use
            }
        }




    }
}