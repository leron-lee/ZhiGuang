using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.cart
{
    public partial class Default : System.Web.UI.Page
    {
        public string username;
        public int gong;
        public string myzd;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cart where username = '" + this.username + "' order by id"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        string sid = new SqlHelper().ExecuteScalar("select id from merchandise where id = " + r["mid"]);
                        if (sid == "")
                        {
                            new SqlHelper().ExecuteNonQuery("delete from cart where id = " + r["id"]);
                            base.Response.Redirect(base.Request.RawUrl);
                        }
                    }
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                    this.gong = this.Repeater1.Items.Count;
                    if (this.Repeater1.Items.Count == 0)
                    {
                        this.myzd = "<div style='text-align:center;'>没有找到相关信息</div>";
                    }
                }
            }
        }
        public string iftj(object v)
        {
            string fig = "dis";
            if (get.m_str(base.Eval("mid"), "iftj") == v.ToString())
            {
                fig = "";
            }
            return fig;
        }
        protected void js_Click(object sender, System.EventArgs e)
        {
            string xj = base.Request.Form["xj"];
            if (xj == null)
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请勾选要结算的商品');location.href='" + base.Request.RawUrl + "';", true);
            }
            else
            {
                base.Response.Redirect("/cart/order.aspx?cart_id=" + xj);
            }
        }
    }
}