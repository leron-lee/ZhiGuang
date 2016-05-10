using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class sh_dv : System.Web.UI.Page
    {
        public string fystr;
        public string username;
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["del"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    string url = base.Request.QueryString["url"];
                    new SqlHelper().ExecuteNonQuery("delete from wysdv where id = " + id);
                    base.Response.Redirect(url);
                }
                this.fy();
            }
        }
        public void fy()
        {
            int x = 6;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "";
            string sqlw = "";
            string dl_xian = new SqlHelper().ExecuteScalar("select dl_xian from username where username = '" + this.username + "'");
            sqlw = sqlw + " and s_xian = " + dl_xian + " ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from wysdv where id <> 0 ",
					sqlw,
					" order by id"
				});
            }
            else
            {
                string sqlabc = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from wysdv where id <> 0 ",
					sqlw,
					" order by id"
				});
                string sqlid = "0";
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlabc))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        sqlid = sqlid + "," + r["id"];
                    }
                }
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from wysdv where id <> 0 and id not in (",
					sqlid,
					") ",
					sqlw,
					" order by id"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "wysdv where id <> 0 " + sqlw, url, p, "pagex", "id", 1);
        }
    }
}