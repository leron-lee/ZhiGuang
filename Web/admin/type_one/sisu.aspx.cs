using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.type_one
{
    public partial class sisu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 100;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = "select top " + x + " * from type order by px";
                }
                else
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from type where px >(select max(px) from type where px in (select top ",
						(p - 1) * x,
						" px from type order by px) ) order by px"
					});
                }
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "type", username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string kid = new SqlHelper().ExecuteScalar("select id from type_one where tid = " + e.CommandArgument);
                if (kid == "")
                {
                    string sqlstring = "delete from type where id=" + e.CommandArgument;
                    int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                    if (a > 0)
                    {
                        base.Response.Redirect(base.Request.RawUrl);
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('请先删除改栏目下的子栏目！');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
            }
            else
            {
                if (e.CommandName == "shang")
                {
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From type where px<" + y_px.ToString() + " order by px desc"))
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
                        string sql = "update type set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update type set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From type where px>" + y_px.ToString() + " order by px"))
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
                            string sql = "update type set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update type set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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