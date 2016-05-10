using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web
{
    public partial class Image : System.Web.UI.Page
    {
        private System.Random ran = new System.Random();
     
        private string CreateCheckCodeString()
        {
            char[] AllCheckCodeArray = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'w',
			'x',
			'y',
			'z'
		};
            string randomcode = "";
            System.Random rd = new System.Random();
            for (int i = 0; i < 4; i++)
            {
                randomcode += AllCheckCodeArray[rd.Next(AllCheckCodeArray.Length)];
            }
            return randomcode;
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string str = this.CreateCheckCodeString();
            this.Session["CheckCode"] = str;
            this.getImageValidate(str);
        }
        private void getImageValidate(string strValue)
        {
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(80, 38);
            System.Drawing.Graphics gfc = System.Drawing.Graphics.FromImage(img);
            gfc.Clear(System.Drawing.Color.White);
            this.drawLine(gfc, img);
            System.Drawing.Font font = new System.Drawing.Font("宋体", 20f, System.Drawing.FontStyle.Bold);
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Color.Gray, System.Drawing.Color.Black, 1.5f, true);
            gfc.DrawString(strValue, font, brush, 3f, 2f);
            this.drawPoint(img);
            gfc.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Gray), 0, 0, img.Width - 1, img.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            base.Response.ClearContent();
            base.Response.ContentType = "image/gif";
            base.Response.BinaryWrite(ms.ToArray());
            gfc.Dispose();
            img.Dispose();
            base.Response.End();
        }
        private void drawLine(System.Drawing.Graphics gfc, System.Drawing.Bitmap img)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = this.ran.Next(img.Width);
                int y = this.ran.Next(img.Height);
                int x2 = this.ran.Next(img.Width);
                int y2 = this.ran.Next(img.Height);
                gfc.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Silver), x, y, x2, y2);
            }
        }
        private void drawPoint(System.Drawing.Bitmap img)
        {
            int col = this.ran.Next();
            for (int i = 0; i < 100; i++)
            {
                int x = this.ran.Next(img.Width);
                int y = this.ran.Next(img.Height);
                img.SetPixel(x, y, System.Drawing.Color.Black);
            }
        }
    }
}