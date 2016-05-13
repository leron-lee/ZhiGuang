using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class wx_login : System.Web.UI.Page
    {
        public string openid;
        public string name;
        public string sex;
        public string img;
        public string province;
        public string city;
 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["code"] != null)
                {
                    string text = getwx.AppId();
                    string text2 = getwx.AppSecret();
                    string text3 = base.Request.QueryString["code"];
                    string s = get.geturl(string.Concat(new string[]
					{
						"https://api.weixin.qq.com/sns/oauth2/access_token?appid=",
						text,
						"&secret=",
						text2,
						"&code=",
						text3,
						"&grant_type=authorization_code"
					}));
                    string text4 = json.JsonTooo(s, "access_token");
                    this.openid = json.JsonTooo(s, "openid");
                    string s2 = get.geturl(string.Concat(new string[]
					{
						"https://api.weixin.qq.com/sns/userinfo?access_token=",
						text4,
						"&openid=",
						this.openid,
						"&lang=zh_CN"
					}));
                    string text5 = json.JsonTooo(s2, "nickname");
                    this.sex = json.JsonTooo(s2, "sex");
                    this.province = json.JsonTooo(s2, "province");
                    this.city = json.JsonTooo(s2, "city");
                    string text6 = json.JsonTooo(s2, "country");
                    string text7 = json.JsonTooo(s2, "headimgurl");
                    string text8 = json.JsonTooo(s2, "privilege");
                    if (this.sex == "1")
                    {
                        this.sex = "男";
                    }
                    else
                    {
                        if (this.sex == "2")
                        {
                            this.sex = "女";
                        }
                    }
                    this.img = text7;
                    this.name = text5;
                    string a = new SqlHelper().ExecuteScalar("select id from username where openid = '" + this.openid + "'");
                    if (this.openid == "")
                    {
                        base.Response.Redirect("login.aspx");
                    }
                    if (a == "")
                    {
                        base.Response.Redirect(string.Concat(new string[]
						{
							"reg.aspx?openid=",
							this.openid,
							"&sex=",
							this.sex,
							"&name=",
							this.name,
							"&img=",
							this.img
						}));
                    }
                    else
                    {
                        string text9 = new SqlHelper().ExecuteScalar("select username from username where openid = '" + this.openid + "'");
                        if (text9 != "")
                        {
                            HttpCookie httpCookie = new HttpCookie("username");
                            httpCookie.Expires = System.DateTime.Now.AddYears(1);
                            httpCookie.Value = base.Server.UrlEncode(text9);
                            base.Response.Cookies.Add(httpCookie);
                            
                            base.Response.Redirect("/user");
                            
                        }
                    }
                }
            }
        }
        protected void bt1_Click(object sender, System.EventArgs e)
        {
            this.openid = base.Request.Form["openid"];
            if (!string.IsNullOrEmpty(this.openid))
            {
                base.Response.Redirect("wx_login1.aspx?openid=" + this.openid);
            }
        }
        protected void bt2_Click(object sender, System.EventArgs e)
        {
            this.openid = base.Request.Form["openid"];
            this.sex = base.Request.Form["sex"];
            this.name = base.Request.Form["name"];
            this.img = base.Request.Form["img"];
            this.province = base.Request.Form["province"];
            this.city = base.Request.Form["city"];
            if (!string.IsNullOrEmpty(this.openid))
            {
                base.Response.Redirect(string.Concat(new string[]
				{
					"reg.aspx?openid=",
					this.openid,
					"&sex=",
					this.sex,
					"&name=",
					this.name,
					"&img=",
					this.img,
					"&province=",
					this.province,
					"&city=",
					this.city
				}));
            }
        }
    }
}