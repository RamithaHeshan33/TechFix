using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace WSEG5
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ProductService : WebService
    {
        string connectionString = @"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True";

        [WebMethod]
        public DataSet GetProducts()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT productID, productName, productPrice, productQty, productDesc," +
                    " productImage FROM ProductsTable";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "Products");
                    }
                }
            }
            return ds;
        }

        [WebMethod]
        public DataTable GetProductsByUsername(string username)
        {
            DataTable dt = new DataTable("Products");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT productID, productName, productPrice, productQty, productDesc," +
                    " productImage FROM ProductsTable WHERE username='" + username + "'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving products: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        [WebMethod]
        public DataSet GetProductNames()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT productID, productName FROM ProductsTable";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Products");
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching product names: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public string AddProduct(string productName, decimal productPrice, int productQty,
            string productDesc, string productImage, string username, string categoryId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO ProductsTable (productName, productPrice, productQty," +
                        " productDesc, productImage, username, categoryId) " +
                                   "VALUES ('" + productName + "', " + productPrice + ", " + productQty +
                                   ", '" + productDesc + "', '" + productImage + "', '" + username + "'," +
                                   " '" + categoryId + "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    int NoRows = cmd.ExecuteNonQuery();
                    return NoRows > 0 ? "Product added successfully!" : "Failed to add product.";
                }
                catch (Exception ex)
                {
                    return "Error inserting product: " + ex.Message;
                }
            }
        }

        [WebMethod]
        public DataSet GetSupplierNames()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT name, username FROM SuppliersTable";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Suppliers");
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching supplier names: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public DataSet GetCategoryNames()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT categoryId, categoryName FROM CategoryTable";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "CategoryTable");
                    return ds;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching category names: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public void UpdateProduct(int productID, string productName, decimal productPrice, int productQty, 
            string productDesc, string productImage)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string updateQuery = "UPDATE ProductsTable SET productName='" + productName
                                        + "', productPrice=" + productPrice
                                        + ", productQty=" + productQty
                                        + ", productDesc='" + productDesc
                                        + "', productImage='" + productImage
                                        + "' WHERE productID=" + productID;
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating product: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public void DeleteProduct(int productID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM ProductsTable WHERE productID=" + productID;
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting product: " + ex.Message);
                }
            }
        }

        [WebMethod]
        public string AddToCart(int productID, string username, int quantity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    decimal price = 0;
                    int availableQty = 0;

                    // Fetch product price and quantity
                    SqlCommand cmd = new SqlCommand("SELECT productPrice, productQty FROM ProductsTable " +
                        "WHERE productID = " + productID, con);
                    
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = Convert.ToDecimal(reader["productPrice"]);
                            availableQty = Convert.ToInt32(reader["productQty"]);

                            if (availableQty < quantity)
                            {
                                return "Not enough stock available.";
                            }
                        }
                        else
                        {
                            return "Product not found.";
                        }
                    }

                    decimal totalPrice = price * quantity;

                    // Insert into CartTable
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO CartTable " +
                        "(productQty, price, totalPrice, username, productID) " +
                        "VALUES (" + quantity + ", " + price + ", " + totalPrice + "," +
                        " '" + username + "', " + productID + ")", con);
                    insertCmd.ExecuteNonQuery();

                    // Update product quantity in ProductsTable
                    //SqlCommand updateCmd = new SqlCommand("UPDATE ProductsTable SET productQty = productQty - "
                    //    + quantity + " WHERE productID = " + productID, con);
                    //updateCmd.ExecuteNonQuery();

                    return "Item added to the cart successfully!";
                }
            }
            catch (Exception ex)
            {
                return "Error adding to cart: " + ex.Message;
            }
        }
    }
}
