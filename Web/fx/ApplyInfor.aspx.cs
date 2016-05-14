using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web.fx
{
    public partial class ApplyInfor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    string sql = "select * from poweruser where Id = " + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sql))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.UserName.Text = r["UserName"].ToString();
                            this.TrueName.Text = r["TrueName"].ToString();
                            this.Sex.Text = r["Sex"].ToString();
                            this.Age.Text = r["Age"].ToString();
                            this.Phone.Text = r["Phone"].ToString();
                            this.Address.Text = string.Concat(new object[]
                            {
                                get.s_sheng(r["sheng"]),
                                get.s_shi(r["shi"]),
                                get.s_xian(r["xian"]),
                                r["Address"]
                            });
                            this.InsertTime.Text = r["InsertTime"].ToString();
                            this.IDCard.Text = r["IDCard"].ToString();
                            switch (Convert.ToInt32(r["Status"]))
                            {
                                case 1:
                                    this.Status.Text= "待审核";
                                    break;
                                case 2:
                                    this.Status.Text = "审核通过";
                                    break;
                                case 3:
                                    this.Status.Text = "已拒绝申请";
                                    break;
                                case 4:
                                    this.Status.Text = "账号禁用";
                                    break;
                                default:
                                    this.Status.Text = "状态异常";
                                    break;
                            }
                        }
                    }
                    string Sql2 = "select UserName from poweruser where ShareCode=(select InvitationCode from poweruser where Id=  " 
                        + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString()+" )";
                    this.tj_UserName.Text = new SqlHelper().ExecuteScalar(Sql2).ToString();

                }
            }
        }
    }
}