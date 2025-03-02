using System;
using System.Data;
using System.Web.UI;

namespace ClientWebApplication
{
    public partial class adminAddOrder : System.Web.UI.Page
    {
        OrderServiceReference.SupplierOrderServiceSoapClient serviceClient = 
            new OrderServiceReference.SupplierOrderServiceSoapClient();

        ProductServiceReference.ProductServiceSoapClient product =
            new ProductServiceReference.ProductServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSupplierNames();
                getCategoryNames();
                getProductNames();
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtProdQty.Text, out int productQty))
                {
                    lblText.Text = "Invalid product quantity.";
                    return;
                }

                // Get the selected product name instead of product ID
                string selectedProductName = ddlProduct.SelectedItem.Text;

                string response = serviceClient.AddOrder(
                    selectedProductName,  // Pass product name instead of ID
                    productQty,
                    dlSupplier.SelectedValue,
                    dlCategory.SelectedValue);

                lblText.Text = response;

                if (response.Contains("successfully"))
                {
                    txtProdQty.Text = "";
                    ddlProduct.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error inserting data: " + ex.Message;
            }
        }



        private void getProductNames()
        {
            try
            {
                DataSet ds = product.GetProducts();

                ddlProduct.DataSource = ds.Tables[0];
                ddlProduct.DataTextField = "productName";
                ddlProduct.DataValueField = "productID";
                ddlProduct.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error fetching product names: " + ex.Message;
            }
        }

        private void getSupplierNames()
        {
            try
            {
                DataSet ds = product.GetSupplierNames();

                dlSupplier.DataSource = ds.Tables[0];
                dlSupplier.DataTextField = "name";
                dlSupplier.DataValueField = "username";
                dlSupplier.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error fetching supplier names: " + ex.Message;
            }
        }

        private void getCategoryNames()
        {
            try
            {
                DataSet ds = product.GetCategoryNames();

                dlCategory.DataSource = ds.Tables[0];
                dlCategory.DataTextField = "categoryName";
                dlCategory.DataValueField = "categoryId";
                dlCategory.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error fetching category names: " + ex.Message;
            }
        }

        protected void backBtn_Click(object sender, EventArgs e) {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}
