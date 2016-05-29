using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.admin
{
    public partial class admin : System.Web.UI.Page
    {
        public string adminstr;
        public string tit;
        public string ip;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Page.Title = get.gsstr() + "后台管理系统";
            this.tit = get.gsstr() + "后台管理系统";
            if (base.Request.Cookies["adminusername"] == null)
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Default.aspx';</script>");
                base.Response.End();
            }
            else
            {
                if (base.Request.QueryString["logout"] != null)
                {
                    HttpCookie cookie = base.Request.Cookies["adminusername"];
                    if (cookie != null)
                    {
                        cookie.Expires = System.DateTime.Now.AddDays(-1.0);
                        base.Response.AppendCookie(cookie);
                    }
                    HttpCookie cookie2 = base.Request.Cookies["fx"];
                    if (cookie2 != null)
                    {
                        cookie2.Expires = System.DateTime.Now.AddDays(-1.0);
                        base.Response.AppendCookie(cookie2);
                    }
                    base.Response.Redirect(base.Request.RawUrl);
                }
                else
                {
                    string um = base.Server.UrlDecode(base.Request.Cookies["adminusername"].Value);
                    if (um == "admin")
                    {
                        this.adminstr = "超级管理员：" + um;
                    }
                    else
                    {
                        this.adminstr = "管理员：" + um;
                    }
                    this.ip = "您的IP地址为：" + base.Request.UserHostAddress;
                }
            }
        }
        public string dits(object v)
        {
            string fig = "dis";
            string um = base.Server.UrlDecode(base.Request.Cookies["adminusername"].Value);
            if (um == "admin")
            {
                fig = "";
            }
            else
            {
                string qx = new access().ExecuteScalar("select qx from adminlogin where username = '" + um + "'");
                string[] strtemp = qx.Split(new char[]
				{
					','
				});
                string[] array = strtemp;
                for (int i = 0; i < array.Length; i++)
                {
                    string str = array[i];
                    if (str == v.ToString())
                    {
                        fig = "";
                    }
                }
            }
            return fig;
        }
    }
}