using System;
using System.Text.RegularExpressions;
using System.Web;
public class SQLInjectionHelper
{
    public static bool ValidUrlPostData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
        {
            result = SQLInjectionHelper.ValidData(HttpContext.Current.Request.Form[i].ToString().ToLower());
            if (result)
            {
                break;
            }
        }
        return result;
    }
    public static bool ValidUrlGetData()
    {
        bool result = false;
        for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
        {
            result = SQLInjectionHelper.ValidData(HttpContext.Current.Request.QueryString[i].ToString().ToLower());
            if (result)
            {
                break;
            }
        }
        return result;
    }
    public static bool ValidData(string inputData)
    {
        return Regex.IsMatch(inputData, SQLInjectionHelper.GetRegexString());
    }
    private static string GetRegexString()
    {
        string[] strBadChar = new string[]
		{
			"exec",
			"create",
			"insert",
			"select",
			"delete",
			"update",
			"drop",
			"script"
		};
        string str_Regex = ".*(";
        for (int i = 0; i < strBadChar.Length - 1; i++)
        {
            str_Regex = str_Regex + strBadChar[i] + "|";
        }
        return str_Regex + strBadChar[strBadChar.Length - 1] + ").*";
    }
}
