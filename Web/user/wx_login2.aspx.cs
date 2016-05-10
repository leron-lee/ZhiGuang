using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class wx_login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void reg_bt_Click(object sender, System.EventArgs e)
        {
            string phone = this.phone.Text.Trim();
            string pwd = this.pwd.Text.Trim();
            string openid = base.Request.QueryString["openid"];
            if (phone != "" && openid != "")
            {
                string sid = new SqlHelper().ExecuteScalar("select id from username where username = '" + phone + "'");
                if (sid != "")
                {
                    base.Response.Write("<script>alert('该手机号码已被注册');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
                else
                {
                    string sql = string.Concat(new string[]
					{
						"update username set username = '",
						phone,
						"',pwd='",
						pwd,
						"' where openid = '",
						openid,
						"'"
					});
                    new SqlHelper().ExecuteNonQuery(sql);
                    HttpCookie cook = new HttpCookie("username");
                    cook.Expires = System.DateTime.Now.AddYears(1);
                    cook.Value = base.Server.UrlEncode(phone);
                    base.Response.Cookies.Add(cook);
                    get.hb_cao(phone, "增加", "100", "注册送红包");
                    base.Response.Redirect("/user");
                }
            }
            else
            {
                base.Response.Write("<script>alert('系统异常请重新登录');location.href='/user';</script>");
                base.Response.End();
            }
        }
    }
}