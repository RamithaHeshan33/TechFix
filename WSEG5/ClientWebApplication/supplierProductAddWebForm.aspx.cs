using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class supplierProductAddWebForm : System.Web.UI.Page
    {
        ProductServiceReference.ProductServiceSoapClient obj = 
            new ProductServiceReference.ProductServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSupplierName();
                getCategoryName();
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtProdPrice.Text, out decimal productPrice))
                {
                    lblText.Text = "Invalid product price.";
                    return;
                }

                if (!int.TryParse(txtProdQty.Text, out int productQty))
                {
                    lblText.Text = "Invalid product quantity.";
                    return;
                }

                // Validate image upload
                string productImage = "";
                if (fuProdImage.HasFile)
                {
                    productImage = "~/Images/" + fuProdImage.FileName;
                    fuProdImage.SaveAs(Server.MapPath(productImage));
                }
                else
                {
                    lblText.Text = "Please upload an image.";
                    return;
                }

                string response = obj.AddProduct(txtProdName.Text, productPrice, productQty, txtProdDesc.Text, productImage, dlSupplier.SelectedValue, dlCategory.SelectedValue);

                lblText.Text = response;

                if (response.Contains("successfully"))
                {
                    txtProdName.Text = "";
                    txtProdPrice.Text = "";
                    txtProdQty.Text = "";
                    txtProdDesc.Text = "";
                    fuProdImage.Attributes.Clear();
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error inserting data: " + ex.Message;
            }
        }

        public void getSupplierName()
        {
            try
            {
                // Call the web service to get supplier data
                DataSet dt = obj.GetSupplierNames();

                dlSupplier.DataSource = dt;
                dlSupplier.DataTextField = "name";  // Display supplier names
                dlSupplier.DataValueField = "username";  // Use username as the value
                dlSupplier.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error fetching supplier names: " + ex.Message;
            }
        }

        public void getCategoryName()
        {
            try
            {
                // Call the web service to get category data
                DataSet dt = obj.GetCategoryNames();

                dlCategory.DataSource = dt;
                dlCategory.DataTextField = "categoryName";  // Display category names
                dlCategory.DataValueField = "categoryId";  // Use category ID as the value
                dlCategory.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error fetching category names: " + ex.Message;
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierDashboardWebForm.aspx");
        }
    }
}
