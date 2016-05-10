using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin
{
    public partial class admin_master : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["adminusername"] == null)
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='../Default.aspx';</script>");
                base.Response.End();
            }
            this.cacha_qk();
        }
        public void cacha_qk()
        {
            System.Collections.IDictionaryEnumerator CacheEnum = base.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (!CacheEnum.Key.ToString().Contains("cart_"))
                {
                    base.Cache.Remove(CacheEnum.Key.ToString());
                }
            }
        }
    }
}