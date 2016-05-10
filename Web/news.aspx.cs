using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class news : System.Web.UI.Page
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
            int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
            int x = 1000;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string username = "&id=" + id;
            string sqlw = " and type_two_id = " + id + " ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from merchandise where id <> 0 ",
					sqlw,
					" order by px desc"
				});
            }
            else
            {
                string zid_sql_one = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" px from merchandise where id <> 0 ",
					sqlw,
					" order by px desc"
				});
                string zid_sqltwo = "select top 1 px from merchandise where px in (" + zid_sql_one + ") order by px";
                string zid = new access().ExecuteScalar(zid_sqltwo);
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from merchandise where px <(",
					zid,
					") ",
					sqlw,
					" order by px desc"
				});
            }
            using (DataTable dt = new access().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "merchandise where id <> 0 " + sqlw, username, p, "pagex", "id", 1);
        }
    }
}