using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.shang
{
    public partial class _in : System.Web.UI.Page
    {
        public string st = "增加";
   
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.s_sheng_mo();
                this.s_shi_mo();
                this.s_xian_mo();
                if (base.Request.QueryString["id"] != null)
                {
                    this.st = "修改";
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shang where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.s_sheng.SelectedValue = r["sheng"].ToString();
                            this.shi(r["sheng"]);
                            this.s_shi.SelectedValue = r["shi"].ToString();
                            this.xian(r["shi"]);
                            this.s_xian.SelectedValue = r["xian"].ToString();
                            this.name.Text = r["name"].ToString();
                            this.phone.Text = r["phone"].ToString();
                            this.address.Text = r["address"].ToString();
                        }
                    }
                }
                this.tj_bt.Text = this.st;
            }
        }
        public void s_sheng_mo()
        {
            this.s_sheng.Items.Add(new ListItem("请选择", ""));
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_sheng order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_sheng.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        public void s_shi_mo()
        {
            this.s_shi.Items.Add(new ListItem("请选择", ""));
        }
        public void s_xian_mo()
        {
            this.s_xian.Items.Add(new ListItem("请选择", ""));
        }
        protected void s_sheng_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.shi(this.s_sheng.SelectedValue);
        }
        public void shi(object s_sheng)
        {
            this.s_shi.Items.Clear();
            this.s_shi_mo();
            this.s_xian.Items.Clear();
            this.s_xian_mo();
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_shi where shengid = " + s_sheng + " order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_shi.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        protected void s_shi_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.xian(this.s_shi.SelectedValue);
        }
        public void xian(object s_shi)
        {
            this.s_xian.Items.Clear();
            this.s_xian_mo();
            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_xian where shiid = " + s_shi + " order by id"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.s_xian.Items.Add(new ListItem(r["name"].ToString(), r["id"].ToString()));
                }
            }
        }
        protected void tj_bt_Click(object sender, System.EventArgs e)
        {
            string sheng = this.s_sheng.SelectedValue;
            string shi = this.s_shi.SelectedValue;
            string xian = this.s_xian.SelectedValue;
            string name = this.name.Text;
            string phone = this.phone.Text;
            string address = this.address.Text;
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@sheng", sheng),
				new SqlParameter("@shi", shi),
				new SqlParameter("@xian", xian),
				new SqlParameter("@name", name),
				new SqlParameter("@phone", phone),
				new SqlParameter("@address", address)
			};
            string sql = "insert into shang (sheng,shi,xian,name,phone,address) values(@sheng,@shi,@xian,@name,@phone,@address)";
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                sql = "update shang set sheng=@sheng,shi=@shi,xian=@xian,name=@name,phone=@phone,address=@address where id = " + id;
            }
            int a = new SqlHelper().ExecuteNonQuery(sql, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('" + this.tj_bt.Text + "成功');location.href='sel.aspx';</script>");
                base.Response.End();
            }
        }
    }
}