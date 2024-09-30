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

            if (!IsPostBack)
            {
                getSupplierName();
                getCategoryName();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO ProductsTable (productName, productPrice, productQty, productDesc, username, categoryId) VALUES (@productName, @productPrice, @productQty, @productDesc, @username, @categoryId)", con);

                // Add parameters with the correct types
                cmd.Parameters.AddWithValue("@productName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", txtProdDesc.Text);
                cmd.Parameters.AddWithValue("@username", dlSupplier.SelectedValue);  // Use the selected value (username) from the dropdown
                cmd.Parameters.AddWithValue("@categoryId", dlCategory.SelectedValue);

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


        public void getSupplierName()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT name, username FROM SuppliersTable", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "SuppliersTable");

                dlSupplier.DataSource = ds.Tables[0];
                dlSupplier.DataTextField = "name"; // Display the supplier name in the dropdown
                dlSupplier.DataValueField = "username"; // Use the username as the value
                dlSupplier.DataBind();
            }
            catch (Exception ex)
            {
                dlSupplier.Text = "Error selecting Department Name: " + ex.Message;
            }
        }


        public string getSupplierUsername()
        {
            string SupplierUsername = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT username FROM SuppliersTable WHERE name = '" + dlSupplier.Text + "'", con);
                SqlDataReader datareader = cmd.ExecuteReader();

                bool records = datareader.HasRows;
                if (records)
                {
                    while (datareader.Read())
                    {
                        SupplierUsername = datareader[0].ToString();
                    }
                }
                datareader.Close();
            }

            catch (Exception ex)
            {
                lblText.Text = "Ërror selecting department Id " + ex;
            }

            return SupplierUsername;
        }


        public void getCategoryName()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CategoryTable", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "CategoryTable");

                dlCategory.DataSource = ds.Tables[0];
                dlCategory.DataTextField = "categoryName"; // Display the supplier name in the dropdown
                dlCategory.DataValueField = "categoryId"; // Use the username as the value
                dlCategory.DataBind();
            }
            catch (Exception ex)
            {
                dlCategory.Text = "Error selecting Category Name: " + ex.Message;
            }
        }

        public string getCategoryID()
        {
            string CategoryID = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT categoryId FROM CategoryTable WHERE categoryName = '" + dlCategory.Text + "'", con);
                SqlDataReader datareader = cmd.ExecuteReader();

                bool records = datareader.HasRows;
                if (records)
                {
                    while (datareader.Read())
                    {
                        CategoryID = datareader[0].ToString();
                    }
                }
                datareader.Close();
            }

            catch (Exception ex)
            {
                lblText.Text = "Ërror selecting department Id " + ex;
            }

            return CategoryID;
        }
    }
}