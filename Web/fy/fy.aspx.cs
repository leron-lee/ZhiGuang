using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.fy
{
    public partial class fy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string fig = "";
                if (base.Request["url"] != null)
                {
                    string url = base.Request["url"];
                    string nt = get.geturl(url);
                    fig = nt.Substring(nt.IndexOf("<!--分页内容开始-->"), nt.IndexOf("<!--分页内容结束-->") - nt.IndexOf("<!--分页内容开始-->") + 13).Replace("<!--分页内容开始-->", "").Replace("<!--分页内容结束-->", "");
                }
                base.Response.Write(fig);
                base.Response.End();
            }
        }
    }
}