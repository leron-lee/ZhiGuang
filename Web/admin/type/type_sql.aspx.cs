using System;
using System.Data;
using System.Web.UI;

namespace Web.admin.type
{
    public partial class type_sql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["type_one_s"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["type_one_s"]);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type_one where id=" + uid.ToString()));
                    int y_type = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select tid from type_one where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new object[]
					{
						"select top 1 * From type_one where px<",
						y_px.ToString(),
						" and tid=",
						y_type,
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
                        string sql = "update type_one set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update type_one set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                        new SqlHelper().ExecuteNonQuery(sql);
                        new SqlHelper().ExecuteNonQuery(sql2);
                        base.Response.Redirect("type.aspx#type_1_" + uid.ToString());
                    }
                    else
                    {
                        base.Response.Write("<script>alert('操作失败！');location.href='type.aspx';</script>");
                    }
                }
                else
                {
                    if (base.Request.QueryString["type_one_x"] != null)
                    {
                        int uid = System.Convert.ToInt32(base.Request.QueryString["type_one_x"]);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type_one where id=" + uid.ToString()));
                        int y_type = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select tid from type_one where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new object[]
						{
							"select top 1 * From type_one where px>",
							y_px.ToString(),
							" and tid=",
							y_type,
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
                            string sql = "update type_one set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update type_one set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                            new SqlHelper().ExecuteNonQuery(sql);
                            new SqlHelper().ExecuteNonQuery(sql2);
                            base.Response.Redirect("type.aspx#type_1_" + uid.ToString());
                        }
                        else
                        {
                            base.Response.Write("<script>alert('操作失败！');location.href='type.aspx';</script>");
                        }
                    }
                    else
                    {
                        if (base.Request.QueryString["type_two_s"] != null)
                        {
                            int uid = System.Convert.ToInt32(base.Request.QueryString["type_two_s"]);
                            int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type_two where id=" + uid.ToString()));
                            string y_type_one = new SqlHelper().ExecuteScalar("select type_one_id from type_two where id=" + uid.ToString()).ToString();
                            int x_id = 0;
                            int x_px = 0;
                            bool bol = true;
                            using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new string[]
							{
								"select top 1 * From type_two where type_one_id=",
								y_type_one,
								" and px<",
								y_px.ToString(),
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
                                string sql = "update type_two set px=" + x_px.ToString() + " where id=" + uid.ToString();
                                string sql2 = "update type_two set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                                new SqlHelper().ExecuteNonQuery(sql);
                                new SqlHelper().ExecuteNonQuery(sql2);
                                base.Response.Redirect("type.aspx#type_2_" + uid.ToString());
                            }
                            else
                            {
                                base.Response.Write("<script>alert('操作失败！');location.href='type.aspx';</script>");
                            }
                        }
                        else
                        {
                            if (base.Request.QueryString["type_two_x"] != null)
                            {
                                int uid = System.Convert.ToInt32(base.Request.QueryString["type_two_x"]);
                                int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from type_two where id=" + uid.ToString()));
                                string y_type_one = new SqlHelper().ExecuteScalar("select type_one_id from type_two where id=" + uid.ToString()).ToString();
                                int x_id = 0;
                                int x_px = 0;
                                bool bol = true;
                                using (DataTable dt = new SqlHelper().ExecuteDataTable(string.Concat(new string[]
								{
									"select top 1 * From type_two where type_one_id=",
									y_type_one,
									" and px>",
									y_px.ToString(),
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
                                    string sql = "update type_two set px=" + x_px.ToString() + " where id=" + uid.ToString();
                                    string sql2 = "update type_two set px=" + y_px.ToString() + " where id=" + x_id.ToString();
                                    new SqlHelper().ExecuteNonQuery(sql);
                                    new SqlHelper().ExecuteNonQuery(sql2);
                                    base.Response.Redirect("type.aspx#type_2_" + uid.ToString());
                                }
                                else
                                {
                                    base.Response.Write("<script>alert('操作失败！');location.href='type.aspx';</script>");
                                }
                            }
                            else
                            {
                                if (base.Request.QueryString["type_one_del"] != null)
                                {
                                    int id = System.Convert.ToInt32(base.Request.QueryString["type_one_del"]);
                                    string ob = new SqlHelper().ExecuteScalar("select id from type_two where type_one_id=" + id.ToString());
                                    if (ob == "")
                                    {
                                        int a = new SqlHelper().ExecuteNonQuery("delete from type_one where id=" + id.ToString());
                                        base.Response.Redirect("type.aspx");
                                    }
                                    else
                                    {
                                        base.Response.Write("<script>alert('该类型下存在子类型无法删除！请先删除该类型下面的子类型！');location.href='type.aspx';</script>");
                                    }
                                }
                                else
                                {
                                    if (base.Request.QueryString["type_two_del"] != null)
                                    {
                                        int id = System.Convert.ToInt32(base.Request.QueryString["type_two_del"]);
                                        string ob = new SqlHelper().ExecuteScalar("select id from Merchandise where type_two_id=" + id.ToString());
                                        if (ob == "")
                                        {
                                            int a = new SqlHelper().ExecuteNonQuery("delete from type_two where id=" + id.ToString());
                                            base.Response.Redirect("type.aspx");
                                        }
                                        else
                                        {
                                            base.Response.Write("<script>alert('该类型下存在商品无法删除！请先删除该类型下面的商品！');location.href='type.aspx';</script>");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}