using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.shang
{
    public partial class sel : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.s_sheng_mo();
                this.s_shi_mo();
                this.s_xian_mo();
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                if (!string.IsNullOrEmpty(base.Request.QueryString["s_sheng"]))
                {
                    string s_sheng = base.Request.QueryString["s_sheng"];
                    this.s_sheng.SelectedValue = s_sheng;
                    this.shi(s_sheng);
                    username = username + "&s_sheng=" + s_sheng;
                    sqlw = sqlw + " and sheng=" + s_sheng + " ";
                }
                if (!string.IsNullOrEmpty(base.Request.QueryString["s_shi"]))
                {
                    string s_shi = base.Request.QueryString["s_shi"];
                    this.s_shi.SelectedValue = s_shi;
                    this.xian(s_shi);
                    username = username + "&s_shi=" + s_shi;
                    sqlw = sqlw + " and shi=" + s_shi + " ";
                }
                if (!string.IsNullOrEmpty(base.Request.QueryString["s_xian"]))
                {
                    string s_xian = base.Request.QueryString["s_xian"];
                    this.s_xian.SelectedValue = s_xian;
                    username = username + "&s_xian=" + s_xian;
                    sqlw = sqlw + " and xian=" + s_xian + " ";
                }
                if (!string.IsNullOrEmpty(base.Request.QueryString["name"]))
                {
                    string name = base.Request.QueryString["name"];
                    this.name.Text = name;
                    username = username + "&name=" + name;
                    sqlw = sqlw + " and name like '%" + name + "%' ";
                }
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from shang where id <> 0 ",
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
						" * from shang where id < (select min(id) from shang where id in (select top ",
						(p - 1) * x,
						" id from shang where id <> 0 ",
						sqlw,
						" order by id desc)) ",
						sqlw,
						" order by id desc"
					});
                }
                using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = li;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr(x, "shang where id <> 0 " + sqlw, username, p, "pagex", "id");
            }
        }
        public void s_sheng_mo()
        {
            this.s_sheng.Items.Add(new ListItem("请选择", ""));
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_sheng order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_sheng.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        public void s_shi_mo()
        {
            this.s_shi.Items.Add(new ListItem("请选择", ""));
        }
        public void s_xian_mo()
        {
            this.s_xian.Items.Add(new ListItem("请选择", ""));
        }
        protected void s_sheng_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.shi(this.s_sheng.SelectedValue);
        }
        public void shi(object s_sheng)
        {
            this.s_shi.Items.Clear();
            this.s_shi_mo();
            this.s_xian.Items.Clear();
            this.s_xian_mo();
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_shi where shengid = " + s_sheng + " order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_shi.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        protected void s_shi_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.xian(this.s_shi.SelectedValue);
        }
        public void xian(object s_shi)
        {
            this.s_xian.Items.Clear();
            this.s_xian_mo();
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_xian where shiid = " + s_shi + " order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_xian.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from shang where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
        }
        protected void search_tj_Click(object sender, System.EventArgs e)
        {
            string s_sheng = this.s_sheng.SelectedValue;
            string s_shi = this.s_shi.SelectedValue;
            string s_xian = this.s_xian.SelectedValue;
            string name = this.name.Text;
            base.Response.Redirect(string.Concat(new string[]
			{
				"sel.aspx?s_sheng=",
				s_sheng,
				"&s_shi=",
				s_shi,
				"&s_xian=",
				s_xian,
				"&name=",
				name
			}));
        }
    }
}