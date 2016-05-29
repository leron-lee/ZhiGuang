using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web.fx
{
    public partial class InfoFX : System.Web.UI.Page
    {
        bool IsInsert = false;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["fx"] == null)
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Default.aspx';</script>");
                base.Response.End();
            }
            else
            {
                string UserName = base.Request.Cookies["fx"].Value;
                string SqlStr1 = "select *  from FxShopInfo where Belong= '" + UserName + "'";
                string SqlStr2 = "select count(Id) from FxShopInfo where Belong= '" + UserName + "'";
                if (new SqlHelper().ExecuteScalar(SqlStr2) == "1")
                    IsInsert = true;
                if (!base.IsPostBack)
                {
                    if (IsInsert)
                    {
                        using (DataTable dt = new SqlHelper().ExecuteDataTable(SqlStr1))
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                this.TextName.Text = r["Name"].ToString();
                                this.ImgLogo.ImageUrl = r["Logo"].ToString();
                                this.TextLogo.Text = r["Logo"].ToString();
                            }
                        }
                    }
                }
            }
        }
        protected void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["fx"] == null)
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Default.aspx';</script>");
                base.Response.End();
            }
            else
            {
                string UserName = this.Request.Cookies["fx"].Value;
                string Name = this.TextName.Text;
                string Logo = this.TextLogo.Text;
                string SqlStr;
                if (IsInsert)
                {
                    SqlStr = "update FxShopInfo set Name=@Name,Logo=@Logo where Belong=@Belong";
                }
                else
                {
                    SqlStr = "INSERT into FxShopInfo (Belong,Name,Logo) values (@Belong,@Name,@Logo)";
                }
                SqlParameter[] op = new SqlParameter[] {
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@Logo",Logo),
                    new SqlParameter("@Belong",UserName)
                };
                int a = new SqlHelper().ExecuteNonQuery(SqlStr, op);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('保存成功！');location.href='" + base.Request.RawUrl + "';</script>");
                }
            }
        }
    }
}