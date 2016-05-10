using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class jb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from jb where id = 1 "))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.s1.Text = r["s1"].ToString();
                        this.s2.Text = r["s2"].ToString();
                        this.s3.Text = r["s3"].ToString();
                        this.s4.Text = r["s4"].ToString();
                        this.s5.Text = r["s5"].ToString();
                        this.s6.Text = r["s6"].ToString();
                        this.s1_zhe.Text = r["s1_zhe"].ToString();
                        this.s2_zhe.Text = r["s2_zhe"].ToString();
                        this.s3_zhe.Text = r["s3_zhe"].ToString();
                        this.s4_zhe.Text = r["s4_zhe"].ToString();
                        this.s5_zhe.Text = r["s5_zhe"].ToString();
                        this.s6_zhe.Text = r["s6_zhe"].ToString();
                    }
                }
            }
        }
        protected void tj_xg_Click(object sender, System.EventArgs e)
        {
            string s = this.s1.Text;
            string s2 = this.s2.Text;
            string s3 = this.s3.Text;
            string s4 = this.s4.Text;
            string s5 = this.s5.Text;
            string s6 = this.s6.Text;
            string s1_zhe = this.s1_zhe.Text;
            string s2_zhe = this.s2_zhe.Text;
            string s3_zhe = this.s3_zhe.Text;
            string s4_zhe = this.s4_zhe.Text;
            string s5_zhe = this.s5_zhe.Text;
            string s6_zhe = this.s6_zhe.Text;
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@s1", s),
				new SqlParameter("@s2", s2),
				new SqlParameter("@s3", s3),
				new SqlParameter("@s4", s4),
				new SqlParameter("@s5", s5),
				new SqlParameter("@s6", s6),
				new SqlParameter("@s1_zhe", s1_zhe),
				new SqlParameter("@s2_zhe", s2_zhe),
				new SqlParameter("@s3_zhe", s3_zhe),
				new SqlParameter("@s4_zhe", s4_zhe),
				new SqlParameter("@s5_zhe", s5_zhe),
				new SqlParameter("@s6_zhe", s6_zhe)
			};
            string sql = "update jb set s1=@s1,s2=@s2,s3=@s3,s4=@s4,s5=@s5,s6=@s6,s1_zhe=@s1_zhe,s2_zhe=@s2_zhe,s3_zhe=@s3_zhe,s4_zhe=@s4_zhe,s5_zhe=@s5_zhe,s6_zhe=@s6_zhe where id = 1";
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功');location.href='" + base.Request.RawUrl + "'</script>");
                base.Response.End();
            }
        }
    }
}