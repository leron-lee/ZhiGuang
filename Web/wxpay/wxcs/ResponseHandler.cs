using System;
using System.Collections;
using System.Text;
using System.Web;
using System.Xml;
namespace Mi_gangUI.WXPay
{
    public class ResponseHandler
    {
        private string key;
        private static string SignField = "appid,appkey,timestamp,openid,noncestr,issubscribe";
        private string charset = "gb2312";
        protected HttpContext httpContext;
        private System.Collections.Hashtable xmlMap;
        public ResponseHandler(HttpContext httpContext)
        {
            this.xmlMap = new System.Collections.Hashtable();
            this.httpContext = httpContext;
            if (this.httpContext.Request.InputStream.Length > 0L)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(this.httpContext.Request.InputStream);
                XmlNode root = xmlDoc.SelectSingleNode("xml");
                XmlNodeList xnl = root.ChildNodes;
                foreach (XmlNode xnf in xnl)
                {
                    this.xmlMap.Add(xnf.Name, xnf.InnerText);
                }
            }
        }
        public virtual void init()
        {
        }
        public string getKey()
        {
            return this.key;
        }
        public void setKey(string key)
        {
            this.key = key;
        }
        public string getParameter(string parameter)
        {
            string s = (string)this.xmlMap[parameter];
            return (s == null) ? "" : s;
        }
        public void setParameter(string parameter, string parameterValue)
        {
        }
        public virtual bool isWXsign(out string error)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Collections.Hashtable signMap = new System.Collections.Hashtable();
            foreach (string i in this.xmlMap.Keys)
            {
                if (i != "sign")
                {
                    signMap.Add(i.ToLower(), this.xmlMap[i]);
                }
            }
            System.Collections.ArrayList akeys = new System.Collections.ArrayList(signMap.Keys);
            akeys.Sort();
            foreach (string i in akeys)
            {
                string v = (string)signMap[i];
                sb.Append(i + "=" + v + "&");
            }
            sb.Append("key=" + this.key);
            string sign = MD5Util.GetMD5(sb.ToString(), this.charset).ToString().ToUpper();
            error = "sign = " + sign + "\r\n xmlMap[sign]=" + this.xmlMap["sign"].ToString();
            return sign.Equals(this.xmlMap["sign"]);
        }
        public virtual bool isWXsignfeedback()
        {
            return true;
        }
        protected virtual string getCharset()
        {
            return this.httpContext.Request.ContentEncoding.BodyName;
        }
    }
}
