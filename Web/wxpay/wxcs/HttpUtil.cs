using System;
using System.IO;
using System.Net;
using System.Text;
namespace Mi_gangUI.WXPay
{
    public class HttpUtil
    {
        private const string sContentType = "application/x-www-form-urlencoded";
        private const string sUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public static string Send(string data, string url)
        {
            return HttpUtil.Send(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data), url);
        }
        public static string Send(byte[] data, string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null)
            {
                throw new System.ApplicationException(string.Format("Invalid url string: {0}", url));
            }
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = (long)data.Length;
            System.IO.Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            System.IO.Stream responseStream;
            try
            {
                responseStream = request.GetResponse().GetResponseStream();
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
            string str = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                str = reader.ReadToEnd();
            }
            responseStream.Close();
            return str;
        }
    }
}
