using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class wysdv : System.Web.UI.Page
    {
        public string username;
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                string sidt = new SqlHelper().ExecuteScalar("select id from wysdv where username = '" + this.username + "'");
                if (sidt != "")
                {
                    base.Response.Write("<script>alert('您的已经提交了申请，请耐心等待审核');location.href='wdcc.aspx';</script>");
                    base.Response.End();
                }
                string iftj = "0";
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.name.Text = r["name"].ToString();
                        this.phone.Text = r["phone"].ToString();
                        string s_xian = r["s_xian"].ToString();
                        if (r["ifdv"].ToString() == "1")
                        {
                            base.Response.Write("<script>alert('您已经是合伙人了');location.href='wdcc.aspx';</script>");
                            base.Response.End();
                        }
                        if (r["tj_username"].ToString() != "")
                        {
                            string sid = new SqlHelper().ExecuteScalar(string.Concat(new object[]
							{
								"select id from username where id = ",
								r["tj_username"],
								" and dl_xian = ",
								s_xian,
								" and jb = 3"
							}));
                            if (sid != "")
                            {
                                iftj = "1";
                            }
                        }
                    }
                }
               
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            this.username = this.username;
            string name = this.name.Text;
            string fen = get.ren(this.username);
            string phone = this.phone.Text;
            string s_sheng = new SqlHelper().ExecuteScalar("select s_sheng from username where username = '" + this.username + "'");
            string s_shi = new SqlHelper().ExecuteScalar("select s_shi from username where username = '" + this.username + "'");
            string s_xian = new SqlHelper().ExecuteScalar("select s_xian from username where username = '" + this.username + "'");
            string times = System.DateTime.Now.ToShortDateString();
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@username", this.username),
				new SqlParameter("@name", name),
				new SqlParameter("@fen", fen),
				new SqlParameter("@phone", phone),
				new SqlParameter("@s_sheng", s_sheng),
				new SqlParameter("@s_shi", s_shi),
				new SqlParameter("@s_xian", s_xian),
				new SqlParameter("@times", times)
			};
            string sql = "insert into wysdv (username,name,fen,phone,s_sheng,s_shi,s_xian,times) values(@username,@name,@fen,@phone,@s_sheng,@s_shi,@s_xian,@times)";
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('提交申请成功');location.href='wdcc.aspx';</script>");
                base.Response.End();
            }
        }
    }
}