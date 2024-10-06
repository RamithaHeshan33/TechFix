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

                // Get the quantity entered by the user
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int quantity = int.Parse(txtQuantity.Text);

                AddToCart(productID, username, quantity);
            }
        }

        private string GetUsername()
        {
            // Assuming you store username in session after login
            return Session["username"]?.ToString();
        }

        private void AddToCart(int productID, string username, int quantity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
                {
                    con.Open();

                    // Fetch product details (price and quantity) based on productID
                    decimal price = 0;
                    int availableQty = 0;

                    // Fetch the product price and quantity
                    SqlCommand cmd = new SqlCommand("SELECT productPrice, productQty FROM ProductsTable WHERE productID = @productID", con);
                    cmd.Parameters.AddWithValue("@productID", productID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = Convert.ToDecimal(reader["productPrice"]);
                            availableQty = Convert.ToInt32(reader["productQty"]);

                            // Check if there is enough stock
                            if (availableQty < quantity)
                            {
                                lblMessage.Text = "Not enough stock available.";
                                lblMessage.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Product not found.";
                            lblMessage.Visible = true;
                            return;
                        }
                    }

                    decimal totalPrice = price * quantity;

                    // Insert into CartTable
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO CartTable (productQty, price, totalPrice, username, productID) VALUES (@productQty, @price, @totalPrice, @username, @productID)", con);
                    insertCmd.Parameters.AddWithValue("@productQty", quantity);
                    insertCmd.Parameters.AddWithValue("@price", price);
                    insertCmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@productID", productID);

                    insertCmd.ExecuteNonQuery();

                    // Update the product quantity in ProductsTable
                    SqlCommand updateCmd = new SqlCommand("UPDATE ProductsTable SET productQty = productQty - @quantity WHERE productID = @productID", con);
                    updateCmd.Parameters.AddWithValue("@quantity", quantity);
                    updateCmd.Parameters.AddWithValue("@productID", productID);

                    updateCmd.ExecuteNonQuery();

                    lblMessage.Text = "Item added to the cart successfully!";
                    lblMessage.Visible = true;

                    // Hide the message after 10 seconds
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideLabel", "setTimeout(function(){ document.getElementById('" + lblMessage.ClientID + "').style.display='none'; }, 10000);", true);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error adding to cart: " + ex.Message;
                lblMessage.Visible = true;
            }
        }
    }
}
