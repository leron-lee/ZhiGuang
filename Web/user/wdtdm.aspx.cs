using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CT.WebUtility;
using System.Data.SqlClient;
namespace Web.user
{
    public partial class wdtdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    int type = Convert.ToInt32(Request.QueryString["type"]);
                    string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);

                    if(type ==1)
                    {
                        Literal1.Text = "一级会员";
                    }
                    else if(type==2)
                    {
                        Literal1.Text = "二级会员";
                    }else if(type ==3)
                    {
                        Literal1.Text = "三级会员";
                    }

                    SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@lgname",username),
                            };
                    DataTable dt = Sql.ExecuteDataSet("PA", sp).Tables[0];


                    List<TM> list = new List<TM>();

                    int i = 0;
                    int m = 0;//总代
                    int n = 0;//小总代
                    foreach (DataRow r in dt.Rows)
                    {


                        TM h = new TM();
                        h.Lgname = r["lgname"].ToString();
                        h.Name = r["name"].ToString();
                        h.Img = r["img"].ToString();
                        if (type == Convert.ToInt32(r["lvl"]))
                        {
                            list.Add(h);
                        }

                    }

                    Repeater1.DataSource = list;
                    Repeater1.DataBind();
                }
            }
        }
    }


    public class TM
    {

        private string lgname;

        public string Lgname
        {
            get { return lgname; }
            set { lgname = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string img;

        public string Img
        {
            get { return img; }
            set { img = value; }
        }
    }
}