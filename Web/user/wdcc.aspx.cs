using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.user
{
    public partial class wdcc : System.Web.UI.Page
    {
        public string username;
        public string gqhb;
        public string gqxfj;
        public double price;
        public string fystr;
        public string username_id;
        public string jb;
        public string ren = "0";
        public string zren = "0";
        public string xjb = "0";
        public string v = "1";
        public string xian_dis = "dis";
        public string name;
        public string phone;
        public string address;
        public string jbmc = "";
        public string ifdl = "dis";
        public string cb = "0";
    
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            System.DateTime dtr = System.DateTime.Now;
            this.price = get.bycj(this.username);
            if (!base.IsPostBack)
            {
                this.gqhb = new SqlHelper().ExecuteScalar(string.Concat(new object[]
				{
					"select sum(jf) from hb where gtimes < '",
					dtr.AddDays(30.0),
					"' and username ='",
					this.username,
					"' "
				}));

                cb = new SqlHelper().ExecuteScalar("select cb from username where username='"+this.username+"'");
                this.gqxfj = new SqlHelper().ExecuteScalar(string.Concat(new object[]
				{
					"select sum(jf) from xfj where gtimes < '",
					dtr.AddDays(30.0),
					"' and username ='",
					this.username,
					"' "
				}));
                if (this.gqhb == "")
                {
                    this.gqhb = "0";
                }
                if (this.gqxfj == "")
                {
                    this.gqxfj = "0";
                }
                string dq_jb = get.jb_dq(this.username);
                string s_sheng = new SqlHelper().ExecuteScalar("select s_sheng from username where username = '" + this.username + "'");
                string s_shi = new SqlHelper().ExecuteScalar("select s_shi from username where username = '" + this.username + "'");
                string s_xian = new SqlHelper().ExecuteScalar("select s_xian from username where username = '" + this.username + "'");
                if (dq_jb == "1")
                {
                    this.Panel5.Visible = false;
                    this.jbmc = "省内";
                }
                else
                {
                    if (dq_jb == "2")
                    {
                        this.jbmc = "市内";
                        string dl_sheng = new SqlHelper().ExecuteScalar("select dl_sheng from username where username = '" + this.username + "'");
                        using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where jb = 1 and dl_sheng = " + dl_sheng))
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                this.name = r["name"].ToString();
                                this.phone = r["phone"].ToString();
                                this.address = r["address"].ToString();
                            }
                        }
                    }
                    else
                    {
                        if (dq_jb == "3")
                        {
                            this.Panel1.Visible = true;
                            this.jbmc = "县内";
                            string dl_shi = new SqlHelper().ExecuteScalar("select dl_shi from username where username = '" + this.username + "'");
                            using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where jb = 2 and dl_shi = " + dl_shi))
                            {
                                foreach (DataRow r in dt.Rows)
                                {
                                    this.name = r["name"].ToString();
                                    this.phone = r["phone"].ToString();
                                    this.address = r["address"].ToString();
                                   
                                }
                            }
                        }
                    }
                }
                if (dq_jb == "6")
                {/*
                    this.Panel4.Visible = true;
                    string ifdv = new SqlHelper().ExecuteScalar("select ifdv from username where username = '" + this.username + "'");
                    if (ifdv == "1")
                    {
                        this.jbmc = "大V";
                        this.Panel4.Visible = false;
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where jb = 3 and dl_xian = " + s_xian))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.name = r["name"].ToString();
                            this.phone = r["phone"].ToString();
                            this.address = r["address"].ToString();
                        }
                    }
                  */
                }
                if (this.jbmc != "")
                {
                    this.ifdl = "";
                }
                if (!string.IsNullOrEmpty(this.name))
                {
                    this.Panel2.Visible = true;
                }
                else
                {
                    this.Panel3.Visible = true;
                }
            }
        }
    }
}