using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.Merchandise
{
    public partial class merchandise : System.Web.UI.Page
    {
        /*标志登录账户是否为管理员*/
        bool IsAdmin = true;
        string um = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (base.Request.Cookies["adminusername"] != null)
            {
                um = base.Server.UrlDecode(base.Request.Cookies["adminusername"].Value);
            }
            else if (base.Request.Cookies["fx"] != null)
            {
                um = base.Server.UrlDecode(base.Request.Cookies["fx"].Value);
                //this.DropDownList1.Enabled = false;
                this.DropDownList1.Visible = false;
                IsAdmin = false;
            }
            if (!base.IsPostBack)
            {
                string sqlwgcb = "";
                if (base.Request.QueryString["type_one_id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                    sqlwgcb = " where id = " + uid;
                    this.DropDownList1.Items.Clear();
                }
                System.Collections.Generic.List<type_oneModel> li = new SqlHelper().ExecuteList<type_oneModel>("select * from type_one" + sqlwgcb + " order by px");
                DataTable dtt = new SqlHelper().ExecuteDataTable("select * from type_two where type not in (1,4,5)  order by px");
                foreach (type_oneModel i in li)
                {
                    int j = 1;
                    foreach (DataRow r in dtt.Rows)
                    {
                        if (r["type_one_id"].ToString() == i.Id.ToString())
                        {
                            ListItem lt = new ListItem();
                            if (j == 1)
                            {
                                lt.Text = i.Type_one_name + "\u3000┣" + r["type_two_name"].ToString();
                            }
                            else
                            {
                                string kong = "\u3000";
                                for (int k = 0; k < i.Type_one_name.Length; k++)
                                {
                                    kong += "\u3000";
                                }
                                lt.Text = kong + "┣" + r["type_two_name"].ToString();
                            }
                            lt.Value = r["id"].ToString();
                            this.DropDownList1.Items.Add(lt);
                            j++;
                        }
                    }
                }
                if (base.Request.QueryString["typeid"] != null)
                {
                    this.DropDownList1.SelectedValue = base.Request.QueryString["typeid"].ToString();
                }
                int x = 10;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlwere = "";
                string sqlandwrer = "";
                if (base.Request.QueryString["typeid"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                    this.DropDownList1.SelectedValue = uid.ToString();
                    sqlwere = " where type_two_id=" + uid.ToString() + " ";
                    sqlandwrer = " and type_two_id=" + uid.ToString() + " ";
                    username = "typeid=" + uid.ToString();
                    if (!IsAdmin)
                    {
                        sqlwere = " where type_two_id=" + uid.ToString() + " " + "and belong= '" + um + "' ";
                    }
                }
                if (base.Request.QueryString["type_one_id"] != null)
                {
                    int uid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                    sqlwere = " where type_two_id in(select id from type_two where type_one_id =" + uid.ToString() + " ) ";
                    sqlandwrer = " and type_two_id in(select id from type_two where type_one_id =" + uid.ToString() + " ) ";
                    username = "type_one_id=" + uid.ToString();
                }
                if (base.Request.QueryString["sm"] != null)
                {
                    string sm = base.Request.QueryString["sm"].ToString();
                    sqlwere = " where name like '%" + sm + "%' ";
                    sqlandwrer = " and name like '%" + sm + "%' ";
                    username = "sm=" + base.Server.UrlEncode(sm);
                    this.TextBox1.Text = sm;
                    if (!IsAdmin)
                    {
                        sqlwere = " where name like '%" + sm + "%' " + " and type_two_id= 7 " + " " + "and belong= '" + um + "' ";
                    }
                }
                string sqlstring;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
                    {
                        "select top ",
                        x,
                        " * from Merchandise ",
                        sqlwere,
                        " order by px desc"
                    });
                }
                else
                {
                    string zid_sql_one = string.Concat(new object[]
                    {
                        "select top ",
                        (p - 1) * x,
                        " px from merchandise ",
                        sqlwere,
                        " order by px desc"
                    });
                    string zid_sqltwo = "select top 1 px from merchandise where px in (" + zid_sql_one + ") order by px";
                    string zid = new SqlHelper().ExecuteScalar(zid_sqltwo);
                    sqlstring = string.Concat(new object[]
                    {
                        "select top ",
                        x,
                        " * from merchandise where px <(",
                        zid,
                        ") ",
                        sqlandwrer,
                        " order by px desc"
                    });
                }
                using (DataTable r2 = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = r2;
                    this.Repeater1.DataBind();
                }
                this.Literal1.Text = liu.fystr_new(x, "Merchandise" + sqlwere, username, p, "pagex", "id");
            }
        }
        public string iftjstr(object ob)
        {
            string result;
            if (ob.ToString() == "0")
            {
                result = "不推荐";
            }
            else
            {
                result = "<span style='color:red;'>推荐</span>";
            }
            return result;
        }
        public string types(object id)
        {
            string fig = "";
            string type = new SqlHelper().ExecuteScalar("select type from type_two where id = (select type_two_id from merchandise where id = " + id + ")");
            if (type == "3")
            {
                fig = string.Concat(new object[]
                {
                    "<a href='../yk/menu.aspx?mid=",
                    id,
                    "&url=",
                    base.Server.UrlEncode(base.Request.RawUrl),
                    "' class='lan'>颜色、尺寸</a>"
                });
            }
            return fig;
        }
        public string typename(object ob)
        {
            string fig = string.Empty;
            string sqlstring = "select type_two_name,type_one_name from type_two,type_one where type_two.type_one_id=type_one.id and type_two.id=" + ob.ToString();
            using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
            {
                foreach (DataRow r in dt.Rows)
                {
                    fig = fig + "一级类：" + r["type_one_name"].ToString() + "<br />";
                    fig = fig + "二级类：" + r["type_two_name"].ToString();
                }
            }
            return fig;
        }
        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from Merchandise where id=" + e.CommandArgument;
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
                    string sqlwere = "";
                    string sqlandwrer = "";
                    if (base.Request.QueryString["typeid"] != null)
                    {
                        int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                        sqlwere = " where type_two_id=" + uuid.ToString() + " ";
                        sqlandwrer = " and type_two_id=" + uuid.ToString() + " ";
                    }
                    if (base.Request.QueryString["type_one_id"] != null)
                    {
                        int uuid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                        sqlwere = " where type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                        sqlandwrer = " and type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                    }
                    int uid = System.Convert.ToInt32(e.CommandArgument);
                    int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Merchandise where id=" + uid.ToString()));
                    int x_id = 0;
                    int x_px = 0;
                    bool bol = true;
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Merchandise where px<" + y_px.ToString() + sqlandwrer + " order by px desc"))
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
                        string sql = "update Merchandise set px=" + x_px.ToString() + " where id=" + uid.ToString();
                        string sql2 = "update Merchandise set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        string sqlwere = "";
                        string sqlandwrer = "";
                        if (base.Request.QueryString["typeid"] != null)
                        {
                            int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                            sqlwere = " where type_two_id=" + uuid.ToString() + " ";
                            sqlandwrer = " and type_two_id=" + uuid.ToString() + " ";
                        }
                        if (base.Request.QueryString["type_one_id"] != null)
                        {
                            int uuid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                            sqlwere = " where type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                            sqlandwrer = " and type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                        }
                        int uid = System.Convert.ToInt32(e.CommandArgument);
                        int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Merchandise where id=" + uid.ToString()));
                        int x_id = 0;
                        int x_px = 0;
                        bool bol = true;
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Merchandise where px>" + y_px.ToString() + sqlandwrer + " order by px"))
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
                            string sql = "update Merchandise set px=" + x_px.ToString() + " where id=" + uid.ToString();
                            string sql2 = "update Merchandise set px=" + y_px.ToString() + " where id=" + x_id.ToString();
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
                        if (e.CommandName == "ding")
                        {
                            string sqlwere = "";
                            if (base.Request.QueryString["typeid"] != null)
                            {
                                int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                                sqlwere = " where type_two_id=" + uuid.ToString() + " ";
                                string sqlandwrer = " and type_two_id=" + uuid.ToString() + " ";
                            }
                            if (base.Request.QueryString["type_one_id"] != null)
                            {
                                int uuid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                                sqlwere = " where type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                                string sqlandwrer = " and type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                            }
                            int uid = System.Convert.ToInt32(e.CommandArgument);
                            int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Merchandise where id=" + uid.ToString()));
                            int x_id = 0;
                            int x_px = 0;
                            bool bol = true;
                            using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Merchandise " + sqlwere + " order by px desc"))
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
                                string sql = "update Merchandise set px=" + x_px.ToString() + " where id=" + uid.ToString();
                                string sql2 = "update Merchandise set px=px-1 " + sqlwere;
                                new SqlHelper().ExecuteNonQuery(sql2);
                                new SqlHelper().ExecuteNonQuery(sql);
                                base.Response.Write("<script>location.href='" + base.Request.RawUrl + "';</script>");
                                base.Response.End();
                            }
                            else
                            {
                                base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                            }
                        }
                        else
                        {
                            if (e.CommandName == "di")
                            {
                                string sqlwere = "";
                                if (base.Request.QueryString["typeid"] != null)
                                {
                                    int uuid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                                    sqlwere = " where type_two_id=" + uuid.ToString() + " ";
                                    string sqlandwrer = " and type_two_id=" + uuid.ToString() + " ";
                                }
                                if (base.Request.QueryString["type_one_id"] != null)
                                {
                                    int uuid = System.Convert.ToInt32(base.Request.QueryString["type_one_id"]);
                                    sqlwere = " where type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                                    string sqlandwrer = " and type_two_id in(select id from type_two where type_one_id =" + uuid.ToString() + " ) ";
                                }
                                int uid = System.Convert.ToInt32(e.CommandArgument);
                                int y_px = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select px from Merchandise where id=" + uid.ToString()));
                                int x_id = 0;
                                int x_px = 0;
                                bool bol = true;
                                using (DataTable dt = new SqlHelper().ExecuteDataTable("select top 1 * From Merchandise " + sqlwere + " order by px"))
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
                                    string sql = "update Merchandise set px=" + x_px.ToString() + " where id=" + uid.ToString();
                                    string sql2 = "update Merchandise set px=px+1 " + sqlwere;
                                    new SqlHelper().ExecuteNonQuery(sql2);
                                    new SqlHelper().ExecuteNonQuery(sql);
                                    base.Response.Write("<script>location.href='" + base.Request.RawUrl + "';</script>");
                                    base.Response.End();
                                }
                                else
                                {
                                    base.Response.Write("<script>alert('操作失败！');location.href='" + base.Request.RawUrl + "';</script>");
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void LinkButton_del_Click(object sender, System.EventArgs e)
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
                    new SqlHelper().ExecuteNonQuery("delete from merchandise where id=" + id);
                }
                base.Response.Write("<script>alert('删除成功...');location.href='" + base.Request.RawUrl + "';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('请选择要删除的项');location.href='" + base.Request.RawUrl + "'</script>");
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int uid = System.Convert.ToInt32(this.DropDownList1.SelectedValue);
            if (uid == 0)
            {
                base.Response.Redirect("merchandise.aspx");
            }
            else
            {
                base.Response.Redirect("merchandise.aspx?typeid=" + uid.ToString());
            }
        }
        protected void LinkButton6_Click(object sender, System.EventArgs e)
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
                    string iftj = new SqlHelper().ExecuteScalar("select iftj from merchandise where id=" + id);
                    if (iftj == "1")
                    {
                        new SqlHelper().ExecuteNonQuery("update merchandise set iftj = 0 where id=" + id);
                    }
                    else
                    {
                        new SqlHelper().ExecuteNonQuery("update merchandise set iftj = 1 where id=" + id);
                    }
                }
                base.Response.Write("<script>alert('操作成功...');location.href='" + base.Request.RawUrl + "';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('你没有选中任何信息');location.href='" + base.Request.RawUrl + "'</script>");
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string s = this.TextBox1.Text;
            base.Response.Redirect("merchandise.aspx?sm=" + s);
        }
    }
}