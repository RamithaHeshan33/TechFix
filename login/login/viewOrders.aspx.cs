using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login
{
    public partial class viewOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
        }

        private void BindProductData()
        {
            // Define connection string and query to get products
            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
            string query = "SELECT orderID, productName, productQty, username, categoryId, status FROM OrderTable";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the product data to GridView
                ProductsGridView.DataSource = dt;
                ProductsGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void ProductsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row in edit mode
            ProductsGridView.EditIndex = e.NewEditIndex;
            BindProductData();
        }

        protected void ProductsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve values from the GridView
            GridViewRow row = ProductsGridView.Rows[e.RowIndex];
            int orderID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            int productQty = Convert.ToInt32((row.FindControl("txtProductQty") as TextBox).Text);
            string username = (row.FindControl("txtUsername") as TextBox).Text;
            string categoryId = (row.FindControl("txtCategoryId") as TextBox).Text;
            string status = (row.FindControl("txtStatus") as TextBox).Text;

            // Update product data in the database
            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
            string updateQuery = "UPDATE OrderTable SET productName=@productName, productQty=@productQty, username=@username, categoryId=@categoryId, status=@status WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productQty", productQty);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@categoryId", categoryId);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ProductsGridView.EditIndex = -1; // Exit edit mode
                BindProductData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void ProductsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);

            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
            string deleteQuery = "DELETE FROM OrderTable WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@orderID", orderID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                BindProductData(); // Refresh the GridView after deletion
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void ProductsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the editing mode
            ProductsGridView.EditIndex = -1;
            BindProductData();
        }
    }
}
