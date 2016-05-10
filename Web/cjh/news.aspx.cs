using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CT.WebUtility;
namespace Web.cjh
{
    public partial class news : System.Web.UI.Page
    {

        public string imgdis;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new access().ExecuteDataTable("select * from cjh_news where id = " + id))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r["imgc"].ToString() == "")
                            {
                                this.imgdis = "dis";
                            }
                            
                            if(Convert.ToInt32(r["type"])==1)
                            {
                                Panel1.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            int tid = Convert.ToInt32(Request.QueryString["id"]);
            string times = DateTime.Now.ToString();

            SqlParameter[] sp = new SqlParameter[] { 
                
                new SqlParameter("@username",username),
                new SqlParameter("@tid",tid),
                new SqlParameter("@times",times),
            };

            int count = Convert.ToInt32(Sql.Query("select count(id) from cjh_baoming where tid="+tid +" and username='"+username+"'"));

            if (count == 1)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您已经报名！');self.location.href='" + Request.RawUrl + "'</script>");
            }
            else {

                string sql = "insert into cjh_baoming (username,tid,times) values (@username,@tid,@times)";
                if(Sql.command(sql,sp) > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('恭喜您报名成功！');self.location.href='" + Request.RawUrl + "'</script>");
                }
            }
        }
    }
}