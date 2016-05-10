using System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.zjd
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from zjd where id = 1"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.hb.Text = r["hb"].ToString();
                        this.qian.Text = r["qian"].ToString();
                        this.nt.Text = r["nt"].ToString();
                        this.ktimes.Text = r["ktimes"].ToString();
                        this.jtimes.Text = r["jtimes"].ToString();
                    }
                }
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            string hb = this.hb.Text;
            string qian = this.qian.Text;
            string nt = this.nt.Text;
            string ktimes = this.ktimes.Text;
            string jtimes = this.jtimes.Text;
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@hb", hb),
				new SqlParameter("@qian", qian),
				new SqlParameter("@nt", nt),
				new SqlParameter("@ktimes", ktimes),
				new SqlParameter("@jtimes", jtimes)
			};
            string sql = "update zjd set hb=@hb,qian=@qian,nt=@nt,ktimes=@ktimes,jtimes=@jtimes where id = 1";
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
    }
}