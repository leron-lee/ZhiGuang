using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wx
{
    public partial class can : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wx_can where id = 1"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.AppId.Text = r["AppId"].ToString();
                        this.AppSecret.Text = r["AppSecret"].ToString();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string AppId = this.AppId.Text;
            string AppSecret = this.AppSecret.Text;
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@AppId", AppId),
				new SqlParameter("@AppSecret", AppSecret)
			};
            string sql = "update wx_can set AppId=@AppId,AppSecret=@AppSecret where id = 1";
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功！');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
        }
    }
}