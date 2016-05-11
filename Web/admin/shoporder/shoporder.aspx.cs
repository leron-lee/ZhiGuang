using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.shoporder
{
    public partial class shoporder : System.Web.UI.Page
    {
        private string fystr;
        /*标志登录账户是否为管理员*/
        bool IsAdmin = true;
        string um = "";
        public string Fystr
        {
            get
            {
                return this.fystr;
            }
            set
            {
                this.fystr = value;
            }
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["adminusername"] != null)
            {
                um = base.Server.UrlDecode(base.Request.Cookies["adminusername"].Value);
                IsAdmin = true;
            }
            else if (base.Request.Cookies["fx"] != null)
            {
                um = base.Server.UrlDecode(base.Request.Cookies["fx"].Value);
                IsAdmin = false;
            }
            if (!base.IsPostBack)
            {
                this.Page.Title = "我的订单 - " + get.gsstr();
                if (base.Request.QueryString["price"] != null)
                {
                    string price = base.Request.QueryString["price"];
                    string url = base.Request.QueryString["url"];
                    string id = base.Request.QueryString["id"];
                    new SqlHelper().ExecuteNonQuery("update shoporder set price = " + price + " where id = " + id);
                    base.Response.Write("<script>alert('修改成功！');location.href='" + url + "';</script>");
                    base.Response.End();
                }
                if (base.Request.QueryString["del"] != null)
                {
                    int del = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    string url = base.Request.QueryString["url"];
                    new SqlHelper().ExecuteNonQuery("delete from shoporder where id = " + del);
                    new SqlHelper().ExecuteNonQuery("delete from shoporderlist where orderid=" + del);
                    base.Response.Redirect(url);
                }
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                if (base.Request.QueryString["ordernumber"] != null)
                {
                    string ordernumber = base.Request.QueryString["ordernumber"];
                    if (ordernumber != "")
                    {
                        username = username + "&ordernumber=" + base.Server.UrlEncode(ordernumber);
                        sqlw = sqlw + " and ordernumber like '%" + ordernumber + "%' ";
                        this.ordernumber.Text = ordernumber;
                    }
                }
                if (base.Request.QueryString["zt"] != null)
                {
                    string zt = base.Request.QueryString["zt"];
                    if (zt != "")
                    {
                        username = username + "&zt=" + base.Server.UrlEncode(zt);
                        sqlw = sqlw + " and zt = " + zt + " ";
                        this.zt.SelectedValue = zt;
                    }
                }
                if (base.Request.QueryString["_username"] != null)
                {
                    string _username = base.Request.QueryString["_username"];
                    if (_username != "")
                    {
                        username = username + "&_username=" + base.Server.UrlEncode(_username);
                        sqlw = sqlw + " and username like '%" + _username + "%' ";
                        this._username.Text = _username;
                    }
                }
                if (base.Request.QueryString["name"] != null)
                {
                    string name = base.Request.QueryString["name"];
                    if (name != "")
                    {
                        username = username + "&name=" + base.Server.UrlEncode(name);
                        sqlw = sqlw + " and name like '%" + name + "%' ";
                        this.name.Text = name;
                    }
                }
                if (base.Request.QueryString["fdan"] != null)
                {
                    string fdan = base.Request.QueryString["fdan"];
                    if (fdan != "")
                    {
                        username = username + "&fdan=" + base.Server.UrlEncode(fdan);
                        sqlw = sqlw + " and fdan like '%" + fdan + "%' ";
                        this.fdan.Text = fdan;
                    }
                }
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    if (!IsAdmin)
                    {
                        sqlstring = string.Concat(new object[]
                        {
                            "select top ",
                            x,
                            " a.ordernumber, a.times,a.username,a.price,a.id,a.zt from shoporder a  inner join shoporderlist b  on a.id=b.OrderId  inner join Merchandise c  on b.mname=c.name where c.belong ='" + um + "' and a.id <>0 ",
                            sqlw,
                            " order by a.id desc"
                        });
                    }
                    else
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
                    if (!IsAdmin)
                    {
                        sqlstring = string.Concat(new object[]
                        {
                            "select top ",
                            x,
                            " a.ordernumber, a.times,a.username,a.price,a.id,a.zt from shoporder a  inner join shoporderlist b  on a.id=b.OrderId  inner join Merchandise c  on b.mname=c.name where c.belong ='" + um + "' and a.id <(",
                            zid,
                            ") ",
                            sqlw,
                            " order by a.id desc"
                        });
                    }
                    else
                    {
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
                using (DataTable d = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = d;
                    this.Repeater1.DataBind();
                }
                if (!IsAdmin)
                {
                    this.fystr = en_page.fystr_one(x, "shoporder a  inner join shoporderlist b  on a.id=b.OrderId  inner join Merchandise c  on b.mname=c.name where c.belong ='" + um + "' and a.id <> 0 " + sqlw, username, p, "pagex", "a.id", 1);
                }
                else
                {
                    this.fystr = en_page.fystr_one(x, "shoporder where id <> 0 " + sqlw, username, p, "pagex", "id", 1);
                }
            }
        }
        public string ckwl()
        {
            string fig = "";
            int zt = System.Convert.ToInt32(base.Eval("zt"));
            if (zt > 2)
            {
                fig = string.Concat(new object[]
                {
                    "<a href=\"http://www.kuaidi100.com/chaxun?com=",
                    base.Eval("fname_id"),
                    "&nu=",
                    base.Eval("fdan"),
                    "\" target=_blank' style='color:blue;'>查看物流</a>"
                });
            }
            return fig;
        }
        public void del()
        {
            if (base.Request.QueryString["del"] != null && base.Request.QueryString["url"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["del"]);
                string url = base.Request.QueryString["url"];
                new SqlHelper().ExecuteNonQuery("delete from shoporder where id = " + id);
                new SqlHelper().ExecuteNonQuery("delete from shoporderlist where orderid = " + id);
                base.Response.Write("<script>alert('删除成功！');location.href='" + url + "';</script>");
                base.Response.End();
            }
        }
        public string ljzf(object zt)
        {
            string fig = "";
            if (zt.ToString() == "1")
            {
                fig = "立即支付";
            }
            return fig;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "id");
                string SqlList = "";
                if (!IsAdmin)
                {
                    SqlList = "select s.id,s.OrderId,s.mid,s.sum,s.price,s.mname,s.mx_img,s.ys,s.cc from  shoporderlist  s inner join Merchandise m on s.mname=m.name where m.belong ='" + um + "' and s.orderid = " + id + " order by s.id";
                }
                else
                {
                    SqlList = "select * from shoporderlist where orderid = " + id + " order by id";
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable(SqlList))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string ordernumber = this.ordernumber.Text;
            string zt = this.zt.SelectedValue;
            string _username = this._username.Text;
            string name = this.name.Text;
            string fdan = this.fdan.Text;
            base.Response.Redirect(string.Concat(new string[]
            {
                "shoporder.aspx?ordernumber=",
                ordernumber,
                "&zt=",
                zt,
                "&_username=",
                _username,
                "&name=",
                name,
                "&fdan=",
                fdan
            }));
        }
    }
}