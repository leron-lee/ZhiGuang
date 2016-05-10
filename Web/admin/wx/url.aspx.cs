using System;
using System.Data;
using System.IO;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Net;
using System.Data.SqlClient;
using System.Text;
namespace Web.admin.wx
{
    public partial class url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {



                if (base.Request.RequestType.ToUpper() == "POST")
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(base.Request.InputStream);
                    string xmlData = reader.ReadToEnd();
                    if (this.js(xmlData, "Event") == "subscribe")
                    {
                        string ToUserName = this.js(xmlData, "ToUserName");
                        string FromUserName = this.js(xmlData, "FromUserName");
                        string CreateTime = this.js(xmlData, "CreateTime");
                        string MsgType = this.js(xmlData, "MsgType");
                        string Event = this.js(xmlData, "Event");
                        string EventKey = this.js(xmlData, "EventKey");
                        string s = this.fstw(FromUserName, ToUserName, "关注回复", EventKey);
                        base.Response.ContentType = "text/xml";
                        base.Response.Write(s);
                        base.Response.End();
                    }

                    if (this.js(xmlData, "Event") == "SCAN")
                    {
                        string ToUserName = this.js(xmlData, "ToUserName");
                        string FromUserName = this.js(xmlData, "FromUserName");
                        string CreateTime = this.js(xmlData, "CreateTime");
                        string MsgType = this.js(xmlData, "MsgType");
                        string Event = this.js(xmlData, "Event");
                        string EventKey = this.js(xmlData, "EventKey");
                        string s = this.fstw2(FromUserName, ToUserName);
                        base.Response.ContentType = "text/xml";
                        base.Response.Write(s);
                        base.Response.End();
                    }
                    if (this.js(xmlData, "Event") == "CLICK")
                    {
                        string ToUserName = this.js(xmlData, "ToUserName");
                        string FromUserName = this.js(xmlData, "FromUserName");
                        string CreateTime = this.js(xmlData, "CreateTime");
                        string MsgType = this.js(xmlData, "MsgType");
                        string Event = this.js(xmlData, "Event");
                        string EventKey = this.js(xmlData, "EventKey");
                        string s = this.fstw(FromUserName, ToUserName, EventKey);
                        base.Response.ContentType = "text/xml";
                        base.Response.Write(s);
                        base.Response.End();
                    }


                    if (this.js(xmlData, "Content") != "")
                    {
                        string ToUserName = this.js(xmlData, "ToUserName");
                        string FromUserName = this.js(xmlData, "FromUserName");
                        string CreateTime = this.js(xmlData, "CreateTime");
                        string MsgType = this.js(xmlData, "MsgType");
                        string Content = this.js(xmlData, "Content");
                        string MsgId = this.js(xmlData, "MsgId");
                        string s = this.fstw(FromUserName, ToUserName, Content);
                        if (s == "")
                        {
                            s += "<xml>";
                            s = s + "<ToUserName><![CDATA[" + FromUserName + "]]></ToUserName>";
                            s = s + "<FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>";
                            s = s + "<CreateTime>" + CreateTime + "</CreateTime>";
                            s += "<MsgType><![CDATA[transfer_customer_service]]></MsgType>";
                            s += "</xml>";
                        }


                        base.Response.ContentType = "text/xml";
                        base.Response.Write(s);
                        base.Response.End();
                    }
                }
                else
                {
                    this.Valid();
                }
            }
        }
        public string js(string xmlData, string fh)
        {
            string fig = "";
            DataSet ds = new DataSet();
            System.IO.StringReader StrStream = new System.IO.StringReader(xmlData);
            XmlTextReader Xmlrdr = new XmlTextReader(StrStream);
            ds.ReadXml(Xmlrdr);
            DataTable dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                if (r.Table.Columns.Contains(fh))
                {
                    fig = r[fh].ToString();
                }
            }
            return fig;
        }


        public string fstw2(string toUser, string fromUser)
        {
            string fig = "";

          
            string s = "";
            s += "<xml>";
            s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
            s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
            object obj = s;
            s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
            s += "<MsgType><![CDATA[text]]></MsgType>";
            s = s + "<Content><![CDATA[欢迎光临，您已经是礼尚挚广的会员！]]></Content>";
            s += "</xml>";

            fig = s;




            return fig;
        }

        public string fstw(string toUser, string fromUser, string gjc, string EventKey)
        {
            string fig = "";
            string count = new access().ExecuteScalar("select count(id) from wx_huifu where gjc like '%," + gjc + ",%'");


            bool f = true;
            if (EventKey.Length > 0)
            {
                string value10 = new SqlHelper().ExecuteScalar("select id from username where openid = '" + toUser + "'");
                if (string.IsNullOrEmpty(value10))
                {

                    string access_token = getwx.access_token();

                    string posturl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token + "&openid=" + toUser + "&lang=zh_CN";
                    string ls2 = get.geturl(posturl);

                    string openid = toUser;
                    int num = 1881101;
                    string value3 = new SqlHelper().ExecuteScalar("select top 1 id from username order by id desc");
                    if (!string.IsNullOrEmpty(value3))
                    {
                        num += System.Convert.ToInt32(value3);
                    }
                    string username = "wx_" + num;
                    string pwd = "123456";
                    string phone = "";
                    string name = json.JsonTooo(ls2, "nickname");
                    string img = json.JsonTooo(ls2, "headimgurl");
                    string tj_username = EventKey.Split('_')[1];

                    string value6 = "";
                    string value7 = "";
                    string value8 = "6";
                    string value9 = System.DateTime.Now.ToString();
                    SqlParameter[] parameters = new SqlParameter[]
					{
						new SqlParameter("@openid", openid),
						new SqlParameter("@username", username),
						new SqlParameter("@pwd", pwd),
						new SqlParameter("@phone", phone),
						new SqlParameter("@name", name),
						new SqlParameter("@img", img),
						new SqlParameter("@tj_username", tj_username),
						new SqlParameter("@tj_ywy", value6),
						new SqlParameter("@tj_mendian", value7),
						new SqlParameter("@jb", value8),
						new SqlParameter("@times", value9)
					};

                    string query = "insert into username (openid,username,pwd,phone,name,img,tj_username,tj_ywy,tj_mendian,jb,times) values(@openid,@username,@pwd,@phone,@name,@img,@tj_username,@tj_ywy,@tj_mendian,@jb,@times)";
                    int num2 = new SqlHelper().ExecuteNonQuery(query, parameters);

                    if (num2 > 0)
                    {


                        new SqlHelper().ExecuteNonQuery("update username set cb=cb+3 where id=" + tj_username);


                        string touser = new SqlHelper().ExecuteScalar("select openid from username where id=" + tj_username);
                        string cb = new SqlHelper().ExecuteScalar("select cb from username where id=" + tj_username);
                        RegMessage(touser, name, cb, access_token);

                    }



                }
                else
                {
                    f = false;
                    string s = "";
                    s += "<xml>";
                    s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
                    s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
                    object obj = s;
                    s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
                    s += "<MsgType><![CDATA[text]]></MsgType>";
                    s = s + "<Content><![CDATA[欢迎光临，您已经是礼尚挚广的会员！]]></Content>";
                    s += "</xml>";

                    fig = s;
                }
            }
            else
            {
                string value10 = new SqlHelper().ExecuteScalar("select id from username where openid = '" + toUser + "'");
                if (string.IsNullOrEmpty(value10))
                {
                    string access_token = getwx.access_token();
                    string posturl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + access_token + "&openid=" + toUser + "&lang=zh_CN";

                    string ls2 = get.geturl(posturl);

                    string openid = toUser;
                    int num = 1881101;
                    string value3 = new SqlHelper().ExecuteScalar("select top 1 id from username order by id desc");
                    if (!string.IsNullOrEmpty(value3))
                    {
                        num += System.Convert.ToInt32(value3);
                    }
                    string username = "wx_" + num;
                    string pwd = "123456";
                    string phone = "";
                    string name = json.JsonTooo(ls2, "nickname");
                    string img = json.JsonTooo(ls2, "headimgurl");
                    string tj_username = "0";

                    string value6 = "";
                    string value7 = "";
                    string value8 = "6";
                    string value9 = System.DateTime.Now.ToString();
                    SqlParameter[] parameters = new SqlParameter[]
					{
						new SqlParameter("@openid", openid),
						new SqlParameter("@username", username),
						new SqlParameter("@pwd", pwd),
						new SqlParameter("@phone", phone),
						new SqlParameter("@name", name),
						new SqlParameter("@img", img),
						new SqlParameter("@tj_username", tj_username),
						new SqlParameter("@tj_ywy", value6),
						new SqlParameter("@tj_mendian", value7),
						new SqlParameter("@jb", value8),
						new SqlParameter("@times", value9)
					};

                    string query = "insert into username (openid,username,pwd,phone,name,img,tj_username,tj_ywy,tj_mendian,jb,times) values(@openid,@username,@pwd,@phone,@name,@img,@tj_username,@tj_ywy,@tj_mendian,@jb,@times)";
                    int num2 = new SqlHelper().ExecuteNonQuery(query, parameters);
                }
            }

            if (count != "0" && f == true)
            {
                string s = "";
                string img = new access().ExecuteScalar("select top 1 img from wx_huifu where gjc like '%" + gjc + "%'");
                if (count == "1" && img == "")
                {
                    string href = new access().ExecuteScalar("select top 1 href from wx_huifu where gjc like '%" + gjc + "%'");
                    string nt = new access().ExecuteScalar("select top 1 nt from wx_huifu where gjc like '%" + gjc + "%'");
                    if (href != "" && href != "http://")
                    {
                        nt = string.Concat(new string[]
						{
							"<a href='",
							href,
							"'>",
							nt,
							"</a>"
						});
                    }
                    s += "<xml>";
                    s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
                    s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
                    object obj = s;
                    s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
                    s += "<MsgType><![CDATA[text]]></MsgType>";
                    s = s + "<Content><![CDATA[" + nt + "]]></Content>";
                    s += "</xml>";
                }
                else
                {
                    s += "<xml>";
                    s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
                    s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
                    object obj = s;
                    s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
                    s += "<MsgType><![CDATA[news]]></MsgType>";
                    s = s + "<ArticleCount>" + count + "</ArticleCount>";
                    s += "<Articles>";
                    using (DataTable dt = new access().ExecuteDataTable("select * from wx_huifu where gjc like '%," + gjc + ",%' order by px"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            s += "<item>";
                            obj = s;
                            s = string.Concat(new object[]
							{
								obj,
								"<Title><![CDATA[",
								r["name"],
								"]]></Title> "
							});
                            obj = s;
                            s = string.Concat(new object[]
							{
								obj,
								"<Description><![CDATA[",
								r["nt"],
								"]]></Description>"
							});
                            obj = s;
                            s = string.Concat(new object[]
							{
								obj,
								"<PicUrl><![CDATA[http://",
								base.Request.Url.Authority,
								r["img"],
								"]]></PicUrl>"
							});
                            obj = s;
                            s = string.Concat(new object[]
							{
								obj,
								"<Url><![CDATA[",
								r["href"],
								"]]></Url>"
							});
                            s += "</item>";
                        }
                    }
                    s += "</Articles>";
                    s += "</xml>";
                }
                fig = s;

            }



            return fig;
        }

        public void RegMessage(string touser, string nick, string amount, string access_token)
        {

            string fig = "";
            fig += "{";
            fig = fig + "\"touser\":\"" + touser + "\",";
            fig += "\"template_id\":\"T9ytE4dHqtAe4ofdZ7wPu08ZS3HoEYIuCizK7k3sGaA\",";
            fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            fig += "\"topcolor\":\"#FF0000\",";
            fig += "\"data\":{";

            fig += "\"first\": {\"value\":\"您的积分账户变更如下\",\"color\":\"#173177\"},";
            fig += "\"FieldName\": {\"value\":\"好友【" + nick + "】关注，新增积分：+3积分\",\"color\":\"#173177\"},";
            fig += "\"change\": {\"value\":\"增加\",\"color\":\"#173177\"},";
            fig += "\"CreditChange\": {\"value\":\"3\",\"color\":\"#173177\"},";
            fig += "\"CreditTotal\": {\"value\":\"" + amount + "\",\"color\":\"#173177\"}";
            fig += "}";
            fig += "}";
            fig = fig.Replace(" ", "");

            get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + access_token, fig);

        }
        public string fstw(string toUser, string fromUser, string gjc)
        {
            string fig = "";
            string count = new access().ExecuteScalar("select count(id) from wx_huifu where gjc like '%," + gjc + ",%'");



            if (gjc.Equals("我要签到"))
            {


                int countq = Convert.ToInt32(new SqlHelper().ExecuteScalar("SELECT count(id) FROM qiandao WHERE DateDiff(dd,times,getdate())=0 and openid='" + toUser + "'"));
                if (countq == 0)
                {

                    new SqlHelper().ExecuteNonQuery("update username set cb=cb+1 where openid='" + toUser + "'");


                    new SqlHelper().ExecuteNonQuery("insert into qiandao (openid,times) values ('" + toUser + "','" + DateTime.Now.ToString() + "')");

                    string access_token = getwx.access_token();
                    //代表可以签到

                    string amount = new SqlHelper().ExecuteScalar("select cb from username where openid='" + toUser + "'");
                    string figq = "";
                    figq += "{";
                    figq = figq + "\"touser\":\"" + toUser + "\",";
                    figq += "\"template_id\":\"T9ytE4dHqtAe4ofdZ7wPu08ZS3HoEYIuCizK7k3sGaA\",";
                    figq += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
                    figq += "\"topcolor\":\"#FF0000\",";
                    figq += "\"data\":{";

                    figq += "\"first\": {\"value\":\"您的积分账户变更如下\",\"color\":\"#173177\"},";
                    figq += "\"FieldName\": {\"value\":\"您在" + DateTime.Now.ToShortDateString() + "签到\",\"color\":\"#173177\"},";
                    figq += "\"change\": {\"value\":\"增加\",\"color\":\"#173177\"},";
                    figq += "\"CreditChange\": {\"value\":\"1\",\"color\":\"#173177\"},";
                    figq += "\"CreditTotal\": {\"value\":\"" + amount + "\",\"color\":\"#173177\"}";
                    figq += "}";
                    figq += "}";
                    figq = figq.Replace(" ", "");

                    get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + access_token, figq);
                }
                else
                {
                    //代表已经签到

                }









            }

            else
            {
                if (count != "0")
                {
                    string s = "";
                    string img = new access().ExecuteScalar("select top 1 img from wx_huifu where gjc like '%" + gjc + "%'");
                    if (count == "1" && img == "")
                    {
                        string href = new access().ExecuteScalar("select top 1 href from wx_huifu where gjc like '%" + gjc + "%'");
                        string nt = new access().ExecuteScalar("select top 1 nt from wx_huifu where gjc like '%" + gjc + "%'");
                        if (href != "" && href != "http://")
                        {
                            nt = string.Concat(new string[]
						{
							"<a href='",
							href,
							"'>",
							nt,
							"</a>"
						});
                        }
                        s += "<xml>";
                        s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
                        s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
                        object obj = s;
                        s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
                        s += "<MsgType><![CDATA[text]]></MsgType>";
                        s = s + "<Content><![CDATA[" + nt + "]]></Content>";
                        s += "</xml>";
                    }
                    else
                    {
                        s += "<xml>";
                        s = s + "<ToUserName><![CDATA[" + toUser + "]]></ToUserName>";
                        s = s + "<FromUserName><![CDATA[" + fromUser + "]]></FromUserName>";
                        object obj = s;
                        s = string.Concat(new object[]
					{
						obj,
						"<CreateTime>",
						System.DateTime.Now.Ticks,
						"</CreateTime>"
					});
                        s += "<MsgType><![CDATA[news]]></MsgType>";
                        s = s + "<ArticleCount>" + count + "</ArticleCount>";
                        s += "<Articles>";
                        using (DataTable dt = new access().ExecuteDataTable("select * from wx_huifu where gjc like '%," + gjc + ",%' order by px"))
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                s += "<item>";
                                obj = s;
                                s = string.Concat(new object[]
							{
								obj,
								"<Title><![CDATA[",
								r["name"],
								"]]></Title> "
							});
                                obj = s;
                                s = string.Concat(new object[]
							{
								obj,
								"<Description><![CDATA[",
								r["nt"],
								"]]></Description>"
							});
                                obj = s;
                                s = string.Concat(new object[]
							{
								obj,
								"<PicUrl><![CDATA[http://",
								base.Request.Url.Authority,
								r["img"],
								"]]></PicUrl>"
							});
                                obj = s;
                                s = string.Concat(new object[]
							{
								obj,
								"<Url><![CDATA[",
								r["href"],
								"]]></Url>"
							});
                                s += "</item>";
                            }
                        }
                        s += "</Articles>";
                        s += "</xml>";
                    }
                    fig = s;
                }
            }
            return fig;
        }
        public bool if_cache(string zd)
        {
            bool fig = false;
            if (base.Cache[zd] == null)
            {
                fig = true;
                base.Cache.Insert(zd, "", null, System.DateTime.Now.AddMinutes(1.0), Cache.NoSlidingExpiration);
            }
            return fig;
        }
        private void Valid()
        {
            string echoStr = base.Request.QueryString["echoStr"];
            if (this.CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    base.Response.Write(echoStr);
                    base.Response.End();
                }
            }
        }
        private bool CheckSignature()
        {
            string signature = base.Request.QueryString["signature"];
            string timestamp = base.Request.QueryString["timestamp"];
            string nonce = base.Request.QueryString["nonce"];
            string[] ArrTmp = new string[]
			{
				getwx.Token(),
				timestamp,
				nonce
			};
            System.Array.Sort<string>(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            return tmpStr == signature;
        }


        public static string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }



    }
}