using System;
using System.Data.SqlClient;
using System.Web.Services;

namespace WSEG5
{
    /// <summary>
    /// Summary description for ClientLoginRegisterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientLoginRegisterService : System.Web.Services.WebService
    {
        private readonly string connectionString = @"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True";

        [WebMethod]
        public string RegisterClient(string clientName, int age, string address, string password, string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ClientTable " +
                        "(clientName, age, address, password, username) " + "VALUES " +
                        "('" + clientName + "', " + age + ", '" + address + "', " +
                        "'" + password + "', '" + username + "')", con);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0 ? "Registered successfully!" : "Failed to add record.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        [WebMethod]
        public string ClientLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand
                        ("SELECT COUNT(*) FROM ClientTable WHERE " +
                        "username='" + username + "' AND password='" + password + "'", con);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0 ? "Login successful" : "Invalid username or password";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        [WebMethod]
        public bool AdminLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand
                        ("SELECT COUNT(*) FROM AdminTable WHERE " +
                        "username='" + username + "' AND password='" + password + "'", con);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        [WebMethod]
        public bool SupplierLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand
                        ("SELECT COUNT(*) FROM SuppliersTable WHERE " +
                        "username='" + username + "' AND password='" + password + "'", con);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
