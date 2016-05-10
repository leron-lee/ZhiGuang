namespace CT.WebUtility
{
    using System;
    using System.Web;

    public static class Session
    {
        public static object Get(string Name)
        {
            return HttpContext.Current.Session[Name];
        }

        public static object Set(string Name, object Value)
        {
            if (Value == null)
            {
                HttpContext.Current.Session.Remove(Name);
                return null;
            }
            HttpContext.Current.Session[Name] = Value;
            return Value;
        }
    }
}

