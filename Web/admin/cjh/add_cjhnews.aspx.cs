using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CT.WebUtility;
namespace Web.admin.cjh
{
    public partial class add_cjhnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cjh"))
                {
                    foreach (DataRow r in dt.Rows)
                    {

                        DropDownList2.Items.Add(new ListItem(GG(r["sheng"],r["shi"],r["xian"]),r["id"].ToString()));
                    
                    }
                }


                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cjh_news where id=" + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {


                            this.TextBox1.Text = r["title"].ToString();
                            this.TextBox2.Text = r["jianjie"].ToString();
                            this.TextBox3.Text = r["main"].ToString();
                            img.Text = r["imgc"].ToString();
                            DropDownList1.Items.FindByValue(r["type"].ToString()).Selected = true;
                            DropDownList2.Items.FindByValue(r["typeb"].ToString()).Selected = true;
                        }
                    }
                }
            }
        }

        public string GG(object a, object b, object c)
        {
            string str = "";

            object a1 = Sql.GetSingle("select name from s_sheng where id=" + a);

            if (a1 != null)
            {
                str += a1;
            }
            object a2 = Sql.GetSingle("select name from s_shi where id=" + b);
            if (a2 != null)
            {
                str += a2;
            }
            object a3 = Sql.GetSingle("select name from s_xian where id=" + c);
            if (a3 != null)
            {
                str += a3;
            }
            return str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = TextBox1.Text;
            string imgc = img.Text;
            string type = DropDownList1.SelectedValue;
            string typeb = DropDownList2.SelectedValue;
            string jianjie = TextBox2.Text;
            string main = TextBox3.Text;
            string times = DateTime.Now.ToString();


            SqlParameter[] sp = new SqlParameter[] { 
                new SqlParameter("@title",title),
                new SqlParameter("@imgc",imgc),
                new SqlParameter("@type",type),
                new SqlParameter("@typeb",typeb),
                new SqlParameter("@jianjie",jianjie),
                new SqlParameter("@main",main),
                new SqlParameter("@times",times),
            };

            string sql = "insert into cjh_news (title, imgc, type,typeb, jianjie, main, times) values (@title, @imgc, @type,@typeb, @jianjie, @main, @times)";

            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                sql = "update cjh_news set title=@title, imgc=@imgc, type=@type,typeb=@typeb, jianjie=@jianjie, main=@main, times=@times where id=" + id;
            }

            if (Sql.command(sql, sp) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('信息保持成功！');self.location.href='" + Request.RawUrl + "'</script>");
            }
        }
    }
}