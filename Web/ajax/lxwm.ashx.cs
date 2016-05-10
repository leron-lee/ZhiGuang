using System;
using System.Data.SqlClient;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// lxwm 的摘要说明
    /// </summary>
    public class lxwm : IHttpHandler
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
            if (context.Request.QueryString["t1"] != null)
            {
                string t = context.Request.QueryString["t1"].ToString();
                string t2 = context.Request.QueryString["t2"].ToString();
                string t3 = context.Request.QueryString["t3"].ToString();
                string t4 = context.Request.QueryString["t4"].ToString();
                string t5 = context.Request.QueryString["t5"].ToString();
                SqlParameter[] op = new SqlParameter[]
				{
					new SqlParameter("@name", t),
					new SqlParameter("@gsmc", t2),
					new SqlParameter("@tel", t3),
					new SqlParameter("@email", t4),
					new SqlParameter("@neir", t5),
					new SqlParameter("@times", System.DateTime.Now.ToString())
				};
                string sql = "insert into lxwm (name,gsmc,tel,email,neir,times) values(@name,@gsmc,@tel,@email,@neir,@times)";
                int a = new SqlHelper().ExecuteNonQuery(sql, op);
                if (a > 0)
                {
                }
                string url = context.Request.QueryString["url"];
                context.Response.Write("<script>alert('提交成功！');location.href='" + url + "';</script>");
                context.Response.End();
            }
        }
    }
}