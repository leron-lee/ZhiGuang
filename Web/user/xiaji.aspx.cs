using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class xiaji : System.Web.UI.Page
    {

        public string fystr;
        public string username;
        public string username_id;
        public string jb;
        public string ren = "0";
        public string zren = "0";
        public string xjb = "0";
        public string v = "1";
        public string xian_dis = "dis";
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["username"] != null)
                {
                    this.username = base.Request.QueryString["username"];
                }
                this.xjb = get.jb_dq(this.username);
                if (base.Request.QueryString["v"] != null)
                {
                    this.v = base.Request.QueryString["v"];
                }
                this.username_id = get.username_id(this.username);
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.jb = get.jb(r["username"]);
                        this.ren = get.ren(r["username"]);
                        this.zren = get.zren(r["username"]);
                    }
                }
                if (this.xjb == "3")
                {
                    this.xian_dis = "";
                }
                if (base.Request.QueryString["lei"] != null)
                {
                    this.fy2();
                }
                else
                {
                    this.fy1();
                }
            }
        }
        public void fy1()
        {
            int x = 12;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "&username=" + this.username + "&v=" + this.v;
            string sqlw = " and tj_username = " + this.username_id + " ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from username where id <> 0 ",
					sqlw,
					" order by id desc"
				});
            }
            else
            {
                string sqlabc = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from username where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string nid = new SqlHelper().ExecuteScalar("select top 1 id from username where id in (" + sqlabc + ") order by id");
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from username where id <> 0 and id < ",
					nid,
					" ",
					sqlw,
					" order by id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "username where id <> 0 " + sqlw, url, p, "pagex", "id", 2);
        }
        public void fy2()
        {
            int x = 12;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "&lei=dl";
            string sqlw = " and id <> " + this.username_id + " ";
            if (this.xjb == "1")
            {
                string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + this.username + "'");
                sqlw = sqlw + " and s_sheng = " + dl_sheng + " ";
            }
            else
            {
                if (this.xjb == "2")
                {
                    string dl_shi = new SqlHelper().ExecuteScalar("select dl_shi from username where username = '" + this.username + "'");
                    sqlw = sqlw + " and s_shi = " + dl_shi + " ";
                }
                else
                {
                    if (this.xjb == "3")
                    {
                        string dl_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + this.username + "'");
                        sqlw = sqlw + " and s_xian = " + dl_xian + " ";
                    }
                    else
                    {
                        if (this.jb != "授权大V")
                        {
                            sqlw += " and id < 1 ";
                        }
                    }
                }
            }
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from username where id <> 0 ",
					sqlw,
					" order by id desc"
				});
            }
            else
            {
                string sqlabc = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from username where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string nid = new SqlHelper().ExecuteScalar("select top 1 id from username where id in (" + sqlabc + ") order by id");
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from username where id <> 0 and id < ",
					nid,
					" ",
					sqlw,
					" order by id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater2.DataSource = dt;
                this.Repeater2.DataBind();
            }
            this.zren = new SqlHelper().ExecuteScalar("select count(id) from username where id <> 0 " + sqlw);
            this.ren = new SqlHelper().ExecuteScalar("select count(id) from username where id <> 0 " + sqlw + " and tj_username = " + this.username_id);
            this.fystr = en_page.fystr_one(x, "username where id <> 0 " + sqlw, url, p, "pagex", "id", 2);
        }
    }
}