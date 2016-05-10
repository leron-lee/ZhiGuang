using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.type
{
    public partial class type_one : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from type_one where id=" + uid.ToString()))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox3.Text = r["type_one_name"].ToString();
                            this.type_one_name_en.Text = r["type_one_name_en"].ToString();
                            this.RadioButtonList1.SelectedValue = r["xid"].ToString();
                            this.Literal1.Text = r["tid"].ToString();
                            this.TextBox1.Text = r["img"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                string t = this.TextBox3.Text;
                string img = this.TextBox1.Text;
                string xid = this.RadioButtonList1.SelectedValue;
                string type_one_name_en = this.type_one_name_en.Text;
                if (t == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('新一级类别名不能为空');</script>");
                }
                else
                {
                    SqlParameter[] sp = new SqlParameter[]
					{
						new SqlParameter("@type_one_name", t),
						new SqlParameter("@type_one_name_en", type_one_name_en),
						new SqlParameter("@xid", xid),
						new SqlParameter("@img", img)
					};
                    int a = new SqlHelper().ExecuteNonQuery("update type_one set type_one_name=@type_one_name,type_one_name_en=@type_one_name_en,xid=@xid,img=@img where id=" + uid.ToString(), sp);
                    if (a > 0)
                    {
                        if (this.Literal1.Text == "0")
                        {
                            base.Response.Write("<script>alert('操作成功');location.href='type.aspx';</script>");
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作成功');location.href='type.aspx?tid=" + this.Literal1.Text + "';</script>");
                        }
                    }
                }
            }
        }
    }
}