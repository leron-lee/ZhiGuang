using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class dongtai_ye : System.Web.UI.Page
    {
        public string fystr;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.fy();
            }
        }
        public void fy()
        {
            int x = 10;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "";
            string sqlw = "";
            string search_username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            sqlw = sqlw + " and username = '" + search_username + "' ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from ye_jilu where id <> 0 ",
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
					" id from ye_jilu where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string nid = new SqlHelper().ExecuteScalar("select top 1 id from ye_jilu where id in (" + sqlabc + ") order by id");
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from ye_jilu where id <> 0 and id < ",
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
            this.fystr = en_page.fystr_one(x, "ye_jilu where id <> 0 " + sqlw, url, p, "pagex", "id", 2);
        }
    }
}