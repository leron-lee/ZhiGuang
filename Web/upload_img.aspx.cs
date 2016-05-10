using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class upload_img : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.myFile.PostedFile != null)
            {
                if (this.myFile.PostedFile.FileName != "")
                {
                    string photoName = this.myFile.PostedFile.FileName;
                    int i = photoName.LastIndexOf(".");
                    string newext = photoName.Substring(i).ToLower();
                    if (newext == ".aspx" || newext == ".asp" || newext == ".php" || newext == ".jsp" || newext == ".cgi" || newext == ".asa" || newext == ".ashx")
                    {
                        base.Response.Write("文件格式不正确!");
                        base.Response.End();
                    }
                    string fileName = System.IO.Path.GetFileName(this.myFile.FileName);
                    System.DateTime now = System.DateTime.Now;
                    System.Random rd = new System.Random();
                    string nyr = "/file/" + get.nyrsfm();
                    string photoName2 = nyr + newext;
                    this.myFile.PostedFile.SaveAs(base.Server.MapPath(photoName2));
                    if (base.Request.QueryString["yzm"] != null)
                    {
                        photoName2 = new WaterImageManage().DrawWords(photoName2, "www.albeads.com", 0.3f, ImagePosition.Center, base.Server.MapPath("/file/"));
                    }
                    this.TextBoxname.Text = photoName2;
                    string sqlstring = string.Concat(new string[]
					{
						"insert into filedata (filename,fileurl,times) values('','",
						photoName2,
						"','",
						System.DateTime.Now.ToString().ToString(),
						"')"
					});
                    new SqlHelper().ExecuteNonQuery(sqlstring);
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script>foo();</script>");
                }
            }
        }
    }
}