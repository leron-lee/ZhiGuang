using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class shang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new access().ExecuteDataTable("select * from s_sheng order by id"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
            }
        }
    }
}