using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class adminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAddOrder.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCategoryWebForm.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminManageProducts.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }
    }
}