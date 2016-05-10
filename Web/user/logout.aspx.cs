using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.user
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                HttpCookie cookie = base.Request.Cookies["username"];
                if (cookie != null)
                {
                    cookie.Expires = System.DateTime.Now.AddYears(-1);
                    base.Response.AppendCookie(cookie);
                }
                if (base.Request.QueryString["url"] == null)
                {
                    base.Response.Redirect("/");
                }
                else
                {
                    string url = base.Request.QueryString["url"];
                    base.Response.Redirect(url);
                }
            }
        }
    }
}