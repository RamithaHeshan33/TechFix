using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace login
{
    /// <summary>
    /// Summary description for CategoryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryWebService : System.Web.Services.WebService
    {
        SqlConnection sqlCon = null;
        public SqlConnection getConnection()
        {
            try
            {
                sqlCon = new SqlConnection
          (@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);
            }
            return sqlCon;
        }

        [WebMethod]
        public string AutoCategoryId()
        {
            string CategoryId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand
                    ("Select CategoryId from  CategoryTable", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";
                bool records = dr.HasRows; //t
                if (records)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString();//C003
                    }
                    string idString = id.Substring(1);//003
                    int CTR = Int32.Parse(idString); //3
                    if (CTR >= 1 && CTR < 9)
                    {
                        CTR = CTR + 1;//4
                        CategoryId = "C00" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        CategoryId = "C" + CTR;
                   }
                }
                else
                {
                    CategoryId = "C001";
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                CategoryId = ex.ToString();
            }
            return CategoryId;
        }
        [WebMethod]
        public string insertCategory(string CategoryId, string CategoryName)
        {
            int NoRows = 0;
            try
            {
                getConnection();
        SqlCommand cmd = new SqlCommand("insert into CategoryTable values ('" +
                           CategoryId + "','" + CategoryName + "');", sqlCon);

                NoRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return NoRows.ToString();
        }
        
    }
}
