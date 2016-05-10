using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.wx
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new access().ExecuteDataTable("select * from wx_menu_one order by px"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "ID");
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wx_menu_two where menu_one_id = " + id + " order by px"))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from wx_menu_one where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
            else
            {
                if (e.CommandName == "shang")
                {
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_menu_one where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From wx_menu_one where px<" + y_px + " order by px desc"))
                    {
                        int i = 0;
                        foreach (DataRow r in dt.Rows)
                        {
                            i++;
                            x_id = System.Convert.ToInt32(r["id"]);
                            x_px = System.Convert.ToInt32(r["px"]);
                        }
                        if (i == 0)
                        {
                            bol = false;
                        }
                    }
                    if (bol)
                    {
                        string sql = "update wx_menu_one set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update wx_menu_one set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                        new SqlHelper().ExecuteNonQuery(sql);
                        new SqlHelper().ExecuteNonQuery(sql2);
                        base.Response.Redirect(base.Request.RawUrl);
                    }
                    else
                    {
                        base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                    }
                }
                else
                {
                    if (e.CommandName == "xia")
                    {
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_menu_one where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From wx_menu_one where px>" + y_px + " order by px"))
                        {
                            int i = 0;
                            foreach (DataRow r in dt.Rows)
                            {
                                i++;
                                x_id = System.Convert.ToInt32(r["id"]);
                                x_px = System.Convert.ToInt32(r["px"]);
                            }
                            if (i == 0)
                            {
                                bol = false;
                            }
                        }
                        if (bol)
                        {
                            string sql = "update wx_menu_one set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update wx_menu_one set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                            new SqlHelper().ExecuteNonQuery(sql);
                            new SqlHelper().ExecuteNonQuery(sql2);
                            base.Response.Redirect(base.Request.RawUrl);
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                        }
                    }
                }
            }
        }
        protected void Repeater111_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from wx_menu_two where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }
            else
            {
                if (e.CommandName == "shang")
                {
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_menu_two where id=" + uid.ToString()));
                    string menu_one_id = new SqlHelper().ExecuteScalar("select menu_one_id from wx_menu_two where id=" + uid.ToString()).ToString();
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new object[]
					{
						"select top 1 * From wx_menu_two where px<",
						y_px,
						" and menu_one_id = ",
						menu_one_id,
						" order by px desc"
					})))
                    {
                        int i = 0;
                        foreach (DataRow r in dt.Rows)
                        {
                            i++;
                            x_id = System.Convert.ToInt32(r["id"]);
                            x_px = System.Convert.ToInt32(r["px"]);
                        }
                        if (i == 0)
                        {
                            bol = false;
                        }
                    }
                    if (bol)
                    {
                        string sql = "update wx_menu_two set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update wx_menu_two set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                        new SqlHelper().ExecuteNonQuery(sql);
                        new SqlHelper().ExecuteNonQuery(sql2);
                        base.Response.Redirect(base.Request.RawUrl);
                    }
                    else
                    {
                        base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                    }
                }
                else
                {
                    if (e.CommandName == "xia")
                    {
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from wx_menu_two where id=" + uid.ToString()));
                        string menu_one_id = new SqlHelper().ExecuteScalar("select menu_one_id from wx_menu_two where id=" + uid.ToString()).ToString();
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new object[]
						{
							"select top 1 * From wx_menu_two where px>",
							y_px,
							" and menu_one_id = ",
							menu_one_id,
							" order by px"
						})))
                        {
                            int i = 0;
                            foreach (DataRow r in dt.Rows)
                            {
                                i++;
                                x_id = System.Convert.ToInt32(r["id"]);
                                x_px = System.Convert.ToInt32(r["px"]);
                            }
                            if (i == 0)
                            {
                                bol = false;
                            }
                        }
                        if (bol)
                        {
                            string sql = "update wx_menu_two set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update wx_menu_two set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                            new SqlHelper().ExecuteNonQuery(sql);
                            new SqlHelper().ExecuteNonQuery(sql2);
                            base.Response.Redirect(base.Request.RawUrl);
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                        }
                    }
                }
            }
        }
        protected void bt_gx_Click(object sender, System.EventArgs e)
        {
            string fig = "{";
            fig += "\"button\":[";
            using (DataTable dt = new access().ExecuteDataTable("select * from wx_menu_one order by px"))
            {
                int i = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (i > 0)
                    {
                        fig += ",";
                    }
                    fig += "{";
                    int zcd = System.Convert.ToInt32(new access().ExecuteScalar("select count(id) from wx_menu_two where menu_one_id = " + r["id"]));
                    if (zcd == 0)
                    {
                        if (r["href"].ToString().Contains("http"))
                        {
                            fig += "\"type\":\"view\",";
                        }
                        else
                        {
                            fig += "\"type\":\"click\",";
                        }
                    }
                    object obj = fig;
                    fig = string.Concat(new object[]
					{
						obj,
						"\"name\":\"",
						r["name"],
						"\","
					});
                    if (zcd == 0)
                    {
                        if (r["href"].ToString().Contains("http") && r["href"].ToString() != "")
                        {
                            if (r["href"].ToString() != "")
                            {
                                obj = fig;
                                fig = string.Concat(new object[]
								{
									obj,
									"\"url\":\"",
									r["href"],
									"\""
								});
                            }
                            else
                            {
                                fig += "\"url\":\"http://\"";
                            }
                        }
                        else
                        {
                            obj = fig;
                            fig = string.Concat(new object[]
							{
								obj,
								"\"key\":\"",
								r["href"],
								"\""
							});
                        }
                    }
                    if (zcd > 0)
                    {
                        fig += "\"sub_button\":[";
                        using (DataTable dtr = new access().ExecuteDataTable("select * from wx_menu_two where menu_one_id = " + r["id"] + " order by px"))
                        {
                            int i2 = 0;
                            foreach (DataRow r2 in dtr.Rows)
                            {
                                if (i2 > 0)
                                {
                                    fig += ",";
                                }
                                fig += "{";
                                if (r2["href"].ToString().Contains("http"))
                                {
                                    fig += "\"type\":\"view\",";
                                }
                                else
                                {
                                    fig += "\"type\":\"click\",";
                                }
                                obj = fig;
                                fig = string.Concat(new object[]
								{
									obj,
									"\"name\":\"",
									r2["name"],
									"\","
								});
                                if (r2["href"].ToString().Contains("http") && r2["href"].ToString() != "")
                                {
                                    if (r2["href"].ToString() != "")
                                    {
                                        obj = fig;
                                        fig = string.Concat(new object[]
										{
											obj,
											"\"url\":\"",
											r2["href"],
											"\""
										});
                                    }
                                    else
                                    {
                                        fig += "\"url\":\"http://\"";
                                    }
                                }
                                else
                                {
                                    obj = fig;
                                    fig = string.Concat(new object[]
									{
										obj,
										"\"key\":\"",
										r2["href"],
										"\""
									});
                                }
                                fig += "}";
                                i2++;
                            }
                        }
                        fig += "]";
                    }
                    fig += "}";
                    i++;
                }
            }
            fig += "]";
            fig += "}";
            string access_token = getwx.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + access_token;
            string sv = get.post(url, fig);
            if (sv.Contains("ok") && access_token != "")
            {
                base.Response.Write("<script>alert('更新成功');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
            else
            {
                base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('",
					sv,
					"');location.href='",
					base.Request.RawUrl,
					"';</script>"
				}));
                base.Response.End();
            }
        }
        protected void bt_del_Click(object sender, System.EventArgs e)
        {
            string access_token = getwx.access_token();
            string url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + access_token;
            string sv = get.geturl(url);
            if (sv.Contains("ok"))
            {
                base.Response.Write("<script>alert('删除成功');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
            else
            {
                base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('",
					sv,
					"');location.href='",
					base.Request.RawUrl,
					"';</script>"
				}));
                base.Response.End();
            }
        }
    }
}