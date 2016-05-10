using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.links
{
    public partial class sisu_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sqlstring = "select * from links where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox3.Text = r["name"].ToString();
                            this.TextBox2.Text = r["img"].ToString();
                            this.TextBox1.Text = r["href"].ToString();
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
            string t2 = this.TextBox1.Text;
            string img = this.TextBox2.Text;
            int tid = 0;
            if (base.Request.QueryString["tid"] != null)
            {
                tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
            }
            string sqlstr = "select MAX(px) FROM links";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@name", t),
				new SqlParameter("@img", img),
				new SqlParameter("@href", t2),
				new SqlParameter("@tid", tid),
				new SqlParameter("@px", px.ToString())
			};
            string sqlstring = string.Empty;
            if (base.Request.QueryString["id"] != null)
            {
                sqlstring = "update links set name=@name,img=@img,href=@href where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
            }
            else
            {
                sqlstring = "insert into links (name,img,href,tid,px) values(@name,@img,@href,@tid,@px)";
            }
            int a = new SqlHelper().ExecuteNonQuery(sqlstring, sp);
            if (a > 0)
            {
                string url = base.Request.QueryString["url"];
                base.Response.Write("<script>alert('操作成功！');location.href='" + url + "';</script>");
            }
        }
    }
}