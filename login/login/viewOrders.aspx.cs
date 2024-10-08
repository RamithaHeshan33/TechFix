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
            // Define connection string and query to get products with category name and supplier name
            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");

            // Updated SQL query to join OrderTable with CategoryTable and SupplierTable
            string query = @"
                SELECT o.OrderID, o.productName, o.productQty, s.name, c.categoryName, o.status 
                FROM OrderTable o
                INNER JOIN CategoryTable c ON o.categoryId = c.categoryId
                INNER JOIN SuppliersTable s ON o.username = s.username";

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
            string supplierName = (row.FindControl("txtUsername") as TextBox).Text; // Display supplier name in update mode
            string categoryName = (row.FindControl("txtCategoryName") as TextBox).Text; // Display category name in update mode
            string status = (row.FindControl("txtStatus") as TextBox).Text;

            // Update product data in the database
            SqlConnection con = new SqlConnection(@"Data Source=RAMITHA-HESHAN\SQLEXPRESS;Initial Catalog=TechFix;Integrated Security=True");
            string updateQuery = @"
                UPDATE OrderTable 
                SET productName=@productName, productQty=@productQty, username=@username, categoryId=(SELECT categoryId FROM CategoryTable WHERE categoryName=@categoryName), status=@status 
                WHERE orderID=@orderID";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productQty", productQty);
            cmd.Parameters.AddWithValue("@username", supplierName);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
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
