using System;
namespace Com.Alipay
{
    public class Config
    {
        private static string partner;
        private static string key;
        private static string private_key;
        private static string public_key;
        private static string input_charset;
        private static string sign_type;
        public static string Partner
        {
            get
            {
                return Config.partner;
            }
            set
            {
                Config.partner = value;
            }
        }
        public static string Key
        {
            get
            {
                return Config.key;
            }
            set
            {
                Config.key = value;
            }
        }
        public static string Private_key
        {
            get
            {
                return Config.private_key;
            }
            set
            {
                Config.private_key = value;
            }
        }
        public static string Public_key
        {
            get
            {
                return Config.public_key;
            }
            set
            {
                Config.public_key = value;
            }
        }
        public static string Input_charset
        {
            get
            {
                return Config.input_charset;
            }
        }
        public static string Sign_type
        {
            get
            {
                return Config.sign_type;
            }
        }
        static Config()
        {
            Config.partner = "";
            Config.key = "";
            Config.private_key = "";
            Config.public_key = "";
            Config.input_charset = "";
            Config.sign_type = "";
            Config.partner = "2088711708528207";
            Config.key = "q7cjhahk3a1ccavnyk5cgbqjv8j913wb";
            Config.private_key = "";
            Config.public_key = "";
            Config.input_charset = "utf-8";
            Config.sign_type = "MD5";
        }
    }
}
