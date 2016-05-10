using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class dl_xian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string fig = "";
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string sid = new SqlHelper().ExecuteScalar("select id from username where dl_xian = " + id + " and jb = 3");
                    if (sid != "")
                    {
                        fig = "1";
                    }
                }
                base.Response.Write(fig);
                base.Response.End();
            }
        }
    }
}