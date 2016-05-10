using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.youfei
{
    public partial class sel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from youfei order by id"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
            }
        }
        protected void tj_xg_Click(object sender, System.EventArgs e)
        {
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from youfei order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    string zhi = base.Request.Form["sheng_" + r["id"]];
                    if (zhi == "")
                    {
                        zhi = "0";
                    }
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"update youfei set price = ",
						zhi,
						" where id = ",
						r["id"]
					}));
                }
            }
            base.Response.Write("<script>alert('修改成功');location.href='" + base.Request.RawUrl + "';</script>");
            base.Response.End();
        }
    }
}