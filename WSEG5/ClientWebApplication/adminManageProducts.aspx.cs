using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class adminManageProducts : System.Web.UI.Page
    {
        ProductServiceReference.ProductServiceSoapClient obj =
            new ProductServiceReference.ProductServiceSoapClient();

        SearchProductsServiceReference.SearchProductsSoapClient search =
            new SearchProductsServiceReference.SearchProductsSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSupplierData();
                BindProductData();
            }
        }

        private void BindSupplierData()
        {
            DataSet dsSuppliers = obj.GetSupplierNames();
            if (dsSuppliers != null && dsSuppliers.Tables.Count > 0)
            {
                ddlSupplier.DataSource = dsSuppliers.Tables[0];
                ddlSupplier.DataTextField = "name";
                ddlSupplier.DataValueField = "username";
                ddlSupplier.DataBind();
            }

            // Add a default "Select" option
            ddlSupplier.Items.Insert(0, new ListItem("Select Supplier", "0"));
        }

        private void BindProductData()
        {
            // Load all products
            DataSet ds = obj.GetProducts();
            if (ds != null && ds.Tables.Count > 0)
            {
                ProductsGridView.DataSource = ds.Tables[0];
                ProductsGridView.DataBind();
            }
        }

        protected void btnSearchBySupp_Click(object sender, EventArgs e)
        {
            string supplierID = ddlSupplier.SelectedValue;

            if (supplierID != "0")
            {
                DataSet dsFilteredProducts = search.SearchBySupplier(supplierID);

                if (dsFilteredProducts != null && dsFilteredProducts.Tables.Count > 0)
                {
                    ProductsGridView.DataSource = dsFilteredProducts.Tables[0];
                    ProductsGridView.DataBind();
                }
            }
            else
            {
                BindProductData();
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

            // Update product using web service
            obj.UpdateProduct(productID, productName, productPrice, productQty, productDesc, productImage); // Include productImage
            ProductsGridView.EditIndex = -1;
            BindProductData();
        }


        protected void ProductsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);

            // Delete product using web service
            obj.DeleteProduct(productID);
            BindProductData();
        }

        protected void ProductsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProductsGridView.EditIndex = -1;
            BindProductData();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}
