using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.cart
{
    public partial class pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["ordernumber"] != null)
                {
                    string ordernumber = base.Request.QueryString["ordernumber"];
                    string shoporderid = new SqlHelper().ExecuteScalar("select id from shoporder where ordernumber = '" + ordernumber + "'");
                    string chongzhi_ye_id = new SqlHelper().ExecuteScalar("select id from chongzhi_ye where ordernumber = '" + ordernumber + "'");
                    string chongzhi_xfj_id = new SqlHelper().ExecuteScalar("select id from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
                    string price = base.Request.QueryString["zffs"];
                    string str = "0";
                    if (shoporderid != "")
                    {
                        str = new SqlHelper().ExecuteScalar("select hxzf from shoporder where ordernumber = '" + ordernumber + "'");
                    }
                    else
                    {
                        if (chongzhi_ye_id != "")
                        {
                            str = new SqlHelper().ExecuteScalar("select price from chongzhi_ye where ordernumber = '" + ordernumber + "'");
                        }
                        else
                        {
                            if (chongzhi_xfj_id != "")
                            {
                                str = new SqlHelper().ExecuteScalar("select price from chongzhi_xfj where ordernumber = '" + ordernumber + "'");
                            }
                        }
                    }
                    if (price == "zfb")
                    {
                        base.Response.Redirect("/alipay/default.aspx?ordernumber=" + ordernumber + "&price=" + str);
                    }
                    else
                    {
                        base.Response.Redirect("/wxpay/WXPay.aspx?ordernumber=" + ordernumber + "&price=" + str);
                    }
                }
            }
        }
    }
}