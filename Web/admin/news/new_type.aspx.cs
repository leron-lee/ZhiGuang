using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.news
{
    public partial class new_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 20;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlwere = "";
                string sqlandwrer = "";
                string sqlstring;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from news_type ",
						sqlwere,
						" order by px "
					});
                }
                else
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from news_type where px not in(select top ",
						(p - 1) * x,
						" px from news_type ",
						sqlwere,
						" order by px ) ",
						sqlandwrer,
						" order by px "
					});
                }
                SqlParameter[] op = new SqlParameter[0];
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring, op))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr_new(x, "news_type" + sqlwere, username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from news_type where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
            else
            {
                if (e.CommandName == "shang")
                {
                    string sqlandwrer = "";
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from news_type where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From news_type where px<" + y_px.ToString() + sqlandwrer + " order by px desc"))
                    {
                        int i = 0;
                        foreach (DataRow r in dt.Rows)
                        {
                            i++;
                            x_id = System.Convert.ToInt32(r["id"]);
                            x_px = System.Convert.ToInt32(r["px"]);
                        }
                        if (i == 0)
                        {
                            bol = false;
                        }
                    }
                    if (bol)
                    {
                        string sql = "update news_type set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update news_type set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                        new SqlHelper().ExecuteNonQuery(sql);
                        new SqlHelper().ExecuteNonQuery(sql2);
                        base.Response.Redirect(base.Request.RawUrl);
                    }
                    else
                    {
                        base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                    }
                }
                else
                {
                    if (e.CommandName == "xia")
                    {
                        string sqlandwrer = "";
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from news_type where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From news_type where px>" + y_px.ToString() + sqlandwrer + " order by px"))
                        {
                            int i = 0;
                            foreach (DataRow r in dt.Rows)
                            {
                                i++;
                                x_id = System.Convert.ToInt32(r["id"]);
                                x_px = System.Convert.ToInt32(r["px"]);
                            }
                            if (i == 0)
                            {
                                bol = false;
                            }
                        }
                        if (bol)
                        {
                            string sql = "update news_type set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update news_type set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                            new SqlHelper().ExecuteNonQuery(sql);
                            new SqlHelper().ExecuteNonQuery(sql2);
                            base.Response.Redirect(base.Request.RawUrl);
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                        }
                    }
                }
            }
        }
    }
}