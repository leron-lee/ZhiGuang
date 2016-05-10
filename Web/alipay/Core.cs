using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace Com.Alipay
{
    public class Core
    {
        public static System.Collections.Generic.Dictionary<string, string> FilterPara(System.Collections.Generic.Dictionary<string, string> dicArrayPre)
        {
            System.Collections.Generic.Dictionary<string, string> dicArray = new System.Collections.Generic.Dictionary<string, string>();
            foreach (System.Collections.Generic.KeyValuePair<string, string> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && temp.Value != "" && temp.Value != null)
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }
            return dicArray;
        }
        public static System.Collections.Generic.Dictionary<string, string> SortPara(System.Collections.Generic.Dictionary<string, string> dicArrayPre)
        {
            SortedDictionary<string, string> dicTemp = new SortedDictionary<string, string>(dicArrayPre);
            return new System.Collections.Generic.Dictionary<string, string>(dicTemp);
        }
        public static string CreateLinkString(System.Collections.Generic.Dictionary<string, string> dicArray)
        {
            System.Text.StringBuilder prestr = new System.Text.StringBuilder();
            foreach (System.Collections.Generic.KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }
        public static string CreateLinkStringUrlencode(System.Collections.Generic.Dictionary<string, string> dicArray, System.Text.Encoding code)
        {
            System.Text.StringBuilder prestr = new System.Text.StringBuilder();
            foreach (System.Collections.Generic.KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + HttpUtility.UrlEncode(temp.Value, code) + "&");
            }
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }
        public static void LogResult(string sWord)
        {
            string strPath = HttpContext.Current.Server.MapPath("log");
            strPath = strPath + "\\" + System.DateTime.Now.ToString().Replace(":", "") + ".txt";
            System.IO.StreamWriter fs = new System.IO.StreamWriter(strPath, false, System.Text.Encoding.Default);
            fs.Write(sWord);
            fs.Close();
        }
        public static string GetAbstractToMD5(System.IO.Stream sFile)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(sFile);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public static string GetAbstractToMD5(byte[] dataFile)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(dataFile);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
    }
}
