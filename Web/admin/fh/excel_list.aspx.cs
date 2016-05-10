using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.fh
{
    public partial class excel_list : System.Web.UI.Page
    {
        public string fystr;
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from excel where id <> 0 ",
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
						" id from excel where id <> 0 ",
						sqlw,
						" order by id desc"
					});
                    string zid_sqltwo = "select top 1 id from excel where id in (" + zid_sql_one + ") order by id";
                    string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from excel where id <(",
						zid,
						") ",
						sqlw,
						" order by id desc"
					});
                }
                using (DataTable d = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = d;
                    this.Repeater1.DataBind();
                }
                this.fystr = en_page.fystr_one(x, "excel where id <> 0 " + sqlw, username, p, "pagex", "id", 1);
            }
        }
    }
}