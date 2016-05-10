using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.sisu
{
    public partial class sisu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["tid"] != null)
                {
                    int tid = System.Convert.ToInt32(base.Request.QueryString["tid"]);
                    int x = 100;
                    int p = 1;
                    if (base.Request.QueryString["pagex"] != null)
                    {
                        p = System.Convert.ToInt32(base.Request.QueryString["pagex"]);
                    }
                    string username = new System.Random().Next(100).ToString();
                    string sqlstring = string.Empty;
                    if ((p - 1) * x == 0)
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from sisu where tid = ",
							tid,
							" order by id"
						});
                    }
                    else
                    {
                        sqlstring = string.Concat(new object[]
						{
							"select top ",
							x,
							" * from sisu where id >(select max(id) from sisu where id in (select top ",
							(p - 1) * x,
							" id from sisu where tid = ",
							tid,
							" order by id) ) and tid = ",
							tid,
							" order by id"
						});
                    }
                    using (DataTable li = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        this.Repeater1.DataSource = li;
                        this.Repeater1.DataBind();
                    }
                    this.Literal1.Text = liu.fystr(x, "sisu where tid = " + tid, username, p, "pagex", "id");
                }
            }
        }
        public string ltype(object v, object nrtext)
        {
            string fig;
            if (v.ToString() == "2")
            {
                fig = string.Concat(new object[]
				{
					"<a href='",
					nrtext,
					"' target='_blank'><img src='",
					nrtext,
					"' width='70px' height='70px' /></a>"
				});
            }
            else
            {
                fig = liu.zifu(liu.htmlGL(base.Eval("ntest")), 15);
            }
            return fig;
        }
    }
}