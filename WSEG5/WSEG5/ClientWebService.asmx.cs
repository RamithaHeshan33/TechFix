using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSEG5
{
    /// <summary>
    /// Summary description for ClientWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientWebService : System.Web.Services.WebService
    {

        private string connectionString = @"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True";

        [WebMethod]
        public DataTable GetClientDetails(string username)
        {
            DataTable dt = new DataTable("ClientDetails");
            string query = "SELECT username, password, clientName, age, address FROM ClientTable WHERE username = @username";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        throw new Exception("Error fetching client details: " + ex.Message);
                    }
                }
            }

            return dt;
        }


        [WebMethod]
        public DataTable GetOrderedItems(string username)
        {
            DataTable dt = new DataTable("OrderedItems");
            string query = @" SELECT orderID, productName, productQty, productPrice, totalPrice, orderDate FROM OrderedListTable
            WHERE username = @username";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        throw new Exception("Error fetching ordered items: " + ex.Message);
                    }
                }
            }

            return dt;
        }

    }
}
