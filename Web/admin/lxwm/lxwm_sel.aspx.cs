using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.lxwm
{
    public partial class lxwm_sel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sql = "select * from lxwm where id = " + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sql))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                }
            }
        }
    }
}