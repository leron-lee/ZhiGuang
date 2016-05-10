using System;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Data;
public class getwx
{
    private static HttpContext context = HttpContext.Current;
    public static string AppId()
    {
        return new access().ExecuteScalar("select AppId from wx_can where id = 1");
    }
    public static string AppSecret()
    {
        return new access().ExecuteScalar("select AppSecret from wx_can where id = 1");
    }
    public static string Token()
    {
        return "weixin";
    }
    public static string gjc(object v)
    {
        return v.ToString().Substring(1, v.ToString().Length - 2);
    }
    public static string access_token()
    {
        string fig;
        if (getwx.context.Cache["access_token"] == null)
        {
            string AppId = getwx.AppId();
            string AppSecret = getwx.AppSecret();
            string s = get.geturl("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppId + "&secret=" + AppSecret);
            fig = json.JsonTooo(s, "access_token");
            getwx.context.Cache.Insert("access_token", fig, null, System.DateTime.Now.AddSeconds(7200.0), Cache.NoSlidingExpiration);
        }
        else
        {
            fig = getwx.context.Cache["access_token"].ToString();
        }
        return fig;
    }


    
    public static string jsapi_ticket()
    {
        string fig;
        if (getwx.context.Cache["jsapi_ticket"] == null)
        {
            fig = get.geturl("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + getwx.access_token() + "&type=jsapi");
            fig = json.JsonTooo(fig, "ticket");
            getwx.context.Cache.Insert("jsapi_ticket", fig, null, System.DateTime.Now.AddSeconds(7200.0), Cache.NoSlidingExpiration);
        }
        else
        {
            fig = getwx.context.Cache["jsapi_ticket"].ToString();
        }
        return fig;
    }
    public static string signature(string noncestr, string timestamp, string url)
    {
        string jsapi_ticket = "jsapi_ticket=" + getwx.jsapi_ticket();
        noncestr = "noncestr=" + noncestr;
        timestamp = "timestamp=" + timestamp;
        url = "url=" + url;
        string[] ArrTmp = new string[]
		{
			jsapi_ticket,
			noncestr,
			timestamp,
			url
		};
        System.Array.Sort<string>(ArrTmp);
        string tmpStr = string.Join("&", ArrTmp);
        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
        return tmpStr.ToLower();
    }
    public static string DateTimeToUnixTimestamp(System.DateTime dt)
    {
        System.DateTime startTime = System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return System.Convert.ToInt64((dt - startTime).TotalSeconds).ToString();
    }
    public static string xiaoxi_reg(object first, object keyword1, object keyword2, object remark, object username)
    {
        string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");
        string xiaoxi_fx = new SqlHelper().ExecuteScalar("select xiaoxi_fx from username where username = '" + username + "'");
        string rt = "";
        if (!string.IsNullOrEmpty(openid) )
        {
            string fig = "";
            fig += "{";
            fig = fig + "\"touser\":\"" + openid + "\",";
            fig += "\"template_id\":\"T9ytE4dHqtAe4ofdZ7wPu08ZS3HoEYIuCizK7k3sGaA\",";
            fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            fig += "\"topcolor\":\"#FF0000\",";
            fig += "\"data\":{";
            fig += "\"first\": {";
            object obj = fig;
            fig = string.Concat(new object[]
			{
				obj,
				"        \"value\":\"用户名：",
				first,
				"\","
			});
            fig += "        \"color\":\"#173177\"";
            fig += "  },";
            fig += "\"keyword1\": {";
            obj = fig;
            fig = string.Concat(new object[]
			{
				obj,
				"        \"value\":\"",
				keyword1,
				"\","
			});
            fig += "        \"color\":\"#173177\"";
            fig += "  },";
            fig += "\"keyword2\": {";
            obj = fig;
            fig = string.Concat(new object[]
			{
				obj,
				"        \"value\":\"",
				keyword2,
				"\","
			});
            fig += "        \"color\":\"#173177\"";
            fig += "  },";
            fig += "\"remark\": {";
            obj = fig;
            fig = string.Concat(new object[]
			{
				obj,
				"        \"value\":\"",
				remark,
				"\","
			});
            fig += "        \"color\":\"#173177\"";
            fig += "  }";
            fig += "}";
            fig += "}";
            fig = fig.Replace(" ", "");
            string ACCESS_TOKEN = getwx.access_token();
            rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
        }
        return rt;
    }
    public static string xiaoxi_fx(object first, object order, object money, object remark, object username)
    {
      
       
        string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");
     
        string f = new SqlHelper().ExecuteScalar("select price from shoporder where ordernumber = '" + order + "'");
        string f2 = new SqlHelper().ExecuteScalar("select name from shoporder where ordernumber = '" + order + "'");


        string rt = "";
        string c = "";
        if (!string.IsNullOrEmpty(openid) )
        {
            
         
            string fig = "";
            fig += "{";
            fig = fig + "\"touser\":\"" + openid + "\",";
            fig += "\"template_id\":\"Gg5QCcN5jAq5NYNgYfpLCQZkzJ2Bm9pG9L8UC5BoOmQ\",";
            fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            fig += "\"topcolor\":\"#FF0000\",";
            fig += "\"data\":{";

            fig += "\"first\": {\"value\":\"您好,您的推荐会员【"+f2+"】，购买下单\",\"color\":\"#173177\"},";
            fig += "\"keyword1\": {\"value\":\"" + order + "\",\"color\":\"#173177\"},";
            fig += "\"keyword2\": {\"value\":\"" + f + "元\",\"color\":\"#173177\"},";
            fig += "\"keyword3\": {\"value\":\"" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分dd秒") + "\",\"color\":\"#173177\"},";
            fig += "\"keyword4\": {\"value\":\"" + money + "元\",\"color\":\"#173177\"},";
            fig += "\"remark\": {\"value\":\"" + "感谢您的支持" + "\",\"color\":\"#173177\"}";
            fig += "}";
            fig += "}";
            fig = fig.Replace(" ", "");
            string ACCESS_TOKEN = getwx.access_token();
            c = ACCESS_TOKEN;
            rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
        }

        new SqlHelper().ExecuteNonQuery("insert into ceshi (a,b) values('" + rt + "','" + c + "')");
        return rt;

    }

    public static string xiaoxi_goumai(string order)
    {

        string username = "";
        string prices = "";
        string id = "";
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select id, username,price from shoporder where ordernumber='" + order + "'"))
        {
            foreach (DataRow r in dt.Rows)
            {
                username = r["username"].ToString();
                prices = r["price"].ToString();
                id = r["id"].ToString();
            }
        }
        string name = "";
        string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");

        using (DataTable dt = new SqlHelper().ExecuteDataTable("select mname from shoporderlist where OrderId=" + id + ""))
        {
            foreach (DataRow r in dt.Rows)
            {

                if (name == "")
                {
                    name = r["mname"].ToString();
                }
                else
                {
                    name += r["mname"].ToString();
                }
            }
        }



        string rt = "";

        if (!string.IsNullOrEmpty(openid))
        {


            string fig = "";
            fig += "{";
            fig = fig + "\"touser\":\"" + openid + "\",";
            fig += "\"template_id\":\"DlUrxft_ylIUTwoM7jn0nW0sv5alCW973w1wV4MQ0G4\",";
            fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            fig += "\"topcolor\":\"#FF0000\",";
            fig += "\"data\":{";

            fig += "\"first\": {\"value\":\"我们已收到您的货款，开始为您打包商品，请耐心等待: )\",\"color\":\"#173177\"},";
            fig += "\"orderMoneySum\": {\"value\":\"" + prices + "元\",\"color\":\"#173177\"},";
            fig += "\"orderProductName\": {\"value\":\"" + name + "\",\"color\":\"#173177\"},";

            fig += "\"remark\": {\"value\":\"" + "" + "\",\"color\":\"#173177\"}";
            fig += "}";
            fig += "}";
            fig = fig.Replace(" ", "");
            string ACCESS_TOKEN = getwx.access_token();
            rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
        }

        return rt;
    }


    public static string xiaoxi_tixian(object money, object remark, object username)
    {
      

        string openid = new SqlHelper().ExecuteScalar("select openid from username where username = '" + username + "'");

      


        string rt = "";

        if (!string.IsNullOrEmpty(openid))
        {

            string fig = "";
            fig += "{";
            fig = fig + "\"touser\":\"" + openid + "\",";
            fig += "\"template_id\":\"h9gsviuewBKygDnIM5igHd0r_lo1dRiiqeq8ZmLQivo\",";
            fig += "\"url\":\"http://www.6666315.com/user/wdcc.aspx\",";
            fig += "\"topcolor\":\"#FF0000\",";
            fig += "\"data\":{";

            fig += "\"first\": {\"value\":\"礼尚挚广余额提现申请已提交，资金预计1-3个工作日到账，请注意查收。\",\"color\":\"#173177\"},";
            fig += "\"money\": {\"value\":\"" + money + "元\",\"color\":\"#173177\"},";
            fig += "\"timet\": {\"value\":\"" + DateTime.Now.ToString() + "\",\"color\":\"#173177\"},";
            fig += "\"remark\": {\"value\":\"" + "感谢您的支持" + "\",\"color\":\"#173177\"}";
            fig += "}";
            fig += "}";
            fig = fig.Replace(" ", "");
            string ACCESS_TOKEN = getwx.access_token();
            rt = get.post("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + ACCESS_TOKEN, fig);
        }

        return rt;

    }
}
