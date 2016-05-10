using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wx
{
    public partial class huifu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                username = (username ?? "");
                string sqlw = "";
                if (base.Request.QueryString["gjc"] != null)
                {
                    string gjc = base.Request.QueryString["gjc"];
                    if (gjc != "")
                    {
                        username = username + "&gjc=" + base.Server.UrlEncode(gjc);
                        sqlw = sqlw + " and gjc like ',%" + gjc + "%,' ";
                        this.gjc.Text = gjc;
                    }
                }
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from wx_huifu where id <> 0 ",
						sqlw,
						" order by px"
					});
                }
                else
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from wx_huifu where px >(select max(px) from wx_huifu where px in (select top ",
						(p - 1) * x,
						" px from wx_huifu where id <> 0 ",
						sqlw,
						" order by px)) ",
						sqlw,
						" order by px"
					});
                }
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "wx_huifu where id <> 0 " + sqlw, username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string img = new SqlHelper().ExecuteScalar("select img from wx_huifu where id=" + e.CommandArgument);
                if (img != "")
                {
                    get.del_file(img.ToString());
                }
                string sqlstring = "delete from wx_huifu where id=" + e.CommandArgument;
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
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_huifu where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From wx_huifu where px<" + y_px + " order by px desc"))
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
                        string sql = "update wx_huifu set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update wx_huifu set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_huifu where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From wx_huifu where px>" + y_px + " order by px"))
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
                            string sql = "update wx_huifu set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update wx_huifu set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string gjc = this.gjc.Text;
            base.Response.Redirect("huifu.aspx?gjc=" + gjc);
        }
    }
}