using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.yk
{
    public partial class menu_two_in : System.Web.UI.Page
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
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from yk_two where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                            this.ku.Text = r["ku"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string yk_one_id = base.Request.QueryString["yk_one_id"];
            string name = this.name.Text;
            string ku = this.ku.Text;
            string url = base.Request.QueryString["url"];
            string sqlstr = "select MAX(px) FROM yk_two";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@ku", ku)
			};
            string sql = string.Concat(new object[]
			{
				"insert into yk_two (yk_one_id,name,ku,px) values (",
				yk_one_id,
				",@name,@ku,",
				px,
				")"
			});
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update yk_two set name=@name,ku=@ku where id = " + id;
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