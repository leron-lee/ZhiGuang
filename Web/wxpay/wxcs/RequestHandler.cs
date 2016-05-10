using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace Mi_gangUI.WXPay
{
    public class RequestHandler
    {
        protected HttpContext httpContext;
        protected System.Collections.Hashtable parameters;
        public RequestHandler(HttpContext httpContext)
        {
            this.parameters = new System.Collections.Hashtable();
            this.httpContext = httpContext;
        }
        public virtual void init()
        {
        }
        public void setParameter(string parameter, string parameterValue)
        {
            if (parameter != null && parameter != "")
            {
                if (this.parameters.Contains(parameter))
                {
                    this.parameters.Remove(parameter);
                }
                this.parameters.Add(parameter, parameterValue);
            }
        }
        public virtual string CreateMd5Sign(string key, string value)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Collections.ArrayList akeys = new System.Collections.ArrayList(this.parameters.Keys);
            akeys.Sort();
            foreach (string i in akeys)
            {
                string v = (string)this.parameters[i];
                if (v != null && "".CompareTo(v) != 0 && "sign".CompareTo(i) != 0 && "key".CompareTo(i) != 0)
                {
                    sb.Append(i + "=" + v + "&");
                }
            }
            sb.Append(key + "=" + value);
            return MD5Util.GetMD5(sb.ToString(), this.getCharset()).ToUpper();
        }
        public string parseXML()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<xml>");
            System.Collections.ArrayList akeys = new System.Collections.ArrayList(this.parameters.Keys);
            foreach (string i in akeys)
            {
                string v = (string)this.parameters[i];
                if (Regex.IsMatch(v, "^[0-9.]$"))
                {
                    sb.Append(string.Concat(new string[]
					{
						"<",
						i,
						">",
						v,
						"</",
						i,
						">"
					}));
                }
                else
                {
                    sb.Append(string.Concat(new string[]
					{
						"<",
						i,
						"><![CDATA[",
						v,
						"]]></",
						i,
						">"
					}));
                }
            }
            sb.Append("</xml>");
            return sb.ToString();
        }
        protected virtual string getCharset()
        {
            return this.httpContext.Request.ContentEncoding.BodyName;
        }
    }
}
