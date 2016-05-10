using System;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class Default : System.Web.UI.Page
    {
        public string username;
        public string img;
        public DataRow r;
        public string ren = "0";
        public string jinshou = "0";
        public int z1 = 0;
        public int z2 = 0;
        public int z3 = 0;
        public int z4 = 0;
        public string z1dis = "dis";
        public string z2dis = "dis";
        public string z3dis = "dis";
        public string z4dis = "dis";
      
        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.username = base.Server.UrlDecode(base.Request.Cookies["username"].Value);
            if (!base.IsPostBack)
            {
                using (DataTable dt = new SqlHelper().ExecuteDataTable("select * from username where username = '" + this.username + "'"))
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        this.r = r;
                        this.ren = get.ren(r["username"]);
                        if (r["ewm"].ToString() == "")
                        {
                            string href = string.Concat(new object[]
							{
								"http://",
								base.Request.Url.Authority,
								"/?tj_username=",
								r["id"]
							});
                            string img = r["img"].ToString();
                            if (string.IsNullOrEmpty(img))
                            {
                                img = get.logoimg();
                            }
                            string ewmstr = ewm.create_Logo(href, img);
                            new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
							{
								"update username set ewm = '",
								ewmstr,
								"' where username = '",
								this.username,
								"'"
							}));
                        }
                    }
                    if (dt.Rows.Count == 0)
                    {
                        base.Response.Redirect("logout.aspx");
                    }
                }
                this.z1 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 1 and username = '" + this.username + "'"));
                this.z2 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 2 and username = '" + this.username + "'"));
                this.z3 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 3 and username = '" + this.username + "'"));
                this.z4 = System.Convert.ToInt32(new SqlHelper().ExecuteScalar("select count(id) from shoporder where zt = 4 and pj = 0 and username = '" + this.username + "'"));
                if (this.z1 > 0)
                {
                    this.z1dis = "";
                }
                if (this.z2 > 0)
                {
                    this.z2dis = "";
                }
                if (this.z3 > 0)
                {
                    this.z3dis = "";
                }
                if (this.z4 > 0)
                {
                    this.z4dis = "";
                }
            }
        }
        protected void lbUploadPhoto_Click(object sender, System.EventArgs e)
        {
            if (this.fuPhoto.PostedFile != null && this.fuPhoto.PostedFile.ContentLength > 0)
            {
                string ext = System.IO.Path.GetExtension(this.fuPhoto.PostedFile.FileName).ToLower();
                if (ext == "")
                {
                    ext = ".jpg";
                }
                if (ext != ".jpg" && ext != ".jepg" && ext != ".bmp" && ext != ".gif" && ext != ".png")
                {
                    base.Response.Write("<script>alert('图片格式不正确，或者请在右上角在浏览器中打开上传');location.href='" + base.Request.RawUrl + "';</script>");
                    base.Response.End();
                }
                string filename = "Image_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string path = "/file/" + filename;
                this.fuPhoto.PostedFile.SaveAs(base.Server.MapPath(path));
                get.xg_imgwd(path, 400);
                new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
				{
					"update username set img = '",
					path,
					"' where username = '",
					this.username,
					"'"
				}));
                string href = "http://" + base.Request.Url.Authority + "/?tj_username=" + get.username_id(this.username);
                string img = path;
                if (string.IsNullOrEmpty(img))
                {
                    img = get.logoimg();
                }
                string ewmstr = ewm.create_Logo(href, img);
                new SqlHelper().ExecuteNonQuery(string.Concat(new string[]
				{
					"update username set ewm = '",
					ewmstr,
					"' where username = '",
					this.username,
					"'"
				}));
            }
            base.Response.Redirect(base.Request.RawUrl);
        }
    }
}