using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.admin
{
    public partial class UserReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlw = "";
                if (base.Request.QueryString["username"] != null)
                {
                    string um = base.Request.QueryString["username"];
                    if (um != "")
                    {
                        sqlw = " and a.UserName like '%" + um + "%' ";
                        username = username + "&username=" + base.Server.UrlEncode(um);
                        this.username.Text = um;
                    }
                }
                if (base.Request.QueryString["tj_username"] != null)
                {
                    string tj_username = base.Request.QueryString["tj_username"];
                    if (tj_username != "")
                    {
                        string usernameid = get.username_id(tj_username);
                        if (usernameid != "")
                        {
                            sqlw = " and b.UserName = " + usernameid + " ";
                            username = username + "&tj_username=" + base.Server.UrlEncode(tj_username);
                            this.tj_username.Text = tj_username;
                        }
                    }
                }
                sqlw += " and a.UserName <> '' ";
                string sqlstring;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
                    {
                        "select top ",
                        x,
                        " a.Id,a.UserName,a.Status,a.TrueName,a.InsertTime,b.UserName as tj_UserName from poweruser a left join poweruser b on a.InvitationCode=b.ShareCode where a.Id <> 0 ",
                        sqlw,
                        " order by a.Id desc"
                    });
                }
                else
                {
                    sqlstring = string.Concat(new object[]
                    {
                        "select top ",
                        x,
                        " a.Id,a.UserName,a.Status,a.TrueName,a.InsertTime,b.UserName as tj_UserName from poweruser a left join poweruser b on a.InvitationCode=b.ShareCode where a.Id not in(select top ",
                        (p - 1) * x,
                        " id from poweruser where id <> 0 ",
                        sqlw,
                        " order by a.Id desc) ",
                        sqlw,
                        " order by a.Id desc"
                    });
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr_new(x, "poweruser a left join poweruser b on a.InvitationCode=b.ShareCode where a.Id <> 0 " + sqlw, username, p, "pagex", "a.Id");
            }
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "pass")
            {
                string sqlstring = "update poweruser set Status=2,UpdateTime=GETDATE(),ShareCode=10000+Id where Id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('操作成功！');</script>");
                    base.Response.End();
                }
            }
            if (e.CommandName == "refuse")
            {
                string sqlstring = "update poweruser set Status=3,UpdateTime=GETDATE() where Id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('操作成功！');</script>");
                    base.Response.End();
                }
            }
            if (e.CommandName == "cancel")
            {
                string sqlstring = "update poweruser set Status=4,UpdateTime=GETDATE() where Id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('操作成功！');</script>");
                    base.Response.End();
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string username = this.username.Text;
            string tj_username = this.tj_username.Text;
            base.Response.Redirect(string.Concat(new string[]
            {
                "UserReview.aspx?username=",
                username,
                "&tj_username=",
                tj_username
            }));
        }
        public string StatusTurn(int Status)
        {
            switch (Status)
            {
                case 1:
                    return "待审核";
                case 2:
                    return "审核通过";
                case 3:
                    return "已拒绝申请";
                case 4:
                    return "账号禁用";
                default:
                    return "状态异常";
            }
        }
    }
}