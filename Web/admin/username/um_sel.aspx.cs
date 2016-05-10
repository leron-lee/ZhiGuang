using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class um_sel : System.Web.UI.Page
    {
        public string _dl_sheng;
        public string _dl_shi;
        public string _dl_xian;
  
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
                if (base.Request.QueryString["username"] != null)
                {
                    string um = base.Request.QueryString["username"];
                    if (um != "")
                    {
                        sqlw = " and username like '%" + um + "%' ";
                        username = username + "&username=" + base.Server.UrlEncode(um);
                        this.username.Text = um;
                    }
                }
                if (base.Request.QueryString["tj_username"] != null)
                {
                    string tj_username = base.Request.QueryString["tj_username"];
                    if (tj_username != "")
                    {
                        string usernameid = get.username_id(tj_username);
                        if (usernameid != "")
                        {
                            sqlw = " and tj_username = " + usernameid + " ";
                            username = username + "&tj_username=" + base.Server.UrlEncode(tj_username);
                            this.tj_username.Text = tj_username;
                        }
                    }
                }
                if (base.Request.QueryString["dl_sheng"] != null)
                {
                    string dl_sheng = base.Request.QueryString["dl_sheng"];
                    string dl_shi = base.Request.QueryString["dl_shi"];
                    string dl_xian = base.Request.QueryString["dl_xian"];
                    if (!string.IsNullOrEmpty(dl_xian))
                    {
                        sqlw = sqlw + " and dl_xian = " + dl_xian + " and jb = 3 ";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dl_shi))
                        {
                            sqlw = sqlw + " and dl_shi = " + dl_shi + " and jb = 2 ";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dl_sheng))
                            {
                                sqlw = sqlw + " and dl_sheng = " + dl_sheng + " and jb = 1 ";
                            }
                        }
                    }
                    username = username + "&dl_sheng=" + dl_sheng;
                    username = username + "&dl_shi=" + dl_shi;
                    username = username + "&dl_xian=" + dl_xian;
                    this._dl_sheng = dl_sheng;
                    this._dl_shi = dl_shi;
                    this._dl_xian = dl_xian;
                }
                if (base.Request.QueryString["dv"] != null)
                {
                    string dv = base.Request.QueryString["dv"];
                    if (dv == "1")
                    {
                        sqlw += " and jb = 6 and ifdv = 1 ";
                    }
                    username = username + "&dv=" + dv;
                    this.dv.SelectedValue = dv;
                }
                sqlw += " and username <> '' ";
                string sqlstring;
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
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from username where id not in(select top ",
						(p - 1) * x,
						" id from username where id <> 0 ",
						sqlw,
						" order by id desc) ",
						sqlw,
						" order by id desc"
					});
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr_new(x, "username where id <> 0 " + sqlw, username, p, "pagex", "id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from username where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string username = this.username.Text;
            string tj_username = this.tj_username.Text;
            string dl_sheng = base.Request.Form["s_sheng"];
            string dl_shi = base.Request.Form["s_shi"];
            string dl_xian = base.Request.Form["s_xian"];
            string dv = this.dv.SelectedValue;
            base.Response.Redirect(string.Concat(new string[]
			{
				"um_sel.aspx?username=",
				username,
				"&tj_username=",
				tj_username,
				"&dl_sheng=",
				dl_sheng,
				"&dl_shi=",
				dl_shi,
				"&dl_xian=",
				dl_xian,
				"&dv=",
				dv
			}));
        }
    }
}