using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class CategoryWebForm : System.Web.UI.Page
    {
        CategoryServiceReference.CategoryWebServiceSoapClient obj =
            new CategoryServiceReference.CategoryWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCategoryID.Text = obj.AutoCategoryId();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCategoryID.Text) || string.IsNullOrEmpty(txtCategoryName.Text))
            {
                Response.Write("<script>alert('Please fill all the fields');</script>");
                return;
            }

            string value = obj.insertCategory(txtCategoryID.Text, txtCategoryName.Text);
            int norecord = Int32.Parse(value);

            if (norecord > 0)
            {
                lblText.Text = "Record Successfuly Added";
            }
            else
            {
                lblText.Text = "Record Fail to Added";
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminDashboard.aspx");
        }
    }
}