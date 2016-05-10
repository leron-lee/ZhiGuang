using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.username
{
    public partial class wysdv : System.Web.UI.Page
    {
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
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from wysdv where id >(select max(id) from wysdv where id in (select top ",
						(p - 1) * x,
						" id from wysdv where id <> 0 ",
						sqlw,
						" order by id))",
						sqlw,
						" order by id"
					});
                }
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "wysdv", username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from wysdv where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
        }
    }
}