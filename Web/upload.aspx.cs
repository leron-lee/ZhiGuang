using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.Files.Count > 0)
            {
                HttpPostedFile file = base.Request.Files[0];
                string path = "/file/";
                string serverPath = base.Server.MapPath(path);
                string fileName = System.IO.Path.GetFileName(file.FileName);
                int i = fileName.LastIndexOf(".");
                string newext = fileName.Substring(i).ToLower();
                if (newext == ".aspx" || newext == ".asp" || newext == ".php" || newext == ".jsp" || newext == ".cgi" || newext == ".asa" || newext == ".ashx")
                {
                    base.Response.Write("文件格式不正确!");
                    base.Response.End();
                }
                System.DateTime now = System.DateTime.Now;
                System.Random rd = new System.Random();
                string nyr = "/file/" + get.nyrsfm();
                string photoName2 = nyr + newext;
                fileName = photoName2;
                if (!System.IO.Directory.Exists(serverPath))
                {
                    System.IO.Directory.CreateDirectory(serverPath);
                }
                string sqlstring = string.Concat(new string[]
			{
				"insert into filedata (filename,fileurl,times) values('','",
				fileName,
				"','",
				System.DateTime.Now.ToString().ToString(),
				"')"
			});
                new SqlHelper().ExecuteNonQuery(sqlstring);
                file.SaveAs(base.Server.MapPath(fileName));
                this.SendFileUploadResponse(0, fileName, fileName, "上传成功！");
            }
            else
            {
                this.SendFileUploadResponse(1, "", "", "上传失败！");
            }
        }
        public void SendFileUploadResponse(int isSucceed, string fileUrl, string fileName, string customMsg)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script type='text/javascript'>");
            base.Response.Write("(function(){var d=document.domain;while (true){try{var A=window.top.opener.document.domain;break;}catch(e) {};d=d.replace(/.*?(?:\\.|$)/,'');if (d.length==0) break;}})();");
            HttpContext.Current.Response.Write(string.Concat(new string[]
		{
			"window.parent.OnUploadCompleted(",
			isSucceed.ToString().ToLower(),
			", '",
			fileUrl,
			"', '",
			fileName,
			"', '",
			customMsg,
			"');"
		}));
            HttpContext.Current.Response.Write("</script>");
            HttpContext.Current.Response.End();
        }
    }
}