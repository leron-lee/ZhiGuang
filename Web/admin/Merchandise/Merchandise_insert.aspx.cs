using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.Merchandise
{
    public partial class Merchandise_insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["px"] != null)
                {
                    string ob = new SqlHelper().ExecuteScalar("select id from merchandise order by px desc");
                    if (ob != "")
                    {
                        base.Response.Redirect("Merchandise_insert.aspx?pid=" + ob);
                    }
                }
                string um = base.Server.UrlDecode(base.Request.Cookies["adminusername"].Value);
                System.Collections.Generic.List<type_oneModel> li = new SqlHelper().ExecuteList<type_oneModel>("select * from type_one order by px");
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
                int tid = 0;
                if (base.Request.QueryString["typeid"] != null)
                {
                    if (base.Request.QueryString["typeid"].ToString() != "")
                    {
                        this.DropDownList1.SelectedValue = base.Request.QueryString["typeid"].ToString();
                        tid = System.Convert.ToInt32(base.Request.QueryString["typeid"]);
                    }
                }
                if (base.Request.QueryString["id"] != null || base.Request.QueryString["pid"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    if (id == 0)
                    {
                        id = System.Convert.ToInt32(base.Request.QueryString["pid"]);
                    }
                    string sqlstring = "select * from Merchandise where id=" + id.ToString();
                    using (DataTable dt = new SqlHelper().ExecuteDataTable(sqlstring))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox1.Text = r["name"].ToString();
                            this.DropDownList1.SelectedValue = r["type_two_id"].ToString();
                            this.RadioButtonList1.SelectedValue = r["iftj"].ToString();
                            this.tj.SelectedValue = r["tj"].ToString();
                            this.sy_tj.SelectedValue = r["sy_tj"].ToString();
                            this.TextBox2.Text = r["x_img"].ToString();
                            this.TextBox8.Text = r["d_img"].ToString();
                            this.TextBox3.Text = r["guige"].ToString();
                            this.lirun.Text = r["lirun"].ToString();
                            this.jrsx.SelectedValue = r["jrsx"].ToString();
                            this.ifsj.SelectedValue = r["ifsj"].ToString();
                            this.fh_sheng.Text = r["fh_sheng"].ToString();
                            this.fh_shi.Text = r["fh_shi"].ToString();
                            this.fh_xian.Text = r["fh_xian"].ToString();
                            this.fh_dv.Text = r["fh_dv"].ToString();
                            this.fh_one.Text = r["fh_one"].ToString();
                            this.fh_two.Text = r["fh_two"].ToString();
                            this.fh_three.Text = r["fh_three"].ToString();
                            this.price_sheng.Text = r["price_sheng"].ToString();
                            this.price_shi.Text = r["price_shi"].ToString();
                            this.price_xian.Text = r["price_xian"].ToString();
                            this.price_dv.Text = r["price_dv"].ToString();
                            this.TextBox4.Text = r["title"].ToString();
                            this.TextBox5.Text = r["keyname"].ToString();
                            this.TextBox6.Text = r["counts"].ToString();
                            this.TextBox7.Text = r["nrtext"].ToString();
                            this.TextBox10.Text = r["s1"].ToString();
                            this.TextBox11.Text = r["s2"].ToString();
                            this.TextBox12.Text = r["s3"].ToString();
                            this.TextBox13.Text = r["s4"].ToString();
                            this.TextBox14.Text = r["s5"].ToString();
                            this.TextBox15.Text = r["s6"].ToString();
                            this.TextBox16.Text = r["s7"].ToString();
                            this.TextBox17.Text = r["s8"].ToString();
                            this.TextBox18.Text = r["s9"].ToString();
                            this.TextBox19.Text = r["s10"].ToString();
                            this.TextBox20.Text = r["s11"].ToString();
                            this.TextBox21.Text = r["s12"].ToString();
                            this.TextBox22.Text = r["s13"].ToString();
                            this.TextBox23.Text = r["s14"].ToString();
                            this.TextBox24.Text = r["s15"].ToString();
                            this.TextBox25.Text = r["s16"].ToString();
                            this.TextBox26.Text = r["s17"].ToString();
                            this.TextBox27.Text = r["s18"].ToString();
                            this.TextBox28.Text = r["s19"].ToString();
                            this.TextBox29.Text = r["s20"].ToString();
                            this.TextBox30.Text = r["s21"].ToString();
                            this.TextBox31.Text = r["s22"].ToString();
                            this.TextBox32.Text = r["s23"].ToString();
                            this.TextBox33.Text = r["s24"].ToString();
                            this.TextBox34.Text = r["s25"].ToString();
                            this.TextBox35.Text = r["s26"].ToString();
                            this.TextBox36.Text = r["s27"].ToString();
                            this.TextBox37.Text = r["s28"].ToString();
                            this.TextBox38.Text = r["s29"].ToString();
                            this.TextBox39.Text = r["s30"].ToString();
                            tid = System.Convert.ToInt32(r["type_two_id"]);
                            this.TextBox9.Text = r["llint"].ToString();
                            this.times.Text = r["times"].ToString();
                        }
                    }
                    this.Button1.Text = " 修改 ";
                    if (base.Request.QueryString["pid"] != null)
                    {
                        this.Button1.Text = " 添加 ";
                    }
                }
                else
                {
                    this.times.Text = System.DateTime.Now.ToString();
                }
                if (tid != 0)
                {
                    string tyd = new SqlHelper().ExecuteScalar("select type from type_two where id=" + tid);
                    if (tyd == "3")
                    {
                        this.Panel1.Visible = true;
                        this.Panel5.Visible = true;
                        this.Panel8.Visible = true;
                        string iffh = new SqlHelper().ExecuteScalar("select iffh from adminlogin where username = '" + um + "'");
                        if (iffh == "1")
                        {
                            this.Panel10.Visible = true;
                        }
                    }
                    else
                    {
                        if (tyd == "6")
                        {
                            this.Panel4.Visible = false;
                            this.Panel7.Visible = true;
                        }
                        else
                        {
                            if (tyd == "2")
                            {
                                this.Panel9.Visible = true;
                            }
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string bs = this.DropDownList1.ClientID.Replace("_", "$");
            string t = this.TextBox1.Text;
            string r = this.DropDownList1.SelectedValue;
            string r2 = this.RadioButtonList1.SelectedValue;
            string t2 = this.TextBox2.Text;
            string t2_d = this.TextBox8.Text;
            string t3 = this.TextBox3.Text;
            string t4 = this.TextBox4.Text;
            string t5 = this.TextBox5.Text;
            string t6 = this.TextBox6.Text;
            string t7 = this.TextBox7.Text;
            string tj = this.tj.SelectedValue;
            string sy_tj = this.sy_tj.SelectedValue;
            string llint = this.jrsx.SelectedValue;
            string s = this.TextBox9.Text;
            string s2 = this.TextBox10.Text;
            string s3 = this.TextBox11.Text;
            string s4 = this.TextBox12.Text;
            string s5 = this.TextBox13.Text;
            string s6 = this.TextBox14.Text;
            string s7 = this.TextBox15.Text;
            string s8 = this.TextBox16.Text;
            string s9 = this.TextBox17.Text;
            string s10 = this.TextBox18.Text;
            string s11 = this.TextBox19.Text;
            string s12 = this.TextBox20.Text;
            string s13 = this.TextBox21.Text;
            string s14 = this.TextBox22.Text;
            string s15 = this.TextBox23.Text;
            string s16 = this.TextBox24.Text;
            string s17 = this.TextBox25.Text;
            string s18 = this.TextBox26.Text;
            string s19 = this.TextBox27.Text;
            string s20 = this.TextBox28.Text;
            string s21 = this.TextBox29.Text;
            string s22 = this.TextBox30.Text;
            string s23 = this.TextBox31.Text;
            string s24 = this.TextBox32.Text;
            string s25 = this.TextBox33.Text;
            string s26 = this.TextBox34.Text;
            string s27 = this.TextBox35.Text;
            string s28 = this.TextBox36.Text;
            string s29 = this.TextBox37.Text;
            string s30 = this.TextBox38.Text;
            string ifsj = this.TextBox39.Text;
            string fh_sheng = this.lirun.Text;
            if (fh_sheng == "")
            {
                fh_sheng = "0";
            }
            string fh_shi = this.ifsj.SelectedValue;
            string fh_xian = this.fh_sheng.Text;
            if (fh_xian == "")
            {
                fh_xian = "0";
            }
            string fh_dv = this.fh_shi.Text;
            if (fh_dv == "")
            {
                fh_dv = "0";
            }
            string fh_one = this.fh_xian.Text;
            if (fh_one == "")
            {
                fh_one = "0";
            }
            string fh_two = this.fh_dv.Text;
            if (fh_two == "")
            {
                fh_two = "0";
            }
            string fh_three = this.fh_one.Text;
            if (fh_three == "")
            {
                fh_three = "0";
            }
            string price_sheng = this.fh_two.Text;
            if (price_sheng == "")
            {
                price_sheng = "0";
            }
            string price_shi = this.fh_three.Text;
            if (price_shi == "")
            {
                price_shi = "0";
            }
            string price_xian = this.price_sheng.Text;
            if (price_xian == "")
            {
                price_xian = "0";
            }
            string price_dv = this.price_shi.Text;
            if (price_dv == "")
            {
                price_dv = "0";
            }
            string times = this.price_xian.Text;
            if (times == "")
            {
                times = "0";
            }
            string sqlstring = this.price_dv.Text;
            if (sqlstring == "")
            {
                sqlstring = "0";
            }
            string px = this.times.Text;
            if (r == "0")
            {
                base.Response.Write("<script>alert('请选择所属类型');location.href='" + base.Request.RawUrl + "';</script>");
                base.Response.End();
            }
            else
            {
                string ob = "select MAX(px) FROM Merchandise";
                int op = 1;
                string strtit = new SqlHelper().ExecuteScalar(ob);
                if (strtit != "")
                {
                    op = System.Convert.ToInt32(strtit) + 1;
                }
                SqlParameter[] sqlstr = new SqlParameter[]
				{
					new SqlParameter("@name", t),
					new SqlParameter("@type_two_id", r),
					new SqlParameter("@iftj", r2),
					new SqlParameter("@tj", tj),
					new SqlParameter("@sy_tj", sy_tj),
					new SqlParameter("@x_img", t2),
					new SqlParameter("@d_img", t2_d),
					new SqlParameter("@guige", t3),
					new SqlParameter("@jrsx", llint),
					new SqlParameter("@lirun", fh_sheng),
					new SqlParameter("@ifsj", fh_shi),
					new SqlParameter("@fh_sheng", fh_xian),
					new SqlParameter("@fh_shi", fh_dv),
					new SqlParameter("@fh_xian", fh_one),
					new SqlParameter("@fh_dv", fh_two),
					new SqlParameter("@fh_one", fh_three),
					new SqlParameter("@fh_two", price_sheng),
					new SqlParameter("@fh_three", price_shi),
					new SqlParameter("@price_sheng", price_xian),
					new SqlParameter("@price_shi", price_dv),
					new SqlParameter("@price_xian", times),
					new SqlParameter("@price_dv", sqlstring),
					new SqlParameter("@title", t4),
					new SqlParameter("@keyname", t5),
					new SqlParameter("@counts", t6),
					new SqlParameter("@nrtext", t7),
					new SqlParameter("@s1", s2),
					new SqlParameter("@s2", s3),
					new SqlParameter("@s3", s4),
					new SqlParameter("@s4", s5),
					new SqlParameter("@s5", s6),
					new SqlParameter("@s6", s7),
					new SqlParameter("@s7", s8),
					new SqlParameter("@s8", s9),
					new SqlParameter("@s9", s10),
					new SqlParameter("@s10", s11),
					new SqlParameter("@s11", s12),
					new SqlParameter("@s12", s13),
					new SqlParameter("@s13", s14),
					new SqlParameter("@s14", s15),
					new SqlParameter("@s15", s16),
					new SqlParameter("@s16", s17),
					new SqlParameter("@s17", s18),
					new SqlParameter("@s18", s19),
					new SqlParameter("@s19", s20),
					new SqlParameter("@s20", s21),
					new SqlParameter("@s21", s22),
					new SqlParameter("@s22", s23),
					new SqlParameter("@s23", s24),
					new SqlParameter("@s24", s25),
					new SqlParameter("@s25", s26),
					new SqlParameter("@s26", s27),
					new SqlParameter("@s27", s28),
					new SqlParameter("@s28", s29),
					new SqlParameter("@s29", s30),
					new SqlParameter("@s30", ifsj),
					new SqlParameter("@llint", s),
					new SqlParameter("@times", px),
					new SqlParameter("@px", op.ToString())
				};
                string a = "insert into Merchandise (name,type_two_id,iftj,tj,sy_tj,x_img,d_img,guige,jrsx,lirun,ifsj,fh_sheng,fh_shi,fh_xian,fh_dv,fh_one,fh_two,fh_three,price_sheng,price_shi,price_xian,price_dv,title,keyname,counts,nrtext,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,llint,times,px) values(@name,@type_two_id,@iftj,@tj,@sy_tj,@x_img,@d_img,@guige,@jrsx,@lirun,@ifsj,@fh_sheng,@fh_shi,@fh_xian,@fh_dv,@fh_one,@fh_two,@fh_three,@price_sheng,@price_shi,@price_xian,@price_dv,@title,@keyname,@counts,@nrtext,@s1,@s2,@s3,@s4,@s5,@s6,@s7,@s8,@s9,@s10,@s11,@s12,@s13,@s14,@s15,@s16,@s17,@s18,@s19,@s20,@s21,@s22,@s23,@s24,@s25,@s26,@s27,@s28,@s29,@s30,@llint,@times,@px)";
                if (base.Request.QueryString["id"] != null)
                {
                    a = "update Merchandise set name=@name,type_two_id=@type_two_id,iftj=@iftj,tj=@tj,sy_tj=@sy_tj,x_img=@x_img,d_img=@d_img,guige=@guige,jrsx=@jrsx,lirun=@lirun,ifsj=@ifsj,fh_sheng=@fh_sheng,fh_shi=@fh_shi,fh_xian=@fh_xian,fh_dv=@fh_dv,fh_one=@fh_one,fh_two=@fh_two,fh_three=@fh_three,price_sheng=@price_sheng,price_shi=@price_shi,price_xian=@price_xian,price_dv=@price_dv,title=@title,keyname=@keyname,counts=@counts,nrtext=@nrtext,s1=@s1,s2=@s2,s3=@s3,s4=@s4,s5=@s5,s6=@s6,s7=@s7,s8=@s8,s9=@s9,s10=@s10,s11=@s11,s12=@s12,s13=@s13,s14=@s14,s15=@s15,s16=@s16,s17=@s17,s18=@s18,s19=@s19,s20=@s20,s21=@s21,s22=@s22,s23=@s23,s24=@s24,s25=@s25,s26=@s26,s27=@s27,s28=@s28,s29=@s29,s30=@s30,llint=@llint,times=@times where id=" + System.Convert.ToInt32(base.Request.QueryString["id"]).ToString();
                }
                int mid = new SqlHelper().ExecuteNonQuery(a, sqlstr);
                if (mid > 0)
                {
                    if (base.Request.QueryString["id"] != null && base.Request.QueryString["url"] != null)
                    {
                        string type = System.Convert.ToString(base.Request.QueryString["url"]);
                        base.Response.Write("<script>alert('修改成功...');location.href='" + type + "';</script>");
                        base.Response.End();
                    }
                    else
                    {
                        string str = new SqlHelper().ExecuteScalar("select top 1 id from merchandise order by id desc");
                        string a2 = new SqlHelper().ExecuteScalar("select type from type_two where id = (select type_two_id from merchandise where id = " + str + ")");
                        if (a2 == "3")
                        {
                            base.Response.Redirect("../yk/menu.aspx?mid=" + str + "&url=" + base.Server.UrlEncode("../merchandise/merchandise.aspx"));
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script type='text/javascript'>showdv();</script>");
                            base.Response.Write("<script>alert('增加成功');location.href='" + base.Request.RawUrl + "';</script>");
                            base.Response.End();
                        }
                    }
                }
            }
        }
    }
}