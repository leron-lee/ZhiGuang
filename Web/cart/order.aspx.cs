using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.cart
{
    public partial class order : System.Web.UI.Page
    {
        public string username;
        public double _zong = 0.0;
        public double _ddzong = 0.0;
        public double s8 = 0.0;
        public string addressid = "0";
        public string alert;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                int ren = System.Convert.ToInt32(get.ren(this.username));
                if (ren == 0)
                {
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from address where username = '" + this.username + "' order by id"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lt = new ListItem();
                        lt.Value = r["id"].ToString();
                        lt.Text = string.Concat(new object[]
						{
							get.s_sheng(r["sheng"]),
							get.s_shi(r["shi"]),
							get.s_xian(r["xian"]),
							r["address"],
							"(",
							r["name"],
							"收) ",
							r["phone"],
							" ",
							r["code"]
						});
                        this.address.Items.Add(lt);
                    }
                    if (dt.Rows.Count == 0)
                    {
                        base.Response.Redirect("/user/address_in.aspx?url=" + base.Request.RawUrl);
                    }
                }
                string mid = new SqlHelper().ExecuteScalar("select top 1 id from address where username = '" + this.username + "' and mo = 1");
                this.addressid = mid;
                this.address.SelectedValue = mid;
                if (base.Request.QueryString["cart_id"] != null)
                {
                    string cart_id = base.Request.QueryString["cart_id"];
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cart where id in (" + cart_id + ") order by id"))
                    {
                        this.Repeater1.DataSource = dt;
                        this.Repeater1.DataBind();
                        foreach (DataRow r in dt.Rows)
                        {
                            if (get.m_str(r["mid"], "iftj") == "1")
                            {
                                this._zong += System.Convert.ToDouble(get.jg(r["mid"], base.Request)) * System.Convert.ToDouble(r["shu"]);
                            }
                            else
                            {
                                this._zong += get.jg(r["mid"], base.Request) * System.Convert.ToDouble(r["shu"]);
                                this._ddzong += this._zong;
                                this.s8 += System.Convert.ToDouble(get.m_str(r["mid"], "s8")) * System.Convert.ToDouble(r["shu"]);
                            }
                        }
                        if (this.Repeater1.Items.Count == 0)
                        {
                            base.Response.Redirect("/user/shoporder.aspx");
                        }
                    }
                }
                this._zong = get.bl(this._zong, 2);
                this._ddzong = get.bl(this._ddzong, 2);
                this.s8 = get.bl(this.s8, 2);
                this.zong.Text = this._zong.ToString();
                this.zddy.Text = this.s8.ToString();
            }
        }
        protected void bt_zf_Click(object sender, System.EventArgs e)
        {
            this.bt_zf.Enabled = false;
            if (base.Request.QueryString["cart_id"] != null)
            {
                string cart_id = base.Request.QueryString["cart_id"];
                string ordernumber = get.nyrsfm();
                string addressid = this.address.SelectedValue;
                double z_2_2 = System.Convert.ToDouble(this.zddy.Text);
                double z_ = System.Convert.ToDouble(this.zong.Text);
                double z_2 = get.hb(this.username);
                double z_3 = get.xfj(this.username);
                double z_4 = get.ye(this.username);
                double hxzf = 0.0;
                double hb = 0.0;
                double xfj = 0.0;
                double ye = 0.0;
                string hb_ipt = base.Request.Form["hb_ipt"];
                string zffs = base.Request.Form["zffs"];
                if (hb_ipt != null)
                {
                    if (z_2_2 > 0.0 && z_ > 0.0)
                    {
                        if (z_2 >= z_2_2)
                        {
                            z_ -= z_2_2;
                            hb = z_2_2;
                        }
                        else
                        {
                            z_ -= z_2;
                            hb = z_2;
                        }
                        get.hb_cao(this.username, "扣除", hb.ToString(), "订单号：" + ordernumber);
                    }
                }
                z_ += get.youfei(addressid);
                hxzf = z_;
                if (zffs == "xfjzf")
                {
                    if (z_3 < hxzf)
                    {
                        base.Response.Write("<script>alert('消费劵不足，请充值。');location.href='" + base.Request.RawUrl + "';</script>");
                        base.Response.End();
                    }
                }
                else
                {
                    if (zffs == "yezf")
                    {
                        if (z_4 < hxzf)
                        {
                            base.Response.Write("<script>alert('余额不足，请充值。');location.href='" + base.Request.RawUrl + "';</script>");
                            base.Response.End();
                        }
                    }
                }
                string address_id = this.address.SelectedValue;
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cart where id in (" + cart_id + ") order by id"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        int mid = System.Convert.ToInt32(r["mid"]);
                        string mname = get.name(mid);
                        int cc = System.Convert.ToInt32(r["cc"]);
                        int shu = System.Convert.ToInt32(r["shu"]);
                        string sqlcc = new SqlHelper().ExecuteScalar("select ku from yk_two where id = " + cc);
                        if (sqlcc == "")
                        {
                            base.Response.Write(string.Concat(new string[]
							{
								"<script>alert('",
								mname,
								"，已经失效！');location.href='",
								base.Request.RawUrl,
								"';</script>"
							}));
                            base.Response.End();
                            return;
                        }
                        if (System.Convert.ToInt32(sqlcc) < shu)
                        {
                            base.Response.Write(string.Concat(new string[]
							{
								"<script>alert('",
								mname,
								"，库存不足！');location.href='",
								base.Request.RawUrl,
								"';</script>"
							}));
                            base.Response.End();
                            return;
                        }
                    }
                    if (dt.Rows.Count == 0)
                    {
                        base.Response.Write("<script>alert('请勿重复提交订单');location.href='/user/shoporder.aspx';</script>");
                        base.Response.End();
                        return;
                    }
                }
                string name = get.address_str(address_id, "name");
                this.username = this.username;
                string tel = get.address_str(address_id, "phone");
                string code = get.address_str(address_id, "code");
                string s_sheng = get.s_sheng(get.address_str(address_id, "sheng"));
                string s_shi = get.s_shi(get.address_str(address_id, "shi"));
                string s_xian = get.s_xian(get.address_str(address_id, "xian"));
                string s_address = get.address_str(address_id, "address");
                string address = s_sheng + s_shi + s_xian + s_address;
                string times = System.DateTime.Now.ToString();
                double zong = z_;
                string bz = "";
                if (CheckBox1.Checked)
                {
                    bz = "发票抬头："+TextBox1.Text;
                }
                SqlParameter[] sp = new SqlParameter[]
				{
					new SqlParameter("@username", this.username),
					new SqlParameter("@zt", "1"),
					new SqlParameter("@ordernumber", ordernumber),
					new SqlParameter("@price", zong),
					new SqlParameter("@name", name),
					new SqlParameter("@tel", tel),
					new SqlParameter("@code", code),
					new SqlParameter("@s_sheng", s_sheng),
					new SqlParameter("@s_shi", s_shi),
					new SqlParameter("@s_xian", s_xian),
					new SqlParameter("@s_address", s_address),
					new SqlParameter("@address", address),
					new SqlParameter("@times", times),
					new SqlParameter("@hb", hb),
					new SqlParameter("@xfj", xfj),
					new SqlParameter("@ye", ye),
					new SqlParameter("@hxzf", hxzf),
                    new SqlParameter("@bz", bz)
				};
                string sql = "insert into shoporder (username,zt,ordernumber,price,name,tel,code,s_sheng,s_shi,s_xian,s_address,address,times,hb,xfj,ye,hxzf,bz) values (@username,@zt,@ordernumber,@price,@name,@tel,@code,@s_sheng,@s_shi,@s_xian,@s_address,@address,@times,@hb,@xfj,@ye,@hxzf,@bz)";
                int a = new SqlHelper().ExecuteNonQuery(sql, sp);
                if (a > 0)
                {
                    string orderid = new SqlHelper().ExecuteScalar("select top 1 id from shoporder where username = '" + this.username + "' order by id desc");
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from cart where id in (" + cart_id + ") order by id"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            string mid2 = r["mid"].ToString();
                            string sum = r["shu"].ToString();
                            string _price;
                            if (get.m_str(r["mid"], "iftj") == "1")
                            {
                                _price = get.jg(r["mid"], base.Request).ToString();
                            }
                            else
                            {
                                _price = get.jg(r["mid"], base.Request).ToString();
                            }
                            string mname = get.name(System.Convert.ToInt32(r["mid"]));
                            string mx_img = get.m_str(r["mid"], "x_img");
                            string ys = new access().ExecuteScalar("select name from yk_one where id = " + r["ys"]);
                            string cc2 = new access().ExecuteScalar("select name from yk_two where id = " + r["cc"]);
                            SqlParameter[] splist = new SqlParameter[]
							{
								new SqlParameter("@OrderId", orderid),
								new SqlParameter("@mid", mid2),
								new SqlParameter("@sum", sum),
								new SqlParameter("@price", _price),
								new SqlParameter("@mname", mname),
								new SqlParameter("@mx_img", mx_img),
								new SqlParameter("@ys", ys),
								new SqlParameter("@cc", cc2)
							};
                            string sqlsqllist = "insert into shoporderlist (OrderId,mid,[sum],price,mname,mx_img,ys,cc) values (@OrderId,@mid,@sum,@price,@mname,@mx_img,@ys,@cc)";
                            new SqlHelper().ExecuteNonQuery(sqlsqllist, splist);
                            new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
							{
								"update yk_two set ku = ku - ",
								r["shu"],
								" where id = ",
								r["cc"]
							}));
                            new SqlHelper().ExecuteNonQuery("delete from cart where id = " + r["id"]);
                            new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
							{
								"update merchandise set s3 = s3+",
								r["shu"],
								" where id = ",
								r["mid"]
							}));
                        }
                    }
                }
                if (zffs == "xfjzf")
                {
                    get.xfj_cao(this.username, "扣除", hxzf.ToString(), "订单号：" + ordernumber);
                    get.zfcg(ordernumber);
                    base.Response.Write("<script>alert('支付成功');location.href='/user/shoporder.aspx';</script>");
                    base.Response.End();
                }
                else
                {
                    if (zffs == "yezf")
                    {
                        get.ye_cao(this.username, "扣除", hxzf.ToString(), "订单号：" + ordernumber, "");
                        get.zfcg(ordernumber);
                        base.Response.Write("<script>alert('支付成功，公司代表你向“把爱传递”爱心捐款1元！');location.href='/user/shoporder.aspx';</script>");
                        base.Response.End();
                    }
                    else
                    {
                        if (zffs == "zfb")
                        {
                            base.Response.Redirect("/cart/pay.aspx?ordernumber=" + ordernumber + "&zffs=zfb");
                        }
                        else
                        {
                            if (zffs == "wx")
                            {
                                base.Response.Redirect("/cart/pay.aspx?ordernumber=" + ordernumber + "&zffs=wx");
                            }
                        }
                    }
                }
            }
        }
    }
}