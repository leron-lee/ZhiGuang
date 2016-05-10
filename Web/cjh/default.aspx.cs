using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CT.WebUtility;
namespace Web.cjh
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string l1 = "";
                string l2 = "";
                int i = 0;
                using (DataTable dt = new access().ExecuteDataTable("select * from cjh_flash"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        i++;
                        l1 += "<div class='dimg'><img src='" + r["img"] + "' onclick=\"location.href='" + r["url"] + "';\" /></div>";
                        string str = "";

                        if (i == 1)
                        {
                            str = "class='on'";
                        }
                        else
                        {
                            str = "";
                        }
                        l2 += "<li " + str + ">●</li>";
                    }
                }
                Literal1.Text = l1;
                Literal2.Text = l2;


                string sql = "select * from cjh_news order by id desc";

                

                if(Request.QueryString["address"]!=null)
                {
                    int xian = 0;
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + username + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            xian = Convert.ToInt32(r["s_xian"]);
                        }
                        if (dt.Rows.Count == 0)
                        {
                            base.Response.Redirect("logout.aspx");
                        }
                    }

                

                    sql = "select id from cjh where xian=" + xian;

                    object ob = Sql.GetSingle(sql);

                    if (ob == null)
                    {
                        Literal3.Text = "<div style='line-height:38px;width:100%;float:left;'><span style='font-size:26px;'>该地区尚未成立！<br/>赶快加入吧！<br/>联系电话：4001691633</span></div>";
                    }
                    else
                    {
                        sql = "select * from cjh_news where typeb=" + ob;

                    }
                }
                if (Request.QueryString["xian"] != null)
                {
                    int xian = Convert.ToInt32(Request.QueryString["xian"]);

                    sql = "select id from cjh where xian=" + xian;

                    object ob = Sql.GetSingle(sql);

                    if (ob == null)
                    {
                        Literal3.Text = "<center><span style='font-size:26px;'>该地区尚未成立！</span></center>";
                    }
                    else
                    {
                        sql = "select * from cjh_news where typeb=" + ob;

                    }
                }

                using (DataTable dt = new access().ExecuteDataTable(sql))
                {
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }


            }
        }
    }
}