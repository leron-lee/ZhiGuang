using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.fh
{
    public partial class sel : System.Web.UI.Page
    {
        public string fystr;
        public string zong;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Page.Title = "我的订单 - " + get.gsstr();
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from s_sheng order by id"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lt = new ListItem();
                        lt.Text = r["name"].ToString();
                        this.sheng.Items.Add(lt);
                    }
                }
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = " and zt = 2 ";
                if (!string.IsNullOrEmpty(base.Request.QueryString["ordernumber"]))
                {
                    string ordernumber = base.Request.QueryString["ordernumber"];
                    username = username + "&ordernumber=" + base.Server.UrlEncode(ordernumber);
                    this.ordernumber.Text = ordernumber;
                    sqlw = sqlw + " and ordernumber = '" + ordernumber + "' ";
                }
                if (!string.IsNullOrEmpty(base.Request.QueryString["sheng"]))
                {
                    string sheng = base.Request.QueryString["sheng"];
                    username = username + "&sheng=" + base.Server.UrlEncode(sheng);
                    this.sheng.SelectedValue = sheng;
                    sqlw = sqlw + " and address like '" + sheng + "%' ";
                }
                string sqlstring = string.Empty;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from shoporder where id <> 0 ",
						sqlw,
						" order by id desc"
					});
                }
                else
                {
                    string zid_sql_one = string.Concat(new object[]
					{
						"select top ",
						(p - 1) * x,
						" id from shoporder where id <> 0 ",
						sqlw,
						" order by id desc"
					});
                    string zid_sqltwo = "select top 1 id from shoporder where id in (" + zid_sql_one + ") order by id";
                    string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                    sqlstring = string.Concat(new object[]
					{
						"select top ",
						x,
						" * from shoporder where id <(",
						zid,
						") ",
						sqlw,
						" order by id desc"
					});
                }
                using (DataTable d = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = d;
                    this.Repeater1.DataBind();
                }
                this.fystr = en_page.fystr_one(x, "shoporder where id <> 0 " + sqlw, username, p, "pagex", "id", 1);
                this.zong = new SqlHelper().ExecuteScalar("select count(id) from shoporder where id <> 0 " + sqlw);
                this.fq.Text = this.zong;
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "id");
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + id + " order by id"))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
        protected void sx_bt_Click(object sender, System.EventArgs e)
        {
            string sheng = this.sheng.SelectedValue;
            string ordernumber = this.ordernumber.Text;
            base.Response.Redirect("sel.aspx?sheng=" + sheng + "&ordernumber=" + ordernumber);
        }
        protected void fh_bt_Click(object sender, System.EventArgs e)
        {
            string fq = this.fq.Text;
            long zong = System.Convert.ToInt64(fq);
            string fname_id = this.fname_id.SelectedValue;
            string fname = this.fname_id.SelectedItem.Text;
            long danhao = System.Convert.ToInt64(this.danhao.Text);
            long jsdanhao = danhao + zong - 1L;
            string sqlw = " and zt = 2 ";
            if (!string.IsNullOrEmpty(base.Request.QueryString["ordernumber"]))
            {
                string ordernumber = base.Request.QueryString["ordernumber"];
                sqlw = sqlw + " and ordernumber = '" + ordernumber + "' ";
            }
            if (!string.IsNullOrEmpty(base.Request.QueryString["sheng"]))
            {
                string sheng = base.Request.QueryString["sheng"];
                sqlw = sqlw + " and address like '" + sheng + "%' ";
            }
            string sqlstring = string.Concat(new object[]
			{
				"select top ",
				zong,
				" * from shoporder where id <> 0 ",
				sqlw,
				" order by id desc"
			});
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                foreach (DataRow r in dt.Rows)
                {
                    string sql = string.Concat(new object[]
					{
						"update shoporder set fdan = '",
						danhao,
						"',fname_id='",
						fname_id,
						"',fname='",
						fname,
						"',zt=3 where id = ",
						r["id"]
					});
                    new SqlHelper().ExecuteNonQuery(sql);
                    danhao += 1L;
                }
                this.ExportTable_fen(dt, jsdanhao);
            }
        }
        public void ExportTable_fen(DataTable tb, long jsdanhao)
        {
            long danhao = System.Convert.ToInt64(this.danhao.Text);
            DataTable dtt = new DataTable();
            dtt.Columns.Add("业务单号", typeof(string));
            dtt.Columns.Add("寄件单位", typeof(string));
            dtt.Columns.Add("寄件人姓名", typeof(string));
            dtt.Columns.Add("寄件人电话", typeof(string));
            dtt.Columns.Add("寄件人手机", typeof(string));
            dtt.Columns.Add("寄件人省", typeof(string));
            dtt.Columns.Add("寄件人市", typeof(string));
            dtt.Columns.Add("寄件区/县", typeof(string));
            dtt.Columns.Add("寄件人地址", typeof(string));
            dtt.Columns.Add("寄件人邮编", typeof(string));
            dtt.Columns.Add("收件人姓名", typeof(string));

            dtt.Columns.Add("收件人电话", typeof(string));
            dtt.Columns.Add("收件人手机", typeof(string));
            dtt.Columns.Add("收件人地址", typeof(string));
            dtt.Columns.Add("收件邮政编码", typeof(string));
            dtt.Columns.Add("运费", typeof(string));
            dtt.Columns.Add("订单金额", typeof(string));
            dtt.Columns.Add("商品名称", typeof(string));
            dtt.Columns.Add("商品编码", typeof(string));
            dtt.Columns.Add("销售属性", typeof(string));
            dtt.Columns.Add("商品金额", typeof(string));
            dtt.Columns.Add("数量", typeof(string));
            dtt.Columns.Add("备注", typeof(string));
            foreach (DataRow row in tb.Rows)
            {
                string bz = "";
                string s10 = "";
                string s11 = "";
                int sum = 0;
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + row["id"]))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        s10 += get.m_str(r["mid"], "s10");
                        sum += Convert.ToInt32(r["sum"]);
                        object obj = bz;
                        s11 += get.m_str(r["mid"], "name");
                    }
                }
                if (row["bz"].ToString() != "")
                {
                    bz = bz + "备注：" + row["bz"];
                }
                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
				{
					"update shoporder set ftimes = '",
					System.DateTime.Now.ToString(),
					"' where id = ",
					row["id"]
				}));
                DataRow drt2 = dtt.NewRow();
                drt2[0] = row["ordernumber"];
                drt2[1] = "";
                drt2[2] = "";
                drt2[3] = "";
                drt2[4] = "";
                drt2[5] = "";
                drt2[6] = "";
                drt2[7] = "";
                drt2[8] = "";
                drt2[9] = "";
                drt2[10] = row["name"];
                drt2[11] = "";
                drt2[12] = row["tel"];
                drt2[13] = row["address"];
                drt2[14] = "";
                drt2[15] = "";
                drt2[16] = "";
                drt2[17] = s11;
                drt2[18] = s10;
                drt2[19] = row["times"];
                drt2[20] = "";
                drt2[21] = sum.ToString();
                drt2[22] = "";




                dtt.Rows.Add(drt2);
            }
            string name = danhao + "-" + jsdanhao;
            string file = "/file/" + name + ".xls";
            ExcelHelper.DataTabletoExcel(dtt, base.Server.MapPath(file));
            SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@name", name),
				new SqlParameter("@neirong", file),
				new SqlParameter("@times", System.DateTime.Now.ToString())
			};
            string sql = "insert into excel (name,neirong,times) values (@name,@neirong,@times)";
            new SqlHelper().ExecuteNonQuery(sql, sp);
            string sid = new SqlHelper().ExecuteScalar("select top 1 id from excel order by id desc");
            base.Response.Redirect("excel.aspx?id=" + sid);
        }
    }
}