using System;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class dzp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string fig = "0";
            string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (base.Cache[username + "chou"] == null)
            {
                base.Cache.Insert(username + "chou", "", null, System.DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration);
                System.Random rd = new System.Random();
                if (rd.Next(1, 200) == 1)
                {
                    fig = "6";
                    get.hb_cao(username, "增加", "100", "每日抽奖获得");
                }
                else
                {
                    if (rd.Next(1, 100) == 1)
                    {
                        fig = "5";
                        get.hb_cao(username, "增加", "50", "每日抽奖获得");
                    }
                    else
                    {
                        if (rd.Next(1, 20) == 1)
                        {
                            fig = "4";
                            get.hb_cao(username, "增加", "10", "每日抽奖获得");
                        }
                        else
                        {
                            if (rd.Next(1, 10) == 1)
                            {
                                fig = "3";
                                get.hb_cao(username, "增加", "5", "每日抽奖获得");
                            }
                            else
                            {
                                if (rd.Next(1, 6) == 1)
                                {
                                    fig = "2";
                                    get.hb_cao(username, "增加", "3", "每日抽奖获得");
                                }
                                else
                                {
                                    if (rd.Next(1, 2) == 1)
                                    {
                                        fig = "1";
                                        get.hb_cao(username, "增加", "1", "每日抽奖获得");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                fig = "100";
            }
            base.Response.Write(fig);
            base.Response.End();
        }
    }
}