using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.jilu
{
    public partial class sel : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.tj();
                int x = 20;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                if (base.Request.QueryString["username"] != null && base.Request.QueryString["zt"] != null)
                {
                    string tj_username = base.Request.QueryString["username"];
                    string zt = base.Request.QueryString["zt"];
                    if (tj_username != "")
                    {
                        sqlw = sqlw + " and tj_username = '" + tj_username + "' ";
                    }
                    if (zt != "")
                    {
                        sqlw = sqlw + " and zt = " + zt + " ";
                    }
                    this.username.Text = tj_username;
                    this.zt.SelectedValue = zt;
                    username = username + "&username=" + base.Server.UrlEncode(username);
                    username = username + "&zt=" + base.Server.UrlEncode(zt);
                }
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
                    string zid = new access().ExecuteScalar(zid_sqltwo);
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
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "jilu where id <> 0 " + sqlw, username, p, "pagex", "id");
            }
        }
        public void tj()
        {
            if (base.Request.QueryString["ti"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["ti"]);
                string url = base.Request.QueryString["url"];
                string sql = "update jilu set zt = 2 where id = " + id;
                new SqlHelper().ExecuteNonQuery(sql);
                base.Response.Redirect(url);
            }
        }
        public string tjcz(object id, object zt)
        {
            string fig = "";
            if (zt.ToString() == "1")
            {
                fig = string.Concat(new object[]
				{
					"<a href='javascript:;' onclick=\"if(confirm('确定？')){location.href='sel.aspx?ti=",
					id,
					"&url=",
					base.Server.UrlEncode(base.Request.RawUrl),
					"';}\" class=\"lv\">提现已处理</a>"
				});
            }
            return fig;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string username = this.username.Text;
            string zt = this.zt.Text;
            base.Response.Redirect("sel.aspx?username=" + username + "&zt=" + zt);
        }
    }
}