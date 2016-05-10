using System;
using System.Text.RegularExpressions;
using System.Web;
public class safe_360
{
    private const string StrRegex = "<[^>]+?style=[\\w]+?:expression\\(|\\b(alert|confirm|prompt)\\b|^\\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\\b(and|or)\\b.{1,6}?(=|>|<|\\bin\\b|\\blike\\b)|/\\*.+?\\*/|<\\s*script\\b|\\bEXEC\\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\\s+(TABLE|DATABASE)";
    public static bool PostData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
        {
            result = safe_360.CheckData(HttpContext.Current.Request.Form[i].ToString());
            if (result)
            {
                break;
            }
        }
        return result;
    }
    public static bool GetData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
        {
            result = safe_360.CheckData(HttpContext.Current.Request.QueryString[i].ToString());
            if (result)
            {
                break;
            }
        }
        return result;
    }
    public static bool CookieData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
        {
            result = safe_360.CheckData(HttpContext.Current.Request.Cookies[i].Value.ToLower());
            if (result)
            {
                break;
            }
        }
        return result;
    }
    public static bool referer()
    {
        return safe_360.CheckData(HttpContext.Current.Request.UrlReferrer.ToString());
    }
    public static bool CheckData(string inputData)
    {
        return Regex.IsMatch(inputData, "<[^>]+?style=[\\w]+?:expression\\(|\\b(alert|confirm|prompt)\\b|^\\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\\b(and|or)\\b.{1,6}?(=|>|<|\\bin\\b|\\blike\\b)|/\\*.+?\\*/|<\\s*script\\b|\\bEXEC\\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\\s+(TABLE|DATABASE)");
    }
}
