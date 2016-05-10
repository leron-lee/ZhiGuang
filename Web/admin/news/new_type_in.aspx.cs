using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.news
{
    public partial class new_type_in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from news_type where id=" + uid.ToString()))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox1.Text = r["name"].ToString();
                            this.TextBox2.Text = r["title"].ToString();
                            this.TextBox3.Text = r["keyname"].ToString();
                            this.TextBox4.Text = r["counts"].ToString();
                        }
                    }
                    this.Button1.Text = " 修改 ";
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string t = this.TextBox1.Text;
            string t2 = this.TextBox2.Text;
            string t3 = this.TextBox3.Text;
            string t4 = this.TextBox4.Text;
            if (t == "")
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('名称不能为空');</script>");
            }
            else
            {
                string sqlstring = "select MAX(px) FROM news_type";
                int i = 1;
                string ob = new SqlHelper().ExecuteScalar(sqlstring);
                if (ob != "")
                {
                    i = System.Convert.ToInt32(ob) + 1;
                }
                SqlParameter[] sp = new SqlParameter[]
				{
					new SqlParameter("@name", t),
					new SqlParameter("@title", t2),
					new SqlParameter("@keyname", t3),
					new SqlParameter("@counts", t4),
					new SqlParameter("@px", i)
				};
                string inset;
                if (base.Request.QueryString["id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string wherepx = "";
                    inset = "update news_type set name=@name,title=@title,keyname=@keyname,counts=@counts" + wherepx + " where id=" + uid.ToString();
                }
                else
                {
                    inset = "insert into news_type (name,title,keyname,counts,px) values (@name,@title,@keyname,@counts,@px)";
                }
                int a = new SqlHelper().ExecuteNonQuery(inset, sp);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('操作成功');location.href='" + base.Request.RawUrl + "';</script>");
                }
            }
        }
    }
}