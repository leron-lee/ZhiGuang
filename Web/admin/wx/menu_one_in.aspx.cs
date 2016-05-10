using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.wx
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
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wx_menu_one where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                            this.href.Text = r["href"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string name = this.name.Text;
            string href = this.href.Text;
            string url = base.Request.QueryString["url"];
            string sqlstr = "select MAX(px) FROM wx_menu_one";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@href", href)
			};
            string sql = "insert into wx_menu_one (name,href,px) values (@name,@href," + px + ")";
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update wx_menu_one set name=@name,href=@href where id = " + id;
            }
            else
            {
                int zs = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from wx_menu_one"));
                if (zs >= 3)
                {
                    base.Response.Write("<script>alert('一级菜单最多只能创建三个');location.href='" + url + "';</script>");
                    base.Response.End();
                }
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