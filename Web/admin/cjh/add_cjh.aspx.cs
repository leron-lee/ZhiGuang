using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CT.WebUtility;
using System.Data;
using System.Data.SqlClient;
namespace Web.admin.cjh
{
    public partial class add_cjh : System.Web.UI.Page
    {

        public string username;
        public string sj;
        public string dl_sheng;
        public string dl_shi;
        public string dl_xian;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["id"]!=null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cjh where id=" +id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {

                            dl_sheng = r["sheng"].ToString();
                            dl_shi = r["shi"].ToString();
                            dl_xian = r["xian"].ToString();
                            this.TextBox1.Text = r["username"].ToString();
                            this.TextBox2.Text = r["password"].ToString();
                            this.TextBox3.Text = r["name"].ToString();
                            this.TextBox4.Text = r["wx"].ToString();
                            this.TextBox5.Text = r["tel"].ToString();
                            this.TextBox6.Text = r["address"].ToString();
                        }
                    }
                }
            }
        }

        protected void tj_xg_Click(object sender, EventArgs e)
        {
            string sheng = base.Request.Form["s_sheng"];
            string shi = base.Request.Form["s_shi"];
            string xian = base.Request.Form["s_xian"];
            if (dl_sheng == "")
            {
                dl_sheng = "0";
            }
            if (dl_shi == "")
            {
                dl_shi = "0";
            }
            if (dl_xian == "")
            {
                dl_xian = "0";
            }
            string name = TextBox3.Text;
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string wx = TextBox4.Text;
            string tel = TextBox5.Text;
            string address = TextBox6.Text;
            string times = DateTime.Now.ToString();

            int count = Convert.ToInt32(Sql.GetSingle("select count(id) from cjh where username='" + username + "'"));

            if(Request.QueryString["id"]!=null)
            {
                count = 0;
            }

            if (count == 0 )
            {

                count = Convert.ToInt32(Sql.GetSingle("select count(id) from cjh where xian=" + xian));


                if (Request.QueryString["id"] != null)
                {
                    count = 0;
                }
                if (count == 0)
                {

                    SqlParameter[] sp = new SqlParameter[] { 
                        new SqlParameter("@sheng",sheng),
                        new SqlParameter("@shi",shi),
                        new SqlParameter("@xian",xian),
                        new SqlParameter("@name",name),
                        new SqlParameter("@username",username),
                        new SqlParameter("@password",password),
                        new SqlParameter("@wx",wx),
                        new SqlParameter("@tel",tel),
                        new SqlParameter("@address",address),
                        new SqlParameter("@times",times),
                    };

                    string sql = "insert into cjh (sheng, shi, xian, name, username, password, wx, tel, address, times) values (@sheng, @shi, @xian, @name, @username, @password, @wx, @tel, @address, @times)";

                    if (Request.QueryString["id"] != null)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);

                        sql = "update cjh set sheng=@sheng, shi=@shi, xian=@xian, name=@name, username=@username, password=@password, wx=@wx, tel=@tel, address=@address, times=@times where id=" + id;
                    }

                    if(Sql.command(sql,sp) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('茶佳会信息保存成功！');location.href='"+Request.RawUrl+"'", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('该地区已经开通，不能重复操作！');", true);
                    return;
                }
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('该会员账号已经存在！');", true);
                return;
            }


        }
    }
}