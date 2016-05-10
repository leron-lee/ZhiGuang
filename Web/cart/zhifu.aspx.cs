using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.cart
{
    public partial class zhifu : System.Web.UI.Page
    {
        public string username;
        public string ordernumber;
        public double price;
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlEncode(base.Request.Cookies["username"].Value);
            if (base.Request.QueryString["ordernumber"] != null)
            {
                this.ordernumber = base.Request.QueryString["ordernumber"];
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporder where ordernumber = '" + this.ordernumber + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.price = System.Convert.ToDouble(r["price"]);
                    }
                }
            }
        }
        protected void ljzf_bt_Click(object sender, System.EventArgs e)
        {
            string zffs = base.Request.Form["zffs"];
            double hxzf = this.price;
            double z_3 = get.xfj(this.username);
            double z_4 = get.ye(this.username);
            if (zffs == "xfjzf")
            {
                if (z_3 < hxzf)
                {
                    base.Response.Write("<script>alert('消费劵不足，请充值。');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
                else
                {
                    get.xfj_cao(this.username, "扣除", hxzf.ToString(), "订单号：" + this.ordernumber);
                    get.zfcg(this.ordernumber);
                    base.Response.Write("<script>alert('支付成功');location.href='/user/shoporder.aspx';</script>");
                    base.Response.End();
                }
            }
            else
            {
                if (zffs == "yezf")
                {
                    if (z_4 < hxzf)
                    {
                        base.Response.Write("<script>alert('余额不足，请充值。');location.href='" + base.Request.RawUrl + "';</script>");
                        base.Response.End();
                    }
                    else
                    {
                        get.ye_cao(this.username, "扣除", hxzf.ToString(), "订单号：" + this.ordernumber, "");
                        get.zfcg(this.ordernumber);
                        base.Response.Write("<script>alert('支付成功');location.href='/user/shoporder.aspx';</script>");
                        base.Response.End();
                    }
                }
                else
                {
                    if (zffs == "zfb")
                    {
                        base.Response.Redirect("/cart/pay.aspx?ordernumber=" + this.ordernumber + "&zffs=zfb");
                    }
                    else
                    {
                        if (zffs == "wx")
                        {
                            base.Response.Redirect("/cart/pay.aspx?ordernumber=" + this.ordernumber + "&zffs=wx");
                        }
                    }
                }
            }
        }
    }
}