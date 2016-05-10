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
    public partial class wdtd : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);


                SqlParameter[] sp = new SqlParameter[]{
                            new SqlParameter("@lgname",username),
                            };
                DataTable dt = Sql.ExecuteDataSet("PA", sp).Tables[0];

                int i = 0;
                int m = 0;//总代
                int n = 0;//小总代
                foreach (DataRow r in dt.Rows)
                {

                    if (Convert.ToInt32(r["lvl"]) == 1)
                    {
                        i++;
                    }

                    if (Convert.ToInt32(r["lvl"]) == 2)
                    {
                        m++;
                    }

                    if (Convert.ToInt32(r["lvl"]) == 3)
                    {
                        n++;
                    }
                }

                Literal1.Text = i.ToString();
                Literal2.Text = m.ToString();
                Literal3.Text = n.ToString();
            }
        }
    }
}