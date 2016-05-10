namespace CT.WebUtility
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class DecryptConnStr
    {
        private string _connstr = string.Empty;

        public DecryptConnStr(object SrcStr)
        {
            if (SrcStr == null)
            {
                this._connstr = "错误0：webconfig.configuration.connectionStrings中没有connectionstring节点";
            }
            else if (SrcStr.ToString().Length < 10)
            {
                this._connstr = "错误1：webconfig.configuration.connectionStrings.connectionstring加密有误";
            }
            else
            {
                try
                {
                    ICryptoTransform transform = new RijndaelManaged().CreateDecryptor(GetKey(SrcStr.ToString().Substring(0, 8)), GetIV());
                    MemoryStream stream = new MemoryStream(Decode(SrcStr.ToString().Substring(8)));
                    CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                    string str = new StreamReader(stream2, Encoding.Unicode).ReadToEnd();
                    stream2.Close();
                    stream.Close();
                    this._connstr = str;
                }
                catch
                {
                    this._connstr = "错误2：webconfig.configuration.connectionStrings.connectionstring加密有误";
                }
            }
        }

        private static byte[] Decode(string SrcStr)
        {
            int num = SrcStr.Length / 4;
            int num2 = 3 - (SrcStr[0] - '0');
            num2 = (3 * num) - (num2 % 3);
            byte[] buffer = new byte[num2];
            int num3 = 0;
            int num4 = 0;
            while (num3 < num)
            {
                int decodeInt = GetDecodeInt(SrcStr.Substring((num3 * 4) + 1));
                if (num4 < num2)
                {
                    buffer[num4++] = (byte) (decodeInt & 0xff);
                }
                if (num4 < num2)
                {
                    buffer[num4++] = (byte) ((decodeInt >> 8) & 0xff);
                }
                if (num4 < num2)
                {
                    buffer[num4++] = (byte) ((decodeInt >> 0x10) & 0xff);
                }
                num3++;
            }
            return buffer;
        }

        private static byte GetDecodeByte(char ch)
        {
            if (ch != '=')
            {
                if (ch == '*')
                {
                    return 1;
                }
                if ((ch >= '0') && (ch <= '9'))
                {
                    return (byte) (2 + (ch - '0'));
                }
                if ((ch >= 'a') && (ch <= 'z'))
                {
                    return (byte) (12 + (ch - 'a'));
                }
                if ((ch >= 'A') && (ch <= 'Z'))
                {
                    return (byte) (0x26 + (ch - 'A'));
                }
            }
            return 0;
        }

        private static int GetDecodeInt(string SrcStr)
        {
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                num = (num << 6) + GetDecodeByte(SrcStr[3 - i]);
            }
            return num;
        }

        private static byte[] GetIV()
        {
            return new byte[] { 0x72, 15, 0x7b, 0xf2, 0x70, 0x20, 190, 240, 0x89, 0x90, 0xae, 0xb9, 0xc5, 0x3e, 0x44, 0xc3 };
        }

        private static byte[] GetKey(string keyStr)
        {
            byte[] buffer = new byte[] { 
                0x55, 0x4d, 0xc5, 0xd4, 0xc3, 60, 0x5c, 0xdd, 0xcf, 0x92, 0xc3, 0x1c, 0xf9, 0x42, 240, 0x81, 
                0x9f, 0x6f, 0, 0xa5, 0x36, 0x7e, 0x34, 0x36, 0xa4, 160, 0xb8, 100, 0x3a, 0xc5, 0x25, 0x43
             };
            byte[] bytes = Encoding.ASCII.GetBytes(keyStr);
            int length = bytes.Length;
            if (length > 0x20)
            {
                length = 0x20;
            }
            for (int i = 0; i < length; i++)
            {
                buffer[i] = bytes[i];
            }
            return buffer;
        }

        public string ConnStr
        {
            get
            {
                return this._connstr;
            }
        }
    }
}

