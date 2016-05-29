using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.AdminFx
{
    public partial class AdminFx : System.Web.UI.Page
    {
        public string adminstr;
        public string tit;
        public string ip;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Page.Title = get.gsstr() + "后台管理系统";
            this.tit = get.gsstr() + "后台管理系统";
            if (base.Request.Cookies["fx"] == null)
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Default.aspx';</script>");
                base.Response.End();
            }
            else
            {
                if (base.Request.QueryString["logout"] != null)
                {
                    HttpCookie cookie = base.Request.Cookies["fx"];
                    if (cookie != null)
                    {
                        cookie.Expires = System.DateTime.Now.AddDays(-1.0);
                        base.Response.AppendCookie(cookie);
                    }
                    HttpCookie cookie2 = base.Request.Cookies["adminusername"];
                    if (cookie2 != null)
                    {
                        cookie2.Expires = System.DateTime.Now.AddDays(-1.0);
                        base.Response.AppendCookie(cookie2);
                    }
                    base.Response.Redirect(base.Request.RawUrl);
                }
                else
                {
                    string um = base.Server.UrlDecode(base.Request.Cookies["fx"].Value);
                    if (!string.IsNullOrWhiteSpace(um) )
                    {     
                        this.adminstr = "您好：" + um;
                    }
                    this.ip = "您的IP地址为：" + base.Request.UserHostAddress;
                }
            }
        }
    }
}