using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.file
{
    public partial class file_insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["del"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["del"]);
                    string fturl2 = new SqlHelper().ExecuteScalar("select fileurl from filedata where id= " + id);
                    if (fturl2 != "")
                    {
                        System.IO.FileInfo fi2 = new System.IO.FileInfo(base.Server.MapPath(fturl2));
                        if (fi2.Exists)
                        {
                            fi2.Delete();
                        }
                    }
                    string sqlstring = "delete from filedata where id=" + id;
                    new SqlHelper().ExecuteNonQuery(sqlstring);
                    base.Response.Write("<script>location.href='file_insert.aspx';</script>");
                    base.Response.End();
                }
                else
                {
                    string sqlstring = "select * from filedata";
                    using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = li;
                        this.Repeater1.DataBind();
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.myFile.PostedFile != null)
            {
                if (this.myFile.PostedFile.FileName != "")
                {
                    string photoName = this.myFile.PostedFile.FileName;
                    int i = photoName.LastIndexOf(".");
                    string newext = photoName.Substring(i);
                    string photoName2 = string.Concat(new string[]
					{
						"~/file/",
						System.DateTime.Now.Millisecond.ToString(),
						"_",
						this.myFile.PostedFile.ContentLength.ToString(),
						newext
					});
                    this.myFile.PostedFile.SaveAs(base.Server.MapPath(photoName2));
                    SqlParameter[] sp = new SqlParameter[]
					{
						new SqlParameter("@filename", this.TextBox3.Text)
					};
                    string sqlstring = string.Concat(new string[]
					{
						"insert into filedata (filename,fileurl,times) values(@filename,'~/file/",
						photoName2,
						"','",
						System.DateTime.Now.ToString().ToString(),
						"')"
					});
                    int a = new SqlHelper().ExecuteNonQuery(sqlstring, sp);
                    if (a > 0)
                    {
                        base.Response.Write("<script>alert('操作成功');location.href='" + base.Request.RawUrl + "';</script>");
                        base.Response.End();
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('操作成功');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
            }
        }
        public static string imgstr(object ob)
        {
            string fig = string.Empty;
            string sob = ob.ToString();
            string newext = System.IO.Path.GetExtension(sob).ToLower();
            if (newext == ".gif" || newext == ".jpg" || newext == ".jpeg" || newext == ".bmp" || newext == ".png")
            {
                fig = string.Concat(new string[]
				{
					"<A HREF='",
					ob.ToString(),
					"' target=\"_blank\"><img src='",
					ob.ToString(),
					"' width='50px' height='57px' /></a>"
				});
            }
            else
            {
                fig = "<img src='../images/icons/search1.PNG' width='50px' height='57px'  />";
            }
            return fig;
        }
        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if (base.Request.Form["Item"] != null)
            {
                string[] array = base.Request.Form["Item"].Split(new char[]
				{
					','
				});
                for (int i = 0; i < array.Length; i++)
                {
                    string item = array[i];
                    string id = item;
                    string fturl2 = new SqlHelper().ExecuteScalar("select fileurl from filedata where id= " + id);
                    if (fturl2 != "")
                    {
                        System.IO.FileInfo fi2 = new System.IO.FileInfo(base.Server.MapPath(fturl2));
                        if (fi2.Exists)
                        {
                            fi2.Delete();
                        }
                    }
                    string sqlstring = "delete from filedata where id=" + id;
                    new SqlHelper().ExecuteNonQuery(sqlstring);
                }
                base.Response.Write("<script>alert('删除成功...');location.href='" + base.Request.RawUrl + "';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('请选择要删除的项');location.href='" + base.Request.RawUrl + "'</script>");
            }
        }
    }
}