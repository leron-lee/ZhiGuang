using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.admin.fh
{
    public partial class excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string neirong = new SqlHelper().ExecuteScalar("select neirong from excel where id = " + id);
                    base.Response.Write("<script>location.href='" + neirong + "';</script>");
                    base.Response.End();
                }
            }
        }
    }
}