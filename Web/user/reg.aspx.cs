using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class reg : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {


             
                string value = "";
                if (base.Request.QueryString["openid"] != null)
                {
                    value = base.Request.QueryString["openid"];
                }
                string text = "";
                if (base.Request.QueryString["name"] != null)
                {
                    text = base.Request.QueryString["name"];
                }
                string value2 = "";
                if (base.Request.QueryString["img"] != null)
                {
                    value2 = base.Request.QueryString["img"];
                }
                int num = 1881101;
                string value3 = new SqlHelper().ExecuteScalar("select top 1 id from username order by id desc");
                if (!string.IsNullOrEmpty(value3))
                {
                    num += System.Convert.ToInt32(value3);
                }
                string value4 = "wx_" + num;
                string text2 = "";
                string value5 = "123456";
                string text3 = "";
                string value6 = "";
                string value7 = "";
                string value8 = "6";
                string value9 = System.DateTime.Now.ToString();
                if (base.Request.Cookies["tj_username"] != null)
                {
                   // new SqlHelper().ExecuteNonQuery("insert into ceshi (a) values('121212')");
                    text3 = base.Server.UrlDecode(base.Request.Cookies["tj_username"].Value);
                    value6 = this._tj_ywy(text3);
                    value7 = this._tj_mendian(text3);
                }
                string value10 = new SqlHelper().ExecuteScalar("select id from username where username = '" + text2 + "'");
                if (!string.IsNullOrEmpty(value10))
                {
                    base.Response.Write("<script>alert('该手机号码已经被注册');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
                else
                {
                    SqlParameter[] parameters = new SqlParameter[]
					{
						new SqlParameter("@openid", value),
						new SqlParameter("@username", value4),
						new SqlParameter("@pwd", value5),
						new SqlParameter("@phone", text2),
						new SqlParameter("@name", text),
						new SqlParameter("@img", value2),
						new SqlParameter("@tj_username", text3),
						new SqlParameter("@tj_ywy", value6),
						new SqlParameter("@tj_mendian", value7),
						new SqlParameter("@jb", value8),
						new SqlParameter("@times", value9)
					};
                    string query = "insert into username (openid,username,pwd,phone,name,img,tj_username,tj_ywy,tj_mendian,jb,times) values(@openid,@username,@pwd,@phone,@name,@img,@tj_username,@tj_ywy,@tj_mendian,@jb,@times)";
                    int num2 = new SqlHelper().ExecuteNonQuery(query, parameters);
                    if (num2 > 0)
                    {
                        HttpCookie httpCookie = new HttpCookie("username");
                        httpCookie.Expires = System.DateTime.Now.AddYears(1);
                        httpCookie.Value = base.Server.UrlEncode(text2);
                        base.Response.Cookies.Add(httpCookie);

                        if (text3 != "")
                        {
                            new SqlHelper().ExecuteNonQuery("update username set cb=cb+3 where id="+text3);
                           // string first = text2;
                            //string keyword = text;
                            //string keyword2 = System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString();
                            //string remark = "您目前的会员人数：" + get.ren(text3);
                           // getwx.xiaoxi_reg(first, keyword, keyword2, remark, text3);
                        }

                        base.Response.Redirect("http://mp.weixin.qq.com/s?__biz=MzI5MjEwNzg3MA==&mid=402839653&idx=1&sn=6e388849cd4a66a5ea89d96407aeb582#rd");
                    }
                }



                
            }
        }
        protected void reg_bt_Click(object sender, System.EventArgs e)
        {
          
          
        }
        public string tj_um(string tj_username)
        {
            string fig = "";
            string jb = get.jb_dq(get.username(tj_username));
            if (jb == "6")
            {
                tj_username = new SqlHelper().ExecuteScalar("select tj_username from username where id = " + tj_username);
                if (!string.IsNullOrEmpty(tj_username) && tj_username != "0")
                {
                    fig = this.tj_um(tj_username);
                }
            }
            else
            {
                fig = tj_username;
            }
            return fig;
        }

        public string _tj_ywy(object username)
        {
            string result = "";
            using (DataTable dataTable = new SqlHelper().ExecuteDataTable("select tj_username,jb,username from username where username = '" + username + "'"))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow["jb"].ToString() == "3")
                    {
                        result = dataRow["username"].ToString();
                    }
                    else
                    {
                        if (dataRow["tj_username"].ToString() != "")
                        {
                            result = this._tj_ywy(dataRow["tj_username"]);
                        }
                    }
                }
            }
            return result;
        }
        public string _tj_mendian(object username)
        {
            string result = "";
            using (DataTable dataTable = new SqlHelper().ExecuteDataTable("select tj_username,jb,username from username where username = '" + username + "'"))
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataRow["jb"].ToString() == "2")
                    {
                        result = dataRow["username"].ToString();
                    }
                    else
                    {
                        if (dataRow["tj_username"].ToString() != "")
                        {
                            result = this._tj_mendian(dataRow["tj_username"]);
                        }
                    }
                }
            }
            return result;
        }
    }
}