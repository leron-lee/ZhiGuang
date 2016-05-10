using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wzinfo
{
    public partial class html : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.TextBox3.Text = new SqlHelper().ExecuteScalar("select hm from sheng where id = 1");
                int ym = 1;
                ym += System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from type_two"));
                ym += System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from merchandise"));
                int miao = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select miao from sheng where id = 1"));
                int shu = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select shu from sheng where id = 1"));
                try
                {
                    if (shu > 1)
                    {
                        ym = shu;
                    }
                    int sudu = ym / miao;
                    this.ym.Text = string.Concat(new object[]
					{
						"您上次的全站生成一共<span style='color:red;'>",
						ym,
						"</span>个页面，速度是一秒<span style='color:red;'>",
						sudu,
						"</span>个页面，花费了约<span style='color:red;'>",
						ym / sudu,
						"</span>秒钟时间"
					});
                }
                catch (System.Exception)
                {
                }
            }
        }
        public int GetAllFiles(System.IO.DirectoryInfo dir)
        {
            int i = 0;
            System.IO.FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            System.IO.FileSystemInfo[] array = fileinfo;
            for (int k = 0; k < array.Length; k++)
            {
                System.IO.FileSystemInfo j = array[k];
                if (j is System.IO.DirectoryInfo)
                {
                    this.GetAllFiles((System.IO.DirectoryInfo)j);
                }
                else
                {
                    i++;
                }
            }
            return i;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            this.del();
        }
        public void del()
        {
            System.IO.FileInfo fl = new System.IO.FileInfo(base.Server.MapPath("/index.html"));
            fl.Delete();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(base.Server.MapPath("/html"));
            System.IO.FileInfo[] f = di.GetFiles();
            System.IO.FileInfo[] array = f;
            for (int i = 0; i < array.Length; i++)
            {
                System.IO.FileInfo myFile = array[i];
                myFile.Delete();
            }
        }
        protected void Button2_Click(object sender, System.EventArgs e)
        {
            System.DateTime startTime = System.DateTime.Now;
            this.del();
            this.one();
            this.two();
            this.three();
            System.DateTime endTime = System.DateTime.Now;
            System.TimeSpan ts = endTime - startTime;
            int miao = ts.Seconds + ts.Minutes * 60;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(base.Server.MapPath("~/html/"));
            int shu = this.GetAllFiles(dir) + 1;
            new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
			{
				"update sheng set miao = ",
				miao,
				",shu=",
				shu,
				" where id = 1"
			}));
            base.Response.Redirect(base.Request.RawUrl);
        }
        protected void Button3_Click(object sender, System.EventArgs e)
        {
            this.one();
        }
        protected void Button4_Click(object sender, System.EventArgs e)
        {
            this.two();
        }
        protected void Button5_Click(object sender, System.EventArgs e)
        {
            this.three();
        }
        public void one()
        {
            string gl = "http://" + base.Request.UrlReferrer.Authority + "/default.aspx";
            string ix = get.geturl(gl);
            ix = this.th(ix);
            string file = base.Server.MapPath("~/index.html");
            using (System.IO.File.Create(file))
            {
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ix);
            }
        }
        public void pro()
        {
            string gl = "http://" + base.Request.UrlReferrer.Authority + "/pro.aspx";
            string ix = get.geturl(gl);
            ix = this.th(ix);
            string file = base.Server.MapPath("~/html/pro.html");
            using (System.IO.File.Create(file))
            {
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ix);
            }
        }
        public void two()
        {
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from type_two"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    string gl = string.Concat(new object[]
					{
						"http://",
						base.Request.UrlReferrer.Authority,
						"/html.aspx?id=",
						r["id"]
					});
                    string ix = get.geturl(gl);
                    ix = this.th(ix);
                    string file = base.Server.MapPath("~/html/" + r["id"] + ".html");
                    using (System.IO.File.Create(file))
                    {
                    }
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
                    {
                        if (r["type"].ToString() != "5")
                        {
                            sw.WriteLine(ix);
                        }
                        else
                        {
                            sw.Write(this.th("<script>location.href='" + r["title"] + "';</script>"));
                        }
                    }
                    int hm = System.Convert.ToInt32(this.TextBox3.Text);
                    System.Threading.Thread.Sleep(hm);
                }
            }
        }
        public void three()
        {
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from merchandise"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    string gl = string.Concat(new object[]
					{
						"http://",
						base.Request.UrlReferrer.Authority,
						"/html_l.aspx?id=",
						r["id"]
					});
                    string ix = get.geturl(gl);
                    ix = this.th(ix);
                    string file = base.Server.MapPath("~/html/page-" + r["id"] + ".html");
                    using (System.IO.File.Create(file))
                    {
                    }
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(ix);
                    }
                    int hm = System.Convert.ToInt32(this.TextBox3.Text);
                    System.Threading.Thread.Sleep(hm);
                }
            }
        }
        public string th(string fig)
        {
            fig = fig.ToLower().Replace("default.aspx", "/index.html");
            fig = fig.ToLower().Replace("Default.aspx", "/index.html");
            fig = fig.Replace("pro.aspx", "/html/pro.html");
            Regex reg = new Regex("(?is)<a[^>]*?href=(['\"]?)(?<url>[^'\"\\s>]+)\\1[^>]*>(?<text>(?:(?!</?a\\b).)*)</a>", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(fig);
            foreach (Match i in mc)
            {
                string url = i.Groups["url"].Value;
                if (url.StartsWith("html.aspx"))
                {
                    string id = url.Substring(13, url.Length - 13);
                    fig = fig.Replace("\"" + url + "\"", "\"/html/" + id + ".html\"");
                    fig = fig.Replace("'" + url + "'", "'/html/" + id + ".html'");
                }
                if (url.ToLower().IndexOf("pagex") > 0)
                {
                    if (url.ToLower().IndexOf("proaspx") > 0)
                    {
                        string nm = url.Replace("?", "").Replace("=", "").Replace("id", "").Replace("&pagex", "-").Replace("proaspx&", "");
                        if (base.Cache[url] == null)
                        {
                            this.pro_fy(url, nm);
                        }
                        string hm = "/html/pro" + nm + ".html";
                        if (fig.IndexOf(url) > -1)
                        {
                            string a = fig.Substring(0, fig.IndexOf(url) + url.Length);
                            string a2 = fig.Substring(fig.IndexOf(url) + url.Length);
                            fig = a.Replace(url, hm) + a2;
                        }
                    }
                    else
                    {
                        string nm = url.Replace("?", "").Replace("=", "").Replace("id", "").Replace("&pagex", "-");
                        if (base.Cache[url] == null)
                        {
                            this.fy(url, nm);
                        }
                        string hm = "/html/" + nm + ".html";
                        if (fig.IndexOf(url) > -1)
                        {
                            string a = fig.Substring(0, fig.IndexOf(url) + url.Length);
                            string a2 = fig.Substring(fig.IndexOf(url) + url.Length);
                            fig = a.Replace(url, hm) + a2;
                        }
                    }
                }
                if (url.StartsWith("html_l.aspx"))
                {
                    string id = url.Substring(15, url.Length - 15);
                    fig = fig.Replace("\"" + url + "\"", "\"/html/page-" + id + ".html\"");
                    fig = fig.Replace("'" + url + "\"", "\"/html/page-" + id + ".html'");
                }
            }
            return fig;
        }
        public void pro_fy(string url, string nm)
        {
            string gl = "http://" + base.Request.UrlReferrer.Authority + "/pro.aspx" + url;
            base.Cache.Insert(url, "", null, System.DateTime.Now.AddDays(1.0), Cache.NoSlidingExpiration);
            string ix = get.geturl(gl);
            ix = this.th(ix);
            string file = base.Server.MapPath("~/html/pro" + nm + ".html");
            using (System.IO.File.Create(file))
            {
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ix);
            }
            int hm = System.Convert.ToInt32(this.TextBox3.Text);
            System.Threading.Thread.Sleep(hm);
        }
        public void fy(string url, string nm)
        {
            string gl = "http://" + base.Request.UrlReferrer.Authority + "/html.aspx" + url;
            base.Cache.Insert(url, "", null, System.DateTime.Now.AddDays(1.0), Cache.NoSlidingExpiration);
            string ix = get.geturl(gl);
            ix = this.th(ix);
            string file = base.Server.MapPath("~/html/" + nm + ".html");
            using (System.IO.File.Create(file))
            {
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ix);
            }
            int hm = System.Convert.ToInt32(this.TextBox3.Text);
            System.Threading.Thread.Sleep(hm);
        }
        public string thbug(string ix)
        {
            Regex reg = new Regex("(?is)<a[^>]*?href=(['\"]?)(?<url>[^'\"\\s>]+)\\1[^>]*>(?<text>(?:(?!</?a\\b).)*)</a>");
            MatchCollection mc = reg.Matches(ix);
            foreach (Match i in mc)
            {
                string url = i.Groups["url"].Value;
                string yurl = url;
                string z = url.Substring(url.Length - 1, 1);
                if (z != "l")
                {
                    url = url.Substring(0, url.Length - 1);
                    if (url.IndexOf(".html") >= 0)
                    {
                    }
                }
                ix = ix.Replace(yurl, url);
            }
            return ix;
        }
        protected void Button6_Click(object sender, System.EventArgs e)
        {
            string st = this.TextBox3.Text;
            int a = new SqlHelper().ExecuteNonQuery("update sheng set hm=" + st + " where id = 1");
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功....');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
    }
}