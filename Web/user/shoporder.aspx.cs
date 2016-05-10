using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class shoporder : System.Web.UI.Page
    {
        public string stv;
        public string username;
        public int z1 = 0;
        public int z2 = 0;
        public int z3 = 0;
        public int z4 = 0;
        public string z1dis = "dis";
        public string z2dis = "dis";
        public string z3dis = "dis";
        public string z4dis = "dis";
        public string fystr;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["del"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    string url = base.Request.QueryString["url"];
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"delete from shoporder where zt = 1 and username = '",
						this.username,
						"' and id = ",
						id
					}));
                    new SqlHelper().ExecuteNonQuery("delete from shoporderlist where orderid = " + id);
                    base.Response.Redirect(url);
                }
                else
                {
                    if (base.Request.QueryString["id"] != null && base.Request.QueryString["zt"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        int zt = System.Convert.ToInt32(base.Request.QueryString["zt"]);
                        string url = base.Request.QueryString["url"];
                        new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
						{
							"update shoporder set zt = ",
							zt,
							" where id = ",
							id
						}));
                        base.Response.Redirect(url);
                    }
                    else
                    {
                        this.fy();
                    }
                }
                this.z1 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 1 and username = '" + this.username + "'"));
                this.z2 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 2 and username = '" + this.username + "'"));
                this.z3 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 3 and username = '" + this.username + "'"));
                this.z4 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 4 and pj = 0 and username = '" + this.username + "'"));
                if (this.z1 > 0)
                {
                    this.z1dis = "";
                }
                if (this.z2 > 0)
                {
                    this.z2dis = "";
                }
                if (this.z3 > 0)
                {
                    this.z3dis = "";
                }
                if (this.z4 > 0)
                {
                    this.z4dis = "";
                }
            }
        }
        public string delztdis()
        {
            string fig = "dis";
            if (base.Eval("zt").ToString() == "1")
            {
                fig = "";
            }
            return fig;
        }
        public void fy()
        {
            string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            int x = 4;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string uka = "";
            string sqlw = " and username = '" + username + "' ";
            if (base.Request.QueryString["zt"] != null)
            {
                int zt = System.Convert.ToInt32(base.Request.QueryString["zt"]);
                object obj = sqlw;
                sqlw = string.Concat(new object[]
				{
					obj,
					" and zt = ",
					zt,
					" "
				});
                uka = uka + "&zt=" + zt;
            }
            if (base.Request.QueryString["pj"] != null)
            {
                int pj = System.Convert.ToInt32(base.Request.QueryString["pj"]);
                if (pj == 1)
                {
                    sqlw += " and pj = 1 ";
                }
                else
                {
                    sqlw += " and pj <> 1 ";
                }
                uka = uka + "&pj=" + pj;
            }
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from shoporder where id <> 0 ",
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
					" id from shoporder where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string zid_sqltwo = "select top 1 id from shoporder where id in (" + zid_sql_one + ") order by id";
                string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from shoporder where id <(",
					zid,
					") ",
					sqlw,
					" order by id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            if (this.Repeater1.Items.Count == 0)
            {
                this.stv = "<div class='b_l_w' style='margin-top:20px;text-align:center;'>没有找到相关信息！</center>";
            }
            this.fystr = en_page.fystr_one(x, "shoporder where id <> 0 " + sqlw, uka, p, "pagex", "id", 2);
        }
        public string pjdis()
        {
            string fig = "dis";
            if (System.Convert.ToInt32(base.Eval("zt")) > 3)
            {
                string pjid = new SqlHelper().ExecuteScalar("select id from pingjia where orderid = " + base.Eval("id"));
                if (pjid == "")
                {
                    fig = "";
                }
            }
            return fig;
        }
        public string str(object id, object s)
        {
            return new access().ExecuteScalar(string.Concat(new object[]
			{
				"select top 1 ",
				s,
				" from shoporderlist where orderid = ",
				id
			}));
        }
        public string ztimg(object zt, object ordernumber, object id)
        {
            string fig = "";
            if (zt.ToString() == "1")
            {
                fig = "<a href='/cart/zhifu.aspx?ordernumber=" + ordernumber + "' class='a_hon'>立即付款</a>";
            }
            else
            {
                if (zt.ToString() == "2")
                {
                    fig = "<a href='javascript:;' class='a_fen'>等待发货</a>";
                }
                else
                {
                    if (zt.ToString() == "3")
                    {
                        fig = string.Concat(new object[]
						{
							"<a href='javascript:;' class='a_lv' onclick=\"if(confirm('确定收货？')){location.href='?zt=4&id=",
							id,
							"&url=",
							base.Server.UrlEncode(base.Request.RawUrl),
							"';}\">确认收货</a>"
						});
                    }
                    else
                    {
                        if (zt.ToString() == "4")
                        {
                        }
                    }
                }
            }
            return fig;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "ID");
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
    }
}