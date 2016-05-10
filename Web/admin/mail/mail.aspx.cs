using System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.mail
{
    public partial class mail : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from mail where id=1"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.TextBox1.Text = r["f_username"].ToString();
                        this.TextBox2.Text = r["f_password"].ToString();
                        this.TextBox3.Text = r["f_smtp"].ToString();
                        this.TextBox4.Text = r["j_username"].ToString();
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
            string sqlstring = "update [mail] set f_username=@f_username,f_password=@f_password,f_smtp=@f_smtp,j_username=@j_username where id = 1";
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@f_username", t),
				new SqlParameter("@f_password", t2),
				new SqlParameter("@f_smtp", t3),
				new SqlParameter("@j_username", t4)
			};
            int a = new SqlHelper().ExecuteNonQuery(sqlstring, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功！');location.href='" + base.Request.RawUrl + "';</script>");
            }
        }
    }
}