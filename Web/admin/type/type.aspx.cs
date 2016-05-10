using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type
{
    public partial class type : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.typestr();
                if (base.Request.QueryString["tid"] != null)
                {
                    this.Panel1.Visible = true;
                    HttpCookie cook = new HttpCookie("tid");
                    cook.Expires = System.DateTime.Now.AddMonths(1);
                    cook.Value = base.Request.QueryString["tid"].ToString();
                    base.Response.Cookies.Add(cook);
                }
                else
                {
                    if (base.Request.Cookies["tid"] != null)
                    {
                        base.Response.Redirect("type.aspx?tid=" + base.Request.Cookies["tid"].Value);
                    }
                }
            }
        }
        public void typestr()
        {
            System.Collections.Generic.List<type_oneModel> li = new SqlHelper().ExecuteList<type_oneModel>("select * from type_one where tid=0 order by px");
            if (base.Request.QueryString["tid"] != null)
            {
                int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                li = new SqlHelper().ExecuteList<type_oneModel>("select * from type_one where tid=" + tid + " order by px");
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 0;
            sb.Append("<div class=\"b_l_w\">\n");
            foreach (type_oneModel j in li)
            {
                i++;
                string imgstr;
                if (i == 1)
                {
                    imgstr = "rplus.gif";
                }
                else
                {
                    if (i == li.Count)
                    {
                        imgstr = "lplus.gif";
                    }
                    else
                    {
                        imgstr = "tplus.gif";
                    }
                }
                sb.Append("    <div class=\"b_l_w\">\n");
                sb.Append("    <div class=\"b_l\">\n");
                sb.Append("        <img src=\"../images/lines/" + imgstr + "\" />     \n");
                sb.Append("    </div>\n");
                sb.Append("    <div class=\"b_l\">\n");
                sb.Append("        <img src=\"../images/folders.gif\" />\n");
                sb.Append("    </div>\n");
                sb.Append(string.Concat(new string[]
				{
					"    <div class=\"b_l\" style=\"margin:0px 0px 0px 5px;\"><a name='type_1_",
					j.Id.ToString(),
					"' href=\"javascript:;\">",
					j.Type_one_name,
					"</a></div>\n"
				}));
                sb.Append("    <div class=\"b_l\" style=\"margin:4px 0px 0px 40px;\"><img src=\"../images/cal_nextMonth.gif\" /></div>\n");
                sb.Append("    <div class=\"b_l\">\n");
                sb.Append(string.Concat(new object[]
				{
					"    <div  title=\"",
					j.Id,
					"\" class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_two.aspx?id=",
					j.Id.ToString(),
					"';\" ><img src=\"../images/add.gif\" />添加&nbsp;</div>\n"
				}));
                sb.Append("    <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='../merchandise/merchandise.aspx?type_one_id=" + j.Id + "';\"  ><img src=\"../images/submit.gif\" />查看&nbsp;</div>\n");
                sb.Append("    <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_one.aspx?id=" + j.Id.ToString() + "';\" ><img src=\"../images/submit.gif\" />编辑&nbsp;</div>\n");
                if (j.Xid != 1)
                {
                    sb.Append("    <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:if(confirm('确定删除吗？')){location.href='type_sql.aspx?type_one_del=" + j.Id.ToString() + "';}\" ><img src=\"../images/del.gif\" />删除&nbsp;</div>\n");
                }
                sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_sql.aspx?type_one_s=" + j.Id.ToString() + "';\" ><img src=\"../images/submit-1.gif\" />上移&nbsp;</div>\n");
                sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_sql.aspx?type_one_x=" + j.Id.ToString() + "';\" ><img src=\"../images/submit-2.gif\" />下移&nbsp;</div>\n");
                sb.Append("    </div>\n");
                sb.Append("    </div>\n");
                int k = 1;
                if (i != li.Count)
                {
                    sb.Append("    <div class=\"b_l_w\" style=\"background-image:url(../images/lines/i.gif);background-repeat:repeat-y;margin-top:-4px;overflow:hidden;height:4px;\"></div>\n");
                    sb.Append("    <div class=\"b_l_w\" style=\"background-image:url(../images/lines/i.gif);background-repeat:repeat-y;\">\n");
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from type_two where type_one_id=" + j.Id.ToString() + " order by px"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        sb.Append("        <div class=\"b_l_w\">\n");
                        sb.Append("        <div class=\"b_l\" style=\"margin-left:20px;height:22px;background-image:url(../images/lines/dfdg.gif);width:19px;\"></div>\n");
                        sb.Append("        <div class=\"b_l\" style=\"margin-left:1px;margin-top:7px;\"><img src=\"../images/folder.gif\" /></div>\n");
                        sb.Append(string.Concat(new string[]
						{
							"        <div class=\"b_l\" style=\"margin-left:3px;margin-top:7px;\"><a name='type_2_",
							r["id"].ToString(),
							"' href=\"javascript:;\">",
							r["type_two_name"].ToString(),
							"</a></div>\n"
						}));
                        sb.Append("        <div class=\"b_l\" style=\"margin:10px 0px 0px 40px;\"><img src=\"../images/cal_nextMonth.gif\" /></div>\n");
                        sb.Append("        <div class=\"b_l\" style=\"margin-top:5px;\">\n");
                        if (r["type"].ToString() == "1" || r["type"].ToString() == "4" || r["type"].ToString() == "5")
                        {
                            sb.Append(string.Concat(new object[]
							{
								"        <div  title=\"",
								r["id"],
								"\" class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_two.aspx?uid=",
								r["id"].ToString(),
								"';\"  ><img src=\"../images/submit.gif\" />查看&nbsp;</div>\n"
							}));
                        }
                        else
                        {
                            sb.Append(string.Concat(new object[]
							{
								"        <div  title=\"",
								r["id"],
								"\" class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='../merchandise/merchandise.aspx?typeid=",
								r["id"].ToString(),
								"';\"  ><img src=\"../images/submit.gif\" />查看&nbsp;</div>\n"
							}));
                        }
                        sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_two.aspx?uid=" + r["id"].ToString() + "';\"  ><img src=\"../images/submit.gif\" />编辑&nbsp;</div>\n");
                        if (r["xid"].ToString() != "1")
                        {
                            sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:if(confirm('确定删除吗？')){location.href='type_sql.aspx?type_two_del=" + r["id"].ToString() + "';}\" ><img src=\"../images/del.gif\" />删除&nbsp;</div>\n");
                        }
                        sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_sql.aspx?type_two_s=" + r["id"].ToString() + "';\" ><img src=\"../images/submit-1.gif\" />上移&nbsp;</div>\n");
                        sb.Append("        <div  class=\"abman b_l\" style=\"margin-left:3px;height:17px;\" onclick=\"javascript:location.href='type_sql.aspx?type_two_x=" + r["id"].ToString() + "';\" ><img src=\"../images/submit-2.gif\" />下移&nbsp;</div>\n");
                        sb.Append("        </div>\n");
                        sb.Append("        </div>\n");
                        k++;
                    }
                }
                sb.Append("        <div class=\"b_l_w\" style=\"height:6px;overflow:hidden;\"></div>\n");
                if (i != li.Count)
                {
                    sb.Append("        </div>\n");
                }
            }
            sb.Append("    </div>\n");
            this.Literal1.Text = sb.ToString();
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string sqlstring = "select MAX(px) FROM type_one";
            int i = 1;
            string ob = new SqlHelper().ExecuteScalar(sqlstring);
            if (ob != "")
            {
                i = System.Convert.ToInt32(ob) + 1;
            }
            int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
            if (this.TextBox3.Text == "")
            {
                base.Response.Write("<script>alert('新一级类别名不能为空');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
            else
            {
                string intsqlstring = string.Concat(new object[]
				{
					"insert Into type_one (type_one_name,tid,px) Values ('",
					this.TextBox3.Text,
					"',",
					tid,
					",",
					i.ToString(),
					")"
				});
                int a = new SqlHelper().ExecuteNonQuery(intsqlstring);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('增加成功');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
            }
        }
    }
}