using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class news_l : System.Web.UI.Page
    {
        public string imgdis;
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new access().ExecuteDataTable("select * from merchandise where id = " + id))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r["x_img"].ToString() == "")
                            {
                                this.imgdis = "dis";
                            }
                            if (r["guige"].ToString() != "" && r["guige"].ToString() != "http://")
                            {
                                base.Response.Redirect(r["guige"].ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}