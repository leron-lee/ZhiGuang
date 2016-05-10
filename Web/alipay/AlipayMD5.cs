using System;
using System.Security.Cryptography;
using System.Text;
namespace Com.Alipay
{
    public sealed class AlipayMD5
    {
        public static string Sign(string prestr, string key, string _input_charset)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
            prestr += key;
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(System.Text.Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public static bool Verify(string prestr, string sign, string key, string _input_charset)
        {
            string mysign = AlipayMD5.Sign(prestr, key, _input_charset);
            return mysign == sign;
        }
    }
}
