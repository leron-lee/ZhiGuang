using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.fh
{
    public partial class dzmd : System.Web.UI.Page
    {
        public string fystr;
        public string zong;
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from htkd where id = 1"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.parternID.Text = r["parternID"].ToString();
                        this.partnerKey.Text = r["partnerKey"].ToString();
                        this.sendMan.Text = r["sendMan"].ToString();
                        this.sendManPhone.Text = r["sendManPhone"].ToString();
                        this.sendProvince.Text = r["sendProvince"].ToString();
                        this.sendCity.Text = r["sendCity"].ToString();
                        this.sendCounty.Text = r["sendCounty"].ToString();
                        this.sendManAddress.Text = r["sendManAddress"].ToString();
                        this.sendPostcode.Text = r["sendPostcode"].ToString();
                    }
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 100 * from htkd_lishi order by id desc"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lt = new ListItem();
                        lt.Text = r["s2"].ToString();
                        lt.Value = "dzmd_l.aspx?id=" + r["id"].ToString();
                        this.htkd_lishi.Items.Add(lt);
                    }
                }
                this.fy();
            }
        }
        public void fy()
        {
            int x = 50;
            int p = 1;
            if (base.Request.QueryString["pagex"] != null)
            {
                p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
            }
            string username = new System.Random().Next(100).ToString();
            string sqlw = " and zt = 2 and s_sheng is not null ";
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
        protected void htjk_bt_Click(object sender, System.EventArgs e)
        {
            string parternID = this.parternID.Text;
            string partnerKey = this.partnerKey.Text;
            new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
			{
				"update htkd set parternID = '",
				parternID,
				"',partnerKey='",
				partnerKey,
				"' where id = 1"
			}));
            base.Response.Write("<script>alert('修改成功');location.href='" + base.Request.RawUrl + "';</script>");
            base.Response.End();
        }
        protected void fhdz_bt_Click(object sender, System.EventArgs e)
        {
            string sendMan = this.sendMan.Text;
            string sendManPhone = this.sendManPhone.Text;
            string sendProvince = this.sendProvince.Text;
            string sendCity = this.sendCity.Text;
            string sendCounty = this.sendCounty.Text;
            string sendManAddress = this.sendManAddress.Text;
            string sendPostcode = this.sendPostcode.Text;
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@sendMan", sendMan),
				new SqlParameter("@sendManPhone", sendManPhone),
				new SqlParameter("@sendProvince", sendProvince),
				new SqlParameter("@sendCity", sendCity),
				new SqlParameter("@sendCounty", sendCounty),
				new SqlParameter("@sendManAddress", sendManAddress),
				new SqlParameter("@sendPostcode", sendPostcode)
			};
            string sql = "update htkd set sendMan=@sendMan,sendManPhone=@sendManPhone,sendProvince=@sendProvince,sendCity=@sendCity,sendCounty=@sendCounty,sendManAddress=@sendManAddress,sendPostcode=@sendPostcode where id = 1";
            new SqlHelper().ExecuteNonQuery(sql, op);
            base.Response.Write("<script>alert('修改成功');location.href='" + base.Request.RawUrl + "';</script>");
            base.Response.End();
        }
        protected void xzfh_bt_Click(object sender, System.EventArgs e)
        {
            if (base.Request.Form["Item"] != null)
            {
                string cgfig = "0";
                string error = "";
                string[] array = base.Request.Form["Item"].Split(new char[]
				{
					','
				});
                for (int i = 0; i < array.Length; i++)
                {
                    string id = array[i];
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from shoporder where id = " + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            string parternID = this.parternID.Text;
                            string partnerKey = this.partnerKey.Text;
                            string sendMan = this.sendMan.Text;
                            string sendManPhone = this.sendManPhone.Text;
                            string sendProvince = this.sendProvince.Text;
                            string sendCity = this.sendCity.Text;
                            string sendCounty = this.sendCounty.Text;
                            string sendManAddress = this.sendManAddress.Text;
                            string sendPostcode = this.sendPostcode.Text;
                            string receiveMan = r["name"].ToString();
                            string receiveManPhone = r["tel"].ToString();
                            string receiveManAddress = r["s_address"].ToString();
                            string receivePostcode = "000000";
                            string receiveProvince = r["s_sheng"].ToString();
                            string receiveCity = r["s_shi"].ToString();
                            string receiveCounty = r["s_xian"].ToString();
                            string txLogisticID = r["ordernumber"].ToString();
                            string itemName = "衣服";
                            string itemWeight = "1";
                            string itemCount = "1";
                            string remark = "";
                            System.Collections.IEnumerator enumerator2;
                            using (DataTable dt2 = new SqlHelper().ExecuteDataTable("select * from shoporderlist where orderid = " + r["id"]))
                            {
                                enumerator2 = dt2.Rows.GetEnumerator();
                                try
                                {
                                    while (enumerator2.MoveNext())
                                    {
                                        DataRow r2 = (DataRow)enumerator2.Current;
                                        string s10 = get.m_str(r2["mid"], "s10");
                                        string sum = r2["sum"].ToString();
                                        object obj = remark;
                                        remark = string.Concat(new object[]
										{
											obj,
											s10,
											"，",
											r2["ys"],
											r2["cc"],
											"，数量：",
											sum
										});
                                    }
                                }
                                finally
                                {
                                    System.IDisposable disposable = enumerator2 as System.IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                            }
                            if (r["bz"].ToString() != "")
                            {
                                remark = remark + "，备注：" + r["bz"];
                            }
                            string bizData = string.Concat(new string[]
							{
								"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?><PrintRequest xmlns:ems=\"http://express.800best.com\"><deliveryConfirm>false</deliveryConfirm><EDIPrintDetailList><sendMan><![CDATA[",
								sendMan,
								"]]></sendMan><sendManPhone><![CDATA[",
								sendManPhone,
								"]]></sendManPhone><sendManAddress><![CDATA[",
								sendManAddress,
								"]]></sendManAddress><sendPostcode><![CDATA[",
								sendPostcode,
								"]]></sendPostcode><sendProvince><![CDATA[",
								sendProvince,
								"]]></sendProvince><sendCity><![CDATA[",
								sendCity,
								"]]></sendCity><sendCounty><![CDATA[",
								sendCounty,
								"]]></sendCounty><receiveMan><![CDATA[",
								receiveMan,
								"]]></receiveMan><receiveManPhone><![CDATA[",
								receiveManPhone,
								"]]></receiveManPhone><receiveManAddress><![CDATA[",
								receiveManAddress,
								"]]></receiveManAddress><receivePostcode><![CDATA[",
								receivePostcode,
								"]]></receivePostcode><receiveProvince><![CDATA[",
								receiveProvince,
								"]]></receiveProvince><receiveCity><![CDATA[",
								receiveCity,
								"]]></receiveCity><receiveCounty><![CDATA[",
								receiveCounty,
								"]]></receiveCounty><txLogisticID><![CDATA[",
								txLogisticID,
								"]]></txLogisticID><itemName><![CDATA[",
								itemName,
								"]]></itemName><itemWeight><![CDATA[",
								itemWeight,
								"]]></itemWeight><itemCount><![CDATA[",
								itemCount,
								"]]></itemCount><remark><![CDATA[",
								remark,
								"]]></remark></EDIPrintDetailList></PrintRequest>"
							});
                            string serviceType = "BillPrintRequest";
                            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(bizData + partnerKey);
                            byte[] targetData = md5.ComputeHash(fromData);
                            string digest = System.Convert.ToBase64String(targetData);
                            bizData = HttpUtility.UrlEncode(bizData, System.Text.Encoding.UTF8);
                            digest = HttpUtility.UrlEncode(digest, System.Text.Encoding.UTF8);
                            string _url = "http://ebill.ns.800best.com/ems/api/process";
                            string url = string.Concat(new string[]
							{
								_url,
								"?bizData=",
								bizData,
								"&serviceType=",
								serviceType,
								"&parternID=",
								parternID,
								"&digest=",
								digest,
								"&msgId=",
								get.nyrsfm()
							});
                            string fig = get.post(url);
                            bool fik = false;
                            string mailNo = "";
                            string markDestination = "";
                            enumerator2 = Regex.Matches(fig, "<mailNo>.*</mailNo>").GetEnumerator();
                            try
                            {
                                while (enumerator2.MoveNext())
                                {
                                    Match mch = (Match)enumerator2.Current;
                                    fik = true;
                                    mailNo = liu.htmlGL(mch.Value);
                                }
                            }
                            finally
                            {
                                System.IDisposable disposable = enumerator2 as System.IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                            enumerator2 = Regex.Matches(fig, "<markDestination>.*</markDestination>").GetEnumerator();
                            try
                            {
                                while (enumerator2.MoveNext())
                                {
                                    Match mch = (Match)enumerator2.Current;
                                    markDestination = liu.htmlGL(mch.Value);
                                }
                            }
                            finally
                            {
                                System.IDisposable disposable = enumerator2 as System.IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                            if (fik)
                            {
                                cgfig = cgfig + "," + r["id"];
                                new SqlHelper().ExecuteNonQuery(string.Concat(new object[]
								{
									"update shoporder set fdan='",
									mailNo,
									"',markDestination='",
									markDestination,
									"',fname_id='huitongkuaidi',fname = '汇通快运',ftimes='",
									System.DateTime.Now,
									"',zt=3 where id = ",
									r["id"],
									" "
								}));
                            }
                            else
                            {
                                error = fig.Replace("\n", "\\n");
                            }
                        }
                    }
                }
                if (cgfig != "0")
                {
                    new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
					{
						"insert into htkd_lishi (s1,s2) values ('",
						cgfig,
						"','",
						get.nyrsfm(),
						"')"
					}));
                    string sid = new SqlHelper().ExecuteScalar("select top 1 id from htkd_lishi order by id desc");
                    base.Response.Redirect("dzmd_l.aspx?id=" + sid);
                }
                else
                {
                    base.Response.Write(string.Concat(new string[]
					{
						"<script>alert('",
						error,
						"');location.href='",
						base.Request.RawUrl,
						"'</script>"
					}));
                    base.Response.End();
                }
            }
            else
            {
                base.Response.Write("<script>alert('请选择要发货的订单');location.href='" + base.Request.RawUrl + "'</script>");
                base.Response.End();
            }
        }
    }
}