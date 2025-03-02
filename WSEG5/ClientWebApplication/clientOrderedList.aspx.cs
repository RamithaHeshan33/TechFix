using System;
using System.Data;
using System.Web.UI;

namespace ClientWebApplication
{
    public partial class clientOrderedList : System.Web.UI.Page
    {
        ClientWebService.ClientWebServiceSoapClient obj =
            new ClientWebService.ClientWebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    LoadOrderedItems();
                }
                else
                {
                    Response.Redirect("clientLogin.aspx");
                }
            }
        }

        protected void LoadOrderedItems()
        {
            string username = Session["username"].ToString();

            DataTable dt = obj.GetOrderedItems(username);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No orders found for this user.');</script>");
            }
        }
    }
}
