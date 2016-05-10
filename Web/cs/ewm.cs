using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;
public class ewm
{
    private static HttpContext context = HttpContext.Current;
    public static string create_two(string href)
    {
        string enCodeString = href;
        System.Drawing.Bitmap bt = new QRCodeEncoder
        {
            QRCodeScale = 8,
            QRCodeVersion = 2
        }.Encode(enCodeString, System.Text.Encoding.UTF8);
        href = ewm.context.Server.UrlEncode(href);
        string filename = "/file/ewm_" + liu.MD5(href) + ".jpg";
        bt.Save(ewm.context.Server.MapPath(filename));
        return filename;
    }
    public static string create_Logo(string code, string img)
    {
        System.Drawing.Bitmap image = new QRCodeEncoder
        {
            QRCodeScale = 8
        }.Encode(code, System.Text.Encoding.UTF8);
        if (!img.Contains("http"))
        {
            img = ewm.context.Server.MapPath(img);
        }
        else
        {
            img = ewm.downRemoteImg(img);
        }
        System.Drawing.Image bt = ewm.CombinImage(image, img, "");
        code = ewm.context.Server.UrlEncode(code);
        string filename = "/file/ewm_" + liu.MD5(code) + ".jpg";
        bt.Save(ewm.context.Server.MapPath(filename));
        return filename;
    }
    public static string downRemoteImg(string imgpath)
    {
        string fig = "";
        string imgName = get.nyrsfm();
        string imgExt = string.Empty;
        string saveFilePath = string.Empty;
        saveFilePath = ewm.context.Server.MapPath("/file/");
        try
        {
            WebRequest wreq = WebRequest.Create(imgpath);
            wreq.Timeout = 10000;
            HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
            System.IO.Stream s = wresp.GetResponseStream();
            System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            fig = saveFilePath + imgName;
            img.Save(fig, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch
        {
        }
        return fig;
    }
    private static System.Drawing.Image CombinImage(System.Drawing.Image imageCode, string logoImagePath, string words)
    {
        System.Drawing.Image imageLogo = System.Drawing.Image.FromFile(logoImagePath);
        if (imageLogo.Height != 100 || imageLogo.Width != 100)
        {
            imageLogo = ewm.KiResizeImage(imageLogo, 100, 100, 0);
        }
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(imageCode);
        g.DrawImage(imageCode, 0, 0, imageCode.Width, imageCode.Height);
        int x = imageCode.Width / 2 - imageLogo.Width / 2;
        int y = imageCode.Width / 2 - imageLogo.Width / 2;
        g.DrawImage(imageLogo, x, y, imageLogo.Width, imageLogo.Height);
        System.Drawing.Font font = new System.Drawing.Font("微软雅黑", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
        x -= (int)(font.Size * (float)words.Length) / 4;
        g.DrawString(words, font, System.Drawing.Brushes.Orange, new System.Drawing.Point(x, y + imageLogo.Height));
        g.Dispose();
        return imageCode;
    }
    private static System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH, int Mode)
    {
        System.Drawing.Image result;
        try
        {
            System.Drawing.Image b = new System.Drawing.Bitmap(newW, newH);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, newW, newH), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            result = b;
        }
        catch
        {
            result = null;
        }
        return result;
    }
}
