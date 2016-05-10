using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class wx_login1 : System.Web.UI.Page
    {

  
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void login_bt_Click(object sender, System.EventArgs e)
        {
            string phone = this.phone.Text.Trim();
            string pwd = this.pwd.Text.Trim();
            string openid = base.Request.QueryString["openid"];
            if (phone != "" && openid != "")
            {
                string spwd = new SqlHelper().ExecuteScalar("select pwd from username where username='" + phone + "'");
                string sopenid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + phone + "'");
                if (spwd == "")
                {
                    base.Response.Write("<script>alert('用户名不存在');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
                else
                {
                    if (sopenid != "")
                    {
                        base.Response.Write("<script>alert('该会员已经绑定了微信号');location.href='" + base.Request.RawUrl + "';</script>");
                        base.Response.End();
                    }
                    else
                    {
                        if (spwd != pwd)
                        {
                            base.Response.Write("<script>alert('密码错误');location.href='" + base.Request.RawUrl + "';</script>");
                            base.Response.End();
                        }
                        else
                        {
                            new SqlHelper().ExecuteNonQuery("delete from username where openid='" + openid + "'");
                            string sql = string.Concat(new string[]
							{
								"update username set openid = '",
								openid,
								"' where username = '",
								phone,
								"'"
							});
                            new SqlHelper().ExecuteNonQuery(sql);
                            HttpCookie cook = new HttpCookie("username");
                            cook.Expires = System.DateTime.Now.AddYears(1);
                            cook.Value = base.Server.UrlEncode(phone);
                            base.Response.Cookies.Add(cook);
                            base.Response.Redirect("/user");
                        }
                    }
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