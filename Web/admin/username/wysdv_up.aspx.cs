using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class wysdv_up : System.Web.UI.Page
    {
        public double bl;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.bl = get.zk(3) * 100.0;
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wysdv where id=" + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.username.Text = r["username"].ToString();
                            this.fen.Text = get.ren(r["username"]);
                            this.phone.Text = r["phone"].ToString();
                            this.address.Text = get.s_sheng(r["s_sheng"]) + get.s_sheng(r["s_shi"]) + get.s_sheng(r["s_xian"]);
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string username = this.username.Text;
            int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
            string ifdv = "1";
            string dvfh = this.dvfh.Text;
            if (System.Convert.ToDouble(dvfh) > this.bl)
            {
                base.Response.Write(string.Concat(new object[]
				{
					"<script>alert('佣金率不能超过",
					this.bl,
					"%');location.href='",
					base.Request.RawUrl,
					"';</script>"
				}));
                base.Response.End();
            }
            else
            {
                string sql = string.Concat(new string[]
				{
					"update username set ifdv = ",
					ifdv,
					",dvfh=",
					dvfh,
					" where username = '",
					username,
					"'"
				});
                new SqlHelper().ExecuteNonQuery(sql);
                new SqlHelper().ExecuteNonQuery("update wysdv set sh = 1 where id = " + id);
                string url = base.Request.QueryString["url"];
                base.Response.Write("<script>alert('设置成功');location.href='" + url + "';</script>");
                base.Response.End();
            }
        }
    }
}