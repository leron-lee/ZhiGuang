using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class address_in : System.Web.UI.Page
    {
        public string username;
        public string sv;
        public string sheng;
        public string shi;
        public string xian;
       
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    this.sv = "修改";
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from address where id =" + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name.Text = r["name"].ToString();
                            this.phone.Text = r["phone"].ToString();
                            this.address.Text = r["address"].ToString();
                            this.sheng = r["sheng"].ToString();
                            this.shi = r["shi"].ToString();
                            this.xian = r["xian"].ToString();
                        }
                    }
                }
                else
                {
                    this.sv = "增加";
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.sheng = r["s_sheng"].ToString();
                            this.shi = r["s_shi"].ToString();
                            this.xian = r["s_xian"].ToString();
                        }
                    }
                }
                this.bt_tj.Text = this.sv;
            }
        }
        protected void bt_tj_Click(object sender, System.EventArgs e)
        {
            string name = this.name.Text;
            string phone = this.phone.Text;
            string code = "";
            string sheng = base.Request.Form["s_sheng"].Replace("省份", "");
            string shi = base.Request.Form["s_shi"].Replace("城市", "");
            string xian = base.Request.Form["s_xian"].Replace("县区", "");
            string address = this.address.Text;
            string mo = "0";
            if (name == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入收货人姓名');", true);
            }
            else
            {
                if (phone.Length != 11)
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入11位的手机号码');", true);
                }
                else
                {
                    if (sheng == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入省份');", true);
                    }
                    else
                    {
                        if (shi == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入地区');", true);
                        }
                        else
                        {
                            if (xian == "")
                            {
                                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入县市');", true);
                            }
                            else
                            {
                                if (address == "")
                                {
                                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入详细地址');", true);
                                }
                                else
                                {
                                    string s_xian = new SqlHelper().ExecuteScalar("select s_xian from username where username = '" + this.username + "'");
                                    if (string.IsNullOrEmpty(s_xian) || s_xian == "0")
                                    {
                                        new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
										{
											"update username set s_sheng = ",
											sheng,
											",s_shi=",
											shi,
											",s_xian=",
											xian,
											" where username = '",
											this.username,
											"'"
										}));
                                    }
                                    SqlParameter[] op = new SqlParameter[]
									{
										new SqlParameter("@name", name),
										new SqlParameter("@phone", phone),
										new SqlParameter("@code", code),
										new SqlParameter("@sheng", sheng),
										new SqlParameter("@shi", shi),
										new SqlParameter("@xian", xian),
										new SqlParameter("@address", address),
										new SqlParameter("@mo", mo)
									};
                                    string sql = "insert into address (username,name,phone,code,sheng,shi,xian,address,mo) values('" + this.username + "',@name,@phone,@code,@sheng,@shi,@xian,@address,@mo)";
                                    if (base.Request.QueryString["id"] != null)
                                    {
                                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                                        sql = string.Concat(new object[]
										{
											"update address set name=@name,phone=@phone,code=@code,sheng=@sheng,shi=@shi,xian=@xian,address=@address where id = ",
											id,
											" and username = '",
											this.username,
											"'"
										});
                                    }
                                    int a = new SqlHelper().ExecuteNonQuery(sql, op);
                                    if (a > 0)
                                    {
                                        string url = "address.aspx";
                                        if (base.Request.QueryString["url"] != null)
                                        {
                                            url = base.Request.QueryString["url"];
                                        }
                                        get.mo(this.username);
                                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), string.Concat(new string[]
										{
											"alert('",
											this.bt_tj.Text,
											"成功');location.href='",
											url,
											"';"
										}), true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}