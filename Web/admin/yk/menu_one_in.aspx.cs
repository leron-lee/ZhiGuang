using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.yk
{
    public partial class menu_one_in : System.Web.UI.Page
    {
        public string tit;
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                this.tit = "修改";
            }
            else
            {
                this.tit = "增加";
            }
            this.Button1.Text = this.tit;
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from yk_one where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string name = this.name.Text;
            string mid = base.Request.QueryString["mid"];
            string url = base.Request.QueryString["url"];
            if (string.IsNullOrEmpty(mid))
            {
                mid = "";
            }
            string sqlstr = "select MAX(px) FROM yk_one";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@mid", mid)
			};
            string sql = "insert into yk_one (name,mid,px) values (@name,@mid," + px + ")";
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update yk_one set name=@name where id = " + id;
            }
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('",
					this.tit,
					"成功！');location.href='",
					url,
					"';</script>"
				}));
                base.Response.End();
            }
        }
    }
}