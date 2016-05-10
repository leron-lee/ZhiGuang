using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
namespace Com.Alipay
{
    public class Notify
    {
        private string _partner = "";
        private string _key = "";
        private string _private_key = "";
        private string _public_key = "";
        private string _input_charset = "";
        private string _sign_type = "";
        private string Https_veryfy_url = "https://mapi.alipay.com/gateway.do?service=notify_verify&";
        public Notify()
        {
            this._partner = Config.Partner.Trim();
            this._key = Config.Key.Trim();
            this._private_key = Config.Private_key.Trim();
            this._public_key = Config.Public_key.Trim();
            this._input_charset = Config.Input_charset.Trim().ToLower();
            this._sign_type = Config.Sign_type.Trim().ToUpper();
        }
        public bool VerifyReturn(System.Collections.Generic.Dictionary<string, string> inputPara, string sign)
        {
            bool isSign = this.GetSignVeryfy(inputPara, sign, true);
            return isSign;
        }
        public bool VerifyNotify(System.Collections.Generic.Dictionary<string, string> inputPara, string sign)
        {
            if (this._sign_type == "0001")
            {
                inputPara = this.Decrypt(inputPara);
            }
            string responseTxt = "true";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(inputPara["notify_data"]);
                string notify_id = xmlDoc.SelectSingleNode("/notify/notify_id").InnerText;
                if (notify_id != "")
                {
                    responseTxt = this.GetResponseTxt(notify_id);
                }
            }
            catch (System.Exception e)
            {
                responseTxt = e.ToString();
            }
            bool isSign = this.GetSignVeryfy(inputPara, sign, false);
            return responseTxt == "true" && isSign;
        }
        public string GetPreSignStr(System.Collections.Generic.Dictionary<string, string> inputPara)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = new System.Collections.Generic.Dictionary<string, string>();
            sPara = Core.FilterPara(inputPara);
            sPara = Core.SortPara(sPara);
            return Core.CreateLinkString(sPara);
        }
        public System.Collections.Generic.Dictionary<string, string> Decrypt(System.Collections.Generic.Dictionary<string, string> inputPara)
        {
            try
            {
                inputPara["notify_data"] = RSAFromPkcs8.decryptData(inputPara["notify_data"], this._private_key, this._input_charset);
            }
            catch (System.Exception e_2D)
            {
            }
            return inputPara;
        }
        private System.Collections.Generic.Dictionary<string, string> SortNotifyPara(System.Collections.Generic.Dictionary<string, string> dicArrayPre)
        {
            return new System.Collections.Generic.Dictionary<string, string>
			{
				
				{
					"service",
					dicArrayPre["service"]
				},
				
				{
					"v",
					dicArrayPre["v"]
				},
				
				{
					"sec_id",
					dicArrayPre["sec_id"]
				},
				
				{
					"notify_data",
					dicArrayPre["notify_data"]
				}
			};
        }
        private bool GetSignVeryfy(System.Collections.Generic.Dictionary<string, string> inputPara, string sign, bool isSort)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = new System.Collections.Generic.Dictionary<string, string>();
            sPara = Core.FilterPara(inputPara);
            if (isSort)
            {
                sPara = Core.SortPara(sPara);
            }
            else
            {
                sPara = this.SortNotifyPara(sPara);
            }
            string preSignStr = Core.CreateLinkString(sPara);
            bool isSgin = false;
            if (sign != null && sign != "")
            {
                string sign_type = this._sign_type;
                if (sign_type != null)
                {
                    if (!(sign_type == "MD5"))
                    {
                        if (!(sign_type == "RSA"))
                        {
                            if (sign_type == "0001")
                            {
                                isSgin = RSAFromPkcs8.verify(preSignStr, sign, this._public_key, this._input_charset);
                            }
                        }
                        else
                        {
                            isSgin = RSAFromPkcs8.verify(preSignStr, sign, this._public_key, this._input_charset);
                        }
                    }
                    else
                    {
                        isSgin = AlipayMD5.Verify(preSignStr, sign, this._key, this._input_charset);
                    }
                }
            }
            return isSgin;
        }
        private string GetResponseTxt(string notify_id)
        {
            string veryfy_url = string.Concat(new string[]
			{
				this.Https_veryfy_url,
				"partner=",
				this._partner,
				"&notify_id=",
				notify_id
			});
            return this.Get_Http(veryfy_url, 120000);
        }
        private string Get_Http(string strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.Stream myStream = HttpWResp.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(myStream, System.Text.Encoding.Default);
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }
                strResult = strBuilder.ToString();
            }
            catch (System.Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }
            return strResult;
        }
    }
}
