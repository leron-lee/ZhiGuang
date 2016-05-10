using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.html
{
    public partial class html : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from html where id=" + uid.ToString()))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.Literal1.Text = "编辑管理 " + r["name"].ToString() + " 栏目";
                            this.TextBox1.Text = r["name"].ToString();
                            this.TextBox2.Text = r["title"].ToString();
                            this.TextBox3.Text = r["key_name"].ToString();
                            this.TextBox4.Text = r["contus"].ToString();
                            this.TextBox5.Text = r["nrtext"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string t = this.TextBox1.Text;
            string t2 = this.TextBox2.Text;
            string t3 = this.TextBox3.Text;
            string t4 = this.TextBox4.Text;
            string t5 = this.TextBox5.Text;
            int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", t),
				new SqlParameter("@title", t2),
				new SqlParameter("@key_name", t3),
				new SqlParameter("@contus", t4),
				new SqlParameter("@nrtext", t5)
			};
            string sql = "select MAX(px) FROM html";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sql);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            string sqlstring;
            if (base.Request.QueryString["id"] != null)
            {
                sqlstring = "update html set name=@name,title=@title,key_name=@key_name,contus=@contus,nrtext=@nrtext where id=" + uid.ToString();
            }
            else
            {
                sqlstring = string.Concat(new object[]
				{
					"insert into html (name,title,key_name,contus,nrtext,px,times) values(@name,@title,@key_name,@contus,@nrtext,",
					px,
					",'",
					System.DateTime.Now,
					"')"
				});
            }
            int a = new SqlHelper().ExecuteNonQuery(sqlstring, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('操作成功');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
    }
}