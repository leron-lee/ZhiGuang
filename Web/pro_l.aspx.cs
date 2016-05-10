using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class pro_l : System.Web.UI.Page
    {
        public string pzong = "0";
        public string ditk = "dis";
        public string nrtext;
        public string hb = "dis";
        public string ys;
        public string cc;
        public string ku = "0";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from merchandise where id = " + id))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            this.nrtext = r["nrtext"].ToString();
                            if (System.Convert.ToInt32(r["s8"]) > 0)
                            {
                                this.hb = "";
                            }
                            if (r["ifsj"].ToString() != "1")
                            {
                                base.Response.Write("<script>alert('宝贝不存在，或者已下架');location.href='default.aspx';</script>");
                                base.Response.End();
                            }
                        }

                        if (id == 51)
                        {
                            ku = new SqlHelper().ExecuteScalar("select ku from yk_two where id=43").ToString();
                        }
                        if (id == 49)
                        {
                            ku = new SqlHelper().ExecuteScalar("select ku from yk_two where id=44").ToString();
                        }
                    }

                    this.pzong = new SqlHelper().ExecuteScalar("select count(id) from pingjia where mid = " + id);
                    this.fy();
                    using (DataTable dt = new access().ExecuteDataTable("select top 8 * from merchandise where id <> " + id + " and tj = 1 and ifsj = 1 order by px desc"))
                    {
                        this.DataList1.DataSource = dt;
                        this.DataList1.DataBind();
                    }
                }
            }
        }
        public void fy()
        {
            int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
            int x = 5;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "&id=" + id;
            string sqlw = " and mid = " + id + " ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from pingjia where id <> 0 ",
					sqlw,
					" order by id desc"
				});
            }
            else
            {
                string zid_sql_one = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from pingjia where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string zid_sqltwo = "select top 1 id from pingjia where id in (" + zid_sql_one + ") order by id";
                string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from pingjia where id <(",
					zid,
					") ",
					sqlw,
					" order by id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater2.DataSource = dt;
                this.Repeater2.DataBind();
            }
        }
        public string qd(object v)
        {
            string fig = "";
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from yk_one where mid = " + v + " order by px"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (fig == "")
                    {
                        this.ys = string.Concat(r["id"]);
                        object obj = fig;
                        fig = string.Concat(new object[]
						{
							obj,
							"<a href='javascript:;' class='a' value='",
							r["id"],
							"'>",
							r["name"],
							"</a>"
						});
                    }
                    else
                    {
                        object obj = fig;
                        fig = string.Concat(new object[]
						{
							obj,
							"<a href='javascript:;' value='",
							r["id"],
							"'>",
							r["name"],
							"</a>"
						});
                    }
                }
            }
            return fig;
        }
        protected void ljgm_bt_Click(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["username"] == null)
            {
                base.Response.Redirect("/user/login.aspx?url=" + base.Request.RawUrl);
            }
            else
            {
                string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                string id = base.Request.QueryString["id"];
                string ys = base.Request.Form["ys"];
                string cc = base.Request.Form["cc"];
                string shu = base.Request.Form["sum"];
                string iftj = get.m_str(id, "iftj");
                int tj_xg = get.tj_xg();
                int dd = 0;
                string ddstr = new SqlHelper().ExecuteScalar(string.Concat(new string[]
				{
					"select sum([sum]) from shoporderlist where mid = ",
					id,
					" and orderid in (select id from shoporder where username = '",
					username,
					"')"
				}));
                if (!string.IsNullOrEmpty(ddstr))
                {
                    dd = System.Convert.ToInt32(ddstr);
                }
                int wuc = 0;
                string wucstr = new SqlHelper().ExecuteScalar(string.Concat(new string[]
				{
					"select sum([shu]) from cart where mid = ",
					id,
					" and username = '",
					username,
					"'"
				}));
                if (!string.IsNullOrEmpty(wucstr))
                {
                    wuc = System.Convert.ToInt32(wucstr);
                }
                dd += wuc;
                ys = "43";
                cc = "43";
                if (ys == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请选择商品的颜色！');location.href='" + base.Request.RawUrl + "';", true);
                }
                else
                {
                    if (cc == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请选择商品的尺寸！');location.href='" + base.Request.RawUrl + "';", true);
                    }
                    else
                    {
                        if (iftj == "1" && System.Convert.ToInt32(shu) + dd > tj_xg)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), string.Concat(new object[]
							{
								"alert('特价产品只能购买",
								tj_xg,
								"件！');location.href='",
								base.Request.RawUrl,
								"';"
							}), true);
                        }
                        else
                        {
                            SqlParameter[] op = new SqlParameter[]
							{
								new SqlParameter("@username", ""),
								new SqlParameter("@mid", id),
								new SqlParameter("@ys", ys),
								new SqlParameter("@cc", cc),
								new SqlParameter("@shu", shu),
								new SqlParameter("@times", System.DateTime.Now.ToShortDateString())
							};
                            new SqlHelper().ExecuteNonQuery("insert into cart (username,mid,ys,cc,shu,times) values (@username,@mid,@ys,@cc,@shu,@times)", op);
                            string newid = new SqlHelper().ExecuteScalar("select top 1 id from cart order by id desc");
                            base.Response.Redirect("/cart/order.aspx?cart_id=" + newid);
                        }
                    }
                }
            }
        }
        protected void jrgwc_bt_Click(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["username"] == null)
            {
                base.Response.Redirect("/user/login.aspx?url=" + base.Request.RawUrl);
            }
            else
            {
                string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                string id = base.Request.QueryString["id"];
                string ys = base.Request.Form["ys"];
                string cc = base.Request.Form["cc"];
                string shu = base.Request.Form["sum"];
                string iftj = get.m_str(id, "iftj");
                int tj_xg = get.tj_xg();
                int dd = 0;
                string ddstr = new SqlHelper().ExecuteScalar(string.Concat(new string[]
				{
					"select sum([sum]) from shoporderlist where mid = ",
					id,
					" and orderid in (select id from shoporder where username = '",
					username,
					"')"
				}));
                if (!string.IsNullOrEmpty(ddstr))
                {
                    dd = System.Convert.ToInt32(ddstr);
                }
                int wuc = 0;
                string wucstr = new SqlHelper().ExecuteScalar(string.Concat(new string[]
				{
					"select sum([shu]) from cart where mid = ",
					id,
					" and username = '",
					username,
					"'"
				}));
                if (!string.IsNullOrEmpty(wucstr))
                {
                    wuc = System.Convert.ToInt32(wucstr);
                }
                dd += wuc;
                ys = "43";
                cc = "43";
                if (ys == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请选择商品的颜色！');location.href='" + base.Request.RawUrl + "';", true);
                }
                else
                {
                    if (cc == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请选择商品的尺寸！');location.href='" + base.Request.RawUrl + "';", true);
                    }
                    else
                    {
                        if (iftj == "1" && System.Convert.ToInt32(shu) + dd > tj_xg)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), string.Concat(new object[]
							{
								"alert('特价产品只能购买",
								tj_xg,
								"件！');location.href='",
								base.Request.RawUrl,
								"';"
							}), true);
                        }
                        else
                        {
                            string cid = new SqlHelper().ExecuteScalar(string.Concat(new string[]
							{
								"select id from cart where username='",
								username,
								"' and mid = ",
								id,
								" and ys=",
								ys,
								" and cc=",
								cc
							}));
                            if (cid == "")
                            {
                                SqlParameter[] op = new SqlParameter[]
								{
									new SqlParameter("@username", username),
									new SqlParameter("@mid", id),
									new SqlParameter("@ys", ys),
									new SqlParameter("@cc", cc),
									new SqlParameter("@shu", shu),
									new SqlParameter("@times", System.DateTime.Now.ToShortDateString())
								};
                                new SqlHelper().ExecuteNonQuery("insert into cart (username,mid,ys,cc,shu,times) values (@username,@mid,@ys,@cc,@shu,@times)", op);
                            }
                            else
                            {
                                new SqlHelper().ExecuteNonQuery("update cart set shu = shu +" + shu + " where id = " + cid);
                            }
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "if(confirm('添加成功，是否前往购物车？')){location.href='/cart';}else{location.href='" + base.Request.RawUrl + "';}", true);
                        }
                    }
                }
            }
        }
    }
}