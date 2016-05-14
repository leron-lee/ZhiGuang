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
    public partial class Apply : System.Web.UI.Page
    {
        public string username;
        public string dp;
        public string disabled = "disabled = 'disabled' style='background-image:none;'";
        public string s_sheng;
        public string s_shi;
        public string s_xian;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(base.Request.Cookies["username"].Value))
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Login.aspx';</script>");
                base.Response.End();
            }
            else
            {
                this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            }            
            if (!base.IsPostBack)
            {
                if (IsApply(username))
                {
                    this.Response.Redirect("ApplyResult.aspx");
                }
                             
            }
        }
        protected void bt_Click(object sender, System.EventArgs e)
        {
            int sex = this.sex.SelectedIndex;
            string TrueName = this.TrueName.Text.Trim();
            string phone = this.phone.Text;
            string address = this.address.Text;
            string InvitationCode = this.InvitationCode.Text;
            string Age = this.Age.Text;
            string IDCard = this.IDCard.Text;
            string s_sheng = base.Request.Form["s_sheng"];
            string s_shi = base.Request.Form["s_shi"];
            string s_xian = base.Request.Form["s_xian"];
            if (string.IsNullOrWhiteSpace(TrueName))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的姓名');", true);
            }
            else if (string.IsNullOrWhiteSpace(Age))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的年龄');", true);
            }
            else if (string.IsNullOrWhiteSpace(InvitationCode))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的邀请码');", true);
            }
            else if (string.IsNullOrWhiteSpace(phone))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的手机号');", true);
            }
            else if (string.IsNullOrWhiteSpace(IDCard))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的身份证号码');", true);
            }
            else if (s_sheng == null || s_shi == null || s_xian == null || string.IsNullOrWhiteSpace(address))
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请完善您的地址信息');", true);
            }
            else
            {
                SqlParameter[] op = new SqlParameter[]
                {
                    new SqlParameter("@UserName", username),
                    new SqlParameter("@TrueName", TrueName),
                    new SqlParameter("@Sex", sex),
                    new SqlParameter("@Age", Age),
                    new SqlParameter("@InvitationCode", InvitationCode),
                    new SqlParameter("@sheng", s_sheng),
                    new SqlParameter("@shi", s_shi),
                    new SqlParameter("@xian", s_xian),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@IDCard", IDCard),
                    new SqlParameter("@Address", address)
                };
                string sql = "insert into  poweruser (UserName,Role,Status,InvitationCode,TrueName,Phone,Sex,Age,Address,IDCard,sheng,shi,xian,InsertTime)"+
                             "values(@UserName,2,1,@InvitationCode,@TrueName,@Phone,@Sex,@Age,@Address,@IDCard,@sheng,@shi,@xian,GETDATE())";
                int a = new SqlHelper().ExecuteNonQuery(sql, op);
                if (a ==1)
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('修改成功');", true);
                }
            }
        }

        private bool IsApply(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                SqlParameter[] op = new SqlParameter[]
                {
                    new SqlParameter("@UserName",UserName)
                };
                string Sql = "select count(Id) from poweruser where UserName=@UserName";
                if (new SqlHelper().ExecuteScalar(Sql, op).ToString() == "1")
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}