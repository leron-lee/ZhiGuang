using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web._html
{
    public partial class ewm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["username"] != null)
                {
                    string username = base.Request.QueryString["username"];
                    string id = get.username_id(username);
                    string ewm = new SqlHelper().ExecuteScalar("select ewm from username where username = '" + username + "'");
                    this.img.ImageUrl = ewm;
                }
            }
        }
    }
}