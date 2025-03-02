using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class supplierManageProductWebForm : System.Web.UI.Page
    {
        ProductServiceReference.ProductServiceSoapClient obj = 
            new ProductServiceReference.ProductServiceSoapClient();

        SearchProductsServiceReference.SearchProductsSoapClient search =
            new SearchProductsServiceReference.SearchProductsSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
        }

        private void BindProductData()
        {
            string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(username))
            {
                DataTable dt = obj.GetProductsByUsername(username);

                if (dt != null)
                {
                    ProductsGridView.DataSource = dt;
                    ProductsGridView.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No products found.');</script>");
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }




        protected void ProductsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProductsGridView.EditIndex = e.NewEditIndex;
            BindProductData();
        }

        protected void ProductsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ProductsGridView.Rows[e.RowIndex];
            int productID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            decimal productPrice = Convert.ToDecimal((row.FindControl("txtProductPrice") as TextBox).Text);
            int productQty = Convert.ToInt32((row.FindControl("txtProductQty") as TextBox).Text);
            string productDesc = (row.FindControl("txtProductDesc") as TextBox).Text;
            string productImage = (row.FindControl("txtProductImage") as TextBox).Text;

            obj.UpdateProduct(productID, productName, productPrice, productQty, productDesc, productImage); 
            ProductsGridView.EditIndex = -1;
            BindProductData();
        }

        protected void ProductsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            obj.DeleteProduct(productID);
            BindProductData();
        }

        protected void ProductsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProductsGridView.EditIndex = -1;
            BindProductData();
        }

        protected void btnSearchByProdName_Click(object sender, EventArgs e)
        {
            string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(username))
            {
                string productName = txtProdName.Text.Trim();
                DataSet ds = search.SearchByProductName(productName);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ProductsGridView.DataSource = ds.Tables[0];
                    ProductsGridView.DataBind();
                }
                else
                {
                    lblMessage.Text = "No products found.";
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierDashboardWebForm.aspx");
        }
    }
}