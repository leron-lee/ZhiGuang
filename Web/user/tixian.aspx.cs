using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class tixian : System.Web.UI.Page
    {
        public double JF;
        public string username;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
                string pay_pwd = new access().ExecuteScalar("select pay_pwd from username where username = '" + this.username + "'");
                if (pay_pwd == "")
                {
                    base.Response.Redirect("tixian_newpwd.aspx");
                }
                this.JF = get.ye(this.username);
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.JE.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入提现金额！');", true);
            }
            else
            {
                if (this.zhifubao.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入提现账号！');", true);
                }
                else
                {
                    if (this.pay_pwd.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入提现密码！');", true);
                    }
                    else
                    {


                        string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);

                        int count = Convert.ToInt32(new SqlHelper().ExecuteScalar("SELECT count(*) FROM jilu WHERE datediff(month,times,getdate())=0 and tj_username='" + username + "'"));

                        if (count == 0)
                        {


                            double jf = get.ye(username);
                            int tjf = System.Convert.ToInt32(this.JE.Text);
                            string pay_pwd = this.pay_pwd.Text;
                            string sql_pay_pwd = new SqlHelper().ExecuteScalar("select pay_pwd from username where username = '" + username + "'");
                            string zhifubao = this.zhifubao.Text;
                            if (tjf < 1 || tjf % 1 != 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('每次提现金额必须是1的倍数');", true);
                            }
                            else
                            {
                                if (jf >= (double)tjf)
                                {
                                    if (sql_pay_pwd == pay_pwd)
                                    {
                                        double a = 0;
                                        if (tjf <= 3500)
                                        {
                                            a = tjf * 0.1;
                                        }
                                        else if (tjf >= 3501 && tjf <= 10000)
                                        {
                                            a = tjf * 0.2;
                                        }
                                        else if (tjf >= 10001 && tjf <= 50000)
                                        {
                                            a = tjf * 0.25;
                                        }
                                        else if (tjf >= 50001 && tjf <= 100000)
                                        {
                                            a = tjf * 0.3;
                                        }
                                        else if (tjf >= 100001 && tjf <= 300000)
                                        {
                                            a = tjf * 0.35;
                                        }
                                        else
                                        {
                                            a = tjf * 0.45;
                                        }


                                        string str = "";
                                        if (tjf <= 3500)
                                        {
                                            str = "(代扣代缴：" + a + "元)";
                                        }
                                        else
                                        {
                                            str = "(暂扣个人所得税：" + a + "元)";
                                        }
                                        string str2 = "";
                                        int type = Convert.ToInt32(RadioButtonList1.SelectedValue);
                                        if (type == 0)
                                        {
                                            str2 = "支付宝";
                                        }
                                        else
                                        {
                                            str2 = "微信钱包";
                                        }

                                        zhifubao += "姓名："+TextBox1.Text+" 电话："+TextBox2.Text;
                                        string sql = string.Concat(new object[]
									{
										"insert into jilu (tj_username,username,cao,nt,JF,zt,times) values('",
										username,
										"','",
										username,
										"',2,'提现"+str2+"：",
										tjf,
										"元 账号："+str,
										zhifubao,
										"',",
										tjf,
										",1,'",
										System.DateTime.Now,
										"')"
									});
                                        new SqlHelper().ExecuteNonQuery(sql);
                                        get.ye_cao(username, "扣除", tjf.ToString(), string.Concat(new object[]
									{
										"提现记录：",
										tjf,
										"元 账号：",
										zhifubao
									}), "");



                                        getwx.xiaoxi_tixian(tjf, "", username);

                                        base.Response.Redirect("jilu.aspx");
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('支付密码不正确！');", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('提现金额不能大于可提现金额！');", true);
                                }
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('您好，一个月只能提现一次！');", true);
                        }



                    }
                }
            }
        }
    }
}