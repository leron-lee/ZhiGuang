using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.cart
{
    public partial class Cart : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["username"] == null)
            {
                base.Response.Redirect("/user/login.aspx?url=" + base.Request.RawUrl);
            }
        }
    }
}