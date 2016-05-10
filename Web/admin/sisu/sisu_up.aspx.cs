using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.sisu
{
    public partial class sisu_up : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sqlstring = "select * from sisu where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox3.Text = r["username"].ToString();
                            string ltype = r["ltype"].ToString();
                            this.ltype.SelectedValue = ltype;
                            this.bj.Text = r["ntest"].ToString();
                            this.TextBox1.Text = r["ntest"].ToString();
                            this.href.Text = r["ntest"].ToString();
                            if (ltype == "1")
                            {
                                this.Panel3.Visible = true;
                            }
                            else
                            {
                                if (ltype == "2")
                                {
                                    this.Panel2.Visible = true;
                                }
                                else
                                {
                                    if (ltype == "3")
                                    {
                                        this.Panel4.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.Button1.Text = " 增加 ";
                    this.Panel3.Visible = true;
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string t = this.TextBox3.Text;
            string t2 = this.TextBox1.Text;
            string ltype = this.ltype.SelectedValue;
            string url = base.Request.QueryString["url"];
            if (ltype == "2")
            {
                t2 = this.bj.Text;
            }
            else
            {
                if (ltype == "3")
                {
                    t2 = this.href.Text;
                }
            }
            int tid = 0;
            if (base.Request.QueryString["tid"] != null)
            {
                tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
            }
            SqlParameter[] sp = new SqlParameter[]
			{
				new SqlParameter("@username", t),
				new SqlParameter("@ntest", t2),
				new SqlParameter("@tid", tid)
			};
            string sqlstring = string.Empty;
            if (base.Request.QueryString["id"] != null)
            {
                sqlstring = "update sisu set username=@username,ntest=@ntest where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
            }
            else
            {
                sqlstring = "insert into sisu (username,Ltype,ntest,tid) values(@username," + ltype + ",@ntest,@tid)";
            }
            int a = new SqlHelper().ExecuteNonQuery(sqlstring, sp);
            if (a > 0)
            {
                base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('",
					this.Button1.Text.Trim(),
					"成功');location.href='",
					url,
					"';</script>"
				}));
                base.Response.End();
            }
        }
        protected void ltype_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string ltype = this.ltype.SelectedValue;
            if (base.Request.QueryString["id"] != null)
            {
                string id = base.Request.QueryString["id"];
                new SqlHelper().ExecuteNonQuery("update sisu set Ltype = " + ltype + " where id = " + id);
            }
            if (ltype == "1")
            {
                this.Panel2.Visible = false;
                this.Panel4.Visible = false;
                this.Panel3.Visible = true;
            }
            else
            {
                if (ltype == "2")
                {
                    this.Panel3.Visible = false;
                    this.Panel4.Visible = false;
                    this.Panel2.Visible = true;
                }
                else
                {
                    if (ltype == "3")
                    {
                        this.Panel2.Visible = false;
                        this.Panel3.Visible = false;
                        this.Panel4.Visible = true;
                    }
                }
            }
        }
    }
}