using System;
using System.Web;
using System.Web.Caching;
public class getcart
{
    private static HttpContext context = HttpContext.Current;
    public static void cache_in(string name, object neirong)
    {
        getcart.context.Cache.Insert(name, neirong, null, System.DateTime.Now.AddDays(1.0), Cache.NoSlidingExpiration);
    }
    public static string str(object id, object name)
    {
        return new access().ExecuteScalar(string.Concat(new object[]
		{
			"select ",
			name,
			" from merchandise where id = ",
			id
		}));
    }
}
