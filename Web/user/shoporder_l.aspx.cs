using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class shoporder_l : System.Web.UI.Page
    {
        public object zong;
        public object zt;
        public object hb;
        public object ye;
        public object xfj;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                    using (DataTable dt = new access().ExecuteDataTable(string.Concat(new object[]
					{
						"select * from shoporder where id = ",
						id,
						" and username = '",
						username,
						"'"
					})))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            this.zong = r["price"];
                            this.hb = r["hb"];
                            this.ye = r["ye"];
                            this.xfj = r["xfj"];
                            this.zt = get.zt(r["zt"]);
                        }
                    }
                    using (DataTable dt = new access().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                    {
                        this.Repeater2.DataSource = dt;
                        this.Repeater2.DataBind();
                    }
                }
            }
        }
    }
}