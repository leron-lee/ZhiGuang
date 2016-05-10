using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class shang_two : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new access().ExecuteDataTable("select * from s_shi where shengid = " + id + " order by id"))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                }
            }
        }
    }
}