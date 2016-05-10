using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class pingjia : System.Web.UI.Page
    {
        public string username;
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new object[]
					{
						"select * from shoporder where id = ",
						id,
						" and zt > 3 and username = '",
						this.username,
						"'"
					})))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                    }
                }
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "ID");
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
        protected void pj_bt_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (base.Request.Form["txt_" + r["id"]] == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('请输入评论内容！');", true);
                            return;
                        }
                    }
                    foreach (DataRow r in dt.Rows)
                    {
                        string nt = base.Request.Form["txt_" + r["id"]];
                        string mid = r["mid"].ToString();
                        string orderid = r["orderid"].ToString();
                        string times = System.DateTime.Now.ToString();
                        SqlParameter[] op = new SqlParameter[]
						{
							new SqlParameter("@username", this.username),
							new SqlParameter("@mid", mid),
							new SqlParameter("@orderid", orderid),
							new SqlParameter("@nt", nt),
							new SqlParameter("@times", times)
						};
                        string sql = "insert into pingjia (username,mid,orderid,nt,times) values(@username,@mid,@orderid,@nt,@times)";
                        new SqlHelper().ExecuteNonQuery(sql, op);
                    }
                }
                new SqlHelper().ExecuteNonQuery("update shoporder set pj = 1 where id = " + id);
                string url = base.Request.QueryString["url"];
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('提交成功！');location.href='" + url + "';", true);
            }
        }
    }
}