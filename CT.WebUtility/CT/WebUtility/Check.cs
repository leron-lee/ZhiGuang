namespace CT.WebUtility
{
    using System;
    using System.Text;

    public static class Check
    {
        public static bool Boolean(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return Boolean(obj.ToString());
        }

        public static bool Boolean(string Value)
        {
            if (Value == "1")
            {
                Value = "true";
            }
            bool result = false;
            bool.TryParse(Value, out result);
            return result;
        }

        public static byte Byte(object obj)
        {
            return ((obj == null) ? ((byte) 0) : Byte(obj.ToString()));
        }

        public static byte Byte(string Value)
        {
            byte result = 0;
            byte.TryParse(Value, out result);
            return result;
        }

        public static System.DateTime DateTime(object obj)
        {
            return ((obj == null) ? DateTime(string.Empty) : DateTime(obj.ToString()));
        }

        public static System.DateTime DateTime(string Value)
        {
            System.DateTime now = System.DateTime.Now;
            System.DateTime.TryParse(Value, out now);
            if (now.Year == 1)
            {
                now = System.DateTime.Parse("1980-01-01");
            }
            return now;
        }

        public static string DeCheck(string Value)
        {
            if ((Value == null) || (Value.Length == 0))
            {
                return string.Empty;
            }
            Value = Value.Replace("</p><p>", "\r\n");
            Value = Statics.RegexPatterns.HtmlTagBr.Replace(Value, "\n");
            return Value;
        }

        public static decimal Decimal(object obj)
        {
            return ((obj == null) ? 0M : Decimal(obj.ToString()));
        }

        public static decimal Decimal(string Value)
        {
            decimal result = 0M;
            decimal.TryParse(Value, out result);
            return result;
        }

        public static decimal Decimal(object obj, decimal Default)
        {
            return ((obj == null) ? Default : Decimal(obj.ToString(), Default));
        }

        public static decimal Decimal(string Value, decimal Default)
        {
            decimal result = Default;
            decimal.TryParse(Value, out result);
            return result;
        }

        public static double Double(object obj)
        {
            return ((obj == null) ? 0.0 : Double(obj.ToString()));
        }

        public static double Double(string Value)
        {
            double result = 0.0;
            double.TryParse(Value, out result);
            return result;
        }

        public static double Double(object obj, double Default)
        {
            return ((obj == null) ? Default : Double(obj.ToString(), Default));
        }

        public static double Double(string Value, double Default)
        {
            double result = Default;
            double.TryParse(Value, out result);
            return result;
        }

        public static bool Flag(string myFlag, int needFlag)
        {
            return Flag(myFlag, needFlag.ToString());
        }

        public static bool Flag(string myFlag, string needFlag)
        {
            if (myFlag.Trim().Length != 0)
            {
                if (needFlag.Trim().Length == 0)
                {
                    return true;
                }
                needFlag = "," + needFlag + ",";
                myFlag = "," + myFlag + ",";
                string[] strArray = needFlag.Split(new char[] { ',' });
                for (int i = 1; i < (strArray.Length - 1); i++)
                {
                    if ((strArray[i].Trim().Length != 0) && (myFlag.IndexOf("," + strArray[i].Trim() + ",") > -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string IdPath(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            string[] strArray = obj.ToString().Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (Int(strArray[i]) > 0)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(",");
                    }
                    builder.Append(Int(strArray[i]));
                }
            }
            return builder.ToString();
        }

        public static int Int(object obj)
        {
            return ((obj == null) ? 0 : Int(obj.ToString()));
        }

        public static int Int(string Value)
        {
            int result = 0;
            int.TryParse(Value, out result);
            return result;
        }

        public static int Int(object obj, int Default)
        {
            return ((obj == null) ? Default : Int(obj.ToString(), Default));
        }

        public static int Int(string Value, int Default)
        {
            int result = Default;
            int.TryParse(Value, out result);
            return result;
        }

        public static long Int64(object obj)
        {
            return ((obj == null) ? 0L : Int64(obj.ToString()));
        }

        public static long Int64(string Value)
        {
            long result = 0L;
            long.TryParse(Value, out result);
            return result;
        }

        public static long Int64(object obj, long Default)
        {
            return ((obj == null) ? Default : Int64(obj.ToString(), Default));
        }

        public static long Int64(string Value, int Default)
        {
            long result = Default;
            long.TryParse(Value, out result);
            return result;
        }

        public static string Search(object obj)
        {
            return ((obj == null) ? string.Empty : Search(obj.ToString()));
        }

        public static string Search(string Value)
        {
            if ((Value == null) || (Value.Length == 0))
            {
                return string.Empty;
            }
            Value = Value.Trim();
            Value = Statics.RegexPatterns.Re5.Replace(Value, "+");
            Value = Statics.RegexPatterns.Re6.Replace(Value, "+");
            Value = Statics.RegexPatterns.Re7.Replace(Value, " ");
            Value = Statics.RegexPatterns.Re8.Replace(Value, string.Empty);
            Value = Statics.RegexPatterns.Re9.Replace(Value, "&#39;");
            return Value;
        }

        public static short Short(object obj)
        {
            return ((obj == null) ? ((short) 0) : Short(obj.ToString()));
        }

        public static short Short(string Value)
        {
            short result = 0;
            short.TryParse(Value, out result);
            return result;
        }

        public static string Str(object obj)
        {
            return ((obj == null) ? string.Empty : Str(obj.ToString()));
        }

        public static string Str(string Value)
        {
            if ((Value == null) || (Value.Length == 0))
            {
                return string.Empty;
            }
            //Value = Value.ToLower();
            Value = Value.Replace(">", "&gt;").Replace("<", "&lt;").Replace("\"", "&quot;").Replace("'", "&#39;").Replace("exec", "");
            Value = Statics.RegexPatterns.RepeatNewline.Replace(Value, "<br />");
            return Value.Trim();
        }

        public static string StrDoNothing(object obj)
        {
            return ((obj == null) ? string.Empty : obj.ToString());
        }
    }
}

