using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.ajax
{
    public partial class s_s_x : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string fig = "";
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["s_sheng"] != null)
                {
                    using (DataTable dt = new access().ExecuteDataTable("select * from s_sheng order by id"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            object obj = fig;
                            fig = string.Concat(new object[]
							{
								obj,
								r["id"],
								":",
								r["name"],
								","
							});
                        }
                    }
                }
                else
                {
                    if (base.Request.QueryString["s_shi"] != null)
                    {
                        string zhi = base.Request.QueryString["s_shi"];
                        using (DataTable dt = new access().ExecuteDataTable("select * from s_shi where shengid = " + zhi + " order by id"))
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                object obj = fig;
                                fig = string.Concat(new object[]
								{
									obj,
									r["id"],
									":",
									r["name"],
									","
								});
                            }
                        }
                    }
                    else
                    {
                        if (base.Request.QueryString["s_xian"] != null)
                        {
                            string zhi = base.Request.QueryString["s_xian"];
                            using (DataTable dt = new access().ExecuteDataTable("select * from s_xian where shiid = " + zhi + " order by id"))
                            {
                                foreach (DataRow r in dt.Rows)
                                {
                                    object obj = fig;
                                    fig = string.Concat(new object[]
									{
										obj,
										r["id"],
										":",
										r["name"],
										","
									});
                                }
                            }
                        }
                    }
                }
            }
            base.Response.Write(fig);
            base.Response.End();
        }
    }
}