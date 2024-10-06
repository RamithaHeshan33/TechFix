using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login
{
    public partial class clientProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchProducts();
            }
        }

        private void FetchProducts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
                {
                    con.Open();

                    // Fetching productName, productDesc, productQty, and price
                    SqlCommand cmd = new SqlCommand("SELECT productID, productName, productDesc, productQty, productPrice FROM ProductsTable", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (you can add a label to display errors)
                lblMessage.Text = "Error fetching products: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                string username = GetUsername(); // Retrieve the username from session

                AddToCart(productID, username);
            }
        }

        private string GetUsername()
        {
            // Assuming you store username in session after login
            return Session["username"]?.ToString(); // Ensure this is set during login
        }

        private void AddToCart(int productID, string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
                {
                    con.Open();

                    // Fetch product details (price and quantity) based on productID
                    decimal price = 0;
                    int productQty = 1; // Default to 1 when adding to cart

                    // Fetch the product price and quantity
                    SqlCommand cmd = new SqlCommand("SELECT productPrice, productQty FROM ProductsTable WHERE productID = @productID", con);
                    cmd.Parameters.AddWithValue("@productID", productID);

                    // Use a single SqlDataReader to fetch the product price and quantity
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = Convert.ToDecimal(reader["productPrice"]);
                            int availableQty = Convert.ToInt32(reader["productQty"]);

                            // Check if the product is in stock
                            if (availableQty <= 0)
                            {
                                lblMessage.Text = "Product is out of stock.";
                                lblMessage.Visible = true;
                                return; // Exit if the product is out of stock
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Product not found.";
                            lblMessage.Visible = true;
                            return; // Exit if the product is not found
                        }
                    }

                    decimal totalPrice = price * productQty;

                    // Insert into CartTable
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO CartTable (productQty, price, totalPrice, username, productID) VALUES (@productQty, @price, @totalPrice, @username, @productID)", con);
                    insertCmd.Parameters.AddWithValue("@productQty", productQty);
                    insertCmd.Parameters.AddWithValue("@price", price);
                    insertCmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                    insertCmd.Parameters.AddWithValue("@username", username); // Fixed to use username
                    insertCmd.Parameters.AddWithValue("@productID", productID);

                    insertCmd.ExecuteNonQuery();

                    // Display success message
                    lblMessage.Text = "Item added to the cart successfully!";
                    lblMessage.Visible = true;

                    // Hide the message after 10 seconds
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideLabel", "setTimeout(function(){ document.getElementById('" + lblMessage.ClientID + "').style.display='none'; }, 10000);", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                lblMessage.Text = "Error adding to cart: " + ex.Message;
                lblMessage.Visible = true;
            }
        }


        private int GetClientID(string username, SqlConnection con)
        {
            int clientID = -1; // Default to -1 if not found
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT clientID FROM ClientTable WHERE username = @username", con);
                cmd.Parameters.AddWithValue("@username", username);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    clientID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                lblMessage.Text = "Error retrieving client ID: " + ex.Message;
                lblMessage.Visible = true;
            }
            return clientID;
        }
    }
}
