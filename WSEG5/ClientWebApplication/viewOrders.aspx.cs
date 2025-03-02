using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class viewOrders : System.Web.UI.Page
    {
        OrderServiceReference.SupplierOrderServiceSoapClient service =
            new OrderServiceReference.SupplierOrderServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    BindProductData(Session["username"].ToString());
                }
                else
                {
                    Response.Redirect("loginSupplierWebForm.aspx");
                }
            }
        }

        private void BindProductData(string username)
        {
            DataSet ds = service.GetOrdersByUsername(username);
            if (ds.Tables.Count > 0)
            {
                ProductsGridView.DataSource = ds.Tables[0];
                ProductsGridView.DataBind();
            }
        }

        protected void ProductsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductsGridView.EditIndex = e.NewEditIndex;
            BindProductData(Session["username"].ToString());
        }

        protected void ProductsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ProductsGridView.Rows[e.RowIndex];
            int orderID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            int productQty = Convert.ToInt32((row.FindControl("txtProductQty") as TextBox).Text);
            string supplierName = (row.FindControl("txtUsername") as TextBox).Text;
            string categoryName = (row.FindControl("txtCategoryName") as TextBox).Text;
            string status = (row.FindControl("txtStatus") as TextBox).Text;

            service.UpdateOrder(orderID, productName, productQty, supplierName, categoryName);

            ProductsGridView.EditIndex = -1;
            BindProductData(Session["username"].ToString());
        }

        protected void ProductsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            service.DeleteOrder(orderID);
            BindProductData(Session["username"].ToString());
        }

        protected void ProductsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProductsGridView.EditIndex = -1;
            BindProductData(Session["username"].ToString());
        }

        

        private void ShowAlert(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}
