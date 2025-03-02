using System;
using System.Web.UI;

namespace ClientWebApplication
{
    public partial class paymentSuccessful : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            // Redirect to the client dashboard
            Response.Redirect("clientDashboard.aspx");
        }
    }
}
