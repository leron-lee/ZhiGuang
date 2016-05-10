using System;
using System.Security.Cryptography;
using System.Text;
namespace Mi_gangUI.WXPay
{
    public class MD5Util
    {
        public static string GetMD5(string encypStr, string charset)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider m5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] inputBye;
            try
            {
                inputBye = System.Text.Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (System.Exception ex_18)
            {
                inputBye = System.Text.Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            byte[] outputBye = m5.ComputeHash(inputBye);
            string retStr = System.BitConverter.ToString(outputBye);
            return retStr.Replace("-", "").ToUpper();
        }
    }
}
