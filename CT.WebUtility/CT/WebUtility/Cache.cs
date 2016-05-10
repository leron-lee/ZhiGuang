namespace CT.WebUtility
{
    using System;
    using System.Web;
    using System.Web.Caching;

    public static class Cache
    {
        public static object Get(string Name)
        {
            return HttpContext.Current.Cache[Name];
        }

        public static object Set(string Name, object Value)
        {
            if (Value == null)
            {
                HttpContext.Current.Cache.Remove(Name);
                return Value;
            }
            HttpContext.Current.Cache.Insert(Name, Value);
            return Value;
        }

        public static object Set(string Name, object Value, int Seconds)
        {
            HttpContext.Current.Cache.Insert(Name, Value, null, DateTime.Now.AddSeconds((double) Seconds), System.Web.Caching.Cache.NoSlidingExpiration);
            return Value;
        }

        public static string SetByFile(string Name, string FilePath)
        {
            if (!Is.ServerMapPath(FilePath))
            {
                FilePath = HttpContext.Current.Server.MapPath(FilePath);
            }
            string str = File.Read(FilePath);
            HttpContext.Current.Cache.Insert(Name, str, new CacheDependency(FilePath));
            return str;
        }
    }
}

