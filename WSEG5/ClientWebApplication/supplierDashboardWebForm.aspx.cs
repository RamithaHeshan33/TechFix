using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class supplierDashboardWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                if (Session["username"] != null)

                {

                    
                }

                else

                {

                    Response.Redirect("supplierLoginWebForm.aspx"); // Redirect to login if not logged in

                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierProductAddWebform.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewOrders.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierManageProductWebForm.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierLoginWebForm.aspx");
        }
    }
}