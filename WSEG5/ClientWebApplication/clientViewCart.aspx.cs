using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class clientViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    LoadCartItems();
                }
                else
                {
                    Response.Redirect("clientLogin.aspx");
                }
            }
        }

        protected void LoadCartItems()
        {
            string username = Session["username"].ToString();

            using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
            {
                string query = @"
                    SELECT c.productID, c.productQty, p.productName, p.productPrice, c.totalPrice
                    FROM CartTable c
                    INNER JOIN ProductsTable p ON c.productID = p.productID
                    WHERE c.username = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Bind data to GridView
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('No items in your cart.');</script>");
                        
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();

            using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
            {
                string selectQuery = @"
                    SELECT c.productID, c.productQty, c.totalPrice, p.productName, p.productPrice
                    FROM CartTable c
                    INNER JOIN ProductsTable p ON c.productID = p.productID
                    WHERE c.username = @username";

                string insertQuery = @"
                    INSERT INTO OrderedListTable (username, productID, productQty, productName, productPrice, totalPrice)
                    VALUES (@username, @productID, @productQty, @productName, @productPrice, @totalPrice)";

                string deleteQuery = "DELETE FROM CartTable WHERE username = @username";

                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                selectCmd.Parameters.AddWithValue("@username", username);
                deleteCmd.Parameters.AddWithValue("@username", username);

                try
                {
                    con.Open();
                    SqlDataReader reader = selectCmd.ExecuteReader();
                    DataTable cartItems = new DataTable();
                    cartItems.Load(reader);

                    foreach (DataRow row in cartItems.Rows)
                    {
                        int productID = Convert.ToInt32(row["productID"]);
                        int quantity = Convert.ToInt32(row["productQty"]);

                        insertCmd.Parameters.Clear();
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@productID", productID);
                        insertCmd.Parameters.AddWithValue("@productQty", quantity);
                        insertCmd.Parameters.AddWithValue("@productName", row["productName"]);
                        insertCmd.Parameters.AddWithValue("@productPrice", row["productPrice"]);
                        insertCmd.Parameters.AddWithValue("@totalPrice", row["totalPrice"]);
                        insertCmd.ExecuteNonQuery();

                        // Update ProductsTable stock
                        using (SqlCommand updateCmd = new SqlCommand("UPDATE ProductsTable SET productQty = productQty - @quantity WHERE productID = @productID", con))
                        {
                            updateCmd.Parameters.AddWithValue("@quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@productID", productID);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Redirect("paymentSuccessful.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No items to delete from your cart.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("clientProductList.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateQuantity")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                int newQuantity = Convert.ToInt32(txtQuantity.Text);

                UpdateCartQuantity(productID, newQuantity);
            }
            else if (e.CommandName == "DeleteItem")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                DeleteCartItem(productID);
            }
        }

        protected void UpdateCartQuantity(int productID, int newQuantity)
        {
            string username = Session["username"].ToString();

            using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
            {
                try
                {
                    con.Open();

                    // Get the price of the product from the ProductsTable
                    decimal productPrice;
                    string priceQuery = "SELECT price FROM CartTable WHERE productID = @productID";
                    using (SqlCommand priceCmd = new SqlCommand(priceQuery, con))
                    {
                        priceCmd.Parameters.AddWithValue("@productID", productID);
                        object result = priceCmd.ExecuteScalar();

                        // Check if the product price was found
                        if (result != null)
                        {
                            productPrice = (decimal)result;
                        }
                        else
                        {
                            Response.Write("<script>alert('Product not found.');</script>");
                            return; // Exit the method if the product is not found
                        }
                    }

                    // Calculate the total price
                    decimal totalPrice = productPrice * newQuantity;

                    // Update the quantity and total price in the CartTable
                    string updateQuery = @"
                UPDATE CartTable 
                SET productQty = @quantity, 
                    totalPrice = @totalPrice 
                WHERE productID = @productID AND username = @username";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            LoadCartItems(); // Refresh cart items
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to update quantity.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
        }


        protected void DeleteCartItem(int productID)
        {
            string username = Session["username"].ToString();

            using (SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True"))
            {
                string deleteQuery = "DELETE FROM CartTable WHERE productID = @productID AND username = @username";

                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Redirect("clientViewCart.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to delete item.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
