using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.news
{
    public partial class news_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["typeid"] != null)
                {
                    this.Label1.Text = news.typeid(base.Request.QueryString["typeid"]);
                }
                if (base.Request.QueryString["id"] == null)
                {
                    this.Button1.Text = " 添加 ";
                }
                else
                {
                    string sqlstring = "select * from news where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox1.Text = r["btname"].ToString();
                            this.Label1.Text = news.typeid(r["type"]);
                            this.TextBox2.Text = r["title"].ToString();
                            this.TextBox3.Text = r["keyname"].ToString();
                            this.TextBox4.Text = r["counts"].ToString();
                            this.TextBox5.Text = r["nrtext"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["typeid"] != null)
            {
                int uid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                string t = this.TextBox1.Text;
                string t2 = this.TextBox2.Text;
                string t3 = this.TextBox3.Text;
                string t4 = this.TextBox4.Text;
                string t5 = this.TextBox5.Text;
                string sqlstg = "select MAX(px) FROM news where type=" + uid.ToString();
                int px = 1;
                string ob = new SqlHelper().ExecuteScalar(sqlstg);
                if (ob != "")
                {
                    px = System.Convert.ToInt32(ob) + 1;
                }
                SqlParameter[] op = new SqlParameter[]
				{
					new SqlParameter("@btname", t),
					new SqlParameter("@type", uid.ToString()),
					new SqlParameter("@title", t2),
					new SqlParameter("@keyname", t3),
					new SqlParameter("@counts", t4),
					new SqlParameter("@nrtext", t5),
					new SqlParameter("@times", System.DateTime.Now.ToString()),
					new SqlParameter("@px", px.ToString())
				};
                string sqlstring;
                if (base.Request.QueryString["id"] != null)
                {
                    sqlstring = "update news set btname=@btname,type=@type,title=@title,keyname=@keyname,counts=@counts,nrtext=@nrtext where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                }
                else
                {
                    sqlstring = "insert into news (btname,type,title,keyname,counts,nrtext,times,px) values(@btname,@type,@title,@keyname,@counts,@nrtext,@times,@px)";
                }
                int a = new SqlHelper().ExecuteNonQuery(sqlstring, op);
                if (a > 0)
                {
                    base.Response.Write(string.Concat(new string[]
					{
						"<script>alert('",
						this.Button1.Text.Trim(),
						"成功');location.href='",
						base.Request.RawUrl,
						"';</script>"
					}));
                    base.Response.End();
                }
            }
        }
    }
}