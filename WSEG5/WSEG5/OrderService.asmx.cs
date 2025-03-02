using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSEG5
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class SupplierOrderService : System.Web.Services.WebService
    {
        private string connectionString = @"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True";

        [WebMethod]
        public string AddOrder(string productName, int productQty, string username, string categoryId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO OrderTable (productName, productQty, username, categoryId) VALUES ('"
                        + productName + "', "
                        + productQty + ", '"
                        + username + "', '"
                        + categoryId + "')",
                        con);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Order added successfully!";
                    }
                    else
                    {
                        return "Failed to add order.";
                    }
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }


        [WebMethod]
        public DataSet GetOrdersByUsername(string username)
        {
            string query = @"
        SELECT o.OrderID, o.productName, o.productQty, s.name, c.categoryName 
        FROM OrderTable o
        INNER JOIN CategoryTable c ON o.categoryId = c.categoryId
        INNER JOIN SuppliersTable s ON o.username = s.username
        WHERE s.username = @username";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        [WebMethod]
        public void DeleteOrder(int orderID)
        {
            string deleteQuery = "DELETE FROM OrderTable WHERE orderID=@orderID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
            {
                cmd.Parameters.AddWithValue("@orderID", orderID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public void UpdateOrder(int orderID, string productName, int productQty, string username, string categoryName)
        {
            string updateQuery = @"
                UPDATE OrderTable 
                SET productName=@productName, productQty=@productQty, username=@username, categoryId=(SELECT categoryId FROM CategoryTable WHERE categoryName=@categoryName)
                WHERE orderID=@orderID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@categoryName", categoryName);
                cmd.Parameters.AddWithValue("@orderID", orderID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
