using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web
{
    public partial class pro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                using (DataTable dt = new access().ExecuteDataTable("select * from type_one where tid = 1 order by px"))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }
                if (base.Request.QueryString["search"] != null)
                {
                    this.search_tx.Text = base.Request.QueryString["search"];
                }
            }
        }
        public string one(object uid)
        {
            string fig = "";
            string url = base.Request.FilePath.ToLower();
            if (url.EndsWith("pro.aspx"))
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    id = System.Convert.ToInt32(new access().ExecuteScalar("select type_one_id from type_two where id=" + id));
                    if (System.Convert.ToInt32(uid) == id)
                    {
                        fig = "a";
                    }
                }
            }
            else
            {
                if (url.EndsWith("pro_l.aspx"))
                {
                    if (base.Request.QueryString["id"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        id = System.Convert.ToInt32(new access().ExecuteScalar("select type_one_id from type_two where id = (select type_two_id from merchandise where id=" + id + ")"));
                        if (System.Convert.ToInt32(uid) == id)
                        {
                            fig = "a";
                        }
                    }
                }
            }
            return fig;
        }
        public string two(object uid)
        {
            string fig = "dis";
            string url = base.Request.FilePath.ToLower();
            if (url.EndsWith("pro.aspx"))
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    id = System.Convert.ToInt32(new access().ExecuteScalar("select type_one_id from type_two where id=" + id));
                    if (System.Convert.ToInt32(uid) == id)
                    {
                        fig = "";
                    }
                }
            }
            else
            {
                if (url.EndsWith("pro_l.aspx"))
                {
                    if (base.Request.QueryString["id"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        id = System.Convert.ToInt32(new access().ExecuteScalar("select type_one_id from type_two where id = (select type_two_id from merchandise where id=" + id + ")"));
                        if (System.Convert.ToInt32(uid) == id)
                        {
                            fig = "";
                        }
                    }
                }
            }
            return fig;
        }
        public string three(object uid)
        {
            string fig = "";
            string url = base.Request.FilePath.ToLower();
            if (url.EndsWith("pro.aspx"))
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    if (System.Convert.ToInt32(uid) == id)
                    {
                        fig = "xhx";
                    }
                }
            }
            else
            {
                if (url.EndsWith("pro_l.aspx"))
                {
                    if (base.Request.QueryString["id"] != null)
                    {
                        int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                        id = System.Convert.ToInt32(new access().ExecuteScalar("select type_two_id from merchandise where id=" + id));
                        if (System.Convert.ToInt32(uid) == id)
                        {
                            fig = "xhx";
                        }
                    }
                }
            }
            return fig;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater Repeater111 = (Repeater)e.Item.FindControl("Repeater111");
                object id = DataBinder.Eval(e.Item.DataItem, "ID");
                using (DataTable dt = new access().ExecuteDataTable("select * from type_two where type_one_id = " + id + " order by px"))
                {
                    Repeater111.DataSource = dt;
                    Repeater111.DataBind();
                }
            }
        }
        protected void search_bt_Click(object sender, System.EventArgs e)
        {
            string tx = this.search_tx.Text;
            base.Response.Redirect("/pro.aspx?search=" + tx);
        }
        public string iftj()
        {
            string fig = "";
            if (base.Request.QueryString["iftj"] != null)
            {
                fig = "a";
            }
            return fig;
        }



    }
}