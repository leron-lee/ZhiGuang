using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class qidai : System.Web.UI.Page
    {
        public string fystr;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.fy();
            }
        }
        public void fy()
        {
            int id = 18;
            int x = 16;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string url = "&id=" + id;
            string sqlw = " and type_two_id = " + id + " ";
            string sqlstring = string.Empty;
            if ((p - 1) * x == 0)
            {
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from merchandise where id <> 0 ",
					sqlw,
					" order by px desc,id desc"
				});
            }
            else
            {
                string sqlabc = string.Concat(new object[]
				{
					"select top ",
					(p - 1) * x,
					" id from merchandise where id <> 0 ",
					sqlw,
					" order by px desc,id desc"
				});
                string sqlid = "0";
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlabc))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        sqlid = sqlid + "," + r["id"];
                    }
                }
                sqlstring = string.Concat(new object[]
				{
					"select top ",
					x,
					" * from merchandise where id <> 0 and id not in (",
					sqlid,
					") order by px desc,id desc"
				});
            }
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            this.fystr = en_page.fystr_one(x, "merchandise where id <> 0 " + sqlw, url, p, "pagex", "id", 1);
        }
    }
}