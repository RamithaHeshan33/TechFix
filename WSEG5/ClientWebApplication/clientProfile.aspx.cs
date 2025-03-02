using System;
using System.Data;
using System.Web.UI;

namespace ClientWebApplication
{
    public partial class clientProfile : System.Web.UI.Page
    {
        ClientWebService.ClientWebServiceSoapClient obj =
            new ClientWebService.ClientWebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure the user is logged in
                if (Session["username"] == null)
                {
                    Response.Redirect("clientLogin.aspx");
                }
                else
                {
                    LoadClientDetails();
                }
            }
        }

        protected void LoadClientDetails()
        {
            string username = Session["username"].ToString();

            DataTable dt = obj.GetClientDetails(username);

            if (dt.Rows.Count > 0)
            {
                lblUsername.Text = dt.Rows[0]["username"].ToString();
                lblPassword.Text = dt.Rows[0]["password"].ToString();
                lblName.Text = dt.Rows[0]["clientName"].ToString();
                lblAge.Text = dt.Rows[0]["age"].ToString();
                lblAddress.Text = dt.Rows[0]["address"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No client details found.');</script>");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Clear session
            Response.Redirect("clientLogin.aspx"); // Redirect to login page
        }
    }
}
