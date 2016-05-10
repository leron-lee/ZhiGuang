using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.cart.ajax
{
    public partial class del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                    new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
					{
						"delete from cart where username = '",
						username,
						"' and id = ",
						id
					}));
                }
            }
        }
    }
}