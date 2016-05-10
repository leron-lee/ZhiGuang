using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class chongzhi_ye : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void cz_je_Click(object sender, System.EventArgs e)
        {
            string s = this.s1.Text;
            if (s != "")
            {
                if (System.Convert.ToInt32(s) > 0)
                {
                    string ordernumber = get.nyrsfm();
                    string zt = "0";
                    string price = s;
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                    SqlParameter[] op = new SqlParameter[]
					{
						new SqlParameter("@ordernumber", ordernumber),
						new SqlParameter("@zt", zt),
						new SqlParameter("@price", price),
						new SqlParameter("@username", username)
					};
                    string sql = "insert into chongzhi_ye (ordernumber,zt,price,username) values(@ordernumber,@zt,@price,@username)";
                    new SqlHelper().ExecuteNonQuery(sql, op);
                    base.Response.Redirect("/cart/pay.aspx?ordernumber=" + ordernumber);
                }
                else
                {
                    base.Response.Write("<script>alert('充值金额必须大于0');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
            }
            else
            {
                base.Response.Write("<script>alert('请输入充值金额');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
    }
}