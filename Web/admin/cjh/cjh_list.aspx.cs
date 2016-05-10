using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CT.WebUtility;
using System.Data;
namespace Web.admin.cjh
{
    public partial class cjh_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int x = 20;
                int p = 1;
                if (base.Request.QueryString["pagex"] != null)
                {
                    p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                }
                string username = new System.Random().Next(100).ToString();
                string sqlwere = " id >0  ";
                string sqlandwrer = " and id>0 ";
                string sqlstring;
                if ((p - 1) * x == 0)
                {
                    sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from cjh where ",
							sqlwere,
							" order by id desc"
						});
                }
                else
                {
                    sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from cjh where px >(select max(px) from cjh_flash where px in (select top ",
							(p - 1) * x,
							" px from cjh_flash where ",
							sqlwere,
							" order  id desc) ) ",
							sqlandwrer,
							" order id desc"
						});
                }
                using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                {
                    this.Repeater1.DataSource = dt;
                    this.Repeater1.DataBind();
                }

                this.Literal1.Text = liu.fystr_new(x, "cjh where" + sqlwere, username, p, "pagex", "id");

            }
        }

        protected void Rp_OnItemCommand(object o, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string sqlstring = "delete from cjh where id=" + e.CommandArgument;
                int a = new SqlHelper().ExecuteNonQuery(sqlstring);
                if (a > 0)
                {
                    base.Response.Redirect(base.Request.RawUrl);
                }
            }

        }



        public string GG(object a, object b, object c)
        {
            string str = "";

            object a1 = Sql.GetSingle("select name from s_sheng where id=" + a);

            if (a1 != null)
            {
                str += a1;
            }
            object a2 = Sql.GetSingle("select name from s_shi where id=" + b);
            if (a2 != null)
            {
                str += a2;
            }
            object a3 = Sql.GetSingle("select name from s_xian where id=" + c);
            if (a3 != null)
            {
                str += a3;
            }
            return str;
        }
    }
}