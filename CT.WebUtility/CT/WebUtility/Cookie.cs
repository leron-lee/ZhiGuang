namespace CT.WebUtility
{
    using System;
    using System.Web;

    public static class Cookie
    {
        public static void Del(string Name)
        {
            Set(Name, string.Empty, -1);
        }

        public static string Get(string Name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[Name];
            if (cookie == null)
            {
                return string.Empty;
            }
            return HttpUtility.UrlDecode(cookie.Value);
        }

        public static void Set(string Name, object Value)
        {
            Set(Name, Value, 30);
        }

        public static void Set(string Name, object Value, int ExpiresDays)
        {
            Set(Name, Value.ToString(), ExpiresDays);
        }

        public static void Set(string Name, string Value, int ExpiresDays)
        {
            HttpCookie cookie = new HttpCookie(Name);
            cookie.Value = HttpUtility.UrlEncode(Value);
            if (ExpiresDays != 0)
            {
                cookie.Expires = DateTime.Now.AddDays((double) ExpiresDays);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}

