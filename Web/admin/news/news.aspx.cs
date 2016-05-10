using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.news
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["typeid"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                    int x = 20;
                    int p = 1;
                    if (base.Request.QueryString["pagex"] != null)
                    {
                        p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                    }
                    string username = new System.Random().Next(100).ToString();
                    string sqlwere = " type=" + uid.ToString() + " ";
                    string sqlandwrer = " and type=" + uid.ToString() + " ";
                    string sqlstring;
                    if ((p - 1) * x == 0)
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from news where ",
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
							" * from news where px >(select max(px) from news where px in (select top ",
							(p - 1) * x,
							" px from news where ",
							sqlwere,
							" order by px) ) ",
							sqlandwrer,
							" order by px "
						});
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                    username = "typeid=" + uid.ToString();
                    this.Literal1.Text = liu.fystr_new(x, "news where " + sqlwere, username, p, "pagex", "id");
                }
            }
        }
        public static string typeid(object ob)
        {
            string fig = "";
            string o = new SqlHelper().ExecuteScalar("select name from news_type where id=" + ob);
            if (o != "")
            {
                fig = o.ToString();
            }
            return fig;
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from news where id=" + e.CommandArgument;
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
                    if (base.Request.QueryString["typeid"] != null)
                    {
                        int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                        string sqlwere = " where type=" + uuid.ToString() + " ";
                        sqlandwrer = " and type=" + uuid.ToString() + " ";
                    }
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from news where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From news where px>" + y_px.ToString() + sqlandwrer + " order by px"))
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
                        string sql = "update news set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update news set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        if (base.Request.QueryString["typeid"] != null)
                        {
                            int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                            string sqlwere = " where type=" + uuid.ToString() + " ";
                            sqlandwrer = " and type=" + uuid.ToString() + " ";
                        }
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from news where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From news where px<" + y_px.ToString() + sqlandwrer + " order by px desc"))
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
                            string sql = "update news set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update news set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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