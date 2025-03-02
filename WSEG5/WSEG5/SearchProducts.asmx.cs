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
    /// Summary description for SearchProducts
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchProducts : WebService
    {
        SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");

        [WebMethod]
        public DataSet SearchByCategory(string categoryId)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductsTable WHERE categoryId = @categoryId", con);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching by category: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public DataSet SearchBySupplier(string supplierUsername)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductsTable WHERE username = @supplierUsername", con);
                cmd.Parameters.AddWithValue("@supplierUsername", supplierUsername);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching by supplier: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public DataSet SearchByProductName(string productName)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductsTable WHERE productName " +
                    "LIKE '%' + @productName + '%'", con);

                cmd.Parameters.AddWithValue("@productName", productName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching by product name: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
