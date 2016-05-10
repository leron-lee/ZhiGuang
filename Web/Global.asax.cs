using System;
using System.Web;
namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, System.EventArgs e)
        {
        }
        protected void Session_Start(object sender, System.EventArgs e)
        {
        }
        protected void Application_BeginRequest(object sender, System.EventArgs e)
        {
            string url = base.Request.FilePath.ToLower();
            if (url.IndexOf("admin") < 0)
            {
                this.jc360();
            }
        }
        protected void Application_AuthenticateRequest(object sender, System.EventArgs e)
        {
        }
        protected void Application_Error(object sender, System.EventArgs e)
        {
        }
        protected void Session_End(object sender, System.EventArgs e)
        {
        }
        protected void Application_End(object sender, System.EventArgs e)
        {
        }
        public void jc360()
        {
            string q = "<div style='position:fixed;top:0px;width:100%;height:100%;background-color:white;color:green;font-weight:bold;border-bottom:5px solid #999;'><br />您的提交带有不合法参数,谢谢合作!</div>";
            if (base.Request.Cookies != null)
            {
                try
                {
                    if (safe_360.CookieData())
                    {
                        base.Response.Write(q);
                        base.Response.End();
                    }
                }
                catch (System.Exception)
                {
                }
            }
            if (base.Request.UrlReferrer != null)
            {
                if (safe_360.referer())
                {
                    base.Response.Write(q);
                    base.Response.End();
                }
            }
            if (base.Request.RequestType.ToUpper() == "POST")
            {
                if (safe_360.PostData())
                {
                    base.Response.Write(q);
                    base.Response.End();
                }
            }
            if (base.Request.RequestType.ToUpper() == "GET")
            {
                if (safe_360.GetData())
                {
                    base.Response.Write(q);
                    base.Response.End();
                }
            }
        }
    }
}