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
    public partial class ApplyResult : System.Web.UI.Page
    {
        string UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(base.Request.Cookies["username"].Value))
            {
                base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Login.aspx';</script>");
                base.Response.End();
            }
            else
            {
                this.UserName = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                if (IsApply(UserName))
                {
                    int Temp = GetStatus(UserName);
                    switch (Temp)
                    {
                        case 1:
                            this.Infor.Text = "您的门店申请已提交，正在审核中。。。";
                            break;
                        case 2:
                            this.Infor.Text = "您的门店申请已通过审核。邀请码为" + GetShareCode(UserName);
                            break;
                        case 3:
                            this.Infor.Text = "抱歉，您的门店申请已被拒绝。";
                            break;
                        case 4:
                            this.Infor.Text = "您的门店账号已被管理员禁用，详情请联系客服。";
                            break;
                        default:
                            base.Response.Write("<script>alert('请先登录...');self.window.parent.location='Login.aspx';</script>");
                            base.Response.End();
                            break;
                    }
                }
                else
                {
                    this.Response.Redirect("Apply.aspx");
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
        private int GetStatus(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                SqlParameter[] op = new SqlParameter[]
                {
                    new SqlParameter("@UserName",UserName)
                };
                string Sql = "select Status from poweruser where UserName=@UserName";
                return Convert.ToInt32(new SqlHelper().ExecuteScalar(Sql, op));
            }
            else
                return 0;
        }
        private string GetShareCode(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                SqlParameter[] op = new SqlParameter[]
                {
                    new SqlParameter("@UserName",UserName)
                };
                string Sql = "select ShareCode from poweruser where UserName=@UserName";
                return new SqlHelper().ExecuteScalar(Sql, op).ToString();
            }
            else
                return null;
        }
    }
}