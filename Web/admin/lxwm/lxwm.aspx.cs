using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.lxwm
{
    public partial class lxwm : System.Web.UI.Page
    {
        public string fystr;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 20;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                string sqlstring;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from lxwm where id <> 0",
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
						" id from lxwm where id <> 0 ",
						sqlw,
						" order by id desc"
					});
                    string zid_sqltwo = "select top 1 id from lxwm where id in (" + zid_sql_one + ") order by id";
                    string zid = new access().ExecuteScalar(zid_sqltwo);
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from lxwm where id <(",
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
                this.fystr = liu.fystr_new(x, "lxwm where id <> 0" + sqlw, username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from lxwm where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
        }
    }
}