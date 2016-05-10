using System;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
public class liu
{
    private static HttpContext context = HttpContext.Current;
    public static object SqlNull(string obj)
    {
        object result;
        if (obj == "")
        {
            result = System.DBNull.Value;
        }
        else
        {
            result = obj;
        }
        return result;
    }
    public static string zifu(object o, int i)
    {
        string result;
        if (o.ToString().Length > i)
        {
            result = o.ToString().Substring(0, i) + "..";
        }
        else
        {
            result = o.ToString();
        }
        return result;
    }
    public static bool IsNumber(string input)
    {
        return Regex.IsMatch(input, "^\\d+$");
    }
    public static string time_n_y_r(System.DateTime t)
    {
        return t.ToString("m");
    }
    public static string time_s_f(System.DateTime t)
    {
        return t.ToString("D");
    }
    public static string htmlGL(object n)
    {
        Regex htmlRegex = new Regex("<[^>]*>");
        return htmlRegex.Replace(n.ToString(), "").Replace("&nbsp;", "").Replace(" ", "");
    }
    public static string limitStr(string oldString, int str_Len)
    {
        string newString = "";
        if (oldString != null)
        {
            if (oldString.Length <= str_Len)
            {
                newString = oldString.PadRight(str_Len, ' ');
            }
            else
            {
                System.Text.StringBuilder buffer = new System.Text.StringBuilder();
                double len = 0.0;
                double strLen = System.Convert.ToDouble(str_Len);
                for (int i = 0; i < oldString.Length; i++)
                {
                    string str_Char = oldString.Substring(i, 1);
                    if (liu.ascii(str_Char) > 255)
                    {
                        buffer.Append(str_Char);
                        len += 1.0;
                    }
                    else
                    {
                        buffer.Append(str_Char);
                        len += 0.5;
                    }
                    if (len >= strLen)
                    {
                        buffer.Append("...");
                        break;
                    }
                }
                newString = buffer.ToString();
            }
        }
        return newString;
    }
    private static int ascii(string c)
    {
        int reValue = 0;
        byte[] x = new byte[2];
        x = System.Text.Encoding.Default.GetBytes(c);
        if (x == null || x.Length > 2 || x.Length <= 0)
        {
            reValue = 0;
        }
        if (x.Length == 1)
        {
            reValue = (int)x[0];
        }
        if (x.Length == 2)
        {
            int hightByte = 256 + (int)x[0];
            int lowByte = 256 + (int)x[1];
            int ascii = 256 * hightByte + lowByte - 65536;
            reValue = ascii;
        }
        return reValue;
    }
    public static string fystr(int x, string sqls, string username, int p, string pax, string sql_id)
    {
        System.Text.StringBuilder templateBuilder = new System.Text.StringBuilder();
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new access().ExecuteScalar(fystring));
        int allNum;
        if (num % x == 0)
        {
            allNum = num / x;
        }
        else
        {
            allNum = num / x + 1;
        }
        templateBuilder.Append("<table style='float:left;margin-top:5px;margin-left:10px' id='fstable'>");
        templateBuilder.Append("<tr>");
        if (allNum < 9)
        {
            for (int ai = 0; ai < allNum; ai++)
            {
                if (p == ai + 1)
                {
                    templateBuilder.Append("<td>[" + (ai + 1) + "]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						ai + 1,
						">",
						ai + 1,
						"</a>]</td>"
					}));
                }
            }
        }
        else
        {
            if (p - 6 < 1)
            {
                if (p == 1)
                {
                    templateBuilder.Append("<td>[1]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=1>1</a>]</td>"
					}));
                }
                if (p == 2)
                {
                    templateBuilder.Append("<td>[2]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=2>2</a>]</td>"
					}));
                }
                if (p == 3)
                {
                    templateBuilder.Append("<td>[3]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=3>3</a>]</td>"
					}));
                }
                if (p == 4)
                {
                    templateBuilder.Append("<td>[4]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=4>4</a>]</td>"
					}));
                }
                if (p == 5)
                {
                    templateBuilder.Append("<td>[5]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=5>5</a>]</td>"
					}));
                }
                if (p == 6)
                {
                    templateBuilder.Append("<td>[6]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=6>6</a>]</td>"
					}));
                }
                if (p == 7)
                {
                    templateBuilder.Append("<td>[7]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=7>7</a>]</td>"
					}));
                }
                if (p == 8)
                {
                    templateBuilder.Append("<td>[8]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=8>8</a>]</td>"
					}));
                }
                if (p == 9)
                {
                    templateBuilder.Append("<td>[9]</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=9>9</a>]</td>"
					}));
                }
                if (allNum != 9)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>...[<a href=?",
						username,
						"&",
						pax,
						"=",
						allNum.ToString(),
						">",
						allNum.ToString(),
						"</a>]</td>"
					}));
                }
            }
            else
            {
                if (p + 6 > allNum)
                {
                    if (allNum - 8 != 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=1>1</a>]...</td>"
						}));
                    }
                    if (allNum - 8 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 8) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 8,
							">",
							allNum - 8,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 7 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 7) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 7,
							">",
							allNum - 7,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 6 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 6) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 6,
							">",
							allNum - 6,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 5 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 5) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 5,
							">",
							allNum - 5,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 4 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 4) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 4,
							">",
							allNum - 4,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 3 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 3) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 3,
							">",
							allNum - 3,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 2 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 2) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 2,
							">",
							allNum - 2,
							"</a>]</td>"
						}));
                    }
                    if (allNum - 1 == p)
                    {
                        templateBuilder.Append("<td>[<span>" + (allNum - 1) + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 1,
							">",
							allNum - 1,
							"</a>]</td>"
						}));
                    }
                    if (allNum == p)
                    {
                        templateBuilder.Append("<td>[<span>" + allNum + "</span>]</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum,
							">",
							allNum,
							"</a>]</td>"
						}));
                    }
                }
                else
                {
                    if (p - 4 != 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td>[<a href=?",
							username,
							"&",
							pax,
							"=1>1</a>]...</td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p - 4,
						">",
						p - 4,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p - 3,
						">",
						p - 3,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p - 2,
						">",
						p - 2,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p - 1,
						">",
						p - 1,
						"</a>]</td>"
					}));
                    templateBuilder.Append("<td>[" + p + "]</td>");
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p + 1,
						">",
						p + 1,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p + 2,
						">",
						p + 2,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p + 3,
						">",
						p + 3,
						"</a>]</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>[<a href=?",
						username,
						"&",
						pax,
						"=",
						p + 4,
						">",
						p + 4,
						"</a>]</td>"
					}));
                    if (allNum != p + 4)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td>...[<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							">",
							allNum.ToString(),
							"</a>]</td>"
						}));
                    }
                }
            }
        }
        templateBuilder.Append("</tr>");
        templateBuilder.Append("</table>");
        return templateBuilder.ToString();
    }
    public static string fystr_new(int x, string sqls, string username, int p, string pax, string sql_id)
    {
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new access().ExecuteScalar(fystring));
        return liu.fsstr_new_nei(num, x, p, username, pax);
    }
    public static string fystr_new(int x, string sqls, string username, int p, string pax, string sql_id, SqlParameter[] parameters)
    {
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new access().ExecuteScalar(fystring, parameters));
        return liu.fsstr_new_nei(num, x, p, username, pax);
    }
    private static string fsstr_new_nei(int num, int x, int p, string username, string pax)
    {
        System.Text.StringBuilder templateBuilder = new System.Text.StringBuilder();
        int allNum;
        if (num % x == 0)
        {
            allNum = num / x;
        }
        else
        {
            allNum = num / x + 1;
        }
        int pageCount = p;
        templateBuilder.Append(string.Concat(new string[]
		{
			"<div style='float:left;margin-left:10px' id='fsdiv'>每页",
			x.ToString(),
			"条/总共",
			num.ToString(),
			"条 页码：",
			p.ToString(),
			"/",
			allNum.ToString(),
			"</div>"
		}));
        templateBuilder.Append("<table style='float:left;margin-left:10px' id='fstable'  cellpadding='0' cellspacing='0'>");
        templateBuilder.Append("<tr>");
        if (allNum < 9)
        {
            if (allNum > 1)
            {
                if (pageCount > 1)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=1>首页</a>&nbsp;&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 1,
						">上页</a>&nbsp;&nbsp;&nbsp;</td>"
					}));
                }
                for (int ai = 0; ai < allNum; ai++)
                {
                    if (pageCount == ai + 1)
                    {
                        templateBuilder.Append("<td><b>[" + (ai + 1) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							ai + 1,
							">[",
							ai + 1,
							"]</a>&nbsp;</td>"
						}));
                    }
                }
                if (allNum != pageCount)
                {
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>&nbsp;&nbsp;<a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 1,
						">下页</a></td>"
					}));
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>&nbsp;&nbsp;<a href=?",
						username,
						"&",
						pax,
						"=",
						allNum.ToString(),
						">末页</a></td>"
					}));
                }
            }
        }
        else
        {
            if (pageCount - 6 < 1)
            {
                if (pageCount > 1)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=1>首页</a>&nbsp;&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 1,
						">上页</a>&nbsp;&nbsp;&nbsp;</td>"
					}));
                }
                if (pageCount == 1)
                {
                    templateBuilder.Append("<td><b>[1]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=1>[1]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 2)
                {
                    templateBuilder.Append("<td><b>[2]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=2>[2]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 3)
                {
                    templateBuilder.Append("<td><b>[3]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=3>[3]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 4)
                {
                    templateBuilder.Append("<td><b>[4]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=4>[4]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 5)
                {
                    templateBuilder.Append("<td>[5]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=5>[5]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 6)
                {
                    templateBuilder.Append("<td><b>[6]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=6>[6]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 7)
                {
                    templateBuilder.Append("<td><b>[7]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=7>[7]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 8)
                {
                    templateBuilder.Append("<td><b>[8]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=8>[8]</a>&nbsp;</td>"
					}));
                }
                if (pageCount == 9)
                {
                    templateBuilder.Append("<td><b>[9]</b>&nbsp;</td>");
                }
                else
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=9>[9]</a>&nbsp;</td>"
					}));
                }
                templateBuilder.Append(string.Concat(new object[]
				{
					"<td>&nbsp;&nbsp;<a href=?",
					username,
					"&",
					pax,
					"=",
					pageCount + 1,
					">下页</a></td>"
				}));
                if (allNum != 9)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td>&nbsp;&nbsp;<a href=?",
						username,
						"&",
						pax,
						"=",
						allNum.ToString(),
						">末页</a></td>"
					}));
                }
            }
            else
            {
                if (pageCount + 6 > allNum)
                {
                    if (allNum - 8 != 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=1>首页</a>&nbsp;&nbsp;</td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 1,
						">上页</a>&nbsp;&nbsp;&nbsp;</td>"
					}));
                    if (allNum - 8 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 8) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 8,
							">[",
							allNum - 8,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 7 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 7) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 7,
							">[",
							allNum - 7,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 6 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 6) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 6,
							">[",
							allNum - 6,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 5 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 5) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 5,
							">[",
							allNum - 5,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 4 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 4) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 4,
							">[",
							allNum - 4,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 3 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 3) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 3,
							">[",
							allNum - 3,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 2 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 2) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 2,
							">[",
							allNum - 2,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum - 1 == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + (allNum - 1) + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum - 1,
							">[",
							allNum - 1,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (allNum == pageCount)
                    {
                        templateBuilder.Append("<td><b>[" + allNum + "]</b>&nbsp;</td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=",
							allNum,
							">[",
							allNum,
							"]</a>&nbsp;</td>"
						}));
                    }
                    if (pageCount != allNum)
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td>&nbsp;&nbsp;<a href=?",
							username,
							"&",
							pax,
							"=",
							pageCount + 1,
							">下页</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td>&nbsp;&nbsp;<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							">末页</a></td>"
						}));
                    }
                }
                else
                {
                    if (pageCount - 4 != 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href=?",
							username,
							"&",
							pax,
							"=1>首页</a>&nbsp;&nbsp;</td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 1,
						">上页</a>&nbsp;&nbsp;&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 4,
						">[",
						pageCount - 4,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 3,
						">[",
						pageCount - 3,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 2,
						">[",
						pageCount - 2,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount - 1,
						">[",
						pageCount - 1,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append("<td><b>[" + pageCount + "]</b>&nbsp;</td>");
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 1,
						">[",
						pageCount + 1,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 2,
						">[",
						pageCount + 2,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 3,
						">[",
						pageCount + 3,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 4,
						">[",
						pageCount + 4,
						"]</a>&nbsp;</td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td>&nbsp;&nbsp;<a href=?",
						username,
						"&",
						pax,
						"=",
						pageCount + 1,
						">下页</a></td>"
					}));
                    if (allNum != pageCount + 4)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td>&nbsp;&nbsp;<a href=?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							">末页</a></td>"
						}));
                    }
                }
            }
        }
        templateBuilder.Append("</tr>");
        templateBuilder.Append("</table>");
        return templateBuilder.ToString();
    }
    public static bool StringCheck(string str)
    {
        bool result;
        if (str.Trim() == " " || str == null)
        {
            result = true;
        }
        else
        {
            Regex re = new Regex("\\s ");
            str = re.Replace(str.Replace("%20 ", "   "), "   ");
            string pattern = "select   |insert   |delete   from   |count\\(|drop   table|update   |truncate   |asc\\(|mid\\(|char\\(|xp_cmdshell|exec   master|net   localgroup   administrators|:|net   user| \"|\\ '|   or   ";
            result = !Regex.IsMatch(str, pattern);
        }
        return result;
    }
    public static string echtml(string ec_text)
    {
        return liu.context.Server.UrlEncode(ec_text);
    }
    public static string validationURL()
    {
        char[] CharArray = new char[]
		{
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9'
		};
        string sCode = "";
        System.Random random = new System.Random();
        for (int i = 0; i < 20; i++)
        {
            sCode += CharArray[random.Next(CharArray.Length)];
        }
        return sCode;
    }
    public static string MD5(string toCryString)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(toCryString, "MD5");
    }
    public static object getCache(string ca_name, string ca_text, System.DateTime dt)
    {
        if (liu.context.Cache[ca_name] == null)
        {
            liu.context.Cache.Insert(ca_name.ToString(), ca_text, null, dt, Cache.NoSlidingExpiration);
        }
        return liu.context.Cache[ca_name];
    }
    public static string text_Replace(string tq, string t, string color)
    {
        return tq.Replace(t, string.Concat(new string[]
		{
			"<span style=\"color:",
			color,
			";\">",
			t,
			"</span>"
		}));
    }
}
