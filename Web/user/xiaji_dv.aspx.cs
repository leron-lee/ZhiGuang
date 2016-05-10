using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class xiaji_dv : System.Web.UI.Page
    {
        public string fystr;
        public string username;
        public string username_id;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            this.username_id = get.username_id(this.username);
            if (!base.IsPostBack)
            {
                this.fy2();
            }
        }
        public string dvfh(object v)
        {
            string fig = "0";
            if (v.ToString() != "")
            {
                fig = v.ToString();
            }
            return fig;
        }
        public string ifdv(object v)
        {
            string fig = "";
            if (v.ToString() == "1")
            {
                fig = "<span style='color:red;'>是</span>";
            }
            return fig;
        }
        public void fy2()
        {
            int x = 12;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "";
            string sqlw = "";
            sqlw = sqlw + " and tj_username = " + this.username_id + " ";
            string sqlstring = string.Empty;
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
                string sqlabc = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from username where id <> 0 ",
					sqlw,
					" order by id desc"
				});
                string nid = new SqlHelper().ExecuteScalar("select top 1 id from username where id in (" + sqlabc + ") order by id");
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from username where id <> 0 and id < ",
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
            this.fystr = en_page.fystr_one(x, "username where id <> 0 " + sqlw, url, p, "pagex", "id", 2);
        }
    }
}