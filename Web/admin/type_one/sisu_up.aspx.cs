using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type_one
{
    public partial class sisu_up : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sqlstring = "select * from type where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox3.Text = r["type_name"].ToString();
                        }
                    }
                }
                else
                {
                    this.Button1.Text = " 增加 ";
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string t = this.TextBox3.Text;
            int px = 1;
            string stg = "select MAX(px) FROM type";
            string ob = new SqlHelper().ExecuteScalar(stg);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@type_name", t),
				new SqlParameter("@px", px.ToString())
			};
            string sqlstring = string.Empty;
            if (base.Request.QueryString["id"] != null)
            {
                sqlstring = "update type set type_name=@type_name where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
            }
            else
            {
                sqlstring = "insert into type (type_name,px) values(@type_name,@px)";
            }
            int a = new SqlHelper().ExecuteNonQuery(sqlstring, sp);
            if (a > 0)
            {
                string url = base.Request.QueryString["url"].ToString();
                base.Response.Write("<script>alert('操作成功！');location.href='" + url + "';</script>");
            }
        }
    }
}