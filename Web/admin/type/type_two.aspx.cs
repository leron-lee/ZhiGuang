using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type
{
    public partial class type_two : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from type_one order by px"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        ListItem lt = new ListItem();
                        lt.Text = r["type_one_name"].ToString();
                        lt.Value = r["id"].ToString();
                        this.DropDownList1.Items.Add(lt);
                    }
                }
                if (base.Request.QueryString["id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    this.DropDownList1.SelectedValue = uid.ToString();
                    this.Literal1.Text = new SqlHelper().ExecuteScalar("select tid from type_one where id=(" + uid + ")").ToString();
                }
                if (base.Request.QueryString["uid"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["uid"]);
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from type_two where id=" + uid.ToString()))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox1.Text = r["type_two_name"].ToString();
                            this.type_two_name_en.Text = r["type_two_name_en"].ToString();
                            this.DropDownList1.SelectedValue = r["type_one_id"].ToString();
                            this.TextBox2.Text = r["title"].ToString();
                            this.TextBox3.Text = r["keyname"].ToString();
                            this.TextBox4.Text = r["conuts"].ToString();
                            this.DropDownList2.SelectedValue = r["type"].ToString();
                            this.TextBox5.Text = r["nt"].ToString();
                            this.Literal1.Text = new SqlHelper().ExecuteScalar("select tid from type_one where id=(" + r["type_one_id"] + ")").ToString();
                            this.TextBox6.Text = r["img"].ToString();
                            this.RadioButtonList1.SelectedValue = r["xid"].ToString();
                        }
                    }
                    this.Button1.Text = " 修改 ";
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            int r = System.Convert.ToInt32(this.DropDownList1.SelectedValue);
            string t = this.TextBox1.Text;
            string t2 = this.TextBox2.Text;
            string t3 = this.TextBox3.Text;
            string t4 = this.TextBox4.Text;
            string d2 = this.DropDownList2.SelectedValue;
            string t5 = this.TextBox5.Text;
            string xid = this.RadioButtonList1.SelectedValue;
            string type_two_name_en = this.type_two_name_en.Text;
            string t6 = this.TextBox6.Text;
            if (t == "")
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('新二级类别名不能为空');</script>");
            }
            else
            {
                if (r == 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>alert('请选择所属类型');</script>");
                }
                else
                {
                    string sqlstring = "select MAX(px) FROM type_two";
                    int i = 1;
                    string ob = new SqlHelper().ExecuteScalar(sqlstring);
                    if (ob != "")
                    {
                        i = System.Convert.ToInt32(ob) + 1;
                    }
                    SqlParameter[] sp = new SqlParameter[]
					{
						new SqlParameter("@type_one_id", r),
						new SqlParameter("@xid", xid),
						new SqlParameter("@type_two_name", t),
						new SqlParameter("@type_two_name_en", type_two_name_en),
						new SqlParameter("@img", t6),
						new SqlParameter("@title", t2),
						new SqlParameter("@keyname", t3),
						new SqlParameter("@conuts", t4),
						new SqlParameter("@type", d2),
						new SqlParameter("@nt", t5),
						new SqlParameter("@px", i)
					};
                    string inset;
                    if (base.Request.QueryString["uid"] != null)
                    {
                        int uid = System.Convert.ToInt32(base.Request.QueryString["uid"]);
                        string wb = new SqlHelper().ExecuteScalar("select type_one_id from type_two where id=" + uid.ToString());
                        if (wb != "")
                        {
                            if (System.Convert.ToInt32(wb) != r)
                            {
                            }
                        }
                        inset = "update type_two set type_one_id=@type_one_id,xid=@xid,type_two_name=@type_two_name,type_two_name_en=@type_two_name_en,img=@img,title=@title,keyname=@keyname,conuts=@conuts,type=@type,nt=@nt where id=" + uid.ToString();
                    }
                    else
                    {
                        inset = "insert into type_two (type_one_id,xid,type_two_name,type_two_name_en,img,title,keyname,conuts,type,nt,px) values (@type_one_id,@xid,@type_two_name,@type_two_name_en,@img,@title,@keyname,@conuts,@type,@nt,@px)";
                    }
                    int a = new SqlHelper().ExecuteNonQuery(inset, sp);
                    if (a > 0)
                    {
                        if (this.Literal1.Text == "0")
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
								"成功');location.href='",
								base.Request.RawUrl,
								"';</script>"
							}));
                            base.Response.End();
                        }
                    }
                }
            }
        }
    }
}