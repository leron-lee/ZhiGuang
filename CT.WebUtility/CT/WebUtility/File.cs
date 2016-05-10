namespace CT.WebUtility
{
    using System;
    using System.IO;
    using System.Text;
    using System.Web;

    public static class File
    {
        public static void Delete(string FilePath)
        {
            if (!Is.ServerMapPath(FilePath))
            {
                FilePath = HttpContext.Current.Server.MapPath(FilePath);
            }
            System.IO.File.Delete(FilePath);
        }

        public static bool IsExit(string FilePath)
        {
            if (!Is.ServerMapPath(FilePath))
            {
                FilePath = HttpContext.Current.Server.MapPath(FilePath);
            }
            return System.IO.File.Exists(FilePath);
        }

        public static string Read(string FilePath)
        {
            if (!Is.ServerMapPath(FilePath))
            {
                FilePath = HttpContext.Current.Server.MapPath(FilePath);
            }
            if (!IsExit(FilePath))
            {
                return string.Empty;
            }
            StreamReader reader = new StreamReader(FilePath, Encoding.UTF8);
            string str = reader.ReadToEnd();
            reader.Close();
            return str;
        }

        public static void Write(string FilePath, string Content)
        {
            Write(FilePath, Content, false, Encoding.UTF8);
        }

        public static void Write(string FilePath, string Content, bool IsAppend)
        {
            Write(FilePath, Content, IsAppend, Encoding.UTF8);
        }

        public static void Write(string FilePath, string Content, Encoding Encoding)
        {
            Write(FilePath, Content, false, Encoding.UTF8);
        }

        public static void Write(string FilePath, string Content, bool IsAppend, Encoding Encoding)
        {
            if (!Is.ServerMapPath(FilePath))
            {
                FilePath = HttpContext.Current.Server.MapPath(FilePath);
            }
            if (Statics.RegexPatterns.HasFileName.Replace(FilePath, "$1") == "inc")
            {
                Encoding = new UTF8Encoding(false);
            }
            string path = string.Empty;
            if (!Statics.RegexPatterns.Re21.IsMatch(FilePath))
            {
                path = Statics.RegexPatterns.Re11.IsMatch(FilePath) ? FilePath : (FilePath + "/");
            }
            else
            {
                path = Statics.RegexPatterns.Re21.Replace(FilePath, "/");
            }
            if (!CT.WebUtility.Directory.IsExit(path))
            {
                CT.WebUtility.Directory.Create(path);
            }
            StreamWriter writer = new StreamWriter(FilePath, IsAppend, Encoding);
            writer.Write(Content);
            writer.Close();
            writer.Dispose();
        }

        public static void WriteLine(string FilePath, string Content)
        {
            Write(FilePath, Content + "\r\n");
        }

        public static void WriteLine(string FilePath, string Content, bool IsAppend)
        {
            Write(FilePath, Content + "\r\n", IsAppend, Encoding.UTF8);
        }

        public static void WriteLine(string FilePath, string Content, Encoding Encoding)
        {
            Write(FilePath, Content + "\r\n", false, Encoding.UTF8);
        }

        public static void WriteLine(string FilePath, string Content, bool IsAppend, Encoding Encoding)
        {
            Write(FilePath, Content + "\r\n", IsAppend, Encoding);
        }
    }
}

