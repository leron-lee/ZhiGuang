namespace CT.WebUtility
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web;

    public static class UpFile
    {
        private static readonly string UpfileAllowPicExt = ",.gif,.jpg,.jpeg,.png,.bmp,.swf,.flv,.shtml,.shtm,.html,.htm,.inc,.txt,.css,.js,.xml,.doc,.psd,.mp3,.xsl,.rar,.zip,";

        public static string CreateSmallPic(string BigPicPath, int width, int height)
        {
            return CreateSmallPic(BigPicPath, Fun.GetUploadsAutoFolder(), width, height);
        }

        public static string CreateSmallPic(string BigPicPath, string Path, int width, int height)
        {
            if (Path.Length == 0)
            {
                Path = Fun.GetUploadsAutoFolder();
            }
            if (!(Statics.RegexPatterns.Re21.IsMatch(Path) || Statics.RegexPatterns.Re11.IsMatch(Path)))
            {
                Path = Path + "/";
            }
            if (!CT.WebUtility.Directory.IsExit(HttpContext.Current.Server.MapPath(Statics.RegexPatterns.Re21.Replace(Path, string.Empty))))
            {
                CT.WebUtility.Directory.Create(HttpContext.Current.Server.MapPath(Statics.RegexPatterns.Re21.Replace(Path, string.Empty)));
            }
            Image image = Image.FromFile(HttpContext.Current.Server.MapPath(BigPicPath));
            int num = image.Width;
            int num2 = image.Height;
            string str = BigPicPath.Substring(BigPicPath.LastIndexOf('.'));
            string str2 = string.Empty;
            string filename = string.Empty;
            string str4 = string.Empty;
            if (!Statics.RegexPatterns.Re21.IsMatch(Path))
            {
                str2 = DateTime.Now.ToString("HHmmss") + Fun.GetRandom(4) + str;
            }
            filename = (Statics.RegexPatterns.ServerMapPath.IsMatch(Path) ? Path : HttpContext.Current.Server.MapPath(Path)) + str2;
            str4 = Path + str2;
            if ((((double) num) / ((double) width)) < (((double) num2) / ((double) height)))
            {
                width = (num * height) / num2;
            }
            else
            {
                height = (num2 * width) / num;
            }
            Image image2 = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(0, 0, num, num2), GraphicsUnit.Pixel);
            image.Dispose();
            try
            {
                string str6 = str.ToLower();
                if (str6 == null)
                {
                    goto Label_0241;
                }
                if (!(str6 == ".bmp"))
                {
                    if (str6 == ".gif")
                    {
                        goto Label_021F;
                    }
                    if (str6 == ".png")
                    {
                        goto Label_0230;
                    }
                    if (str6 == ".jpeg")
                    {
                    }
                    goto Label_0241;
                }
                image2.Save(filename, ImageFormat.Bmp);
                return str4;
            Label_021F:
                image2.Save(filename, ImageFormat.Gif);
                return str4;
            Label_0230:
                image2.Save(filename, ImageFormat.Png);
                return str4;
            Label_0241:
                image2.Save(filename, ImageFormat.Jpeg);
                return str4;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
            return str4;
        }

        public static bool IsAllowExt(string FileExt)
        {
            return CT.WebUtility.Check.Flag(UpfileAllowPicExt, FileExt);
        }

        public static bool IsUpfile(string filename)
        {
            return IsUpfile(filename, UpfileAllowPicExt, 0xa00000);
        }

        public static bool IsUpfile(string filename, int MaxSize)
        {
            return IsUpfile(filename, UpfileAllowPicExt, MaxSize);
        }

        public static bool IsUpfile(string filename, string allowext)
        {
            return IsUpfile(filename, allowext, 0xa00000);
        }

        public static bool IsUpfile(string filename, string allowext, int MaxSize)
        {
            if (filename.Length != 0)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[filename];
                if (file == null)
                {
                    return false;
                }
                if ((file.ContentLength != 0) || (file.ContentLength <= MaxSize))
                {
                    return (allowext.IndexOf("," + Path.GetExtension(Path.GetFileName(file.FileName)).ToLower() + ",") > -1);
                }
            }
            return false;
        }

        public static string Save(string filename)
        {
            return Save(filename, Fun.GetUploadsAutoFolder());
        }

        public static string Save(string filename, string Path)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[filename];
            if (file == null)
            {
                return string.Empty;
            }
            string str = string.Empty;
            string uploadsAutoFileName = string.Empty;
            string input = string.Empty;
            string path = string.Empty;
            if (Path.Length == 0)
            {
                Path = Fun.GetUploadsAutoFolder();
            }
            if (!Statics.RegexPatterns.Re21.IsMatch(Path))
            {
                uploadsAutoFileName = Fun.GetUploadsAutoFileName(System.IO.Path.GetExtension(System.IO.Path.GetFileName(file.FileName)).ToLower());
                input = Statics.RegexPatterns.Re11.IsMatch(Path) ? Path : (Path + "/");
                str = input + uploadsAutoFileName;
                path = input + uploadsAutoFileName;
            }
            else
            {
                input = Statics.RegexPatterns.Re21.Replace(Path, "/");
                str = Path;
                path = Path;
            }
            if (!Statics.RegexPatterns.ServerMapPath.IsMatch(input))
            {
                input = HttpContext.Current.Server.MapPath(input);
                path = HttpContext.Current.Server.MapPath(path);
            }
            if (!CT.WebUtility.Directory.IsExit(input))
            {
                CT.WebUtility.Directory.Create(input);
            }
            file.SaveAs(path);
            return str;
        }
    }
}

