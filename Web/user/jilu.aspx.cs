using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class jilu : System.Web.UI.Page
    {
        public string JF;
        public string username;
        public string fystr;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
               // this.JF = new SqlHelper().ExecuteScalar("select JF from username where username = '" + this.username + "'");
                this.fy();
            }
        }
        public void fy()
        {
            string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            int x = 12;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string uks = "";
            string sqlw = " and tj_username = '" + username + "' ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from jilu where id <> 0 ",
					sqlw,
					" order by id desc"
				});
            }
            else
            {
                string zid_sql_one = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from jilu where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string zid_sqltwo = "select top 1 id from jilu where id in (" + zid_sql_one + ") order by id";
                string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from jilu where id <(",
					zid,
					") ",
					sqlw,
					" order by id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "jilu where id <> 0 " + sqlw, uks, p, "pagex", "id", 2);
        }
    }
}