using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
using System.Xml;
namespace Web.alipay
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = this.GetRequestPost();
            if (sPara.Count > 0)
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyNotify(sPara, base.Request.Form["sign"]);
                if (verifyResult)
                {
                    sPara = aliNotify.Decrypt(sPara);
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(sPara["notify_data"]);
                        string out_trade_no = xmlDoc.SelectSingleNode("/notify/out_trade_no").InnerText;
                        string trade_no = xmlDoc.SelectSingleNode("/notify/trade_no").InnerText;
                        string trade_status = xmlDoc.SelectSingleNode("/notify/trade_status").InnerText;
                        if (trade_status == "TRADE_FINISHED")
                        {
                            get.zfcg(out_trade_no);
                            base.Response.Write("success");
                        }
                        else
                        {
                            if (trade_status == "TRADE_SUCCESS")
                            {
                                get.zfcg(out_trade_no);
                                base.Response.Write("success");
                            }
                            else
                            {
                                base.Response.Write(trade_status);
                            }
                        }
                    }
                    catch (System.Exception exc)
                    {
                        base.Response.Write(exc.ToString());
                    }
                }
                else
                {
                    base.Response.Write("fail");
                }
            }
            else
            {
                base.Response.Write("无通知参数");
            }
        }
        public System.Collections.Generic.Dictionary<string, string> GetRequestPost()
        {
            System.Collections.Generic.Dictionary<string, string> sArray = new System.Collections.Generic.Dictionary<string, string>();
            NameValueCollection coll = base.Request.Form;
            string[] requestItem = coll.AllKeys;
            for (int i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], base.Request.Form[requestItem[i]]);
            }
            return sArray;
        }
    }
}