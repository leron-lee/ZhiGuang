using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class up_center : System.Web.UI.Page
    {
        public string username;
        public string dp;
        public string disabled = "disabled = 'disabled' style='background-image:none;'";
        public string s_sheng;
        public string s_shi;
        public string s_xian;
   
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.sex.SelectedValue = r["sex"].ToString();
                        this.name.Text = r["name"].ToString();
                        this.address.Text = r["address"].ToString();
                        this.phone.Text = r["phone"].ToString();
                        this.gsname.Text = r["gsname"].ToString();
                        this.sy_key.Text = r["sy_key"].ToString();
                        this.sy_contus.Text = r["sy_contus"].ToString();
                        this.s_sheng = r["s_sheng"].ToString();
                        this.s_shi = r["s_shi"].ToString();
                        this.s_xian = r["s_xian"].ToString();
                        if (r["s_xian"].ToString() == "")
                        {
                            this.disabled = "";
                        }
                        if (r["jb"].ToString() == "6")
                        {
                            this.dp = "";
                        }
                    }
                }
            }
        }
        protected void bt_Click(object sender, System.EventArgs e)
        {
            string sex = this.sex.SelectedValue;
            string name = this.name.Text.Trim();
            string phone = this.phone.Text;
            string address = this.address.Text;
            string gsname = this.gsname.Text;
            string sy_key = this.sy_key.Text;
            string sy_contus = this.sy_contus.Text;
            string s_sheng = base.Request.Form["s_sheng"];
            string s_shi = base.Request.Form["s_shi"];
            string s_xian = base.Request.Form["s_xian"];
            if (s_sheng == null)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        s_sheng = r["s_sheng"].ToString();
                        s_shi = r["s_shi"].ToString();
                        s_xian = r["s_xian"].ToString();
                    }
                }
            }
            if (sex == "")
            {
              
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请选择您的性别');", true);
            }
            else
            {
                if (name == "")
                {
                  
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入您的姓名');", true);
                }
                else
                {
                    SqlParameter[] op = new SqlParameter[]
					{
						new SqlParameter("@sex", sex),
						new SqlParameter("@name", name),
						new SqlParameter("@phone", phone),
						new SqlParameter("@address", address),
						new SqlParameter("@s_sheng", s_sheng),
						new SqlParameter("@s_shi", s_shi),
						new SqlParameter("@s_xian", s_xian),
						new SqlParameter("@gsname", gsname),
						new SqlParameter("@sy_key", sy_key),
						new SqlParameter("@sy_contus", sy_contus)
					};
                    string sql = "update username set sex=@sex,name=@name,phone=@phone,address=@address,s_sheng=@s_sheng,s_shi=@s_shi,s_xian=@s_xian,gsname=@gsname,sy_key=@sy_key,sy_contus=@sy_contus where username = '" + this.username + "'";
                    int a = new SqlHelper().ExecuteNonQuery(sql, op);
                    if (a > 0)
                    {
                   
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('修改成功');", true);
                    }
                }
            }
        }
    }
}