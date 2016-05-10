using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class wyzdl : System.Web.UI.Page
    {
        public string username;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                string sidt = new SqlHelper().ExecuteScalar("select id from wyzdl where username = '" + this.username + "'");
                if (sidt != "")
                {
                    base.Response.Write("<script>alert('您的已经提交了申请，请耐心等待审核');location.href='wdcc.aspx';</script>");
                    base.Response.End();
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.name.Text = r["name"].ToString();
                        this.phone.Text = r["phone"].ToString();
                    }
                }
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            this.username = this.username;
            string name = this.name.Text;
            string phone = this.phone.Text;
            string dl_sheng = base.Request.Form["s_sheng"];
            string dl_shi = base.Request.Form["s_shi"];
            string dl_xian = base.Request.Form["s_xian"];
            string jianjian = this.jianjian.Text;
            string times = System.DateTime.Now.ToString();
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@username", this.username),
				new SqlParameter("@name", name),
				new SqlParameter("@phone", phone),
				new SqlParameter("@dl_sheng", dl_sheng),
				new SqlParameter("@dl_shi", dl_shi),
				new SqlParameter("@dl_xian", dl_xian),
				new SqlParameter("@jianjian", jianjian),
				new SqlParameter("@times", times)
			};
            string sql = "insert into wyzdl (username,name,phone,dl_sheng,dl_shi,dl_xian,jianjian,times) values(@username,@name,@phone,@dl_sheng,@dl_shi,@dl_xian,@jianjian,@times)";
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('提交申请成功');location.href='wdcc.aspx';</script>");
                base.Response.End();
            }
        }
    }
}