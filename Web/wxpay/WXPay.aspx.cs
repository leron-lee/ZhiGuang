using Mi_gangUI.WXPay;
using Mi_gangUI.WXpay;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;
namespace Web.wxpay
{
    public partial class WXPay : System.Web.UI.Page
    {
        public static string tenpay = "1";
        public static string mchid = "1306992201";
        public static string appId = getwx.AppId();
        public static string appsecret = getwx.AppSecret();
        public static string appkey = "ljklsdjgklsjdlgjsdklgsdlkgjskllk";
        public static string pay_url = "http://XXXX/cart/WXPay.aspx";
        public static string notify_url = "http://XXXX/cart/notify_url.aspx";
        public static string timeStamp = "";
        public static string nonceStr = "";
        public static string code = "";
        public static string prepayId = "";
        public static string sign = "";
        public static string paySign = "";
        public static string package = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            WXPay.pay_url = string.Concat(new string[]
			{
				"http://",
				base.Request.Url.Authority,
				"/wxpay/WXPay.aspx?ordernumber=",
				base.Request.QueryString["ordernumber"],
				"&price=",
				base.Request.QueryString["price"]
			});
            WXPay.notify_url = "http://" + base.Request.Url.Authority + "/wxpay/notify_url.aspx";
            WXPay.pay_url = base.Server.UrlEncode(WXPay.pay_url);
            if (base.Request.QueryString["code"] != null)
            {

               // new SqlHelper().ExecuteNonQuery("insert into ceshi (a) values('11113')");
                WXPay.code = base.Request.QueryString["code"];
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", WXPay.appId, WXPay.appsecret, WXPay.code);
                string returnStr = HttpUtil.Send("", url);
                ModelOpenID obj = JsonConvert.DeserializeObject<ModelOpenID>(returnStr);
                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", WXPay.appId, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<ModelOpenID>(returnStr);
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "OpenID > access_token=" + obj.access_token);
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "OpenID > openid=" + obj.openid);
                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "OpenID > returnStr=" + returnStr);
                string sp_billno = base.Request["ordernumber"];
                string date = System.DateTime.Now.ToString("yyyyMMdd");
                if (null == sp_billno)
                {
                    sp_billno = System.DateTime.Now.ToString("HHmmss") + TenpayUtil.BuildRandomStr(4);
                }
                else
                {
                    sp_billno = base.Request["ordernumber"];
                }
                WXPay.timeStamp = TenpayUtil.getTimestamp();
                WXPay.nonceStr = TenpayUtil.getNoncestr();
                sp_billno = sp_billno.Trim();
                string xordernumber = get.nyrsfm();
                double price = System.Convert.ToDouble(base.Request.QueryString["price"]) * 100.0;
                sp_billno = liu.MD5(xordernumber).Substring(0, 4) + "_" + sp_billno;
                RequestHandler packageReqHandler = new RequestHandler(this.Context);
                packageReqHandler.init();
                packageReqHandler.setParameter("body", "订单号：" + sp_billno);
                packageReqHandler.setParameter("appid", WXPay.appId);
                packageReqHandler.setParameter("mch_id", WXPay.mchid);
                packageReqHandler.setParameter("nonce_str", WXPay.nonceStr.ToLower());
                packageReqHandler.setParameter("notify_url", WXPay.notify_url);
                packageReqHandler.setParameter("openid", obj.openid);
                packageReqHandler.setParameter("out_trade_no", sp_billno);
                packageReqHandler.setParameter("spbill_create_ip", this.Page.Request.UserHostAddress);
                packageReqHandler.setParameter("total_fee", string.Concat(price));
                packageReqHandler.setParameter("trade_type", "JSAPI");
                WXPay.sign = packageReqHandler.CreateMd5Sign("key", WXPay.appkey);
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "sign=" + WXPay.sign);
                packageReqHandler.setParameter("sign", WXPay.sign);
                string data = packageReqHandler.parseXML();
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "package > XML=" + data);
                string prepayXml = HttpUtil.Send(data, "https://api.mch.weixin.qq.com/pay/unifiedorder");
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "package > Back_XML=" + prepayXml);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(prepayXml);
                XmlNode xn = xdoc.SelectSingleNode("xml");
                XmlNodeList xnl = xn.ChildNodes;
                if (xnl.Count > 7)
                {
                    WXPay.prepayId = xnl[7].InnerText;
                    WXPay.package = string.Format("prepay_id={0}", WXPay.prepayId);
                    WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "package > package=" + WXPay.package);
                }
                RequestHandler paySignReqHandler = new RequestHandler(this.Context);
                paySignReqHandler.setParameter("appId", WXPay.appId);
                paySignReqHandler.setParameter("timeStamp", WXPay.timeStamp);
                paySignReqHandler.setParameter("nonceStr", WXPay.nonceStr);
                paySignReqHandler.setParameter("package", WXPay.package);
                paySignReqHandler.setParameter("signType", "MD5");
                WXPay.paySign = paySignReqHandler.CreateMd5Sign("key", WXPay.appkey);
                WXPay.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "paySign > paySign = " + WXPay.paySign);
            }
            else
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=lk#wechat_redirect", WXPay.appId, WXPay.pay_url);
                base.Response.Redirect(code_url);
            }
        }
        public static void WriteFile(string pathWrite, string content)
        {
            if (System.IO.File.Exists(pathWrite))
            {
            }
            System.IO.File.AppendAllText(pathWrite, content + "\r\n----------------------------------------\r\n", System.Text.Encoding.GetEncoding("utf-8"));
        }
    }
}