using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.alipay
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["ordernumber"] != null && base.Request.QueryString["price"] != null)
                {
                    string ordernumber = base.Request.QueryString["ordernumber"];
                    string price = base.Request.QueryString["price"];
                    string GATEWAY_NEW = "http://wappaygw.alipay.com/service/rest.htm?";
                    string format = "xml";
                    string v = "2.0";
                    string req_id = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    string notify_url = "http://" + base.Request.Url.Authority + "/alipay/notify_url.aspx";
                    string call_back_url = "http://" + base.Request.Url.Authority + "/alipay/call_back_url.aspx";
                    string merchant_url = "http://" + base.Request.Url.Authority + "/user/shoporder.aspx";
                    string seller_email = "3097886587@qq.com";
                    string out_trade_no = ordernumber;
                    string subject = "订单编号：" + ordernumber;
                    string total_fee = price;
                    string req_dataToken = string.Concat(new string[]
				{
					"<direct_trade_create_req><notify_url>",
					notify_url,
					"</notify_url><call_back_url>",
					call_back_url,
					"</call_back_url><seller_account_name>",
					seller_email,
					"</seller_account_name><out_trade_no>",
					out_trade_no,
					"</out_trade_no><subject>",
					subject,
					"</subject><total_fee>",
					total_fee,
					"</total_fee><merchant_url>",
					merchant_url,
					"</merchant_url></direct_trade_create_req>"
				});
                    string sHtmlTextToken = Submit.BuildRequest(GATEWAY_NEW, new System.Collections.Generic.Dictionary<string, string>
				{

					{
						"partner",
						Config.Partner
					},

					{
						"_input_charset",
						Config.Input_charset.ToLower()
					},

					{
						"sec_id",
						Config.Sign_type.ToUpper()
					},

					{
						"service",
						"alipay.wap.trade.create.direct"
					},

					{
						"format",
						format
					},

					{
						"v",
						v
					},

					{
						"req_id",
						req_id
					},

					{
						"req_data",
						req_dataToken
					}
				});
                    System.Text.Encoding code = System.Text.Encoding.GetEncoding(Config.Input_charset);
                    sHtmlTextToken = HttpUtility.UrlDecode(sHtmlTextToken, code);
                    System.Collections.Generic.Dictionary<string, string> dicHtmlTextToken = Submit.ParseResponse(sHtmlTextToken);
                    string request_token = dicHtmlTextToken["request_token"];
                    string req_data = "<auth_and_execute_req><request_token>" + request_token + "</request_token></auth_and_execute_req>";
                    string sHtmlText = Submit.BuildRequest(GATEWAY_NEW, new System.Collections.Generic.Dictionary<string, string>
				{

					{
						"partner",
						Config.Partner
					},

					{
						"_input_charset",
						Config.Input_charset.ToLower()
					},

					{
						"sec_id",
						Config.Sign_type.ToUpper()
					},

					{
						"service",
						"alipay.wap.auth.authAndExecute"
					},

					{
						"format",
						format
					},

					{
						"v",
						v
					},

					{
						"req_data",
						req_data
					}
				}, "get", "确认");
                    base.Response.Write(sHtmlText);
                }
            }
        }
    }
}