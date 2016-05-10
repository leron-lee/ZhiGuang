using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wx
{
    public partial class huifu_in : System.Web.UI.Page
    {
        public string tit;
   
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.tit = "增加";
                if (base.Request.QueryString["id"] != null)
                {
                    this.tit = "修改";
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wx_huifu where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                            this.img.Text = r["img"].ToString();
                            this.nt.Text = r["nt"].ToString();
                            this.href.Text = r["href"].ToString();
                            this.gjc.Text = getwx.gjc(r["gjc"]);
                        }
                    }
                }
                this.Button1.Text = " " + this.tit + " ";
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string name = this.name.Text;
            string img = this.img.Text;
            string nt = this.nt.Text;
            string href = this.href.Text;
            string gjc = "," + this.gjc.Text + ",";
            string url = base.Request.QueryString["url"];
            string sqlstr = "select MAX(px) FROM wx_huifu";
            int px = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstr);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@img", img),
				new SqlParameter("@nt", nt),
				new SqlParameter("@href", href),
				new SqlParameter("@gjc", gjc)
			};
            string sql = "insert into wx_huifu (name,img,nt,href,gjc,px) values (@name,@img,@nt,@href,@gjc," + px + ")";
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update wx_huifu set name=@name,img=@img,nt=@nt,href=@href,gjc=@gjc where id = " + id;
            }
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('操作成功！');location.href='" + url + "';</script>");
                base.Response.End();
            }
        }
    }
}