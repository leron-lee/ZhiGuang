using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Web.admin.cjh
{
    public partial class flash : System.Web.UI.Page
    {

        public string tit;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.tit = "增加";
                if (base.Request.QueryString["id"] != null)
                {
                    this.tit = "修改";
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cjh_flash where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                            this.img.Text = r["img"].ToString();

                            this.href.Text = r["url"].ToString();
                         
                        }
                    }
                }
                this.Button1.Text = " " + this.tit + " ";




              
                 
                    int x = 20;
                    int p = 1;
                    if (base.Request.QueryString["pagex"] != null)
                    {
                        p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                    }
                    string username = new System.Random().Next(100).ToString();
                    string sqlwere = " id >0  ";
                    string sqlandwrer = " and id>0 ";
                    string sqlstring;
                    if ((p - 1) * x == 0)
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from cjh_flash where ",
							sqlwere,
							" order by px ,id desc"
						});
                    }
                    else
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from cjh_flash where px >(select max(px) from cjh_flash where px in (select top ",
							(p - 1) * x,
							" px from cjh_flash where ",
							sqlwere,
							" order by px , id desc) ) ",
							sqlandwrer,
							" order by px , id desc"
						});
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                   
                    this.Literal1.Text = liu.fystr_new(x, "cjh_flash where " + sqlwere, username, p, "pagex", "id");
            

            }
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string name = this.name.Text;
            string img = this.img.Text;

            string url = this.href.Text;

            string sqlstr = "select MAX(px) FROM wx_huifu";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            string times = DateTime.Now.ToString();
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@img", img),
				new SqlParameter("@url", url),
				new SqlParameter("@px", px),
				new SqlParameter("@times", times)
			};
            string sql = "insert into cjh_flash (name,img,url,px,times) values (@name,@img,@url,@px,@times)";
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update cjh_flash set name=@name,img=@img,url=@url,px=@px,times=@times where id = " + id;
            }
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('操作成功！');location.href='" + Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }

        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from cjh_flash where id=" + e.CommandArgument;
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
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from cjh_flash where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From cjh_flash where px>" + y_px.ToString() + sqlandwrer + " order by px "))
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
                        string sql = "update cjh_flash set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update cjh_flash set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from cjh_flash where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From cjh_flash where px<" + y_px.ToString() + sqlandwrer + " order by px desc"))
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
                            string sql = "update cjh_flash set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update cjh_flash set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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