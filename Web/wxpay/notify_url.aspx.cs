using Mi_gangUI.WXPay;
using System;
using System.IO;
using System.Text;
using System.Web.UI;
using WJcms.Common;

namespace Web.wxpay
{
    public partial class notify_url : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            ResponseHandler resHandler = new ResponseHandler(this.Context);
            resHandler.setKey("ljklsdjgklsjdlgjsdklgsdlkgjskllk");
            try
            {
                string error = "";
                if (resHandler.isWXsign(out error))
                {
                    string return_code = resHandler.getParameter("return_code");
                    string return_msg = resHandler.getParameter("return_msg");
                    string appid = resHandler.getParameter("appid");
                    string mch_id = resHandler.getParameter("mch_id");
                    string device_info = resHandler.getParameter("device_info");
                    string nonce_str = resHandler.getParameter("nonce_str");
                    string result_code = resHandler.getParameter("result_code");
                    string err_code = resHandler.getParameter("err_code");
                    string err_code_des = resHandler.getParameter("err_code_des");
                    string openid = resHandler.getParameter("openid");
                    string is_subscribe = resHandler.getParameter("is_subscribe");
                    string trade_type = resHandler.getParameter("trade_type");
                    string bank_type = resHandler.getParameter("bank_type");
                    string total_fee = resHandler.getParameter("total_fee");
                    string fee_type = resHandler.getParameter("fee_type");
                    string transaction_id = resHandler.getParameter("transaction_id");
                    string out_trade_no = resHandler.getParameter("out_trade_no");
                    string attach = resHandler.getParameter("attach");
                    string time_end = resHandler.getParameter("time_end");
                    if (!out_trade_no.Equals("") && Utils.IsDouble(total_fee) && return_code.Equals("SUCCESS") && result_code.Equals("SUCCESS"))
                    {

                        
                            //new SqlHelper().ExecuteNonQuery("insert into ceshi (a) values('11112')");
                            get.zfcg(out_trade_no);
                            base.Response.Write("success");
                            notify_url.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "notify > success \r\n");
                            return;
                       
                       
                    }
                    notify_url.WriteFile(base.Server.MapPath("/") + "\\Log.txt", string.Concat(new string[]
					{
						"notify > total_fee= ",
						total_fee,
						" \r\n  err_code_des= ",
						err_code_des,
						" \r\n  result_code= ",
						result_code,
						" \r\n"
					}));
                }
                else
                {
                    notify_url.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "notify > isWXsign= false \r\n" + error);
                }
            }
            catch (System.Exception ee)
            {
                notify_url.WriteFile(base.Server.MapPath("/") + "\\Log.txt", "notify > ee=" + ee.Message + " \r\n");
            }
            base.Response.End();
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