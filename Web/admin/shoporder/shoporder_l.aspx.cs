using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.shoporder
{
    public partial class shoporder_l : System.Web.UI.Page
    {
        public object hb = "0";
        public object xfj = "0";
        public object ye = "0";
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Page.Title = "订单详情 - " + get.gsstr();
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporder where id = " + id))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            this.zt.Text = r["zt"].ToString();
                            this.fdan.Text = r["fdan"].ToString();
                            this.fname_id.SelectedValue = r["fname_id"].ToString();
                            this.s2.Text = r["price"].ToString();
                            this.ftimes.Text = r["ftimes"].ToString();
                            this.bz.Text = r["bz"].ToString();
                            this.hb = r["hb"];
                            this.xfj = r["xfj"];
                            this.ye = r["ye"];
                            this.s1.Text = new SqlHelper().ExecuteScalar("select count(id) from shoporderlist where orderid = " + id);
                        }
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                    {
                        this.Repeater2.DataSource = dt;
                        this.Repeater2.DataBind();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string id = base.Request.QueryString["id"];
            string url = base.Request.QueryString["url"];
            string zt = this.zt.SelectedValue;
            string fdan = this.fdan.Text;
            string fname_id = this.fname_id.SelectedValue;
            string fname = this.fname_id.SelectedItem.Text;
            string bz = this.bz.Text;
            SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@bz", bz)
			};
            new SqlHelper().ExecuteNonQuery("update shoporder set bz = @bz  where id = " + id, sp);
            string sql = string.Concat(new string[]
			{
				"update shoporder set fdan = '",
				fdan,
				"',fname_id='",
				fname_id,
				"',fname='",
				fname,
				"',zt=",
				zt,
				" where id = ",
				id
			});
            new SqlHelper().ExecuteNonQuery(sql);
            if (zt == "3")
            {
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update shoporder set ftimes = '",
					System.DateTime.Now,
					"' where id = ",
					id
				}));
            }
            base.Response.Write("<script>alert('修改成功!');location.href='" + url + "';</script>");
            base.Response.End();
        }
    }
}