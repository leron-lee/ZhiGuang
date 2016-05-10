using System;
using System.Web.UI;
namespace Web.admin.wx
{
    public partial class getuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string AppId = getwx.AppId();
                string AppSecret = getwx.AppSecret();
                if (base.Request.QueryString["code"] == null)
                {
                    base.Response.Redirect(string.Concat(new string[]
					{
						"https://open.weixin.qq.com/connect/oauth2/authorize?appid=",
						AppId,
						"&redirect_uri=",
						base.Server.UrlEncode("http://" + base.Request.Url.Authority),
						"&response_type=code&scope=snsapi_userinfo&state=123#wechat_redirect"
					}));
                }
                else
                {
                    string code = base.Request.QueryString["code"];
                    string ls = get.geturl(string.Concat(new string[]
					{
						"https://api.weixin.qq.com/sns/oauth2/access_token?appid=",
						AppId,
						"&secret=",
						AppSecret,
						"&code=",
						code,
						"&grant_type=authorization_code"
					}));
                    string access_token = json.JsonTooo(ls, "access_token");
                    string openid = json.JsonTooo(ls, "openid");
                    string lask = get.geturl(string.Concat(new string[]
					{
						"https://api.weixin.qq.com/sns/userinfo?access_token=",
						access_token,
						"&openid=",
						openid,
						"&lang=zh_CN"
					}));
                    string nickname = json.JsonTooo(lask, "nickname");
                    string sex = json.JsonTooo(lask, "sex");
                    string province = json.JsonTooo(lask, "province");
                    string city = json.JsonTooo(lask, "city");
                    string country = json.JsonTooo(lask, "country");
                    string headimgurl = json.JsonTooo(lask, "headimgurl");
                    string privilege = json.JsonTooo(lask, "privilege");
                }
            }
        }
    }
}