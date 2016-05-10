using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
namespace Com.Alipay
{
    public class Submit
    {
        private static string _key;
        private static string _private_key;
        private static string _input_charset;
        private static string _sign_type;
        static Submit()
        {
            Submit._key = "";
            Submit._private_key = "";
            Submit._input_charset = "";
            Submit._sign_type = "";
            Submit._key = Config.Key;
            Submit._private_key = Config.Private_key;
            Submit._input_charset = Config.Input_charset.Trim().ToLower();
            Submit._sign_type = Config.Sign_type.Trim().ToUpper();
        }
        private static string BuildRequestMysign(System.Collections.Generic.Dictionary<string, string> sPara)
        {
            string prestr = Core.CreateLinkString(sPara);
            string sign_type = Submit._sign_type;
            string mysign;
            if (sign_type != null)
            {
                if (sign_type == "MD5")
                {
                    mysign = AlipayMD5.Sign(prestr, Submit._key, Submit._input_charset);
                    return mysign;
                }
                if (sign_type == "RSA")
                {
                    mysign = RSAFromPkcs8.sign(prestr, Submit._private_key, Submit._input_charset);
                    return mysign;
                }
                if (sign_type == "0001")
                {
                    mysign = RSAFromPkcs8.sign(prestr, Submit._private_key, Submit._input_charset);
                    return mysign;
                }
            }
            mysign = "";
            return mysign;
        }
        private static System.Collections.Generic.Dictionary<string, string> BuildRequestPara(System.Collections.Generic.Dictionary<string, string> sParaTemp)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = new System.Collections.Generic.Dictionary<string, string>();
            sPara = Core.FilterPara(sParaTemp);
            sPara = Core.SortPara(sPara);
            string mysign = Submit.BuildRequestMysign(sPara);
            sPara.Add("sign", mysign);
            if (sPara["service"] != "alipay.wap.trade.create.direct" && sPara["service"] != "alipay.wap.auth.authAndExecute")
            {
                sPara.Add("sign_type", Submit._sign_type);
            }
            return sPara;
        }
        private static string BuildRequestParaToString(System.Collections.Generic.Dictionary<string, string> sParaTemp, System.Text.Encoding code)
        {
            System.Collections.Generic.Dictionary<string, string> sPara = new System.Collections.Generic.Dictionary<string, string>();
            sPara = Submit.BuildRequestPara(sParaTemp);
            return Core.CreateLinkStringUrlencode(sPara, code);
        }
        public static string BuildRequest(string GATEWAY_NEW, System.Collections.Generic.Dictionary<string, string> sParaTemp, string strMethod, string strButtonValue)
        {
            System.Collections.Generic.Dictionary<string, string> dicPara = new System.Collections.Generic.Dictionary<string, string>();
            dicPara = Submit.BuildRequestPara(sParaTemp);
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            sbHtml.Append(string.Concat(new string[]
			{
				"<form id='alipaysubmit' name='alipaysubmit' action='",
				GATEWAY_NEW,
				"_input_charset=",
				Submit._input_charset,
				"' method='",
				strMethod.ToLower().Trim(),
				"'>"
			}));
            foreach (System.Collections.Generic.KeyValuePair<string, string> temp in dicPara)
            {
                sbHtml.Append(string.Concat(new string[]
				{
					"<input type='hidden' name='",
					temp.Key,
					"' value='",
					temp.Value,
					"'/>"
				}));
            }
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");
            return sbHtml.ToString();
        }
        public static string BuildRequest(string GATEWAY_NEW, System.Collections.Generic.Dictionary<string, string> sParaTemp)
        {
            System.Text.Encoding code = System.Text.Encoding.GetEncoding(Submit._input_charset);
            string strRequestData = Submit.BuildRequestParaToString(sParaTemp, code);
            byte[] bytesRequestData = code.GetBytes(strRequestData);
            string strUrl = GATEWAY_NEW + "_input_charset=" + Submit._input_charset;
            string strResult = "";
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(strUrl);
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = (long)bytesRequestData.Length;
                System.IO.Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.Stream myStream = HttpWResp.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(myStream, code);
                System.Text.StringBuilder responseData = new System.Text.StringBuilder();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    responseData.Append(line);
                }
                myStream.Close();
                strResult = responseData.ToString();
            }
            catch (System.Exception exp)
            {
                strResult = "报错：" + exp.Message;
            }
            return strResult;
        }
        public static string BuildRequest(string GATEWAY_NEW, System.Collections.Generic.Dictionary<string, string> sParaTemp, string strMethod, string fileName, byte[] data, string contentType, int lengthFile)
        {
            System.Collections.Generic.Dictionary<string, string> dicPara = new System.Collections.Generic.Dictionary<string, string>();
            dicPara = Submit.BuildRequestPara(sParaTemp);
            string strUrl = GATEWAY_NEW + "_input_charset=" + Submit._input_charset;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = strMethod;
            string boundaryValue = System.DateTime.Now.Ticks.ToString("x");
            string boundary = "--" + boundaryValue;
            request.ContentType = "\r\nmultipart/form-data; boundary=" + boundaryValue;
            request.KeepAlive = true;
            System.Text.StringBuilder sbHtml = new System.Text.StringBuilder();
            foreach (System.Collections.Generic.KeyValuePair<string, string> key in dicPara)
            {
                sbHtml.Append(string.Concat(new string[]
				{
					boundary,
					"\r\nContent-Disposition: form-data; name=\"",
					key.Key,
					"\"\r\n\r\n",
					key.Value,
					"\r\n"
				}));
            }
            sbHtml.Append(boundary + "\r\nContent-Disposition: form-data; name=\"withhold_file\"; filename=\"");
            sbHtml.Append(fileName);
            sbHtml.Append("\"\r\nContent-Type: " + contentType + "\r\n\r\n");
            string postHeader = sbHtml.ToString();
            System.Text.Encoding code = System.Text.Encoding.GetEncoding(Submit._input_charset);
            byte[] postHeaderBytes = code.GetBytes(postHeader);
            byte[] boundayBytes = System.Text.Encoding.ASCII.GetBytes("\r\n" + boundary + "--\r\n");
            long length = (long)(postHeaderBytes.Length + lengthFile + boundayBytes.Length);
            request.ContentLength = length;
            System.IO.Stream requestStream = request.GetRequestStream();
            System.IO.Stream myStream;
            string result;
            try
            {
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                requestStream.Write(data, 0, lengthFile);
                requestStream.Write(boundayBytes, 0, boundayBytes.Length);
                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
                myStream = HttpWResp.GetResponseStream();
            }
            catch (WebException e)
            {
                result = e.ToString();
                return result;
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(myStream, code);
            System.Text.StringBuilder responseData = new System.Text.StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                responseData.Append(line);
            }
            myStream.Close();
            result = responseData.ToString();
            return result;
        }
        public static System.Collections.Generic.Dictionary<string, string> ParseResponse(string strText)
        {
            string[] strSplitText = strText.Split(new char[]
			{
				'&'
			});
            System.Collections.Generic.Dictionary<string, string> dicText = new System.Collections.Generic.Dictionary<string, string>();
            for (int i = 0; i < strSplitText.Length; i++)
            {
                int nPos = strSplitText[i].IndexOf('=');
                int nLen = strSplitText[i].Length;
                string strKey = strSplitText[i].Substring(0, nPos);
                string strValue = strSplitText[i].Substring(nPos + 1, nLen - nPos - 1);
                dicText.Add(strKey, strValue);
            }
            if (dicText["res_data"] != null)
            {
                if (Submit._sign_type == "0001")
                {
                    dicText["res_data"] = RSAFromPkcs8.decryptData(dicText["res_data"], Submit._private_key, Submit._input_charset);
                }
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.LoadXml(dicText["res_data"]);
                    string strRequest_token = xmlDoc.SelectSingleNode("/direct_trade_create_res/request_token").InnerText;
                    dicText.Add("request_token", strRequest_token);
                }
                catch (System.Exception exp)
                {
                    dicText.Add("request_token", exp.ToString());
                }
            }
            return dicText;
        }
        public static string Query_timestamp()
        {
            string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
            string url = string.Concat(new string[]
			{
				GATEWAY_NEW,
				"service=query_timestamp&partner=",
				Config.Partner,
				"&_input_charset=",
				Config.Input_charset
			});
            XmlTextReader Reader = new XmlTextReader(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Reader);
            return xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;
        }
    }
}
