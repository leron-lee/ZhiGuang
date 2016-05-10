using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class youfei : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string fig = "";
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    fig = get.youfei(id).ToString();
                }
            }
            base.Response.Write(fig);
            base.Response.End();
        }
    }
}