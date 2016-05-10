using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.uppassword
{
    public partial class pass_in : System.Web.UI.Page
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
                if (tl2 == "" || tl3 == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('新密码不能为空，确定密码不能为空');</script>");
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
                        string t15 = this.TextBox2.Text;
                        string ts2 = liu.MD5(t15).Substring(7, 18);
                        string sqlstring = string.Concat(new string[]
						{
							"insert into adminlogin (username,[password],qx,iffh) values('",
							t14,
							"','",
							ts2,
							"','",
							qx,
							"',",
							iffh,
							")"
						});
                        bool fig = true;
                        string ob = new SqlHelper().ExecuteScalar("select username from adminlogin where username='" + t14 + "'");
                        if (ob != "")
                        {
                            fig = false;
                        }
                        if (fig)
                        {
                            int a = new SqlHelper().ExecuteNonQuery(sqlstring);
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
}