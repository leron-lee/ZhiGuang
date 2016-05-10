namespace CT.WebUtility
{
    using System;
    using System.Web;

    public static class Req
    {
        public static bool Boolean(string key)
        {
            return CT.WebUtility.Check.Boolean(HttpContext.Current.Request[key]);
        }

        public static byte Byte(string key)
        {
            return CT.WebUtility.Check.Byte(HttpContext.Current.Request[key]);
        }

        public static System.DateTime DateTime(string key)
        {
            return CT.WebUtility.Check.DateTime(HttpContext.Current.Request[key]);
        }

        public static decimal Decimal(string key)
        {
            return CT.WebUtility.Check.Decimal(HttpContext.Current.Request[key]);
        }

        public static double Double(string key)
        {
            return CT.WebUtility.Check.Double(HttpContext.Current.Request[key]);
        }

        public static string IdPath(string key)
        {
            return CT.WebUtility.Check.IdPath(HttpContext.Current.Request[key]);
        }

        public static int Int(string key)
        {
            return CT.WebUtility.Check.Int(HttpContext.Current.Request[key]);
        }

        public static long Int64(string key)
        {
            return CT.WebUtility.Check.Int64(HttpContext.Current.Request[key]);
        }

        public static short Short(string key)
        {
            return CT.WebUtility.Check.Short(HttpContext.Current.Request[key]);
        }

        public static string Str(string key)
        {
            return CT.WebUtility.Check.Str(HttpContext.Current.Request[key]);
        }

        public static string StrVal(string key)
        {
            return CT.WebUtility.Check.Str(key);
        }

        public static string StrDoNothing(string key)
        {
            return CT.WebUtility.Check.StrDoNothing(HttpContext.Current.Request[key]);
        }
    }
}

