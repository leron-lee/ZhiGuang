using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class fxcg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string fig = "0";
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["username"] != null)
                {
                    string username = base.Server.UrlEncode(base.Request.Cookies["username"].Value);
                    string iffx = new SqlHelper().ExecuteScalar("select iffx from username where username = '" + username + "'");
                    if (iffx != "1")
                    {
                        new SqlHelper().ExecuteNonQuery("update username set iffx = 1 where username = '" + username + "'");
                        fig = "1";
                    }
                    string jb = get.jb_dq(username);
                    if (jb == "6")
                    {
                        string tj_username = get.tj_username(username);
                        string tj_jb = get.jb_dq(tj_username);
                        if (System.Convert.ToInt32(tj_jb) < 5)
                        {
                            new SqlHelper().ExecuteNonQuery("update username set jb = 5 where username = '" + username + "'");
                        }
                    }
                }
            }
            base.Response.Write(fig);
            base.Response.End();
        }
    }
}