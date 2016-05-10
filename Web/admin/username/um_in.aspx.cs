using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class um_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sql = "select * from username where id = " + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sql))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.tj_username.Text = get.username(r["tj_username"]);
                            this.username.Text = r["username"].ToString();
                            this.pwd.Text = r["pwd"].ToString();
                            this.pay_pwd.Text = r["pay_pwd"].ToString();
                            this.name.Text = r["name"].ToString();
                            this.phone.Text = r["phone"].ToString();
                            this.address.Text = string.Concat(new object[]
							{
								get.s_sheng(r["s_sheng"]),
								get.s_shi(r["s_shi"]),
								get.s_xian(r["s_xian"]),
								r["address"]
							});
                            this.times.Text = r["times"].ToString();
                            this.fx.Text = r["fx"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                string fx = this.fx.Text;
                string url = base.Request.QueryString["url"];
                string sql = string.Concat(new object[]
				{
					"update username set fx=",
					fx,
					" where id=",
					id
				});
                int a = new SqlHelper().ExecuteNonQuery(sql);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('操作成功..');location.href='" + url + "';</script>");
                    base.Response.End();
                }
            }
        }
    }
}