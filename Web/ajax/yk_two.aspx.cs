using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class yk_two : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string fig = "";
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from yk_two where yk_one_id = " + id + " and ku > 0 order by px"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            if (fig == "")
                            {
                                object obj = fig;
                                fig = string.Concat(new object[]
								{
									obj,
									"<a href='javascript:;' class='a' value='",
									r["id"],
									"' ku='",
									r["ku"],
									"'>",
									r["name"],
									"</a>"
								});
                            }
                            else
                            {
                                object obj = fig;
                                fig = string.Concat(new object[]
								{
									obj,
									"<a href='javascript:;' value='",
									r["id"],
									"' ku='",
									r["ku"],
									"'>",
									r["name"],
									"</a>"
								});
                            }
                        }
                    }
                }
                base.Response.Write(fig);
                base.Response.End();
            }
        }
    }
}