using System;
using System.Data;
using System.Web.UI;

namespace Web
{
    public partial class html : System.Web.UI.Page
    {
        public string type_two_name;
        public string nt;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new access().ExecuteDataTable("select * from type_two where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.type_two_name = r["type_two_name"].ToString();
                            this.nt = r["nt"].ToString();
                        }
                    }
                }
            }
        }
    }
}