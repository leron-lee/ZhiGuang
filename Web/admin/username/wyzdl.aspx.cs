using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class wyzdl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["tongguo"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["tongguo"]);
                    string url = base.Request.QueryString["url"];
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wyzdl where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            string username = r["username"].ToString();
                            string dl_sheng = r["dl_sheng"].ToString();
                            string dl_shi = r["dl_shi"].ToString();
                            string dl_xian = r["dl_xian"].ToString();
                            string sid = new SqlHelper().ExecuteScalar("select id from username where jb = 3 and dl_xian = " + dl_xian);
                            if (sid == "")
                            {
                                new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
								{
									"update username set jb = 3,dl_sheng = ",
									dl_sheng,
									",dl_shi=",
									dl_shi,
									",dl_xian=",
									dl_xian,
									" where username = '",
									username,
									"'"
								}));
                                new SqlHelper().ExecuteNonQuery("update wyzdl set sh = 1 where id=" + id);
                                base.Response.Write("<script>alert('设置成功');location.href='" + url + "';</script>");
                                base.Response.End();
                            }
                            else
                            {
                                base.Response.Write("<script>alert('该县区已存在代理');location.href='" + url + "';</script>");
                                base.Response.End();
                            }
                        }
                    }
                }
                int x = 20;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string urlw = new System.Random().Next(100).ToString();
                string sqlw = "";
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from wyzdl where id <> 0 ",
						sqlw,
						" order by id"
					});
                }
                else
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from wyzdl where id >(select max(id) from wyzdl where id in (select top ",
						(p - 1) * x,
						" id from wyzdl where id <> 0 ",
						sqlw,
						" order by id))",
						sqlw,
						" order by id"
					});
                }
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "wyzdl", urlw, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from wyzdl where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
        }
    }
}