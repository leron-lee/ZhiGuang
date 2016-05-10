using System;
using System.Data.SqlClient;
using System.Text;
public class en_page
{
    public static string fystr_one(int x, string sqls, string username, int p, string pax, string sql_id)
    {
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new access().ExecuteScalar(fystring));
        return en_page.fsstr_one_nei(num, x, p, username, pax, 1);
    }
    public static string fystr_one(int x, string sqls, string username, int p, string pax, string sql_id, int style_int)
    {
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new SqlHelper().ExecuteScalar(fystring));
        return en_page.fsstr_style(style_int) + "\n" + en_page.fsstr_one_nei(num, x, p, username, pax, style_int);
    }
    public static string fystr_one(int x, string sqls, string username, int p, string pax, string sql_id, int style_int, SqlParameter[] parameters)
    {
        string fystring = "select count(" + sql_id + ") from " + sqls;
        int num = System.Convert.ToInt32(new SqlHelper().ExecuteScalar(fystring, parameters));
        return en_page.fsstr_style(style_int) + "\n" + en_page.fsstr_one_nei(num, x, p, username, pax, style_int);
    }
    private static string fsstr_one_nei(int num, int x, int p, string username, string pax, int style_int)
    {
        string result;
        if (style_int == 2)
        {
            result = en_page.fsstr_one_nei_wx(num, x, p, username, pax);
        }
        else
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
            templateBuilder.Append("<table  id='fstable'  cellpadding='0' cellspacing=\"0\">");
            templateBuilder.Append("<tr>");
            if (allNum < 9)
            {
                if (allNum > 1)
                {
                    if (p > 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=1'>‹‹</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 1,
							"'>‹</a></td>"
						}));
                    }
                    for (int ai = 0; ai < allNum; ai++)
                    {
                        if (p == ai + 1)
                        {
                            templateBuilder.Append("<td><span>" + (ai + 1) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								ai + 1,
								"'>",
								ai + 1,
								"</a></td>"
							}));
                        }
                    }
                    if (allNum != p)
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 1,
							"'>›</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							"'>››</a></td>"
						}));
                    }
                }
            }
            else
            {
                if (p - 6 < 1)
                {
                    if (p > 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=1'>‹‹</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 1,
							"'>‹</a></td>"
						}));
                    }
                    if (p == 1)
                    {
                        templateBuilder.Append("<td><span>1</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=1'>1</a></td>"
						}));
                    }
                    if (p == 2)
                    {
                        templateBuilder.Append("<td><span>2</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=2'>2</a></td>"
						}));
                    }
                    if (p == 3)
                    {
                        templateBuilder.Append("<td><span>3</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=3'>3</a></td>"
						}));
                    }
                    if (p == 4)
                    {
                        templateBuilder.Append("<td><span>4</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=4'>4</a></td>"
						}));
                    }
                    if (p == 5)
                    {
                        templateBuilder.Append("<td><span>5</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=5'>5</a></td>"
						}));
                    }
                    if (p == 6)
                    {
                        templateBuilder.Append("<td><span>6</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=6'>6</a></td>"
						}));
                    }
                    if (p == 7)
                    {
                        templateBuilder.Append("<td><span>7</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=7'>7</a></td>"
						}));
                    }
                    if (p == 8)
                    {
                        templateBuilder.Append("<td><span>8</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=8'>8</a></td>"
						}));
                    }
                    if (p == 9)
                    {
                        templateBuilder.Append("<td><span>9</span></td>");
                    }
                    else
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=9'>9</a></td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p + 1,
						"'>›</a></td>"
					}));
                    if (allNum != 9)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							"'>››</a></td>"
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
								"<td><a href='?",
								username,
								"&",
								pax,
								"=1'>‹‹</a></td>"
							}));
                        }
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 1,
							"'>‹</a></td>"
						}));
                        if (allNum - 8 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 8) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 8,
								"'>",
								allNum - 8,
								"</a></td>"
							}));
                        }
                        if (allNum - 7 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 7) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 7,
								"'>",
								allNum - 7,
								"</a></td>"
							}));
                        }
                        if (allNum - 6 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 6) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 6,
								"'>",
								allNum - 6,
								"</a></td>"
							}));
                        }
                        if (allNum - 5 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 5) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 5,
								"'>",
								allNum - 5,
								"</a></td>"
							}));
                        }
                        if (allNum - 4 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 4) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 4,
								"'>",
								allNum - 4,
								"</a></td>"
							}));
                        }
                        if (allNum - 3 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 3) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 3,
								"'>",
								allNum - 3,
								"</a></td>"
							}));
                        }
                        if (allNum - 2 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 2) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 2,
								"'>",
								allNum - 2,
								"</a></td>"
							}));
                        }
                        if (allNum - 1 == p)
                        {
                            templateBuilder.Append("<td><span>" + (allNum - 1) + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum - 1,
								"'>",
								allNum - 1,
								"</a></td>"
							}));
                        }
                        if (allNum == p)
                        {
                            templateBuilder.Append("<td><span>" + allNum + "</span></td>");
                        }
                        else
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum,
								"'>",
								allNum,
								"</a></td>"
							}));
                        }
                        if (p != allNum)
                        {
                            templateBuilder.Append(string.Concat(new object[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								p + 1,
								"'>›</a></td>"
							}));
                            templateBuilder.Append(string.Concat(new string[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum.ToString(),
								"'>››</a></td>"
							}));
                        }
                    }
                    else
                    {
                        if (p - 4 != 1)
                        {
                            templateBuilder.Append(string.Concat(new string[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=1'>‹‹</a></td>"
							}));
                        }
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 1,
							"'>‹</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 4,
							"'>",
							p - 4,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 3,
							"'>",
							p - 3,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 2,
							"'>",
							p - 2,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p - 1,
							"'>",
							p - 1,
							"</a></td>"
						}));
                        templateBuilder.Append("<td><span>" + p + "</span></td>");
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 1,
							"'>",
							p + 1,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 2,
							"'>",
							p + 2,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 3,
							"'>",
							p + 3,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 4,
							"'>",
							p + 4,
							"</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 1,
							"'>›</a></td>"
						}));
                        if (allNum != p + 4)
                        {
                            templateBuilder.Append(string.Concat(new string[]
							{
								"<td><a href='?",
								username,
								"&",
								pax,
								"=",
								allNum.ToString(),
								"'>››</a></td>"
							}));
                        }
                    }
                }
            }
            templateBuilder.Append("</tr>");
            templateBuilder.Append("</table>");
            result = templateBuilder.ToString();
        }
        return result;
    }
    private static string fsstr_one_nei_wx(int num, int x, int p, string username, string pax)
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
        templateBuilder.Append("<table  id='fstable'  cellpadding='0' cellspacing=\"0\">");
        templateBuilder.Append("<tr>");
        if (allNum < 9)
        {
            if (allNum > 1)
            {
                if (p > 1)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=1'>首页</a></td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p - 1,
						"'>上一页</a></td>"
					}));
                }
                if (allNum != p)
                {
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p + 1,
						"'>下一页</a></td>"
					}));
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						allNum.ToString(),
						"'>末页</a></td>"
					}));
                }
            }
        }
        else
        {
            if (p - 6 < 1)
            {
                if (p > 1)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=1'>首页</a></td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p - 1,
						"'>上一页</a></td>"
					}));
                }
                templateBuilder.Append(string.Concat(new object[]
				{
					"<td><a href='?",
					username,
					"&",
					pax,
					"=",
					p + 1,
					"'>下一页</a></td>"
				}));
                if (allNum != 9)
                {
                    templateBuilder.Append(string.Concat(new string[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						allNum.ToString(),
						"'>末页</a></td>"
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
							"<td><a href='?",
							username,
							"&",
							pax,
							"=1'>首页</a></td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p - 1,
						"'>上一页</a></td>"
					}));
                    if (p != allNum)
                    {
                        templateBuilder.Append(string.Concat(new object[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							p + 1,
							"'>下一页</a></td>"
						}));
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							"'>末页</a></td>"
						}));
                    }
                }
                else
                {
                    if (p - 4 != 1)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=1'>首页</a></td>"
						}));
                    }
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p - 1,
						"'>上一页</a></td>"
					}));
                    templateBuilder.Append(string.Concat(new object[]
					{
						"<td><a href='?",
						username,
						"&",
						pax,
						"=",
						p + 1,
						"'>下一页</a></td>"
					}));
                    if (allNum != p + 4)
                    {
                        templateBuilder.Append(string.Concat(new string[]
						{
							"<td><a href='?",
							username,
							"&",
							pax,
							"=",
							allNum.ToString(),
							"'>末页</a></td>"
						}));
                    }
                }
            }
        }
        templateBuilder.Append("</tr>");
        templateBuilder.Append("</table>");
        return templateBuilder.ToString();
    }
    private static string fsstr_style(int i)
    {
        string fig = string.Empty;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("\n\n<style type=\"text/css\">\n");
        if (i == 1)
        {
            sb.Append("    #fstable td{height:30px;}/*设置td的高度*/\n");
            sb.Append("    #fstable{font-size:11px;}/*设置字体的大小*/\n");
            sb.Append("    #fstable a{float:left;display:inline;border:1px solid #DDDDDD;color:#AAAAAA;text-decoration:none;padding:0px 7px 0px 7px;height:23px;line-height:23px;margin-left:7px;}/*设置a标签的样子*/\n");
            sb.Append("    #fstable a:hover{border:1px solid #A1A1A1;}/*设置移动到a标签的样子*/\n");
            sb.Append("    #fstable span{float:left;display:inline;border:1px solid #DDDDDD;COLOR: #AAAAAA;background-color:#F0F0F0;padding:0px 7px 0px 7px;height:23px;line-height:23px;margin-left:7px;}\n");
        }
        else
        {
            if (i == 2)
            {
                sb.Append("    #fstable td{height:20px;}/*设置td的高度*/\n");
                sb.Append("    #fstable{font-size:12px;}/*设置字体的大小*/\n");
                sb.Append("    #fstable a{float:left;display:inline;border:1px solid #DDDDDD;color:#AAAAAA;text-decoration:none;padding:5px 10px 5px 10px;margin-left:5px;}/*设置a标签的样子*/\n");
                sb.Append("    #fstable a:hover{border:1px solid #A1A1A1;}/*设置移动到a标签的样子*/\n");
                sb.Append("    #fstable span{float:left;display:inline;border:1px solid #DDDDDD;COLOR: #AAAAAA;background-color:#F0F0F0;padding:5px 10px 5px 10px;margin-left:5px;}\n");
            }
        }
        sb.Append("</style>\n");
        return sb.ToString();
    }
}
