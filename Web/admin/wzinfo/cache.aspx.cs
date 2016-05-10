using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wzinfo
{
    public partial class cache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cache where id = 1"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.RadioButtonList1.SelectedValue = r["iftj"].ToString();
                        this.TextBox1.Text = r["times"].ToString();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string iftj = this.RadioButtonList1.SelectedValue;
            string times = this.TextBox1.Text;
            string sql = string.Concat(new string[]
			{
				"update cache set iftj = ",
				iftj,
				",times=",
				times,
				" where id = 1"
			});
            int a = new SqlHelper().ExecuteNonQuery(sql);
            if (a > 0)
            {
                base.Response.Write("<script>alert('修改成功！');location.href='" + base.Request.RawUrl + "';</script>");
            }
        }
    }
}