using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
namespace Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              // string a= getwx.xiaoxi_tixian(1000,"","wx_1881101");

            //   Response.Write(a+"1");
                //get.zfcg("2015111722275729828");
              //  getwx.xiaoxi_fx("", "201511123657475184", 0.01, "", "wx_1881101");

               // get.DengJi("wx_1881189", 10, "2015111505036333");
                /*
                string fig = "";
                fig += "{";
                fig = fig + "\"touser\":\"" + "oa5I-t9yaBPZ6O4m8dkiPVcfmI-g" + "\",";
                fig += "\"template_id\":\"Gg5QCcN5jAq5NYNgYfpLCQZkzJ2Bm9pG9L8UC5BoOmQ\",";
                fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
                fig += "\"topcolor\":\"#FF0000\",";
                fig += "\"data\":{";

                fig += "\"first\": {\"value\":\"您好,您分享的商品获得返利回馈\",\"color\":\"#173177\"},";
                fig += "\"keyword1\": {\"value\":\"" + "122222222222222222" + "\",\"color\":\"#173177\"},";
                fig += "\"keyword2\": {\"value\":\"" + "11" + "\",\"color\":\"#173177\"},";
                fig += "\"keyword3\": {\"value\":\"" + DateTime.Now.ToShortDateString() + "\",\"color\":\"#173177\"},";
                fig += "\"keyword4\": {\"value\":\"" + "12" + "元\",\"color\":\"#173177\"},";
                fig += "\"remark\": {\"value\":\"" + "感谢您的支持" + "\",\"color\":\"#173177\"}";
                fig += "}";
                fig += "}";
                fig = fig.Replace(" ", "");
                string ACCESS_TOKEN = getwx.access_token();
                get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);

                
               string AppId = getwx.AppId();
               string AppSecret = getwx.AppSecret();
               string ls = get.geturl("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppId + "&secret=" + AppSecret + "");

               string access_token = json.JsonTooo(ls, "access_token");

               
               string QrcodeUrl = "https://graph.qq.com/oauth2.0/me?access_token=" + access_token;//WxQrcodeAPI接口


               string fig = get.geturl(QrcodeUrl);
               fig = json.JsonTooo(fig, "openid");

               
            string scene_id = "1";

            string PostJson = "{ \"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scene_id + "}}}";

            string str1 = PostMoths(QrcodeUrl, PostJson);
            string nickname = json.JsonTooo(str1, "ticket");
            string imgurl = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + nickname;
            

                string tj_username = "4";

                new SqlHelper().ExecuteNonQuery("update username set cb=cb+3 where id=" + tj_username);

                string name = "1";
                string touser = new SqlHelper().ExecuteScalar("select openid from username where id=" + tj_username);
                string cb = new SqlHelper().ExecuteScalar("select cb from username where id=" + tj_username);
               string a = RegMessage(touser, name, cb, access_token);

               Response.Write(a);
                 */

                // string str= xiaoxi_fx("", "20151114331675630", "20", "", "wx_1881101");
               //Response.Write(str);

             // string sr=  xiaoxi_goumai("2015111318473795255");
             // Response.Write(sr);

               // string img = 

//Response.Write("<img src='"+img+"'>");
            }
        }


        public string GETGZEWM(string scene_id)
        {
           


            string access_token = getwx.access_token();

            string QrcodeUrl = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + access_token;//WxQrcodeAPI接口


            string PostJson = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scene_id + "}}}";

            string str1 = PostMoths(QrcodeUrl, PostJson);
            string nickname = json.JsonTooo(str1, "ticket");
            string imgurl = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + nickname;


            //string jsonimg = "{\"is_add_friend_reply_open\":\"1\",\"add_friend_autoreply_info\":{\"type\":\"img\",\"mediaID\",\"" + imgurl + "\"}}";

            return imgurl;

        }

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            
            return (sb.ToString());
        }

        public string xiaoxi_goumai(string order)
        {

            string username = "";
            string prices = "";
            string id = "";
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select id, username,price from shoporder where ordernumber='" + order + "'"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    username = r["username"].ToString();
                    prices = r["price"].ToString();
                    id = r["id"].ToString();
                }
            }
            string name = "";
            string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");

            using (DataTable dt = new SqlHelper().ExecuteDataTable("select mname from shoporderlist where OrderId=" + id + ""))
            {
                foreach (DataRow r in dt.Rows)
                {

                    if (name == "")
                    {
                        name = r["mname"].ToString();
                    }
                    else
                    {
                        name += r["mname"].ToString();
                    }
                }
            }



            string rt = "";

            if (!string.IsNullOrEmpty(openid))
            {
                

                string fig = "";
                fig += "{";
                fig = fig + "\"touser\":\"" + openid + "\",";
                fig += "\"template_id\":\"DlUrxft_ylIUTwoM7jn0nW0sv5alCW973w1wV4MQ0G4\",";
                fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
                fig += "\"topcolor\":\"#FF0000\",";
                fig += "\"data\":{";

                fig += "\"first\": {\"value\":\"我们已收到您的货款，开始为您打包商品，请耐心等待: )\",\"color\":\"#173177\"},";
                fig += "\"orderMoneySum\": {\"value\":\"" + prices + "元\",\"color\":\"#173177\"},";
                fig += "\"orderProductName\": {\"value\":\"" + name + "\",\"color\":\"#173177\"},";

                fig += "\"remark\": {\"value\":\"" + "" + "\",\"color\":\"#173177\"}";
                fig += "}";
                fig += "}";
                fig = fig.Replace(" ", "");
                string ACCESS_TOKEN = getwx.access_token();
                rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
            }

            return rt;
        }
        public static string xiaoxi_fx(object first, object order, object money, object remark, object username)
        {
            new SqlHelper().ExecuteNonQuery("insert into ceshi (a) values('" + username + "')");

            string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");

            string f = new SqlHelper().ExecuteScalar("select price from shoporder where ordernumber = '" + order + "'");
            string f2 = new SqlHelper().ExecuteScalar("select name from shoporder where ordernumber = '" + order + "'");


            string rt = "";

            if (!string.IsNullOrEmpty(openid))
            {
                openid = "oa5I-t9yaBPZ6O4m8dkiPVcfmI-g";

                string fig = "";
                fig += "{";
                fig = fig + "\"touser\":\"" + openid + "\",";
                fig += "\"template_id\":\"Gg5QCcN5jAq5NYNgYfpLCQZkzJ2Bm9pG9L8UC5BoOmQ\",";
                fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
                fig += "\"topcolor\":\"#FF0000\",";
                fig += "\"data\":{";

                fig += "\"first\": {\"value\":\"您好,您的推荐会员【" + f2 + "】，购买下单\",\"color\":\"#173177\"},";
                fig += "\"keyword1\": {\"value\":\"" + order + "\",\"color\":\"#173177\"},";
                fig += "\"keyword2\": {\"value\":\"" + f + "元\",\"color\":\"#173177\"},";
                fig += "\"keyword3\": {\"value\":\"" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分dd秒") + "\",\"color\":\"#173177\"},";
                fig += "\"keyword4\": {\"value\":\"" + money + "元\",\"color\":\"#173177\"},";
                fig += "\"remark\": {\"value\":\"" + "感谢您的支持" + "\",\"color\":\"#173177\"}";
                fig += "}";
                fig += "}";
                fig = fig.Replace(" ", "");
                string ACCESS_TOKEN = getwx.access_token();
                rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
            }

            return rt;

        }
        public string  RegMessage(string touser, string nick, string amount, string access_token)
        {

            string figq = "";
            figq += "{";
            figq = figq + "\"touser\":\"" + touser + "\",";
            figq += "\"template_id\":\"T9ytE4dHqtAe4ofdZ7wPu08ZS3HoEYIuCizK7k3sGaA\",";
            figq += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            figq += "\"topcolor\":\"#FF0000\",";
            figq += "\"data\":{";

            figq += "\"first\": {\"value\":\"您的积分账户变更如下\",\"color\":\"#173177\"},";
            figq += "\"FieldName\": {\"value\":\"您在" + DateTime.Now.ToShortDateString() + "签到，新增积分：+1积分\",\"color\":\"#173177\"},";
            figq += "\"change\": {\"value\":\"增加\",\"color\":\"#173177\"},";
            figq += "\"CreditChange\": {\"value\":\"1\",\"color\":\"#173177\"},";
            figq += "\"CreditTotal\": {\"value\":\"" + amount + "\",\"color\":\"#173177\"}";
            figq += "}";
            figq += "}";

            return get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + access_token, figq);

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