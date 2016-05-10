using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class login : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["username"] != null)
                {
                    base.Response.Redirect("/user");
                }
                else
                {
                    string text = getwx.AppId();
                    string text2 = getwx.AppSecret();
                    base.Response.Redirect(string.Concat(new string[]
					{
						"https://open.weixin.qq.com/connect/oauth2/authorize?appid=",
						text,
						"&redirect_uri=",
						base.Server.UrlEncode("http://" + base.Request.Url.Authority + "/user/wx_login.aspx"),
						"&response_type=code&scope=snsapi_userinfo&state=123#wechat_redirect"
					}));
                }
            }
        }
        protected void login_bt_Click(object sender, System.EventArgs e)
        {
            string phone = this.phone.Text.Trim();
            string pwd = this.pwd.Text.Trim();
            if (phone == "")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入手机号码');", true);
            }
            else
            {
                if (pwd == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入密码');", true);
                }
                else
                {
                    string spwd = new SqlHelper().ExecuteScalar("select pwd from username where username='" + phone + "'");
                    if (spwd == "")
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('用户名不存在');", true);
                    }
                    else
                    {
                        if (spwd != pwd)
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('密码错误');", true);
                            this.pwd.Text = "";
                        }
                        else
                        {
                            HttpCookie cook = new HttpCookie("username");
                            cook.Expires = System.DateTime.Now.AddYears(1);
                            cook.Value = base.Server.UrlEncode(phone);
                            base.Response.Cookies.Add(cook);
                            if (base.Request.QueryString["url"] == null)
                            {
                                base.Response.Redirect("/user");
                            }
                            else
                            {
                                base.Response.Redirect(base.Request.QueryString["url"]);
                            }
                        }
                    }
                }
            }
        }
        protected void wx_bt_Click(object sender, System.EventArgs e)
        {
            string AppId = getwx.AppId();
            string AppSecret = getwx.AppSecret();
            base.Response.Redirect(string.Concat(new string[]
			{
				"https://open.weixin.qq.com/connect/oauth2/authorize?appid=",
				AppId,
				"&redirect_uri=",
				base.Server.UrlEncode("http://" + base.Request.Url.Authority),
				"/user/wx_login.aspx&response_type=code&scope=snsapi_userinfo&state=123#wechat_redirect"
			}));
        }
    }
}