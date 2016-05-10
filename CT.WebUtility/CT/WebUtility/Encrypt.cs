namespace CT.WebUtility
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;

    public static class Encrypt
    {
        public static string AESDecrypt(string toDecrypt)
        {
            return AESDecrypt(toDecrypt, "lj8slj23lxj09flasjdlfih823jhlsk7");
        }

        public static string AESDecrypt(string toDecrypt, string code)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(code);
                byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Key = bytes;
                managed.Mode = CipherMode.ECB;
                managed.Padding = PaddingMode.PKCS7;
                byte[] buffer3 = managed.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(buffer3);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string AESEncrypt(string toEncrypt)
        {
            return AESEncrypt(toEncrypt, "lj8slj23lxj09flasjdlfih823jhlsk7");
        }

        public static string AESEncrypt(string toEncrypt, string code)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(code);
            byte[] inputBuffer = Encoding.UTF8.GetBytes(toEncrypt);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Key = bytes;
            managed.Mode = CipherMode.ECB;
            managed.Padding = PaddingMode.PKCS7;
            byte[] inArray = managed.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public static string DecodeBase64(string code_type)
        {
            return DecodeBase64(code_type, "3lxj09f");
        }

        public static string DecodeBase64(string code_type, string code)
        {
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                return Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                return code;
            }
        }

        public static string EncodeBase64(string code_type)
        {
            return EncodeBase64(code_type, "3lxj09f");
        }

        public static string EncodeBase64(string code_type, string code)
        {
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return code;
            }
        }

        public static string Md5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
        }



    }
}

