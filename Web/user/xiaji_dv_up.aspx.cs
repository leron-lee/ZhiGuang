using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class xiaji_dv_up : System.Web.UI.Page
    {
        public string username;
        public string _username;
        public double bl;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            this.bl = get.zk(3) * 100.0;
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this._username = r["username"].ToString();
                            this.ifdv.SelectedValue = r["ifdv"].ToString();
                            this.dvfh.Text = r["dvfh"].ToString();
                        }
                    }
                }
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
            string ifdv = this.ifdv.SelectedValue;
            string dvfh = this.dvfh.Text;
            if (dvfh == "")
            {
                dvfh = "0";
            }
            if (System.Convert.ToDouble(dvfh) > this.bl)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), get.nyrsfm(), string.Concat(new object[]
				{
					"alert('佣金率不能超过",
					this.bl,
					"%');location.href='",
					base.Request.RawUrl,
					"';"
				}), true);
            }
            else
            {
                string sql = string.Concat(new object[]
				{
					"update username set ifdv = ",
					ifdv,
					",dvfh=",
					dvfh,
					" where id = ",
					id
				});
                new SqlHelper().ExecuteNonQuery(sql);
                if (ifdv == "1")
                {
                    new SqlHelper().ExecuteNonQuery("delete from wysdv where username = '" + this._username + "'");
                }
                string url = base.Request.QueryString["url"];
                base.Response.Write("<script>alert('设置成功');location.href='" + url + "';</script>");
                base.Response.End();
            }
        }
    }
}