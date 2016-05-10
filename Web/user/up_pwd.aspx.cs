using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class up_pwd : System.Web.UI.Page
    {
        public string username;
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
        }
        protected void bt_Click(object sender, System.EventArgs e)
        {
            string ypwd = this.ypwd.Text;
            string xpwd = this.xpwd.Text;
            string cpwd = this.cpwd.Text;
            if (ypwd == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入原密码');", true);
            }
            else
            {
                if (xpwd.Length < 6 || xpwd.Length > 16)
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入6-16个字符的新密码');", true);
                }
                else
                {
                    if (cpwd == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入重复密码');", true);
                    }
                    else
                    {
                        if (cpwd != xpwd)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('两次密码输入不一致');", true);
                        }
                        else
                        {
                            string spwd = new SqlHelper().ExecuteScalar("select pwd from username where username = '" + this.username + "'");
                            if (ypwd != spwd)
                            {
                                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('原密码输入不正确');", true);
                            }
                            else
                            {
                                string sql = string.Concat(new string[]
								{
									"update username set pwd = '",
									xpwd,
									"' where username = '",
									this.username,
									"'"
								});
                                int a = new SqlHelper().ExecuteNonQuery(sql);
                                if (a > 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('修改成功');location.href='default.aspx';", true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}