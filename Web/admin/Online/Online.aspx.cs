using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.Online
{
    public partial class Online : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["tid"] != null)
                {
                    int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                    string sqlstring = "select * from online where tid = " + tid + " order by px";
                    using (DataTable r = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = r;
                        this.Repeater1.DataBind();
                    }
                    string sqlstr = "select pint from ifOnline where id=1";
                    string ob = new SqlHelper().ExecuteScalar(sqlstr);
                    if (ob != "")
                    {
                        if (ob.ToString() == "0")
                        {
                            this.RadioButton1.Checked = true;
                        }
                        else
                        {
                            if (ob.ToString() == "1")
                            {
                                this.RadioButton2.Checked = true;
                            }
                        }
                    }
                }
            }
        }
        public string qqstr(object ob)
        {
            string fig = "";
            if (ob.ToString() == "1")
            {
                fig = "QQ";
            }
            else
            {
                if (ob.ToString() == "2")
                {
                    fig = "阿里旺旺";
                }
                else
                {
                    if (ob.ToString() == "3")
                    {
                        fig = "MSN  客服";
                    }
                    else
                    {
                        if (ob.ToString() == "4")
                        {
                            fig = "skype客服";
                        }
                        else
                        {
                            if (ob.ToString() == "5")
                            {
                                fig = "雅虎通";
                            }
                            else
                            {
                                if (ob.ToString() == "6")
                                {
                                    fig = "企业QQ";
                                }
                            }
                        }
                    }
                }
            }
            return fig;
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string t = this.DropDownList1.SelectedValue;
            string t2 = this.TextBox1.Text;
            string t3 = this.TextBox2.Text;
            int px = 1;
            int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
            string sqlstring = "select MAX(px) FROM Online";
            string ob = new SqlHelper().ExecuteScalar(sqlstring);
            if (ob != "")
            {
                px = System.Convert.ToInt32(ob) + 1;
            }
            SqlParameter[] op = new SqlParameter[]
			{
				new SqlParameter("@pint", t),
				new SqlParameter("@username", t2),
				new SqlParameter("@ntest", t3),
				new SqlParameter("@tid", tid.ToString()),
				new SqlParameter("@px", px.ToString())
			};
            string sq = "insert into Online (pint,username,ntest,tid,px) values(@pint,@username,@ntest,@tid,@px)";
            int a = new SqlHelper().ExecuteNonQuery(sq, op);
            if (a > 0)
            {
                base.Response.Write("<script>alert('添加成功!');location.href='" + base.Request.RawUrl + "';</script>");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from online where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
            else
            {
                if (e.CommandName == "shang")
                {
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Online where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Online where px<" + y_px.ToString() + " order by px desc"))
                    {
                        int i = 0;
                        foreach (DataRow r in dt.Rows)
                        {
                            i++;
                            x_id = System.Convert.ToInt32(r["id"]);
                            x_px = System.Convert.ToInt32(r["px"]);
                        }
                        if (i == 0)
                        {
                            bol = false;
                        }
                    }
                    if (bol)
                    {
                        string sql = "update Online set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update Online set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                        new SqlHelper().ExecuteNonQuery(sql);
                        new SqlHelper().ExecuteNonQuery(sql2);
                        base.Response.Redirect(base.Request.RawUrl);
                    }
                    else
                    {
                        base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                    }
                }
                else
                {
                    if (e.CommandName == "xia")
                    {
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Online where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Online where px>" + y_px.ToString() + " order by px"))
                        {
                            int i = 0;
                            foreach (DataRow r in dt.Rows)
                            {
                                i++;
                                x_id = System.Convert.ToInt32(r["id"]);
                                x_px = System.Convert.ToInt32(r["px"]);
                            }
                            if (i == 0)
                            {
                                bol = false;
                            }
                        }
                        if (bol)
                        {
                            string sql = "update Online set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update Online set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                            new SqlHelper().ExecuteNonQuery(sql);
                            new SqlHelper().ExecuteNonQuery(sql2);
                            base.Response.Redirect(base.Request.RawUrl);
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                        }
                    }
                }
            }
        }
        protected void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            string strsql = "update ifOnline set pint=0 where id=1";
            int a = new SqlHelper().ExecuteNonQuery(strsql);
            if (a > 0)
            {
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
        protected void RadioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            string strsql = "update ifOnline set pint=1 where id=1";
            int a = new SqlHelper().ExecuteNonQuery(strsql);
            if (a > 0)
            {
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
    }
}