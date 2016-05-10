namespace CT.WebUtility
{
    using System;
    using System.IO;
    using System.Web;

    public static class Directory
    {
        public static void Create(string Path)
        {
            System.IO.Directory.CreateDirectory(Path);
        }

        public static void Delete(string Path)
        {
            System.IO.Directory.Delete(Path);
        }

        public static bool IsExit(string Path)
        {
            if (!Is.ServerMapPath(Path))
            {
                Path = HttpContext.Current.Server.MapPath(Path);
            }
            return System.IO.Directory.Exists(Path);
        }
    }
}

