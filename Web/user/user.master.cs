using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class user : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["username"] == null)
            {
                base.Response.Redirect("/user/login.aspx?url=" + base.Request.RawUrl);
            }
            else
            {
                string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                string sid = new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
                if (sid == "")
                {
                    base.Response.Redirect("logout.aspx");
                }
                string url = base.Request.FilePath.ToLower();
                if (!url.Contains("up_center.aspx"))
                {
                    string s_xian = new SqlHelper().ExecuteScalar("select s_xian from username where username = '" + username + "'");
                }
            }
        }
    }
}