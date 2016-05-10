namespace CT.WebUtility
{
    using System;
    using System.Web;

    public static class Application
    {
        public static object Get(string Name)
        {
            return HttpContext.Current.Application[Name];
        }

        public static object Set(string Name, object Value)
        {
            if (Value == null)
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application.Remove(Name);
                HttpContext.Current.Application.UnLock();
                return null;
            }
            HttpContext.Current.Application.Lock();
            HttpContext.Current.Application[Name] = Value;
            HttpContext.Current.Application.UnLock();
            return Value;
        }
    }
}

