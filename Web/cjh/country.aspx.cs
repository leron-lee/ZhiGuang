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
    public partial class country : System.Web.UI.Page
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

                string sql = "select * from s_sheng";
                if (Request.QueryString["sheng"] != null)
                {
                    int a = Convert.ToInt32(Request.QueryString["sheng"]);
                    sql = "select * from s_shi where shengID=" + a;
                    Repeater1.Visible = false;
                   
                }

                if (Request.QueryString["shi"] != null)
                {
                   int a = Convert.ToInt32(Request.QueryString["shi"]);
                    sql = "select * from s_xian where shiID=" + a;
                }

                using (DataTable dt = new access().ExecuteDataTable(sql))
                {
                    if (Request.QueryString["sheng"] != null)
                    {
                        Repeater2.DataSource = dt;
                        Repeater2.DataBind();
                    }
                    else if (Request.QueryString["shi"] != null)
                    {
                        Repeater3.DataSource = dt;
                        Repeater3.DataBind();
                    }
                    else
                    {

                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }


            }
        }
    }
}