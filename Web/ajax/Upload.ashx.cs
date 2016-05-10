using System;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string photoName = postedFile.FileName;
            int i = photoName.LastIndexOf(".");
            string newext = photoName.Substring(i).ToLower();
            if (newext == ".aspx" || newext == ".asp" || newext == ".php" || newext == ".jsp" || newext == ".cgi" || newext == ".asa" || newext == ".ashx")
            {
                context.Response.Write("文件格式不正确!");
                context.Response.End();
            }
            System.DateTime now = System.DateTime.Now;
            string nyr = "/file/" + get.nyrsfm();
            string photoName2 = nyr + newext;
            postedFile.SaveAs(context.Server.MapPath(photoName2));
            if (context.Request.QueryString["yzm"] != null)
            {
                photoName2 = new WaterImageManage().DrawWords(photoName2, "www.albeads.com", 0.3f, ImagePosition.Center, context.Server.MapPath("/"));
            }
            string sqlstring = string.Concat(new string[]
			{
				"insert into filedata (filename,fileurl,times) values('",
				postedFile.FileName.Substring(0, photoName.LastIndexOf(".")),
				"','",
				photoName2,
				"','",
				System.DateTime.Now.ToString().ToString(),
				"')"
			});
            new SqlHelper().ExecuteNonQuery(sqlstring);
            context.Response.Write(photoName2);
            context.Response.StatusCode = 200;
        }
    }
}