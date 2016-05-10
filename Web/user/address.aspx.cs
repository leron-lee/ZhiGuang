using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class address : System.Web.UI.Page
    {
        public string username;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                this.ding();
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from address where username = '" + this.username + "' order by id"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
            }
        }
        public void ding()
        {
            if (base.Request.QueryString["mo"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["mo"]);
                new SqlHelper().ExecuteNonQuery("update address set mo = 0 where username = '" + this.username + "'");
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update address set mo = 1 where username = '",
					this.username,
					"' and id = ",
					id
				}));
            }
            else
            {
                if (base.Request.QueryString["del"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"delete from address where username = '",
						this.username,
						"' and id = ",
						id
					}));
                    get.mo(this.username);
                }
            }
        }
        public string mo(object v)
        {
            string fig = "";
            if (v.ToString() == "1")
            {
                fig = "默认";
            }
            return fig;
        }
    }
}