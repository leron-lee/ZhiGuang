using System;
using System.Web.UI;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
namespace Web.user
{
    public partial class wyzq : System.Web.UI.Page
    {
        public string tj_username;
        public string username;
        public string logo;
        public string alert;
        public string ewm;
        public DataRow r;
        public string img = "";
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

                    }

                }

                this.tj_username = get.username_id(this.username);
                string jb = get.jb(this.username);
                if (jb == "普通会员")
                {
                    this.alert = "alert('您目前还没有购买产品，还不能成为我们的分销爱粉哦！');";
                }
                this.ewm = new SqlHelper().ExecuteScalar("select ewm from username where username = '" + this.username + "'");
                this.logo = new SqlHelper().ExecuteScalar("select img from username where username = '" + this.username + "'");
                if (string.IsNullOrEmpty(this.logo))
                {
                    this.logo = get.logoimg();
                }
                if (!this.logo.Contains("http"))
                {
                    this.logo = base.Server.UrlEncode("http://" + base.Request.Url.Authority + this.logo);
                }
                else
                {
                    this.logo = base.Server.UrlEncode(this.logo);
                }

                img = GETGZEWM(this.tj_username);

            }
        }

        public string GETGZEWM(string scene_id)
        {

           

            string access_token = getwx.access_token();

            string QrcodeUrl = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + access_token;//WxQrcodeAPI接口

            string PostJson = "{\"expire_seconds\":\"604800\", \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + scene_id + "}}}";

            string str1 = PostMoths(QrcodeUrl, PostJson);
            string nickname = json.JsonTooo(str1, "ticket");
            string imgurl = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + nickname;


            //string jsonimg = "{\"is_add_friend_reply_open\":\"1\",\"add_friend_autoreply_info\":{\"type\":\"img\",\"mediaID\",\"" + imgurl + "\"}}";

            return imgurl;

        }


        public static string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
    }
}