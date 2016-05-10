
using System.Data.SqlClient;
namespace CT.WebUtility
{
    using System;
    using System.Net.Mail;

    public static class Is
    {
        public static bool BadIp(string BadIpGroup, string Ip)
        {
            if (BadIpGroup.Length != 0)
            {
                int num = 0;
                string[] strArray = BadIpGroup.Split(new char[] { '|' });
                string[] strArray2 = Ip.Split(new char[] { '.' });
                if (strArray2.Length != 4)
                {
                    return true;
                }
                for (int i = 0; i < strArray.Length; i++)
                {
                    num = 0;
                    string[] strArray3 = strArray[i].Split(new char[] { '.' });
                    if (strArray3.Length == 4)
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            if ((strArray3[j] == "*") || (strArray2[j] == strArray3[j]))
                            {
                                num++;
                            }
                        }
                        if (num == 4)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool DateTime(string Value)
        {
            System.DateTime now = System.DateTime.Now;
            return System.DateTime.TryParse(Value, out now);
        }


       

        public static bool Email(string Value)
        {
            try
            {
                MailAddress address = new MailAddress(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Number(string text)
        {
            return Statics.RegexPatterns.Number.IsMatch(text);
        }

        public static bool Numeric(string text)
        {
            int result = 0;
            return int.TryParse(text, out result);
        }

        public static bool ServerMapPath(string text)
        {
            return Statics.RegexPatterns.ServerMapPath.IsMatch(text);
        }

        public static bool StaticHTMLPath(string val)
        {
            string str = Statics.RegexPatterns.HasFileName.Replace(val, "$1");
            return (" shtml shtm html htm inc txt ".IndexOf(" " + str + " ") > -1);
        }
    }
}

