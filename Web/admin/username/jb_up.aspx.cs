using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.username
{
    public partial class jb_up : System.Web.UI.Page
    {

        public string username;
        public string sj;
        public string dl_sheng;
        public string dl_shi;
        public string dl_xian;
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    this.username = get.username(base.Request.QueryString["id"]);
                    this.jb.Items.Add(new ListItem(get.jb(1), "1"));
                    this.jb.Items.Add(new ListItem(get.jb(2), "2"));
                    this.jb.Items.Add(new ListItem(get.jb(3), "3"));
                    this.jb.Items.Add(new ListItem("取消", "6"));
                    this.jb2.Items.Add(new ListItem(get.jb(4), "4"));
                    this.jb2.Items.Add(new ListItem(get.jb(5), "5"));
                     this.jb2.Items.Add(new ListItem(get.jb(6), "6"));
                     this.jb2.Items.Add(new ListItem("取消", "0"));
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.dl_sheng = r["dl_sheng"].ToString();
                            this.dl_shi = r["dl_shi"].ToString();
                            this.dl_xian = r["dl_xian"].ToString();
                            this.ifdv.SelectedValue = r["ifdv"].ToString();
                            this.dvfh.Text = r["dvfh"].ToString();
                        }
                    }
                    string jb = get.jb_dq(this.username);
                    string jb2 = get.jb_dq2(this.username);
                    this.jb.SelectedValue = jb;
                    this.jb2.SelectedValue = jb2;
                    this.sj = get.tj_username(this.username);
                    this.tj_username.Text = this.sj;
                }
            }
        }
        protected void tj_xg_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                this.username = get.username(base.Request.QueryString["id"]);
                string jb = this.jb.SelectedValue;
                string jb2 = this.jb2.SelectedValue;
                string tj_username = this.tj_username.Text.Trim();
                string tj_username_id = "0";
                string dl_sheng = base.Request.Form["s_sheng"];
                string dl_shi = base.Request.Form["s_shi"];
                string dl_xian = base.Request.Form["s_xian"];
                if (dl_sheng == "")
                {
                    dl_sheng = "0";
                }
                if (dl_shi == "")
                {
                    dl_shi = "0";
                }
                if (dl_xian == "")
                {
                    dl_xian = "0";
                }
                string ifdv = this.ifdv.SelectedValue;
                string dvfh = this.dvfh.Text;
                if (string.IsNullOrEmpty(dvfh))
                {
                    dvfh = "0";
                }
                if (dl_sheng != "0" && jb == "1")
                {
                    string sid = new SqlHelper().ExecuteScalar("select username from username where username <> '" + dl_sheng + "' and jb = 1 and dl_sheng = " + dl_sheng);
                    if (sid != "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('该省已经被" + sid + "占领了');", true);
                        return;
                    }
                }
                if (dl_shi != "0" && jb == "2")
                {
                    string sid = new SqlHelper().ExecuteScalar("select username from username where username <> '" + dl_sheng + "' and jb = 2 and dl_shi = " + dl_shi);
                    if (sid != "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('该市已经被" + sid + "占领了');", true);
                        return;
                    }
                }
                if (dl_xian != "0" && jb == "3")
                {
                    string sid = new SqlHelper().ExecuteScalar("select username from username where username <> '" + dl_sheng + "' and jb = 3 and dl_xian = " + dl_xian);
                    if (sid != "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('该县区已经被" + sid + "占领了');", true);
                        return;
                    }
                }
                if (jb == "1" && tj_username != "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('您当前选中了省级代理，请设置上级会员为空！');", true);
                }
                else
                {
                    if (tj_username != "")
                    {
                        tj_username_id = get.username_id(tj_username);
                        string dq_jb = get.jb_dq(tj_username);
                        if (tj_username == this.username)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('设置新的上级会员不能是自己');", true);
                            return;
                        }
                    }

                    if (jb2 == "")
                    {
                        jb2 = "0";
                    }
                    if(jb=="")
                    {
                        jb = "6";
                    }

                    new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
					{
						"update username set jb = ",
						jb,
						",jb2="+jb2+",tj_username = ",
						tj_username_id,
						",dl_sheng=",
						dl_sheng,
						",dl_shi=",
						dl_shi,
						",dl_xian=",
						dl_xian,
						",ifdv=",
						ifdv,
						",dvfh=",
						dvfh,
						" where username = '",
						this.username,
						"'"
					}));
                    string url = base.Request.QueryString["url"];
                    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, base.GetType(), get.nyrsfm(), "alert('设置成功');location.href='" + url + "';", true);
                }
            }
        }
    }
}