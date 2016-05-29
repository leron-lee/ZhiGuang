using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.fx
{
    public partial class ShopFX : System.Web.UI.Page
    {
        public string fystr;
        public string ditk = "dis";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["username"] != null)
                {
                    this.fy();
                }
                else
                {
                    base.Response.Redirect("/user/login.aspx");
                }
            }
        }
        public void fy()
        {
            string UserName = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            int x = 100;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "";
            string sqlw = " ";
            if (base.Request.QueryString["search"] != null)
            {
                string search_tx = base.Request.QueryString["search"];
                url = url + "&search=" + base.Server.UrlEncode(search_tx);
                sqlw = sqlw + " and name like '%" + search_tx + "%' ";
            }
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
                {
                    "select top ",
                    x,
                    " * from FxShopInfo where  id <> 0 ",
                    sqlw,
                    " order by ",
                    "id desc"
                });
            }
            else
            {
                string sqlabc = string.Concat(new object[]
                {
                    "select top ",
                    (p - 1) * x,
                    " id from FxShopInfo where id <> 0 ",
                    sqlw,
                    " order by ",
                    "id desc"
                });
                string sqlid = "0";
                using (DataTable dt = new access().ExecuteDataTable(sqlabc))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        sqlid = sqlid + "," + r["id"];
                    }
                }
                sqlstring = string.Concat(new object[]
                {
                    "select top ",
                    x,
                    " * from FxShopInfo where id <> 0 and id not in (",
                    sqlid,
                    ") ",
                    sqlw,
                    " order by ",
                    "id desc"
                });
            }
            using (DataTable dt = new access().ExecuteDataTable(sqlstring))
            {
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "FxShopInfo where id <> 0 " + sqlw, url, p, "pagex", "id", 2);
        }
        public string iffx(object s1)
        {
            string fig = "";
            if (base.Request.QueryString["px"] == s1.ToString())
            {
                fig = "a";
            }
            else
            {
                if (base.Request.QueryString["px"] == null)
                {
                    if (s1.ToString() == "1")
                    {
                        fig = "a";
                    }
                }
            }
            return fig;
        }
        public string ata(object v)
        {
            string fig = "";
            if (base.Request.QueryString["px"] != null)
            {
                int px = System.Convert.ToInt32(base.Request.QueryString["px"]);
                if (v.ToString() == "1")
                {
                    if (px == 1)
                    {
                        fig = "2";
                    }
                    else
                    {
                        fig = "1";
                    }
                }
                else
                {
                    if (v.ToString() == "3")
                    {
                        if (px == 3)
                        {
                            fig = "4";
                        }
                        else
                        {
                            fig = "3";
                        }
                    }
                    else
                    {
                        if (v.ToString() == "5")
                        {
                            if (px == 5)
                            {
                                fig = "6";
                            }
                            else
                            {
                                fig = "5";
                            }
                        }
                    }
                }
            }
            else
            {
                if (v.ToString() == "1")
                {
                    fig = "2";
                }
                else
                {
                    fig = v.ToString();
                }
            }
            return fig;
        }
        public string url(object v1, object v2)
        {
            string fig = "?";
            int i = 0;
            string s = v1.ToString();
            string s2 = v2.ToString();
            foreach (string nm in base.Request.QueryString)
            {
                if (nm == s)
                {
                    string text = fig;
                    fig = string.Concat(new string[]
                    {
                        text,
                        "&",
                        nm,
                        "=",
                        base.Server.UrlEncode(s2)
                    });
                    i = 1;
                }
                else
                {
                    if (!string.IsNullOrEmpty(nm))
                    {
                        string text = fig;
                        fig = string.Concat(new string[]
                        {
                            text,
                            "&",
                            nm,
                            "=",
                            base.Server.UrlEncode(base.Request.QueryString[nm])
                        });
                    }
                }
            }
            if (i == 0)
            {
                string text = fig;
                fig = string.Concat(new string[]
                {
                    text,
                    "&",
                    s,
                    "=",
                    base.Server.UrlEncode(s2)
                });
            }
            return fig;
        }
    }
}