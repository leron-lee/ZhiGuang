using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web.admin.fh
{
    public partial class dzmd_l : System.Web.UI.Page
    {
        public string sendMan;
        public string sendManPhone;
        public string sendProvince;
        public string sendCity;
        public string sendCounty;
        public string sendManAddress;
        public string sendPostcode;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string s = new SqlHelper().ExecuteScalar("select s1 from htkd_lishi where id = " + id);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporder where id in(" + s + ") order by id desc"))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from htkd where id = 1"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.sendMan = r["sendMan"].ToString();
                            this.sendManPhone = r["sendManPhone"].ToString();
                            this.sendProvince = r["sendProvince"].ToString();
                            this.sendCity = r["sendCity"].ToString();
                            this.sendCounty = r["sendCounty"].ToString();
                            this.sendManAddress = r["sendManAddress"].ToString();
                            this.sendPostcode = r["sendPostcode"].ToString();
                        }
                    }
                }
            }
        }
        public string bz()
        {
            string fig = "";
            using (DataTable dt2 = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + base.Eval("id")))
            {
                foreach (DataRow r2 in dt2.Rows)
                {
                    string s10 = get.m_str(r2["mid"], "s10");
                    string sum = r2["sum"].ToString();
                    object obj = fig;
                    fig = string.Concat(new object[]
					{
						obj,
						s10,
						"，",
						r2["ys"],
						r2["cc"],
						"，数量：",
						sum
					});
                }
            }
            if (base.Eval("bz").ToString() != "")
            {
                fig = fig + "，备注：" + base.Eval("bz");
            }
            return fig;
        }
    }
}