using System;
using System.Text;
using System.Web;
namespace Mi_gangUI.WXPay
{
    public class TenpayUtil
    {
        public static string getNoncestr()
        {
            System.Random random = new System.Random();
            return MD5Util.GetMD5(random.Next(1000).ToString(), "GBK");
        }
        public static string getTimestamp()
        {
            return System.Convert.ToInt64((System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        }
        public static string UrlEncode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string res;
                try
                {
                    res = HttpUtility.UrlEncode(instr, System.Text.Encoding.GetEncoding(charset));
                }
                catch (System.Exception ex_39)
                {
                    res = HttpUtility.UrlEncode(instr, System.Text.Encoding.GetEncoding("GB2312"));
                }
                result = res;
            }
            return result;
        }
        public static string UrlDecode(string instr, string charset)
        {
            string result;
            if (instr == null || instr.Trim() == "")
            {
                result = "";
            }
            else
            {
                string res;
                try
                {
                    res = HttpUtility.UrlDecode(instr, System.Text.Encoding.GetEncoding(charset));
                }
                catch (System.Exception ex_39)
                {
                    res = HttpUtility.UrlDecode(instr, System.Text.Encoding.GetEncoding("GB2312"));
                }
                result = res;
            }
            return result;
        }
        public static uint UnixStamp()
        {
            return System.Convert.ToUInt32((System.DateTime.Now - System.TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalSeconds);
        }
        public static string BuildRandomStr(int length)
        {
            System.Random rand = new System.Random();
            string str = rand.Next().ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else
            {
                if (str.Length < length)
                {
                    for (int i = length - str.Length; i > 0; i--)
                    {
                        str.Insert(0, "0");
                    }
                }
            }
            return str;
        }
    }
}
