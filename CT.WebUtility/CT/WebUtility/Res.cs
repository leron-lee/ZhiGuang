namespace CT.WebUtility
{
    using System;
    using System.Web;

    public static class Res
    {
        public static void Clear()
        {
            HttpContext.Current.Response.Clear();
        }

        public static void End()
        {
            HttpContext.Current.Response.End();
        }

        public static void Flush()
        {
            HttpContext.Current.Response.Flush();
        }

        public static void Write(object val)
        {
            if (val == null)
            {
                HttpContext.Current.Response.Write("[null]");
            }
            else
            {
                HttpContext.Current.Response.Write(val.ToString());
            }
        }

        public static void WriteAndEnd(object val)
        {
            Write(val);
            HttpContext.Current.Response.End();
        }
    }
}

