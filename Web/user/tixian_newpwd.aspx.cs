﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class tixian_newpwd : System.Web.UI.Page
    {
        public string username;
   
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
        }
        protected void bt_bj_Click(object sender, System.EventArgs e)
        {
            string pay_pwd = this.pay_pwd.Text;
            string cfpay_pwd = this.cfpay_pwd.Text;
            if (pay_pwd == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入提现密码！');", true);
            }
            else
            {
                if (pay_pwd.Length < 6 || pay_pwd.Length > 16)
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入6-16个字符的提现密码');", true);
                }
                else
                {
                    if (cfpay_pwd == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请再次输入提现密码！');", true);
                    }
                    else
                    {
                        if (cfpay_pwd != pay_pwd)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('两次密码输入不一致！');", true);
                        }
                        else
                        {
                            string sql = string.Concat(new string[]
							{
								"update username set pay_pwd = '",
								pay_pwd,
								"' where username = '",
								this.username,
								"'"
							});
                            int a = new SqlHelper().ExecuteNonQuery(sql);
                            if (a > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('设置成功！');location.href='tixian.aspx';", true);
                            }
                        }
                    }
                }
            }
        }
    }
}