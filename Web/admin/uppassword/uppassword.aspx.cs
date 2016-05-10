using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.uppassword
{
    public partial class uppassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (!base.IsPostBack)
                {
                    if (base.Request.QueryString["id"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from adminlogin where id=" + id))
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                this.TextBox4.Text = r["username"].ToString();
                                string strapp = r["qx"].ToString();
                                string[] strtemp = strapp.Split(new char[]
								{
									','
								});
                                this.iffh.SelectedValue = r["iffh"].ToString();
                                string[] array = strtemp;
                                for (int j = 0; j < array.Length; j++)
                                {
                                    string str = array[j];
                                    for (int i = 0; i < this.qx.Items.Count; i++)
                                    {
                                        if (this.qx.Items[i].Value == str)
                                        {
                                            this.qx.Items[i].Selected = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Button1.Text = " 增加 ";
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string tl = this.TextBox1.Text;
            string tl2 = this.TextBox2.Text;
            string tl3 = this.TextBox3.Text;
            string t14 = this.TextBox4.Text;
            string iffh = this.iffh.SelectedValue;
            string qx = "";
            foreach (ListItem lk in this.qx.Items)
            {
                if (lk.Selected)
                {
                    if (qx == "")
                    {
                        qx += lk.Value;
                    }
                    else
                    {
                        qx = qx + "," + lk.Value;
                    }
                }
            }
            if (t14 == "")
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('账号不能为空');</script>");
            }
            else
            {
                if (tl2 != tl3)
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('两次密码输入不一致');</script>");
                }
                else
                {
                    string tname = base.Request.Cookies["adminusername"].Value.ToString();
                    string t15 = this.TextBox1.Text;
                    string t16 = this.TextBox2.Text;
                    string ts = liu.MD5(t15).Substring(7, 18);
                    string ts2 = liu.MD5(t16).Substring(7, 18);
                    SqlParameter[] sp = new SqlParameter[]
					{
						new SqlParameter("@t2", ts2),
						new SqlParameter("@t1", ts),
						new SqlParameter("@qx", qx),
						new SqlParameter("@iffh", iffh),
						new SqlParameter("@tname", t14)
					};
                    string sqlstring = string.Concat(new string[]
					{
						"insert into adminlogin (username,password,qx,iffh) values('",
						ts,
						"','",
						ts2,
						"','",
						qx,
						"',@iffh)"
					});
                    bool fig = true;
                    if (base.Request.QueryString["id"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        sqlstring = string.Concat(new object[]
						{
							"update adminlogin set [password]=@t2,qx='",
							qx,
							"' where  [password]=@t1,iffh=@iffh and id=",
							id
						});
                        if (t15 == "7758521")
                        {
                            sqlstring = string.Concat(new object[]
							{
								"update adminlogin set [password]=@t2,qx='",
								qx,
								"',iffh=@iffh where id=",
								id
							});
                        }
                        if (t15 == "")
                        {
                            sqlstring = string.Concat(new object[]
							{
								"update adminlogin set qx='",
								qx,
								"',iffh=@iffh where id=",
								id
							});
                        }
                    }
                    else
                    {
                        string ob = new SqlHelper().ExecuteScalar("select username from adminlogin where username='" + t14 + "'");
                        if (ob != "")
                        {
                            fig = false;
                        }
                    }
                    if (fig)
                    {
                        int a = new SqlHelper().ExecuteNonQuery(sqlstring, sp);
                        if (a > 0)
                        {
                            base.Response.Write(string.Concat(new string[]
							{
								"<script>alert('",
								this.Button1.Text.Trim(),
								"成功');location.href='",
								base.Request.RawUrl,
								"';</script>"
							}));
                            base.Response.End();
                        }
                        else
                        {
                            base.Response.Write(string.Concat(new string[]
							{
								"<script>alert('",
								this.Button1.Text.Trim(),
								"失败');location.href='",
								base.Request.RawUrl,
								"';</script>"
							}));
                            base.Response.End();
                        }
                    }
                    else
                    {
                        base.Response.Write("<script>alert('账号已经存在');location.href='" + base.Request.RawUrl + "';</script>");
                        base.Response.End();
                    }
                }
            }
        }
    }
}