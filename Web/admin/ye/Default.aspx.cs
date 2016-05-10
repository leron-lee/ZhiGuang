using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.ye
{
    public partial class Default : System.Web.UI.Page
    {
        public string fystr;
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["del"] != null)
                {
                    int del = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    new SqlHelper().ExecuteNonQuery("delete from ye_jilu where id = " + del);
                    base.Response.Redirect(base.Request.QueryString["url"]);
                }
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
            if (base.Request.QueryString["search_username"] != null)
            {
                string search_username = base.Request.QueryString["search_username"];
                if (search_username != "")
                {
                    url = url + "&search_username=" + search_username;
                    sqlw = sqlw + " and username = '" + search_username + "' ";
                    this.search_username.Text = search_username;
                }
            }
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
                string nid = new access().ExecuteScalar("select top 1 id from ye_jilu where id in (" + sqlabc + ") order by id");
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
            using (DataTable dt = new access().ExecuteDataTable(sqlstring))
            {
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "ye_jilu where id <> 0 " + sqlw, url, p, "pagex", "id", 1);
        }
        protected void cao_bt_Click(object sender, System.EventArgs e)
        {
            string username = this.username.Text;
            string cao = this.cao.SelectedValue;
            string jf = this.jf.Text;
            string bz = this.bz.Text;
            string times = System.DateTime.Now.ToString();
            string sid = new SqlHelper().ExecuteScalar("select id from username where username = '" + username + "'");
            if (sid != "")
            {
                get.ye_cao(username, cao, jf, bz, "");
                base.Response.Write("<script>alert('提交成功');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
            else
            {
                base.Response.Write("<script>alert('用户名不存在');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
        protected void search_bt_Click(object sender, System.EventArgs e)
        {
            string search_username = this.search_username.Text;
            base.Response.Redirect("default.aspx?search_username=" + search_username);
        }
    }
}