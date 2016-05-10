using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class fs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                System.DateTime dte = System.DateTime.Now;
                string jtimes = System.DateTime.Now.ToShortDateString();
                if (base.Cache[jtimes] == null)
                {
                    base.Cache[jtimes] = "";
                    dte = dte.AddDays(-15.0);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select id from shoporder where zt = 3 and ftimes < '" + dte + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            new SqlHelper().ExecuteNonQuery("update shoporder set zt = 4 where id = " + r["id"]);
                        }
                    }
                    new SqlHelper().ExecuteNonQuery("delete from cart where username = '' and times < '" + dte + "'");
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from hb where gtimes < '" + System.DateTime.Now + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            get.hb_cao(r["username"].ToString(), "扣除", r["jf"].ToString(), "红包过期");
                            new SqlHelper().ExecuteNonQuery("delete from hb where id =" + r["id"]);
                        }
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from xfj where gtimes < '" + System.DateTime.Now + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            get.xfj_cao(r["username"].ToString(), "扣除", r["jf"].ToString(), "消费劵过期");
                            new SqlHelper().ExecuteNonQuery("delete from xfj where id =" + r["id"]);
                        }
                    }
                }
            }
        }
    }
}