using System;
using System.Web.UI;
namespace Web._html
{
    public partial class imga : System.Web.UI.Page
    {
        public string img;
        public string src;
        public string href;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["src"] != null)
                {
                    this.src = base.Request.QueryString["src"];
                }
                if (base.Request.QueryString["href"] != null)
                {
                    this.href = base.Request.QueryString["href"];
                    this.img = string.Concat(new string[]
					{
						"<a href='",
						this.href,
						"'><img src='",
						this.src,
						"' width='100%' /></a>"
					});
                }
                else
                {
                    this.img = "<img src='" + this.src + "' width='100%' />";
                }
            }
        }
    }
}