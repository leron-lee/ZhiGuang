using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;
using CT.WebUtility;
public class get
{
    private static HttpContext context = HttpContext.Current;
    public static double bl(double d1, int d2)
    {
        return System.Math.Round(d1, d2);
    }
    public static void zfcg(object ordernumber)
    {
        get.zfcg(ordernumber, 1);
    }
    public static string ifsj(object v)
    {
        string fig;
        if (v.ToString() == "1")
        {
            fig = "<span style='color:green;'>已上架</span>";
        }
        else
        {
            fig = "<span style='color:red;'>未上架</span>";
        }
        return fig;
    }
    public static double jinshou(object username)
    {
        double fig = 0.0;
        string abc = new SqlHelper().ExecuteScalar(string.Concat(new object[]
		{
			"select sum(jf) from ye_jilu where username = '",
			username,
			"' and cao = '增加' and bz like '%会员%' and times > '",
			System.DateTime.Now.ToShortDateString(),
			"'"
		}));
        if (abc != "")
        {
            fig = System.Convert.ToDouble(abc);
        }
        return fig;
    }
    public static double zongshou(object username)
    {
        double fig = 0.0;
        string abc = new SqlHelper().ExecuteScalar("select sum(jf) from ye_jilu where username = '" + username + "' and cao = '增加' and bz like '%会员%'");
        if (abc != "")
        {
            fig = System.Convert.ToDouble(abc);
        }
        return fig;
    }
    public static int dv_zong(object username)
    {
        int fig = 0;
        string s_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + username + "'");
        if (s_xian != "")
        {
            string abc = new SqlHelper().ExecuteScalar("select count(id) from username where ifdv = 1 and s_xian = " + s_xian);
            if (abc != "")
            {
                fig = System.Convert.ToInt32(abc);
            }
        }
        return fig;
    }
    public static double dv_shouyi(object username)
    {
        double fig = 0.0;
        string s_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + username + "'");
        if (s_xian != "")
        {
            string abc = new SqlHelper().ExecuteScalar("select sum(jf) from ye_jilu where username in (select username from username where ifdv = 1 and s_xian = " + s_xian + ") and cao = '增加' and bz like '%下级%'");
            if (abc != "")
            {
                fig = System.Convert.ToDouble(abc);
            }
        }
        return fig;
    }
    public static double bycj(object username)
    {
        double fig = 0.0;
        System.DateTime dt = System.DateTime.Now;
        string ktimes = string.Concat(new object[]
		{
			dt.Year,
			"-",
			dt.Month,
			"-1"
		});
        string jtimes = string.Concat(new object[]
		{
			dt.AddMonths(1).Year,
			"-",
			dt.AddMonths(1).Month,
			"-1"
		});
        string zje = new SqlHelper().ExecuteScalar(string.Concat(new object[]
		{
			"select sum(price) from shoporder where username ='",
			username,
			"' and zt > 1 and times > '",
			ktimes,
			"' and times < '",
			jtimes,
			"' "
		}));
        if (zje != "")
        {
            fig = get.bl(System.Convert.ToDouble(zje), 2);
        }
        return fig;
    }
    public static double youfei(object id)
    {
        double fig = 0.0;
        string sheng = new SqlHelper().ExecuteScalar("select sheng from address where id = " + id);
        sheng = get.s_sheng(sheng);
        sheng = sheng.Replace("省", "").Replace("市", "");
        string price = new SqlHelper().ExecuteScalar("select price from youfei where sheng like '%" + sheng + "%'");
        if (price != "")
        {
            fig = System.Convert.ToDouble(price);
        }
        return fig;
    }
    public static string s_sheng(object v)
    {
        string fig = "";
        if (!string.IsNullOrEmpty(v.ToString()))
        {
            fig = new SqlHelper().ExecuteScalar("select name from s_sheng where id = " + v);
        }
        return fig;
    }
    public static string s_shi(object v)
    {
        string fig = "";
        if (!string.IsNullOrEmpty(v.ToString()))
        {
            fig = new SqlHelper().ExecuteScalar("select name from s_shi where id = " + v);
        }
        return fig;
    }
    public static string s_xian(object v)
    {
        string fig = "";
        if (!string.IsNullOrEmpty(v.ToString()))
        {
            fig = new SqlHelper().ExecuteScalar("select name from s_xian where id = " + v);
        }
        return fig;
    }
    public static void zfcg(object ordernumber, int i)
    {
        if (ordernumber.ToString().Contains("_"))
        {
            string[] ing = ordernumber.ToString().Split(new char[]
			{
				'_'
			});
            ordernumber = ing[1];
        }
        string shoporderid = new SqlHelper().ExecuteScalar("select id from shoporder where ordernumber = '" + ordernumber + "'");
        string chongzhi_ye_id = new SqlHelper().ExecuteScalar("select id from chongzhi_ye where ordernumber = '" + ordernumber + "'");
        string chongzhi_xfj_id = new SqlHelper().ExecuteScalar("select id from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
        if (shoporderid != "")
        {
            string zt = new SqlHelper().ExecuteScalar("select zt from shoporder where ordernumber = '" + ordernumber + "'");
            if (zt == "1")
            {
                string username = new SqlHelper().ExecuteScalar("select username from shoporder where ordernumber = '" + ordernumber + "'");
                string jb = get.jb_dq(username);
                if (i == 1)
                {
                    string cm = username;
                    string tj_username = username;
                    if (get.jb_dq(username) == "6")
                    {

                    }
                    string s_sheng = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + username + "'");
                    if (s_sheng != "1")
                    { }
                    tj_username = get.ye_fh(tj_username, ordernumber, get.zk(4), "fh_one", cm);
                    tj_username = get.ye_fh(tj_username, ordernumber, get.zk(5), "fh_two", cm);
                    tj_username = get.ye_fh(tj_username, ordernumber, get.zk(6), "fh_three", cm);
                    string s_shi = new SqlHelper().ExecuteScalar("select s_sheng from username where username = '" + username + "'");
                    string s_xian = new SqlHelper().ExecuteScalar("select s_shi from username where username = '" + username + "'");
                    string dv_username = new SqlHelper().ExecuteScalar("select s_xian from username where username = '" + username + "'");
                    string dvfh = get.dv_username(username);
                    double dl_sheng_username = 0.0;
                    if (!string.IsNullOrEmpty(dvfh))
                    {
                        dl_sheng_username = System.Convert.ToDouble(new SqlHelper().ExecuteScalar("select dvfh from username where username = '" + username + "'"));
                    }
                    string dl_shi_username = new SqlHelper().ExecuteScalar("select username from username where jb = 1 and dl_sheng = " + s_shi);
                    string dl_xian_username = new SqlHelper().ExecuteScalar("select username from username where jb = 2 and dl_shi = " + s_xian);
                    string hb = new SqlHelper().ExecuteScalar("select username from username where jb = 3 and dl_xian = " + dv_username);
                    double dt = System.Convert.ToDouble(new SqlHelper().ExecuteScalar("select hb from shoporder where ordernumber = '" + ordernumber + "'"));
                    using (DataTable ui = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + shoporderid))
                    {
                        int r = 0;
                        foreach (DataRow price in ui.Rows)
                        {
                            double sum = System.Convert.ToDouble(price["price"]);
                            double iftj = System.Convert.ToDouble(price["sum"]);
                            string tj_fh = get.m_str(price["mid"], "iftj");
                            sum *= iftj;
                            double sheng_zk = System.Convert.ToDouble(get.tj_fh());
                            if (tj_fh != "1")
                            {
                                r++;
                                if (r == 1)
                                {
                                    sum -= dt;
                                }
                            }

                            if (!string.IsNullOrEmpty(dl_shi_username))
                            {
                                double xprice = get.zk(1);
                                if (xprice > 0.0)
                                {
                                    double shi_zk = sum * xprice;
                                    if (tj_fh == "1")
                                    {
                                        shi_zk = sheng_zk * iftj;
                                    }
                                    get.ye_cao(dl_shi_username, "增加", (get.fh(price["mid"], "fh_sheng") * iftj).ToString(), "省内会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                                }
                            }

                            if (!string.IsNullOrEmpty(dl_xian_username))
                            {
                                double xian_zk = get.zk(2);
                                if (xian_zk > 0.0)
                                {
                                    double shi_zk = sum * xian_zk;
                                    if (tj_fh == "1")
                                    {
                                        shi_zk = sheng_zk * iftj;
                                    }
                                    get.ye_cao(dl_xian_username, "增加", (get.fh(price["mid"], "fh_shi") * iftj).ToString(), "市内会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                                }
                            }
                            /*
                            if (!string.IsNullOrEmpty(dvfh))
                            {
                                if (dl_sheng_username > 0.0)
                                {
                                    double shi_zk = sum * dl_sheng_username;
                                    if (tj_fh == "1")
                                    {
                                        shi_zk = sheng_zk * iftj;
                                    }
                                    get.ye_cao(dvfh, "增加", shi_zk.ToString(), "(大V)下级会员：" + get.ying(username) + "消费增加", ordernumber);
                                }
                            }
                            */
                            if (!string.IsNullOrEmpty(hb))
                            {
                                double price2 = get.zk(3);
                                price2 -= dl_sheng_username;
                                if (price2 > 0.0)
                                {
                                    double shi_zk = sum * dl_sheng_username;
                                    if (tj_fh == "1")
                                    {
                                        shi_zk = sheng_zk * iftj;
                                    }
                                    get.ye_cao(hb, "增加", (get.fh(price["mid"], "fh_xian") * iftj - shi_zk).ToString(), "县区内会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                                }
                            }

                            ////////////////////////////////



                            DengJi(username.ToString(), Convert.ToDouble(get.fh(price["mid"], "lirun")) * iftj, ordernumber);

                        }
                    }


                }






                new SqlHelper().ExecuteNonQuery("update shoporder set zt = 2 where ordernumber = '" + ordernumber + "'");
                // get.bccs(username);
                getwx.xiaoxi_goumai(ordernumber.ToString());
            }
        }
        else
        {
            if (chongzhi_ye_id != "")
            {
                string zt = new SqlHelper().ExecuteScalar("select zt from chongzhi_ye where ordernumber = '" + ordernumber + "'");
                if (zt == "0")
                {
                    string jf = new SqlHelper().ExecuteScalar("select price from chongzhi_ye where ordernumber = '" + ordernumber + "'");
                    string username = new SqlHelper().ExecuteScalar("select username from chongzhi_ye where ordernumber = '" + ordernumber + "'");
                    get.ye_cao(username, "增加", jf, "金额充值", "");
                    new SqlHelper().ExecuteNonQuery("update chongzhi_ye set zt = 1 where ordernumber = '" + ordernumber + "'");
                }
            }
            else
            {
                if (chongzhi_xfj_id != "")
                {
                    string zt = new SqlHelper().ExecuteScalar("select zt from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
                    if (zt == "0")
                    {
                        string jf = new SqlHelper().ExecuteScalar("select price from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
                        string username = new SqlHelper().ExecuteScalar("select username from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
                        get.xfj_cao(username, "增加", jf, "消费劵充值");
                        new SqlHelper().ExecuteNonQuery("update chongzhi_xfj set zt = 1 where ordernumber = '" + ordernumber + "'");
                    }
                }
            }
        }
    }


    public static void DengJi(string username, double money, object ordernumber)
    {
        SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@lgname",username),
                            };
        DataTable dt = Sql.ExecuteDataSet("PB", sp).Tables[0];

        int i = 0;
        int m = 0;//总代
        int n = 0;//小总代
        foreach (DataRow r in dt.Rows)
        {
            i++;
            if (i > 1)
            {

                string hb = r["lgname"].ToString();
                int jb = Convert.ToInt32(r["jb2"]);

                if (jb == 4)
                {
                    int f = 0;

                    if (m == 0 && n == 0)
                    {
                        f = 10;
                    }
                    else if (n == 6 && m == 0)
                    {
                        f = 5;
                    }
                    else if (n == 0 && m == 5)
                    {
                        f = 7;
                    }
                    else if (n == 6 && m == 5)
                    {
                        f = 2;
                    }



                    if (f > 0)
                    {
                        get.ye_cao(hb, "增加", (f * 0.01 * money).ToString(), "团队会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                    }

                    break;
                }
                else if (jb == 5 && m != 5)
                {

                    //总代
                    int f = 0;
                    if (n == 6)
                    {
                        f = 3;
                    }
                    else if (n == 0)
                    {
                        f = 8;
                    }
                    if (f > 0)
                    {
                        get.ye_cao(hb, "增加", (f * 0.01 * money).ToString(), "团队会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                    }

                    m = 5;

                }
                else if (jb == 6 && n != 6)
                {

                    //小总代

                    int f = 0;

                    if (m == 0)
                    {
                        f = 5;
                    }


                    if (f > 0)
                    {
                        get.ye_cao(hb, "增加", (f * 0.01 * money).ToString(), "团队会员：" + get.ying(username) + "消费增加", ordernumber, 0);
                    }



                    n = 6;

                }
            }
        }

    }


    public static string dv_username(object username)
    {
        string fig = "";
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select ifdv,dvfh,tj_username,username,jb from username where username = '" + username + "'"))
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r["ifdv"].ToString() == "1" && r["jb"].ToString() == "6" && username.ToString() != r["username"].ToString())
                {
                    fig = r["username"].ToString();
                }
                else
                {
                    if (r["tj_username"].ToString() != "" && r["tj_username"].ToString() != "0")
                    {
                        fig = get.dv_username(get.username(r["tj_username"]));
                    }
                }
            }
        }
        return fig;
    }
    public static string dv_username2(object username)
    {
        string fig = "";
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select ifdv,dvfh,tj_username,username,jb from username where username = '" + username + "'"))
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r["ifdv"].ToString() == "1" && r["jb"].ToString() == "6")
                {
                    fig = r["username"].ToString();
                }
                else
                {
                    if (r["tj_username"].ToString() != "" && r["tj_username"].ToString() != "0")
                    {
                        fig = get.dv_username2(get.username(r["tj_username"]));
                    }
                }
            }
        }
        return fig;
    }
    public static void bccs(object username)
    {
        double byxf = get.bycj(username);
        string dqsj = string.Concat(new object[]
		{
			System.DateTime.Now.Year,
			"-",
			System.DateTime.Now.Month,
			"-1"
		});
        int xz = System.Convert.ToInt32(byxf) / 1000;
        if (xz > 0)
        {
            string zhi = new SqlHelper().ExecuteScalar(string.Concat(new object[]
			{
				"select zhi from byxf where username = '",
				username,
				"' and name = '",
				dqsj,
				"' "
			}));
            if (zhi == "")
            {
                int xzhi = 0;
                while (xz > xzhi)
                {
                    xzhi++;
                    get.ye_cao(username.ToString(), "增加", "50", "本月消费达1000元奖励50元", "");
                }
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"insert into byxf (username,name,zhi) values('",
					username,
					"','",
					dqsj,
					"',",
					xzhi,
					")"
				}));
            }
            else
            {
                if (xz > System.Convert.ToInt32(zhi))
                {
                    int xzhi = System.Convert.ToInt32(zhi);
                    while (xz > xzhi)
                    {
                        xzhi++;
                        get.ye_cao(username.ToString(), "增加", "50", "本月消费达1000元奖励50元", "");
                    }
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"update byxf set zhi = ",
						xz,
						" where username = '",
						username,
						"' and name = '",
						dqsj,
						"' "
					}));
                }
            }
        }
    }
    public static string ye_fh(object username, object ordernumber, double feilv, string zd, string cm)
    {
        string fig = "";
        if (username.ToString() != "")
        {
            string shoporderid = new SqlHelper().ExecuteScalar("select id from shoporder where ordernumber = '" + ordernumber + "'");
            double hb = System.Convert.ToDouble(new SqlHelper().ExecuteScalar("select hb from shoporder where ordernumber = '" + ordernumber + "'"));
            string yusername = new SqlHelper().ExecuteScalar("select username from shoporder where ordernumber = '" + ordernumber + "'");
            string tj_username_id = new SqlHelper().ExecuteScalar("select tj_username from username where username = '" + username + "'");
            int i = 0;
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + shoporderid))
            {
                foreach (DataRow r in dt.Rows)
                {
                    double price = System.Convert.ToDouble(r["price"]);
                    double sum = System.Convert.ToDouble(r["sum"]);
                    price *= sum;
                    string iftj;
                    if (get.m_str(r["mid"], "iftj").ToString() == "1")
                    {
                        iftj = "1";
                        price = System.Convert.ToDouble(get.tj_fh()) * sum;
                    }
                    else
                    {
                        iftj = "0";
                        i++;
                        if (i == 1)
                        {
                            price -= hb;
                        }
                    }
                    if (tj_username_id != "" && tj_username_id != "0")
                    {
                        string tj_username = get.username(tj_username_id);
                        if (tj_username != "")
                        {
                            if (iftj == "0")
                            {
                                price *= feilv;
                            }
                            string jb = get.jb(tj_username);

                            string id = new SqlHelper().ExecuteScalar("select mid from shoporderlist where orderId=(select id from shoporder where ordernumber = '" + ordernumber + "')");

                           
                                price = get.fh(r["mid"], zd) * sum;
                                get.ye_cao(tj_username, "增加", price.ToString(), string.Concat(new object[]
								{
									"下级会员：",
									get.ying(cm),
									"消费增加",
									get.bl(price, 2),
									"元"
								}), ordernumber);
                         

                            /*
                            if (Convert.ToInt32(id) == 51)
                            {
                                jb = "茶商";
                            }

                            if (jb != "茶客")
                            {
                                price = get.fh(r["mid"], zd) * sum;
                                get.ye_cao(tj_username, "增加", price.ToString(), string.Concat(new object[]
								{
									"下级会员：",
									get.ying(cm),
									"消费增加",
									get.bl(price, 2),
									"元"
								}), ordernumber);
                            }
                             */
                            fig = tj_username;
                        }
                    }
                }
            }
        }
        return fig;
    }
    public static double tj_fh()
    {
        double i = 0.0;
        string tj = new access().ExecuteScalar("select tj_fh from wzinfo where id = 1");
        if (tj != "")
        {
            i = System.Convert.ToDouble(tj);
        }
        return i;
    }
    public static int tj_xg()
    {
        int i = 0;
        string tj = new access().ExecuteScalar("select tj_xg from wzinfo where id = 1");
        if (tj != "")
        {
            i = System.Convert.ToInt32(tj);
        }
        return i;
    }
    public static void cz_fx(object price, object username)
    {
        double pr = System.Convert.ToDouble(price);
        if (pr >= 100.0 && pr < 200.0)
        {
            new SqlHelper().ExecuteNonQuery("update username set fx = fx+5 where username = '" + username + "'");
        }
        else
        {
            if (pr >= 200.0 && pr < 300.0)
            {
                new SqlHelper().ExecuteNonQuery("update username set fx = fx+10 where username = '" + username + "'");
            }
            else
            {
                if (pr >= 300.0 && pr < 400.0)
                {
                    new SqlHelper().ExecuteNonQuery("update username set fx = fx+20 where username = '" + username + "'");
                }
                else
                {
                    if (pr >= 400.0 && pr < 500.0)
                    {
                        new SqlHelper().ExecuteNonQuery("update username set fx = fx+35 where username = '" + username + "'");
                    }
                    else
                    {
                        if (pr >= 500.0 && pr < 1000.0)
                        {
                            new SqlHelper().ExecuteNonQuery("update username set fx = fx+50 where username = '" + username + "'");
                        }
                        else
                        {
                            if (pr >= 1000.0 && pr < 10000.0)
                            {
                                new SqlHelper().ExecuteNonQuery("update username set fx = fx+150 where username = '" + username + "'");
                            }
                            else
                            {
                                if (pr >= 10000.0)
                                {
                                    new SqlHelper().ExecuteNonQuery("update username set fx = fx+10000 where username = '" + username + "'");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public static string sheng(object id)
    {
        return new SqlHelper().ExecuteScalar("select name from s_sheng where id = " + id);
    }
    public static string shi(object id)
    {
        return new SqlHelper().ExecuteScalar("select name from s_shi where id = " + id);
    }
    public static string xian(object id)
    {
        return new SqlHelper().ExecuteScalar("select name from s_xian where id = " + id);
    }
    public static string jang(int i, string str)
    {
        string fig = "";
        if (i == 0)
        {
            fig = str;
        }
        return fig;
    }
    public static double jf(object username)
    {
        return System.Convert.ToDouble(new SqlHelper().ExecuteScalar("select jf from username where username = '" + username + "'"));
    }
    public static int usernemfxs(object username)
    {
        return System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select fx from username where username = '" + username + "'"));
    }
    public static string cao(object v)
    {
        string fig = "";
        if (v.ToString() == "增加")
        {
            fig = "<span style='color:green;'>" + v + "</span>";
        }
        else
        {
            if (v.ToString() == "扣除")
            {
                fig = "<span style='color:red;'>" + v + "</span>";
            }
        }
        return fig;
    }
    public static void ye_jian(object username, object jf)
    {
        double d2 = System.Convert.ToDouble(jf);
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from ye where username = '" + username + "' order by gtimes"))
        {
            foreach (DataRow r in dt.Rows)
            {
                double ndb = System.Convert.ToDouble(r["jf"]);
                if (ndb >= d2)
                {
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"update ye set jf = jf - ",
						d2,
						" where id = ",
						r["id"]
					}));
                    break;
                }
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update ye set jf = jf - ",
					d2,
					" where id = ",
					r["id"]
				}));
                new SqlHelper().ExecuteNonQuery("delete from ye where id = " + r["id"]);
                d2 -= ndb;
            }
        }
    }
    public static double ye(object username)
    {
        string fig = new SqlHelper().ExecuteScalar("select sum(jf) from ye where username = '" + username + "'");
        if (fig == "")
        {
            fig = "0";
        }
        return get.bl(System.Convert.ToDouble(fig), 2);
    }
    public static void ye_cao(string username, string cao, string jf, string bz, object ordernumber)
    {
        if (System.Convert.ToDouble(jf) > 0.0)
        {
            string times = System.DateTime.Now.ToString();
            string dqjf = "0";
            if (cao == "增加")
            {
                dqjf = (System.Convert.ToDouble(jf) + System.Convert.ToDouble(get.ye(username))).ToString();
                string sql2 = string.Concat(new object[]
				{
					"insert into ye (username,jf,gtimes) values('",
					username,
					"',",
					jf,
					",'",
					System.DateTime.Now.AddYears(100),
					"')"
				});
                new SqlHelper().ExecuteNonQuery(sql2);
            }
            else
            {
                if (cao == "扣除")
                {
                    dqjf = (System.Convert.ToDouble(get.ye(username)) - System.Convert.ToDouble(jf)).ToString();
                    get.ye_jian(username, jf);
                }
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@username", username),
				new SqlParameter("@cao", cao),
				new SqlParameter("@jf", jf),
				new SqlParameter("@dqjf", dqjf),
				new SqlParameter("@bz", bz),
				new SqlParameter("@times", times)
			};
            string sql3 = "insert into ye_jilu (username,cao,jf,dqjf,bz,times) values(@username,@cao,@jf,@dqjf,@bz,@times)";
            new SqlHelper().ExecuteNonQuery(sql3, op);
            if (cao == "增加")
            {
                getwx.xiaoxi_fx(bz, ordernumber, get.bl(System.Convert.ToDouble(jf), 2), "", username);
            }
        }
    }
    public static void ye_cao(string username, string cao, string jf, string bz, object ordernumber, int i)
    {
        if (System.Convert.ToDouble(jf) > 0.0)
        {
            string times = System.DateTime.Now.ToString();
            string dqjf = "0";
            if (cao == "增加")
            {
                dqjf = (System.Convert.ToDouble(jf) + System.Convert.ToDouble(get.ye(username))).ToString();
                string sql2 = string.Concat(new object[]
				{
					"insert into ye (username,jf,gtimes) values('",
					username,
					"',",
					jf,
					",'",
					System.DateTime.Now.AddYears(100),
					"')"
				});
                new SqlHelper().ExecuteNonQuery(sql2);
            }
            else
            {
                if (cao == "扣除")
                {
                    dqjf = (System.Convert.ToDouble(get.ye(username)) - System.Convert.ToDouble(jf)).ToString();
                    get.ye_jian(username, jf);
                }
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@username", username),
				new SqlParameter("@cao", cao),
				new SqlParameter("@jf", jf),
				new SqlParameter("@dqjf", dqjf),
				new SqlParameter("@bz", bz),
				new SqlParameter("@times", times)
			};
            string sql3 = "insert into ye_jilu (username,cao,jf,dqjf,bz,times) values(@username,@cao,@jf,@dqjf,@bz,@times)";
            new SqlHelper().ExecuteNonQuery(sql3, op);
            if (cao == "增加" && i == 1)
            {
                getwx.xiaoxi_fx(bz, ordernumber, get.bl(System.Convert.ToDouble(jf), 2), "", username);
            }
        }
    }
    public static string sh(object v)
    {
        string fig = "";
        if (v.ToString() == "1")
        {
            fig = "通过";
        }
        return fig;
    }
    public static string sh_class(object v)
    {
        string fig = "";
        if (v.ToString() == "1")
        {
            fig = "dis";
        }
        return fig;
    }
    public static void hb_jian(object username, object jf)
    {
        double d2 = System.Convert.ToDouble(jf);
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from hb where username = '" + username + "' order by gtimes"))
        {
            foreach (DataRow r in dt.Rows)
            {
                double ndb = System.Convert.ToDouble(r["jf"]);
                if (ndb >= d2)
                {
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"update hb set jf = jf - ",
						d2,
						" where id = ",
						r["id"]
					}));
                    break;
                }
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update hb set jf = jf - ",
					d2,
					" where id = ",
					r["id"]
				}));
                new SqlHelper().ExecuteNonQuery("delete from hb where id = " + r["id"]);
                d2 -= ndb;
            }
        }
    }
    public static double hb(object username)
    {
        string fig = new SqlHelper().ExecuteScalar("select sum(jf) from hb where username = '" + username + "'");
        if (fig == "")
        {
            fig = "0";
        }
        return get.bl(System.Convert.ToDouble(fig), 2);
    }
    public static void hb_cao(string username, string cao, string jf, string bz)
    {
        string times = System.DateTime.Now.ToString();
        string dqjf = "0";
        if (cao == "增加")
        {
            dqjf = (System.Convert.ToDouble(jf) + System.Convert.ToDouble(get.hb(username))).ToString();
            string sql2 = string.Concat(new object[]
			{
				"insert into hb (username,jf,gtimes) values('",
				username,
				"',",
				jf,
				",'",
				System.DateTime.Now.AddMonths(1),
				"')"
			});
            new SqlHelper().ExecuteNonQuery(sql2);
        }
        else
        {
            if (cao == "扣除")
            {
                dqjf = (System.Convert.ToDouble(get.hb(username)) - System.Convert.ToDouble(jf)).ToString();
                get.hb_jian(username, jf);
            }
        }
        SqlParameter[] op = new SqlParameter[]
		{
			new SqlParameter("@username", username),
			new SqlParameter("@cao", cao),
			new SqlParameter("@jf", jf),
			new SqlParameter("@dqjf", dqjf),
			new SqlParameter("@bz", bz),
			new SqlParameter("@times", times)
		};
        string sql3 = "insert into hb_jilu (username,cao,jf,dqjf,bz,times) values(@username,@cao,@jf,@dqjf,@bz,@times)";
        new SqlHelper().ExecuteNonQuery(sql3, op);
    }
    public static void xfj_jian(object username, object jf)
    {
        double d2 = System.Convert.ToDouble(jf);
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from xfj where username = '" + username + "' order by gtimes"))
        {
            foreach (DataRow r in dt.Rows)
            {
                double ndb = System.Convert.ToDouble(r["jf"]);
                if (ndb >= d2)
                {
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"update xfj set jf = jf - ",
						d2,
						" where id = ",
						r["id"]
					}));
                    break;
                }
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update xfj set jf = jf - ",
					d2,
					" where id = ",
					r["id"]
				}));
                new SqlHelper().ExecuteNonQuery("delete from xfj where id = " + r["id"]);
                d2 -= ndb;
            }
        }
    }
    public static double xfj(object username)
    {
        string fig = new SqlHelper().ExecuteScalar("select sum(jf) from xfj where username = '" + username + "'");
        if (fig == "")
        {
            fig = "0";
        }
        return get.bl(System.Convert.ToDouble(fig), 2);
    }
    public static void xfj_cao(string username, string cao, string jf, string bz)
    {
        string times = System.DateTime.Now.ToString();
        string dqjf = "0";
        if (cao == "增加")
        {
            get.cz_fx(jf, username);
            dqjf = (System.Convert.ToDouble(jf) + System.Convert.ToDouble(get.xfj(username))).ToString();
            System.DateTime dt = System.DateTime.Now;
            double jfd = System.Convert.ToDouble(jf);
            if (jfd <= 500.0)
            {
                dt = dt.AddMonths(3);
            }
            else
            {
                if (jfd > 500.0 && jfd <= 1000.0)
                {
                    dt = dt.AddMonths(6);
                }
                else
                {
                    if (jfd > 1000.0)
                    {
                        dt = dt.AddYears(1);
                    }
                }
            }
            string sql2 = string.Concat(new object[]
			{
				"insert into xfj (username,jf,gtimes) values('",
				username,
				"',",
				jf,
				",'",
				dt,
				"')"
			});
            new SqlHelper().ExecuteNonQuery(sql2);
        }
        else
        {
            if (cao == "扣除")
            {
                dqjf = (System.Convert.ToDouble(get.xfj(username)) - System.Convert.ToDouble(jf)).ToString();
                get.xfj_jian(username, jf);
            }
        }
        SqlParameter[] op = new SqlParameter[]
		{
			new SqlParameter("@username", username),
			new SqlParameter("@cao", cao),
			new SqlParameter("@jf", jf),
			new SqlParameter("@dqjf", dqjf),
			new SqlParameter("@bz", bz),
			new SqlParameter("@times", times)
		};
        string sql3 = "insert into xfj_jilu (username,cao,jf,dqjf,bz,times) values(@username,@cao,@jf,@dqjf,@bz,@times)";
        new SqlHelper().ExecuteNonQuery(sql3, op);
    }
    public static string ying(object v)
    {
        string zhi = v.ToString();
        string fig;
        if (zhi.Length > 8)
        {
            fig = zhi.Substring(0, 3) + "****" + zhi.Substring(zhi.Length - 4, 4);
        }
        else
        {
            fig = "*****";
        }
        return fig;
    }
    public static string ztdis(object v)
    {
        string fig = "dis";
        int zt = System.Convert.ToInt32(v);
        if (zt > 2)
        {
            fig = "";
        }
        return fig;
    }
    public static string username_id(object username)
    {
        return new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
    }
    public static string username(object username_id)
    {
        if (username_id != null && username_id.ToString().Length > 0)
        {
            object ob = new SqlHelper().ExecuteScalar("select [username] from username where id = " + username_id);

            if (ob != null)
            {
                return ob.ToString();
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }


    }
    public static string tj_username(object username)
    {
        string fig = "";
        if (username.ToString() != "")
        {
            fig = new SqlHelper().ExecuteScalar("select tj_username from username where username = '" + username + "'");
            if (fig != "")
            {
                fig = get.username(fig);
            }
        }
        return fig;
    }


    public static string ren(object username)
    {
        string username_id = new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
        if (username_id != "")
        {
            string sql = "select count(id) from username where tj_username = " + username_id + " ";
            string fig = new SqlHelper().ExecuteScalar(sql);
            if (fig == "")
            {
                fig = "0";
            }
            return fig;
        }
        else
        {
            return "";
        }


    }
    public static string dlren(object username)
    {
        string sqlw = "";
        string dq_jb = get.jb_dq(username);
        if (dq_jb == "1")
        {
            string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + username + "'");
            if (!string.IsNullOrEmpty(dl_sheng))
            {
                sqlw = sqlw + " and s_sheng = " + dl_sheng + " ";
            }
        }
        else
        {
            if (dq_jb == "2")
            {
                string dl_shi = new SqlHelper().ExecuteScalar("select dl_shi from username where username = '" + username + "'");
                if (!string.IsNullOrEmpty(dl_shi))
                {
                    sqlw = sqlw + " and s_shi = " + dl_shi + " ";
                }
            }
            else
            {
                if (dq_jb == "3")
                {
                    string dl_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + username + "'");
                    if (!string.IsNullOrEmpty(dl_xian))
                    {
                        sqlw = sqlw + " and s_xian = " + dl_xian + " ";
                    }
                }
            }
        }
        string sql = "select count(id) from username where id <> 0 " + sqlw;
        if (dq_jb == "6")
        {
            string ifdv = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + username + "'");
            if (ifdv == "1")
            {
                sql = "select dvaf from username where username = '" + username + "'";
            }
        }
        string fig = new SqlHelper().ExecuteScalar(sql);
        if (fig == "")
        {
            fig = "0";
        }
        return fig;
    }
    public static string ren_sj(object username)
    {
        string username_id = new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
        string sql = "select count(id) from username where yj_tj_username = " + username_id + " ";
        return new SqlHelper().ExecuteScalar(sql);
    }
    public static string zren(object username)
    {
        string jb = new SqlHelper().ExecuteScalar("select jb from username where username = '" + username + "'");
        string username_id = new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
        string s = "select id from username where tj_username in (select id from username where tj_username = " + username_id + ")";
        string s2 = "select id from username where tj_username = " + username_id;
        string s3 = username_id;
        string sql = string.Concat(new string[]
		{
			"select count(id) from username where tj_username in (",
			s,
			") or tj_username in (",
			s2,
			") or tj_username in (",
			s3,
			") "
		});
        return new SqlHelper().ExecuteScalar(sql);
    }
    public static string jfcaostr(object cao, object jf)
    {
        string fig = "";
        if (cao.ToString() == "1")
        {
            fig = "<span style='color:#D13D3D;'>+" + jf + "</span>";
        }
        else
        {
            if (cao.ToString() == "2")
            {
                fig = "<span style='color:green;'>-" + jf + "</span>";
            }
        }
        return fig;
    }
    public static string jfzt(object zt)
    {
        string fig = "";
        if (zt.ToString() == "1")
        {
            fig = "提现中(预计2-3个工作日)";
        }
        return fig;
    }
    public static string address_str(object id, object sv)
    {
        return new SqlHelper().ExecuteScalar(string.Concat(new object[]
		{
			"select ",
			sv,
			" from address where id = ",
			id
		}));
    }
    public static string jb(object username)
    {
        string fig;
        if (username.ToString().Length == 1)
        {
            fig = new SqlHelper().ExecuteScalar("select s" + username + " from jb where id = 1");
        }
        else
        {
            string jb = new SqlHelper().ExecuteScalar("select jb from username where username = '" + username + "'");
            int ord = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt >= 2 and price >=3580 and username = '" + username + "'"));
            if (jb == "6")
            {
                string ifdv = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + username + "'");

                if (ord == 0)
                {
                    fig = "挚友";
                }
                else
                {
                    fig = "挚友";
                    //fig = new SqlHelper().ExecuteScalar("select s" + jb + " from jb where id = 1");
                }

            }
            else
            {
                fig = new SqlHelper().ExecuteScalar("select s" + jb + " from jb where id = 1");
            }

            if (jb == "1")
            {
                string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + username + "'");
                dl_sheng = get.s_sheng(dl_sheng);
                fig = dl_sheng + fig;
            }
            else
            {
                if (jb == "2")
                {
                    string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + username + "'");
                    string dl_shi = new SqlHelper().ExecuteScalar("select dl_shi from username where username = '" + username + "'");
                    dl_shi = get.s_sheng(dl_sheng) + get.s_shi(dl_shi);
                    fig = dl_shi + fig;
                }
                else
                {
                    if (jb == "3")
                    {
                        string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + username + "'");
                        string dl_shi = new SqlHelper().ExecuteScalar("select dl_shi from username where username = '" + username + "'");
                        string dl_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + username + "'");
                        dl_xian = get.s_sheng(dl_sheng) + get.s_shi(dl_shi) + get.s_xian(dl_xian);
                        fig = dl_xian + fig;
                    }
                }
            }
        }
        return fig;
    }

    public static string jb2(object username)
    {
        string fig = "";
        if (username.ToString().Length == 1)
        {
            fig = new SqlHelper().ExecuteScalar("select s" + username + " from jb where id = 1");
        }
        else
        {
            string jb = new SqlHelper().ExecuteScalar("select jb2 from username where username = '" + username + "'");
            int ord = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt > 1 and username = '" + username + "'"));
            if (jb != "0")
            {
                // string ifdv = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + username + "'");



                fig = new SqlHelper().ExecuteScalar("select s" + jb + " from jb where id = 1");


            }

        }
        return fig;
    }


    public static string jb_dq(object username)
    {
        return new SqlHelper().ExecuteScalar("select jb from username where username = '" + username + "'");
    }
    public static string jb_dq2(object username)
    {
        return new SqlHelper().ExecuteScalar("select jb2 from username where username = '" + username + "'");
    }
    public static string q3h4(string phone)
    {
        string fig = "";
        try
        {
            string q3 = phone.Substring(0, 3);
            string h4 = phone.Substring(phone.Length - 4, 4);
            fig = q3 + "****" + h4;
        }
        catch (System.Exception)
        {
            fig = phone;
        }
        return fig;
    }
    public static string zt(object id)
    {
        string fig = "";
        if (id.ToString() == "1")
        {
            fig = "待付款";
        }
        else
        {
            if (id.ToString() == "2")
            {
                fig = "<span style='color:red;'>已付款</span>";
            }
            else
            {
                if (id.ToString() == "3")
                {
                    fig = "<span style='color:green;'>已发货</span>";
                }
                else
                {
                    if (id.ToString() == "4")
                    {
                        fig = "<span style='color:green;'>交易完成</span>";
                    }
                }
            }
        }
        return fig;
    }
    public static void mo(object username)
    {
        string sid = new SqlHelper().ExecuteScalar("select id from address where username = '" + username + "' and mo = 1");
        if (sid == "")
        {
            string sqlid = new SqlHelper().ExecuteScalar("select top 1 id from address where username = '" + username + "' order by id");
            if (sqlid != "")
            {
                new SqlHelper().ExecuteNonQuery("update address set mo = 1 where id = " + sqlid);
            }
        }
    }
    public static double jg(object id, HttpRequest Request)
    {
        double fig = 0.0;
        string value = new SqlHelper().ExecuteScalar("select s2 from merchandise where id = " + id);
        if (!string.IsNullOrEmpty(value))
        {
            fig = System.Convert.ToDouble(value);
        }

        /*
        if (Request.Cookies["username"] != null)
        {
            string username = get.context.Server.UrlDecode(Request.Cookies["username"].Value);
            fig = get.jg(id, username);
        }
        else
        {
            string value = new SqlHelper().ExecuteScalar("select s2 from merchandise where id = " + id);
            if (!string.IsNullOrEmpty(value))
            {
                fig = System.Convert.ToDouble(value);
            }
        }*/
        return fig;
    }
    public static double fh(object id, string zt)
    {
        double fig = 0.0;
        string fhstr = new SqlHelper().ExecuteScalar(string.Concat(new object[]
		{
			"select ",
			zt,
			" from merchandise where id = ",
			id
		}));
        if (!string.IsNullOrEmpty(fhstr))
        {
            fig = System.Convert.ToDouble(fhstr);
        }
        return fig;
    }
    public static double jg(object id, string username)
    {
        double fig = 0.0;
        string jb = get.jb_dq(username);
        string jssv = "s2";
        if (jb == "1")
        {
            jssv = "price_sheng";
        }
        else
        {
            if (jb == "2")
            {
                jssv = "price_shi";
            }
            else
            {
                if (jb == "3")
                {
                    jssv = "price_xian";
                }
                else
                {
                    if (jb == "6")
                    {
                        string ifdv = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + username + "'");
                        if (ifdv == "1")
                        {
                            jssv = "price_dv";
                        }
                    }
                }
            }
        }
        string mprice = new SqlHelper().ExecuteScalar(string.Concat(new object[]
		{
			"select ",
			jssv,
			" from merchandise where id = ",
			id
		}));
        if (!string.IsNullOrEmpty(mprice) && mprice != "0.00")
        {
            fig = System.Convert.ToDouble(mprice);
        }
        else
        {
            string value = new SqlHelper().ExecuteScalar("select s2 from merchandise where id = " + id);
            if (!string.IsNullOrEmpty(value))
            {
                fig = System.Convert.ToDouble(value);
            }
        }
        return fig;
    }
    public static void username_sj(object username)
    {
        if (username.ToString() != "")
        {
            int username_jb = System.Convert.ToInt32(get.jb_dq(username));
            int ren = System.Convert.ToInt32(get.ren(username));
            string tj_username = get.tj_username(username);
            int tj_uername_jb = System.Convert.ToInt32(get.jb_dq(tj_username));
            if (username_jb + 1 < tj_uername_jb)
            {
                if (ren >= 10 && tj_uername_jb < 3)
                {
                    new SqlHelper().ExecuteNonQuery("update username set jb = 3 where username = '" + username + "'");
                }
                else
                {
                    if (ren >= 5 && tj_uername_jb < 4)
                    {
                        new SqlHelper().ExecuteNonQuery("update username set jb = 4 where username = '" + username + "'");
                    }
                }
            }
        }
    }
    public static double zk(object v)
    {
        double fig = 0.0;
        string vk = new SqlHelper().ExecuteScalar("select s" + v + "_zhe from jb where id = 1");
        if (!string.IsNullOrEmpty(vk))
        {
            fig = System.Convert.ToDouble(vk) / 100.0;
        }
        return fig;
    }
    public static string m_str(object s1, object s2)
    {
        return new access().ExecuteScalar(string.Concat(new object[]
		{
			"select ",
			s2,
			" from merchandise where id = ",
			s1
		}));
    }
    public static string yk_one_name(object id)
    {
        return new access().ExecuteScalar("select name from yk_one where id = " + id);
    }
    public static string yk_two_name(object id)
    {
        return new access().ExecuteScalar("select name from yk_two where id = " + id);
    }
    public static string yk_two_ku(object id)
    {
        return new SqlHelper().ExecuteScalar("select ku from yk_two where id = " + id);
    }
    public static string gethtml(int id)
    {
        string fig = string.Empty;
        string sqlstring = "select ntest from sisu where id=" + id.ToString();
        using (DataTable dt = new access().ExecuteDataTable(sqlstring))
        {
            foreach (DataRow r in dt.Rows)
            {
                fig = r["ntest"].ToString();
            }
        }
        return fig;
    }
    public static string ltype(object v)
    {
        string fig = "";
        if (v.ToString() == "1")
        {
            fig = "内容";
        }
        else
        {
            if (v.ToString() == "2")
            {
                fig = "背景";
            }
            else
            {
                if (v.ToString() == "3")
                {
                    fig = "链接";
                }
            }
        }
        return fig;
    }
    public static string nyrsfm()
    {
        System.DateTime now = System.DateTime.Now;
        System.Random rd = new System.Random();
        return string.Concat(new object[]
		{
			now.Year,
			now.Month,
			now.Hour,
			now.Minute,
			now.Second,
			now.Millisecond,
			rd.Next(0, 10000)
		});
    }
    public static string yd()
    {
        return " 技术支持：<a href=\"http://www.jhzwz.com/\" target=\"_blank\">易点网络</a>";
    }
    public static string txt(object ob)
    {
        return ob.ToString().Replace(char.ConvertFromUtf32(32), "&nbsp;").Replace("\r\n", "<br />");
    }
    public static string kong(object str, string img)
    {
        string fig = img;
        if (str.ToString() == "")
        {
            fig = "";
        }
        return fig;
    }
    public static string js(int id)
    {
        string fig = string.Empty;
        string sqlstring = "select js from wzinfo where id=" + id.ToString();
        using (DataTable dt = new access().ExecuteDataTable(sqlstring))
        {
            foreach (DataRow r in dt.Rows)
            {
                fig = r["js"].ToString();
            }
        }
        return fig;
    }
    public static string llint(object id)
    {
        string fig = string.Empty;
        string sqlstring = "select llint from merchandise where id=" + id.ToString();
        using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
        {
            foreach (DataRow r in dt.Rows)
            {
                fig = r["llint"].ToString();
            }
        }
        return fig;
    }
    public static string gang(int i, string str)
    {
        string fig = str;
        if (i == 0)
        {
            fig = "";
        }
        return fig;
    }
    public static string hang(int i, string str)
    {
        string fig = str;
        if (i != 0)
        {
            fig = "";
        }
        return fig;
    }
    public static void del_file(string path)
    {
        try
        {
            if (System.IO.File.Exists(get.context.Server.MapPath(path)))
            {
                System.IO.File.Delete(get.context.Server.MapPath(path));
            }
        }
        catch (System.Exception)
        {
        }
    }
    public static string gethtml_name(int id)
    {
        string fig = string.Empty;
        string sqlstring = "select username from sisu where id=" + id.ToString();
        using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
        {
            foreach (DataRow r in dt.Rows)
            {
                fig = r["username"].ToString();
            }
        }
        return fig;
    }
    public static string logoimg()
    {
        return new access().ExecuteScalar("select logo from wzinfo where id=1").ToString();
    }
    public static string bottom()
    {
        return new access().ExecuteScalar("select Copyright from wzinfo where id=1").ToString();
    }
    public static string logoimg_en()
    {
        return new access().ExecuteScalar("select logo from wzinfo where id=2").ToString();
    }
    public static string bottom_en()
    {
        return new access().ExecuteScalar("select Copyright from wzinfo where id=2").ToString();
    }
    public static string get_y_r(object ob)
    {
        System.DateTime dt = System.Convert.ToDateTime(ob);
        return dt.Month + "-" + dt.Day;
    }
    public static void ol()
    {
        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from merchandise where id=1"))
        {
            foreach (DataRow r in dt.Rows)
            {
                using (DataTable dt2 = new SqlHelper().ExecuteDataTable("select * from type_two where type in (2) "))
                {
                    foreach (DataRow r2 in dt2.Rows)
                    {
                        string sql = string.Concat(new object[]
						{
							"insert into merchandise (name,type_two_id,iftj,x_img,d_img,guige,title,keyname,counts,nrtext,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,llint,px,times) values('",
							r["name"],
							"','",
							r2["id"],
							"',",
							r["iftj"],
							",'",
							r["x_img"],
							"','",
							r["d_img"],
							"','",
							r["guige"],
							"','",
							r["title"],
							"','",
							r["keyname"],
							"','",
							r["counts"],
							"','",
							r["nrtext"],
							"','",
							r["s1"],
							"','",
							r["s2"],
							"','",
							r["s3"],
							"','",
							r["s4"],
							"','",
							r["s5"],
							"','",
							r["s6"],
							"','",
							r["s7"],
							"','",
							r["s8"],
							"','",
							r["s9"],
							"','",
							r["s10"],
							"','",
							r["s11"],
							"','",
							r["s12"],
							"','",
							r["s13"],
							"','",
							r["s14"],
							"','",
							r["s15"],
							"','",
							r["s16"],
							"','",
							r["s17"],
							"','",
							r["s18"],
							"','",
							r["s19"],
							"','",
							r["s20"],
							"','",
							r["s21"],
							"','",
							r["s22"],
							"','",
							r["s23"],
							"','",
							r["s24"],
							"','",
							r["s25"],
							"','",
							r["s26"],
							"','",
							r["s27"],
							"','",
							r["s28"],
							"','",
							r["s29"],
							"','",
							r["s30"],
							"',",
							r["llint"],
							",",
							r["px"],
							",'",
							r["times"],
							"')"
						});
                        for (int i = 0; i < 10; i++)
                        {
                            new SqlHelper().ExecuteNonQuery(sql);
                        }
                    }
                }
            }
        }
        new SqlHelper().ExecuteNonQuery("update merchandise set px=id ");
    }
    public static string ynimg(object img)
    {
        string fig = string.Empty;
        try
        {
            System.IO.FileInfo fi2 = new System.IO.FileInfo(get.context.Server.MapPath(img.ToString()));
            if (fi2.Exists)
            {
                fig = img.ToString();
            }
            else
            {
                fig = "/images/bmjj-1.jpg";
            }
        }
        catch (System.Exception)
        {
        }
        return fig;
    }
    public static string get_Time_n_y_r()
    {
        return string.Concat(new object[]
		{
			System.DateTime.Now.Year,
			"年",
			System.DateTime.Now.Month,
			"月",
			System.DateTime.Now.Day,
			"日"
		});
    }
    public static string getTime_DayOfWeek()
    {
        string week = "";
        string text = System.DateTime.Today.DayOfWeek.ToString();
        switch (text)
        {
            case "Monday":
                week = "星期一 ";
                break;
            case "Tuesday":
                week = "星期二 ";
                break;
            case "Wednesday":
                week = "星期三 ";
                break;
            case "Thursday":
                week = "星期四 ";
                break;
            case "Friday":
                week = "星期五 ";
                break;
            case "Saturday":
                week = "星期六 ";
                break;
            case "Sunday":
                week = "星期日 ";
                break;
        }
        return week;
    }
    public static string imgwh(object img, int width, int height)
    {
        string fig = "";
        try
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(get.context.Server.MapPath(img.ToString()));
            int photoWidth = image.Width;
            int photoHeight = image.Height;
            fig = " src='" + img + "'";
            if (photoWidth >= photoHeight)
            {
                object obj = fig;
                fig = string.Concat(new object[]
				{
					obj,
					" width=",
					width,
					" "
				});
            }
            else
            {
                object obj = fig;
                fig = string.Concat(new object[]
				{
					obj,
					" height=",
					height,
					" "
				});
            }
            image.Dispose();
        }
        catch (System.Exception)
        {
        }
        return fig;
    }
    public static string gsstr()
    {
        string fig = string.Empty;
        return new access().ExecuteScalar("select gsname from wzinfo where id=1").ToString();
    }
    public static string gsstr_en()
    {
        string fig = string.Empty;
        return new access().ExecuteScalar("select gsname from wzinfo where id=2").ToString();
    }
    public static string getflash()
    {
        string fig = string.Empty;
        using (DataTable dt = new access().ExecuteDataTable("select * from wzinfo where id=1"))
        {
            foreach (DataRow r in dt.Rows)
            {
                string str = "";
                string lj = "";
                int i = 1;
                if (r["img1"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img1"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj1"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img2"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img2"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj2"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img3"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img3"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj3"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img4"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img4"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj4"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img5"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img5"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj5"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img6"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img6"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj6"].ToString(),
						"';"
					});
                    i++;
                }
                fig = lj + "\n" + str;
            }
        }
        return fig;
    }
    public static string getflash2()
    {
        string fig = "";
        string texts = "";
        string str = "";
        string lj = "";
        string result;
        using (DataTable dt = new access().ExecuteDataTable("select * from wzinfo where id=1"))
        {
            foreach (DataRow r in dt.Rows)
            {
                int i = 1;
                if (r["img7"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img7"].ToString();
                        lj += r["lj7"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img7"].ToString();
                        lj = lj + "|" + r["lj7"].ToString();
                    }
                    i++;
                }
                if (r["img8"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img8"].ToString();
                        lj += r["lj8"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img8"].ToString();
                        lj = lj + "|" + r["lj8"].ToString();
                    }
                    i++;
                }
                if (r["img9"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img9"].ToString();
                        lj += r["lj9"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img9"].ToString();
                        lj = lj + "|" + r["lj9"].ToString();
                    }
                    i++;
                }
                if (r["img10"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img10"].ToString();
                        lj += r["lj10"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img10"].ToString();
                        lj = lj + "|" + r["lj10"].ToString();
                    }
                    i++;
                }
                if (r["img11"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img11"].ToString();
                        lj += r["lj11"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img11"].ToString();
                        lj = lj + "|" + r["lj11"].ToString();
                    }
                    i++;
                }
                if (r["img12"].ToString() != "")
                {
                    if (str == "")
                    {
                        str += r["img12"].ToString();
                        lj += r["lj12"].ToString();
                    }
                    else
                    {
                        str = str + "|" + r["img12"].ToString();
                        lj = lj + "|" + r["lj12"].ToString();
                    }
                    i++;
                }
            }
            fig = fig + "var pics = '" + str + "';";
            fig = fig + "var links = '" + lj + "';";
            fig = fig + "var texts = '" + texts + "';";
            result = fig;
        }
        return result;
    }
    public static string getflash_en()
    {
        string fig = string.Empty;
        using (DataTable dt = new access().ExecuteDataTable("select * from wzinfo where id=2"))
        {
            foreach (DataRow r in dt.Rows)
            {
                string str = "";
                string lj = "";
                int i = 1;
                if (r["img1"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img1"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj1"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img2"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img2"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj2"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img3"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img3"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj3"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img4"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img4"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj4"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img5"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img5"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj5"].ToString(),
						"';"
					});
                    i++;
                }
                if (r["img6"].ToString() != "")
                {
                    string text = str;
                    str = string.Concat(new string[]
					{
						text,
						"picarr[",
						i.ToString(),
						"]='",
						r["img6"].ToString(),
						"';"
					});
                    text = lj;
                    lj = string.Concat(new string[]
					{
						text,
						"linkarr[",
						i.ToString(),
						"] = '",
						r["lj6"].ToString(),
						"';"
					});
                    i++;
                }
                fig = lj + "\n" + str;
            }
        }
        return fig;
    }
    public static string html_name(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select name from html where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string news_name(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select name from news_name where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string meb_name(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select type_one_name from type_one where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string name(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select name from merchandise where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string meb_two_name(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select type_two_name from type_two where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string nt(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select nt from type_two where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string meb_name_en(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select type_one_name_en from type_one where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string name_en(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select name_en from merchandise where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string meb_two_name_en(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select type_two_name_en from type_two where id=" + id);
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string meb_name_id(int id)
    {
        string fig = "";
        object ob = new access().ExecuteScalar("select top 1 id from type_two where type_one_id=" + id + " order by px");
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string geturl(string url)
    {
        HttpWebRequest request = null;
        HttpWebResponse response = null;
        System.IO.StreamReader reader = null;
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        string result;
        try
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 20000;
            request.AllowAutoRedirect = false;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1048576L)
            {
                if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    reader = new System.IO.StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), encoding);
                }
                else
                {
                    reader = new System.IO.StreamReader(response.GetResponseStream(), encoding);
                }
                string html = reader.ReadToEnd();
                result = html;
                return result;
            }
        }
        catch
        {
        }
        finally
        {
            if (response != null)
            {
                response.Close();
                response = null;
            }
            if (reader != null)
            {
                reader.Close();
            }
            if (request != null)
            {
                request = null;
            }
        }
        result = string.Empty;
        return result;
    }
    public static string Video(int width, int height, object flv, object img)
    {
        string fig = "";
        fig += "<!--[if !IE 6]><!-->";
        object obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"<object width=\"",
			width,
			"\" height=\"",
			height,
			"\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\">"
		});
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <param name=\"movie\" value=\"/js/Flvplayer.swf?file=",
			flv,
			"&image=",
			img,
			"\">"
		});
        fig += "    <param name=\"quality\" value=\"high\">";
        fig += "    <param name=\"allowfullscreen\" value=\"true\">";
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <embed width=\"",
			width,
			"\" height=\"",
			height,
			"\" allowfullscreen=\"true\" src=\"/js/Flvplayer.swf?file=",
			flv,
			"&image=",
			img,
			"\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\"></embed>"
		});
        fig += "</object>";
        fig += "<!--<![endif]-->";
        fig += "<!--[if IE 6]>";
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"<object width=\"",
			width,
			"\" height=\"",
			height,
			"\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\">"
		});
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <param name=\"movie\" value=\"/js/Flvplayer.swf?file=",
			flv,
			"\">"
		});
        fig += "    <param name=\"quality\" value=\"high\">";
        fig += "    <param name=\"allowfullscreen\" value=\"true\">";
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <embed width=\"",
			width,
			"\" height=\"",
			height,
			"\" allowfullscreen=\"true\" src=\"/js/Flvplayer.swf?file=",
			flv,
			"\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\"></embed>"
		});
        fig += "</object>";
        return fig + "<!--<![endif]-->";
    }
    public static string Video(int width, int height, object flv)
    {
        string fig = "";
        object obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"<object width=\"",
			width,
			"\" height=\"",
			height,
			"\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\">"
		});
        fig += "    <param name=\"movie\" value=\"/images/flv.swf\" />";
        fig += "    <param name=\"quality\" value=\"high\" />";
        fig += "    <param name=\"allowFullScreen\" value=\"true\" />";
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <param name=\"FlashVars\" value=\"vcastr_file=",
			flv,
			"\" />"
		});
        fig += "    <param name=\"wmode\" value=\"transparent\" />";
        obj = fig;
        fig = string.Concat(new object[]
		{
			obj,
			"    <embed width=\"",
			width,
			"\" height=\"",
			height,
			"\" wmode='transparent' allowfullscreen=\"true\" flashvars=\"vcastr_file=",
			flv,
			"\" pluginspage=\"http://www.hbjinyan.com/go/getflashplayer\" quality=\"high\" src=\"/images/flv.swf\" type=\"application/x-shockwave-flash\"></embed>"
		});
        return fig + "</object>";
    }
    public static string post(string uri, string postData)
    {
        string result;
        try
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);
            Uri uRI = new Uri(uri);
            HttpWebRequest req = WebRequest.Create(uRI) as HttpWebRequest;
            req.Method = "POST";
            req.KeepAlive = true;
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = (long)data.Length;
            req.AllowAutoRedirect = true;
            System.IO.Stream outStream = req.GetRequestStream();
            outStream.Write(data, 0, data.Length);
            outStream.Close();
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            System.IO.Stream inStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(inStream, System.Text.Encoding.UTF8);
            string htmlResult = sr.ReadToEnd();
            result = htmlResult;
        }
        catch (System.Exception ex)
        {
            result = "网络错误：" + ex.Message.ToString();
        }
        return result;
    }
    public static string post(string url)
    {
        string result;
        try
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] data = encoding.GetBytes(url);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentLength = (long)data.Length;
            System.IO.Stream outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Flush();
            outstream.Close();
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            System.IO.Stream instream = response.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(instream, encoding);
            string content = sr.ReadToEnd();
            result = content;
        }
        catch (System.Exception ex)
        {
            result = "网络错误：" + ex.Message.ToString();
        }
        return result;
    }
    public static string upload(object s1, object s2)
    {
        string s3 = "";
        string fig = new SqlHelper().ExecuteScalar("select fig from Uploadify where id = 1");
        if (fig == "1")
        {
            object obj = s3;
            s3 = string.Concat(new object[]
			{
				obj,
				"<script>$(function () { StartUploadify_two('fupd",
				s1,
				s2,
				"', '",
				s1,
				"','",
				s2,
				"'); })</script>"
			});
            obj = s3;
            s3 = string.Concat(new object[]
			{
				obj,
				"<input id=\"fupd",
				s1,
				s2,
				"\" type=\"file\" />"
			});
        }
        else
        {
            if (fig == "2")
            {
                s3 = string.Concat(new object[]
				{
					"<input type=\"button\" value=\"上传\" onclick=\"chuan_two('",
					s1,
					"','",
					s2,
					"');\" />"
				});
            }
        }
        return s3;
    }
    public static string upload(object s1)
    {
        string s2 = "";
        string fig = new SqlHelper().ExecuteScalar("select fig from Uploadify where id = 1");
        if (fig == "1")
        {
            object obj = s2;
            s2 = string.Concat(new object[]
			{
				obj,
				"<script>$(function () { StartUploadify('fupd",
				s1,
				"', '",
				s1,
				"'); })</script>"
			});
            obj = s2;
            s2 = string.Concat(new object[]
			{
				obj,
				"<input id=\"fupd",
				s1,
				"\" type=\"file\" />"
			});
        }
        else
        {
            if (fig == "2")
            {
                s2 = "<input type=\"button\" value=\"上传\" onclick=\"chuan_one('" + s1 + "');\" />";
            }
        }
        return s2;
    }
    public static string upload_yzm(object s1)
    {
        string s2 = "";
        string fig = new SqlHelper().ExecuteScalar("select fig from Uploadify where id = 1");
        if (fig == "1")
        {
            object obj = s2;
            s2 = string.Concat(new object[]
			{
				obj,
				"<script>$(function () { StartUploadify_yzm('fupd",
				s1,
				"', '",
				s1,
				"'); })</script>"
			});
            obj = s2;
            s2 = string.Concat(new object[]
			{
				obj,
				"<input id=\"fupd",
				s1,
				"\" type=\"file\" />"
			});
        }
        else
        {
            if (fig == "2")
            {
                s2 = "<input type=\"button\" value=\"上传\" onclick=\"chuan_one_yzm('" + s1 + "');\" />";
            }
        }
        return s2;
    }
    public static void xg_imgwd(string src, int _width)
    {
        try
        {
            string path = get.context.Server.MapPath(src);
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            System.Drawing.Imaging.ImageFormat thisFormat = image.RawFormat;
            int dqkd = image.Width;
            int dqgh = image.Height;
            double xgb = System.Convert.ToDouble(_width) / System.Convert.ToDouble(dqkd);
            int fixHeight = System.Convert.ToInt32(System.Convert.ToDouble(dqgh) * xgb);
            System.Drawing.Bitmap imageOutput = new System.Drawing.Bitmap(image, _width, fixHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(imageOutput);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, new System.Drawing.Rectangle(0, 0, _width, fixHeight), 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
            long[] quality = new long[]
			{
				100L
			};
            System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            System.Drawing.Imaging.ImageCodecInfo[] arrayICI = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            System.Drawing.Imaging.ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];
                    break;
                }
            }
            image.Dispose();
            if (jpegICI != null)
            {
                imageOutput.Save(path, jpegICI, encoderParams);
            }
            else
            {
                imageOutput.Save(path, thisFormat);
            }
            imageOutput.Dispose();
        }
        catch (System.Exception ex_163)
        {
        }
    }
}
