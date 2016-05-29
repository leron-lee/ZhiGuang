using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        public string img;
        public string name;
        public string alert;
        public string zksk = "dis";
        public string jb;
        public double ai = 10.0;
        public int int_ai = 0;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.img = get.logoimg();
                this.name = get.gsstr();
                if (base.Request.Cookies["zksk"] == null)
                {
                    this.zksk = "";
                    HttpCookie cook = new HttpCookie("zksk");
                    cook.Expires = System.DateTime.Now.AddHours(24.0);
                    cook.Value = "";
                    base.Response.Cookies.Add(cook);
                }
                using (DataTable dt = new access().ExecuteDataTable("select * from wzinfo where id = 1"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }

                using (DataTable dt = new access().ExecuteDataTable("select * from merchandise where type_two_id=19 order by id desc"))
                {
                    this.Repeater2.DataSource = dt;
                    this.Repeater2.DataBind();
                }

                using (DataTable dt = new access().ExecuteDataTable("select * from merchandise where jrsx = 1 order by px desc"))
                {
                    this.DataList1.DataSource = dt;
                    this.DataList1.DataBind();
                }
                using (DataTable dt = new access().ExecuteDataTable("select * from merchandise where sy_tj = 1 and ifsj = 1 order by px desc"))
                {
                    this.DataList2.DataSource = dt;
                    this.DataList2.DataBind();
                }
                if (base.Request.QueryString["tj_username"] != null && base.Request.Cookies["username"] == null)
                {
                    this.alert = "alert('注册会员就可以领取100元红包');";
                }
                if (base.Request.Cookies["username"] != null)
                {
                    this.Panel2.Visible = false;
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                    string aix = new SqlHelper().ExecuteScalar("select sum([price]) from shoporder where zt > 1 and username = '" + username + "'");
                    if (aix != "")
                    {
                        this.ai += System.Convert.ToDouble(aix) * 10.0;
                    }
                    string ren = get.ren(username);
                    if (!string.IsNullOrEmpty(ren))
                    {
                        this.ai += System.Convert.ToDouble(ren) * 10.0;
                    }
                    this.int_ai = System.Convert.ToInt32(this.ai);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + username + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name = r["name"].ToString();
                            if (r["img"].ToString() != "")
                            {
                                this.img = r["img"].ToString();
                            }
                            this.jb = get.jb(r["username"]);
                        }
                    }
                }
                else
                {
                    base.Response.Redirect("/user/login.aspx");
                    //               string text = getwx.AppId();
                    //               string text2 = getwx.AppSecret();
                    //               base.Response.Redirect(string.Concat(new string[]
                    //{
                    //	"https://open.weixin.qq.com/connect/oauth2/authorize?appid=",
                    //	text,
                    //	"&redirect_uri=",
                    //	base.Server.UrlEncode("http://" + base.Request.Url.Authority + "/user/wx_login.aspx"),
                    //	"&response_type=code&scope=snsapi_userinfo&state=123#wechat_redirect"
                    //}));


                    this.Panel1.Visible = true;
                }

                this.Panel1.Visible = true;
            }
        }
        public void pdifgz()
        {
            if (base.Request.Cookies["username"] != null)
            {
                string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                string sql_openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");
                if (string.IsNullOrEmpty(sql_openid))
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
                            base.Server.UrlEncode(base.Request.Url.AbsoluteUri),
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
                        if (openid != "")
                        {
                            new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
                            {
                                "update username set openid = '",
                                openid,
                                "' where username = '",
                                username,
                                "'"
                            }));
                        }
                    }
                }
            }
        }

        protected void search_bt_Click(object sender, System.EventArgs e)
        {
            string tx = this.search_tx.Text;
            base.Response.Redirect("/pro.aspx?search=" + tx);
        }
    }
}