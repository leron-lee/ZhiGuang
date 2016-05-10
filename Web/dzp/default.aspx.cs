using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Web.dzp
{
    public partial class _default : System.Web.UI.Page
    {
        public string shezhi;
        public string shuoming;
        public string zhi;
   
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Page.Title = get.gsstr();
            if (!base.IsPostBack)
            {
                if (base.Request.Cookies["username"] == null)
                {
                    base.Response.Redirect("/user/login.aspx?url=" + base.Request.RawUrl);
                }
                this.zhi = new SqlHelper().ExecuteScalar("select top 1 id from hb order by id desc");
                this.zhi = (System.Convert.ToInt32(570000) + System.Convert.ToInt32(this.zhi)).ToString();
            }
        }
    }
}