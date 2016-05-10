using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class xiaoxi : System.Web.UI.Page
    {
        public string username;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.xiaoxi_reg.SelectedValue = r["xiaoxi_reg"].ToString();
                        this.xiaoxi_fx.SelectedValue = r["xiaoxi_fx"].ToString();
                    }
                }
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            string xiaoxi_reg = this.xiaoxi_reg.SelectedValue;
            string xiaoxi_fx = this.xiaoxi_fx.SelectedValue;
            string sql = string.Concat(new string[]
			{
				"update username set xiaoxi_reg = ",
				xiaoxi_reg,
				",xiaoxi_fx=",
				xiaoxi_fx,
				" where username = '",
				this.username,
				"'"
			});
            int a = new SqlHelper().ExecuteNonQuery(sql);
            base.Response.Write("<script>alert('设置成功');location.href='default.aspx';</script>");
            base.Response.End();
        }
    }
}