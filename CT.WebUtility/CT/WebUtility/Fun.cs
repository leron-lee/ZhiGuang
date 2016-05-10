namespace CT.WebUtility
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;

    public static class Fun
    {
        private static readonly string[] RandomString1 = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private static readonly string[] RandomString2 = new string[] { 
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", 
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
         };
        private static readonly string[] RandomString3 = new string[] { 
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
         };
        private static readonly string[] RandomString4 = new string[] { 
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", 
            "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", 
            "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", 
            "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
         };

        public static int BoolToInt(bool Value)
        {
            if (Value)
            {
                return 1;
            }
            return 0;
        }

        public static string CutStr(string text, int length)
        {
            return CutStr(text, length, string.Empty);
        }

        public static string CutStr(string text, int length, string InsertText)
        {
            if ((text == null) || (text.Length == 0))
            {
                return string.Empty;
            }
            int num = 0;
            if (StringLengths(text) <= length)
            {
                return text;
            }
            length -= StringLengths(InsertText);
            StringBuilder builder = new StringBuilder();
            foreach (char ch in text)
            {
                if (ch > '\x007f')
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
                if (num > length)
                {
                    break;
                }
                builder.Append(ch);
            }
            builder.Append(InsertText);
            return builder.ToString();
        }

        public static string DelBadWords(string Value, string BadWordGroup)
        {
            if (BadWordGroup.Length != 0)
            {
                Value = Regex.Replace(Value, "" + BadWordGroup + "", "**");
            }
            return Value;
        }

        public static string FilterHTML(string Value)
        {
            return (((Value == null) || (Value.Length == 0)) ? string.Empty : Statics.RegexPatterns.FilterHtml.Replace(Value, string.Empty));
        }

        public static string GetFileExt(string FileName)
        {
            return Statics.RegexPatterns.FileExt.Replace(FileName, "$1");
        }

        public static string GetIp()
        {
            string str = string.Empty;
            string str2 = CT.WebUtility.Check.StrDoNothing(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            string str3 = CT.WebUtility.Check.StrDoNothing(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (str3.Length == 0)
            {
                str = str2;
            }
            else if (str3.IndexOf("unknown") > -1)
            {
                str = "unknown";
            }
            else if (str3.IndexOf(",") > -1)
            {
                str = str3.Substring(0, str3.IndexOf(",") + 1);
            }
            else if (str3.IndexOf(";") > -1)
            {
                str = str3.Substring(0, str3.IndexOf(";") + 1);
            }
            else
            {
                str = str3;
            }
            return CutStr(CT.WebUtility.Check.Str(str), 30);
        }

        public static string GetOrderId()
        {
            return (DateTime.Now.ToString("yyyyMMddHHmmss") + GetRandom(2));
        }

        public static string GetRandom(int len)
        {
            return GetRandom(len, 1);
        }

        public static string GetRandom(int len, int style)
        {
            string[] strArray;
            switch (style)
            {
                case 1:
                    strArray = RandomString1;
                    break;

                case 2:
                    strArray = RandomString2;
                    break;

                case 3:
                    strArray = RandomString3;
                    break;

                default:
                    strArray = RandomString4;
                    break;
            }
            string str = string.Empty;
            Thread.Sleep(50);
            Random random = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < len; i++)
            {
                str = str + strArray[random.Next(strArray.Length)];
            }
            return str;
        }

        public static string GetRe(string Content, string Patterns, string Returns)
        {
            if ((Content != null) && (Content.Length != 0))
            {
                Regex regex = new Regex(Patterns, RegexOptions.Multiline | RegexOptions.IgnoreCase);
                if (regex.IsMatch(Content))
                {
                    Match match = regex.Matches(Content)[0];
                    return regex.Replace(match.ToString(), Returns);
                }
            }
            return string.Empty;
        }

        private static MatchCollection GetRes(string Content, string Patterns, string Returns)
        {
            if ((Content == null) || (Content.Length == 0))
            {
                return null;
            }
            Regex regex = new Regex(Patterns, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return regex.Matches(Content);
        }

        public static string GetRouteWithServerMapPath(string Path)
        {
            if (!Is.ServerMapPath(Path))
            {
                Path = HttpContext.Current.Server.MapPath(Path);
            }
            return Path;
        }

        public static string GetUploadsAutoFileName(string FileExt)
        {
            if (!Statics.RegexPatterns.Re28.IsMatch(FileExt))
            {
                FileExt = "." + FileExt;
            }
            return (DateTime.Now.ToString("HHmmss") + GetRandom(4) + FileExt);
        }

        public static string GetUploadsAutoFolder()
        {
            return ("/Uploads/Files/" + DateTime.Now.ToString(@"yyyyMM\/dd\/"));
        }

        public static string GetUploadsAutoFolderAndFileName(string FileExt)
        {
            return (GetUploadsAutoFolder() + GetUploadsAutoFileName(FileExt));
        }

        public static int GetWeekOfTheYear()
        {
            return GetWeekOfTheYear(DateTime.Now);
        }

        public static int GetWeekOfTheYear(DateTime dt)
        {
            CultureInfo info = new CultureInfo("zh-CN");
            Calendar calendar = info.Calendar;
            CalendarWeekRule calendarWeekRule = info.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = info.DateTimeFormat.FirstDayOfWeek;
            return calendar.GetWeekOfYear(dt, calendarWeekRule, firstDayOfWeek);
        }

        public static string Post(string uri)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "Post";
                req.Timeout = 30000;
                req.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.1.4) Gecko/20091016 Firefox/3.5.4 (.NET CLR 3.5.30729)";
                String ReturnedEncoding = "";
                req.AllowAutoRedirect = true;

                req.CookieContainer = new CookieContainer();

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                Stream ReceiveStream = res.GetResponseStream();
                StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);
                string ReturnedContent = sr.ReadToEnd();
                if (ReturnedEncoding == "")
                {
                    //string h = "<meta http-equiv='Content-Type' content='text/html; charset=big5'>";
                    Regex reg_charset = new Regex(@"charset\b\s*=\s*(?<charset>[^""|^'']*)");
                    if (reg_charset.IsMatch(ReturnedContent))
                    {
                        ReturnedEncoding = reg_charset.Match(ReturnedContent).Groups["charset"].Value;
                    }
                }

                if (ReturnedEncoding == "")
                {
                    String ct = res.ContentType.ToLower().Replace(" ", "");
                    if (ct.IndexOf("charset") > -1)
                    {
                        ReturnedEncoding = ct.Substring(ct.IndexOf("charset=") + 8);
                    }
                }

                if (ReturnedEncoding == "")
                {
                    ReturnedEncoding = res.ContentEncoding;
                }


                if (ReturnedEncoding == "")
                {
                    ReturnedEncoding = res.CharacterSet;
                }

                Encoding HtmlEncoding = Encoding.Default;
                if (ReturnedEncoding != "")
                {
                    HtmlEncoding = Encoding.GetEncoding(ReturnedEncoding);
                }

                req = (HttpWebRequest)WebRequest.Create(uri);
                req.Method = "Post";
                req.Timeout = 10000;
                req.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.1.4) Gecko/20091016 Firefox/3.5.4 (.NET CLR 3.5.30729)";
                res = req.GetResponse() as HttpWebResponse;
                ReceiveStream = res.GetResponseStream();
                sr = new StreamReader(ReceiveStream, HtmlEncoding);
                ReturnedContent = sr.ReadToEnd();
                return ReturnedContent;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Post(string Url, string Content)
        {
            Exception exception;
            byte[] bytes = Encoding.UTF8.GetBytes(Content);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.50215;)";
            request.Timeout = 30000;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            request.AllowAutoRedirect = true;
            request.CookieContainer = new CookieContainer();
            request.MaximumAutomaticRedirections = 50;
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            catch (Exception exception1)
            {
                exception = exception1;
                return exception.Message;
            }
            try
            {

                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string str = new StreamReader(responseStream, Encoding.UTF8, true).ReadToEnd();
                    responseStream.Close();
                    return str;
                }
                return response.StatusCode.ToString();
            }
            catch (Exception exception2)
            {
                exception = exception2;
                return exception.Message;
            }
        }

        public static string PostXml(string Url, string XmlString)
        {
            Exception exception;
            byte[] bytes = Encoding.UTF8.GetBytes(XmlString);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(Url);
            request.Method = "POST";
            request.Headers.Add("ContentType", "text/xml;charset=utf-8");
            int length = bytes.Length;
            request.Headers.Add("ContentLength", length.ToString());
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            catch (Exception exception1)
            {
                exception = exception1;
                return exception.Message;
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string str = new StreamReader(responseStream, Encoding.UTF8, true).ReadToEnd();
                    responseStream.Close();
                    return str;
                }
                return response.StatusCode.ToString();
            }
            catch (Exception exception2)
            {
                exception = exception2;
                return exception.Message;
            }
        }

        public static int StringLengths(string text)
        {
            int num = 0;
            foreach (char ch in text)
            {
                if (ch > '\x007f')
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
            }
            return num;
        }

        public static string Succ(int Num, int Len)
        {
            string str = "000000000000" + Num;
            return str.Substring(str.Length - Len, Len);
        }
    }
}

