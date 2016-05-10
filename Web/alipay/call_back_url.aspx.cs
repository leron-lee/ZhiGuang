using System;
using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.alipay
{
    public partial class call_back_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = this.GetRequestGet();
            if (sPara.Count > 0)
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.VerifyReturn(sPara, base.Request.QueryString["sign"]);
                if (verifyResult)
                {
                    string out_trade_no = base.Request.QueryString["out_trade_no"];
                    string trade_no = base.Request.QueryString["trade_no"];
                    string result = base.Request.QueryString["result"];
                    get.zfcg(out_trade_no);
                    base.Response.Redirect("/user/shoporder.aspx");
                }
                else
                {
                    base.Response.Write("验证失败");
                }
            }
            else
            {
                base.Response.Write("无返回参数");
            }
        }
        public System.Collections.Generic.Dictionary<string, string> GetRequestGet()
        {
            System.Collections.Generic.Dictionary<string, string> sArray = new System.Collections.Generic.Dictionary<string, string>();
            NameValueCollection coll = base.Request.QueryString;
            string[] requestItem = coll.AllKeys;
            for (int i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], base.Request.QueryString[requestItem[i]]);
            }
            return sArray;
        }
    }
}