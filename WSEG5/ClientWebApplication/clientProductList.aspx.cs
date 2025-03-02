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
    public partial class clientProductList : System.Web.UI.Page
    {
        ProductServiceReference.ProductServiceSoapClient obj =
            new ProductServiceReference.ProductServiceSoapClient();

        SearchProductsServiceReference.SearchProductsSoapClient search =
            new SearchProductsServiceReference.SearchProductsSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
                FetchProducts();
            }
        }

        private void FetchProducts()
        {
            try
            {
                DataSet ds = obj.GetProducts();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptProducts.DataSource = ds.Tables[0];
                    rptProducts.DataBind();
                }
                else
                {
                    lblMessage.Text = "No products found.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error fetching products: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                string username = GetUsername();

                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int quantity = int.Parse(txtQuantity.Text);

                string message = obj.AddToCart(productID, username, quantity);
                lblMessage.Text = message;
                lblMessage.Visible = true;

                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "hideLabel", "setTimeout(function(){ document.getElementById('" + lblMessage.ClientID + "').style.display='none'; }, 10000);", true);
            }
        }

        private string GetUsername()
        {
            return Session["username"]?.ToString();
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("clientViewCart.aspx");
        }

        private void BindCategories()
        {
            try
            {
                DataSet dsCategories = obj.GetCategoryNames();

                if (dsCategories != null && dsCategories.Tables.Count > 0)
                {
                    ddlCategory.DataSource = dsCategories.Tables[0];
                    ddlCategory.DataTextField = "CategoryName"; // Assuming the web service returns 'CategoryName'
                    ddlCategory.DataValueField = "CategoryID";  // Assuming the web service returns 'CategoryID'
                    ddlCategory.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading categories: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void btnSearchByCat_Click(object sender, EventArgs e)
        {
            string selectedCategoryID = ddlCategory.SelectedValue;
            FetchProductsByCategory(selectedCategoryID); // Fetch filtered products
        }

        private void FetchProductsByCategory(string categoryID)
        {
            try
            {
                DataSet ds = search.SearchByCategory(categoryID);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptProducts.DataSource = ds.Tables[0];
                    rptProducts.DataBind();
                }
                else
                {
                    lblMessage.Text = "No products found for this category.";
                    lblMessage.Visible = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideLabel", "setTimeout(function(){ document.getElementById('" + lblMessage.ClientID + "').style.display='none'; }, 10000);", true);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error fetching products: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("clientDashboard.aspx");
        }
    }
}