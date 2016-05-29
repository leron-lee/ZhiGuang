using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Web.admin.wzinfo
{
    public partial class wzinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    string sqlstr = "select fig from Uploadify where id = 1";
                    string fig = new SqlHelper().ExecuteScalar(sqlstr);
                    if (fig != "")
                    {
                        if (fig.ToString() == "1")
                        {
                            this.scan_1.Checked = true;
                        }
                        else
                        {
                            if (fig.ToString() == "2")
                            {
                                this.scan_2.Checked = true;
                            }
                        }
                    }
                    using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from wzinfo where id=" + id))
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            this.TextBox1.Text = r["gsname"].ToString();
                            this.TextBox2.Text = r["logo"].ToString();
                            this.TextBox3.Text = r["sy_tit"].ToString();
                            this.TextBox4.Text = r["sy_key"].ToString();
                            this.TextBox5.Text = r["sy_contus"].ToString();
                            this.TextBox6.Text = r["js"].ToString();
                            this.TextBox_bq.Text = r["Copyright"].ToString();
                            this.tj_fh.Text = r["tj_fh"].ToString();
                            this.tj_xg.Text = r["tj_xg"].ToString();
                            this.tximg1.Text = r["img1"].ToString();
                            this.tximg2.Text = r["img2"].ToString();
                            this.tximg3.Text = r["img3"].ToString();
                            this.tximg4.Text = r["img4"].ToString();
                            this.tximg5.Text = r["img5"].ToString();
                            this.tximg6.Text = r["img6"].ToString();
                            this.tximg7.Text = r["img7"].ToString();
                            this.tximg8.Text = r["img8"].ToString();
                            this.tximg9.Text = r["img9"].ToString();
                            this.tximg10.Text = r["img10"].ToString();
                            this.tximg11.Text = r["img11"].ToString();
                            this.tximg12.Text = r["img12"].ToString();
                            this.Image1.ImageUrl = get.ynimg(r["img1"].ToString());
                            this.Image2.ImageUrl = get.ynimg(r["img2"].ToString());
                            this.Image3.ImageUrl = get.ynimg(r["img3"].ToString());
                            this.Image4.ImageUrl = get.ynimg(r["img4"].ToString());
                            this.Image5.ImageUrl = get.ynimg(r["img5"].ToString());
                            this.Image6.ImageUrl = get.ynimg(r["img6"].ToString());
                            this.Image7.ImageUrl = get.ynimg(r["img7"].ToString());
                            this.Image8.ImageUrl = get.ynimg(r["img8"].ToString());
                            this.Image9.ImageUrl = get.ynimg(r["img9"].ToString());
                            this.Image10.ImageUrl = get.ynimg(r["img10"].ToString());
                            this.Image11.ImageUrl = get.ynimg(r["img11"].ToString());
                            this.Image12.ImageUrl = get.ynimg(r["img12"].ToString());
                            this.lj1.Text = r["lj1"].ToString();
                            this.lj2.Text = r["lj2"].ToString();
                            this.lj3.Text = r["lj3"].ToString();
                            this.lj4.Text = r["lj4"].ToString();
                            this.lj5.Text = r["lj5"].ToString();
                            this.lj6.Text = r["lj6"].ToString();
                            this.lj7.Text = r["lj7"].ToString();
                            this.lj8.Text = r["lj8"].ToString();
                            this.lj9.Text = r["lj9"].ToString();
                            this.lj10.Text = r["lj10"].ToString();
                            this.lj11.Text = r["lj11"].ToString();
                            this.lj12.Text = r["lj12"].ToString();
                            this.wz1.Text = r["wz1"].ToString();
                            this.wz2.Text = r["wz2"].ToString();
                            this.wz3.Text = r["wz3"].ToString();
                            this.wz4.Text = r["wz4"].ToString();
                            this.wz5.Text = r["wz5"].ToString();
                            this.wz6.Text = r["wz6"].ToString();
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                string t = this.TextBox1.Text;
                string t2 = this.TextBox2.Text;
                string t3 = this.TextBox3.Text;
                string t4 = this.TextBox4.Text;
                string t5 = this.TextBox5.Text;
                string t6 = this.TextBox_bq.Text;
                string tj_fh = this.tj_fh.Text;
                string tj_xg = this.tj_xg.Text;
                string img = this.tximg1.Text;
                string img2 = this.tximg2.Text;
                string img3 = this.tximg3.Text;
                string img4 = this.tximg4.Text;
                string img5 = this.tximg5.Text;
                string img6 = this.tximg6.Text;
                string img7 = this.tximg7.Text;
                string img8 = this.tximg8.Text;
                string img9 = this.tximg9.Text;
                string img10 = this.tximg10.Text;
                string img11 = this.tximg11.Text;
                string img12 = this.tximg12.Text;
                string lj = this.lj1.Text;
                string lj2 = this.lj2.Text;
                string lj3 = this.lj3.Text;
                string lj4 = this.lj4.Text;
                string lj5 = this.lj5.Text;
                string lj6 = this.lj6.Text;
                string lj7 = this.lj7.Text;
                string lj8 = this.lj8.Text;
                string lj9 = this.lj9.Text;
                string lj10 = this.lj10.Text;
                string lj11 = this.lj11.Text;
                string lj12 = this.lj12.Text;
                string wz = this.wz1.Text;
                string wz2 = this.wz2.Text;
                string wz3 = this.wz3.Text;
                string wz4 = this.wz4.Text;
                string wz5 = this.wz5.Text;
                string wz6 = this.wz6.Text;
                string js = this.TextBox6.Text;
                string sqlstring = "update wzinfo set gsname=@gsname,logo=@logo,sy_tit=@sy_tit,sy_key=@sy_key,sy_contus=@sy_contus,js=@js,Copyright=@Copyright,tj_fh=@tj_fh,tj_xg=@tj_xg,img1=@img1,img2=@img2,img3=@img3,img4=@img4,img5=@img5,img6=@img6,img7=@img7,img8=@img8,img9=@img9,img10=@img10,img11=@img11,img12=@img12,lj1=@lj1,lj2=@lj2,lj3=@lj3,lj4=@lj4,lj5=@lj5,lj6=@lj6,lj7=@lj7,lj8=@lj8,lj9=@lj9,lj10=@lj10,lj11=@lj11,lj12=@lj12,wz1=@wz1,wz2=@wz2,wz3=@wz3,wz4=@wz4,wz5=@wz5,wz6=@wz6 where id=" + id;
                SqlParameter[] op = new SqlParameter[]
                {
                    new SqlParameter("@gsname", t),
                    new SqlParameter("@logo", t2),
                    new SqlParameter("@sy_tit", t3),
                    new SqlParameter("@sy_key", t4),
                    new SqlParameter("@sy_contus", t5),
                    new SqlParameter("@js", js),
                    new SqlParameter("@Copyright", t6),
                    new SqlParameter("@tj_fh", tj_fh),
                    new SqlParameter("@tj_xg", tj_xg),
                    new SqlParameter("@img1", img),
                    new SqlParameter("@img2", img2),
                    new SqlParameter("@img3", img3),
                    new SqlParameter("@img4", img4),
                    new SqlParameter("@img5", img5),
                    new SqlParameter("@img6", img6),
                    new SqlParameter("@img7", img7),
                    new SqlParameter("@img8", img8),
                    new SqlParameter("@img9", img9),
                    new SqlParameter("@img10", img10),
                    new SqlParameter("@img11", img11),
                    new SqlParameter("@img12", img12),
                    new SqlParameter("@lj1", lj),
                    new SqlParameter("@lj2", lj2),
                    new SqlParameter("@lj3", lj3),
                    new SqlParameter("@lj4", lj4),
                    new SqlParameter("@lj5", lj5),
                    new SqlParameter("@lj6", lj6),
                    new SqlParameter("@lj7", lj7),
                    new SqlParameter("@lj8", lj8),
                    new SqlParameter("@lj9", lj9),
                    new SqlParameter("@lj10", lj10),
                    new SqlParameter("@lj11", lj11),
                    new SqlParameter("@lj12", lj12),
                    new SqlParameter("@wz1", wz),
                    new SqlParameter("@wz2", wz2),
                    new SqlParameter("@wz3", wz3),
                    new SqlParameter("@wz4", wz4),
                    new SqlParameter("@wz5", wz5),
                    new SqlParameter("@wz6", wz6)
                };
                int a = new SqlHelper().ExecuteNonQuery(sqlstring, op);
                if (a > 0)
                {
                    base.Response.Write("<script>alert('修改成功！');location.href='" + base.Request.RawUrl + "';</script>");
                }
            }
        }
        protected void scan_1_CheckedChanged(object sender, System.EventArgs e)
        {
            string strsql = "update Uploadify set fig = 1 where id = 1";
            int a = new SqlHelper().ExecuteNonQuery(strsql);
            if (a > 0)
            {
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
        protected void scan_2_CheckedChanged(object sender, System.EventArgs e)
        {
            string strsql = "update Uploadify set fig = 2 where id = 1";
            int a = new SqlHelper().ExecuteNonQuery(strsql);
            if (a > 0)
            {
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
    }
}