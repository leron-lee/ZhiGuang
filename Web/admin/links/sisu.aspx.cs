using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.links
{
    public partial class sisu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["tid"] != null)
                {
                    int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                    int x = 100;
                    int p = 1;
                    if (base.Request.QueryString["pagex"] != null)
                    {
                        p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                    }
                    string username = new System.Random().Next(100).ToString();
                    username = username + "&tid=" + tid;
                    string sqlstring = string.Empty;
                    if ((p - 1) * x == 0)
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from links where tid = ",
							tid,
							" order by px"
						});
                    }
                    else
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from links where px >(select max(px) from links where px in (select top ",
							(p - 1) * x,
							" px from links where tid = ",
							tid,
							" order by px) ) and tid = ",
							tid,
							" order by px"
						});
                    }
                    using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = li;
                        this.Repeater1.DataBind();
                    }
                    this.Literal1.Text = liu.fystr(x, "links where tid = " + tid, username, p, "pagex", "id");
                }
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string img = new SqlHelper().ExecuteScalar("select img from links where id=" + e.CommandArgument);
                if (img != "")
                {
                    get.del_file(img.ToString());
                }
                string sqlstring = "delete from links where id=" + e.CommandArgument;
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
                    if (base.Request.QueryString["tid"] != null)
                    {
                        int uuid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                        string sqlwere = " where tid=" + uuid.ToString() + " ";
                        sqlandwrer = " and tid=" + uuid.ToString() + " ";
                    }
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from links where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From links where px<" + y_px.ToString() + sqlandwrer + " order by px desc"))
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
                        string sql = "update links set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update links set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        if (base.Request.QueryString["tid"] != null)
                        {
                            int uuid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                            string sqlwere = " where tid=" + uuid.ToString() + " ";
                            sqlandwrer = " and tid=" + uuid.ToString() + " ";
                        }
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from links where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From links where px>" + y_px.ToString() + sqlandwrer + " order by px"))
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
                            string sql = "update links set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update links set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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