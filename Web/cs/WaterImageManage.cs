using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
public class WaterImageManage
{
    public string DrawImage(string sourcePicture, string waterImage, float alpha, ImagePosition position, string PicturePath)
    {
        string result;
        if (sourcePicture == string.Empty || waterImage == string.Empty || (double)alpha == 0.0 || PicturePath == string.Empty)
        {
            result = sourcePicture;
        }
        else
        {
            string sourcePictureName = PicturePath + sourcePicture;
            string waterPictureName = PicturePath + waterImage;
            string fileSourceExtension = System.IO.Path.GetExtension(sourcePictureName).ToLower();
            string fileWaterExtension = System.IO.Path.GetExtension(waterPictureName).ToLower();
            if (!System.IO.File.Exists(sourcePictureName) || !System.IO.File.Exists(waterPictureName) || (fileSourceExtension != ".gif" && fileSourceExtension != ".jpg" && fileSourceExtension != ".png") || (fileWaterExtension != ".gif" && fileWaterExtension != ".jpg" && fileWaterExtension != ".png"))
            {
                result = sourcePicture;
            }
            else
            {
                string targetImage = sourcePictureName.Replace(System.IO.Path.GetExtension(sourcePictureName), "") + "_1101.jpg";
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(sourcePictureName);
                int phWidth = imgPhoto.Width;
                int phHeight = imgPhoto.Height;
                System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(phWidth, phHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
                System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
                System.Drawing.Image imgWatermark = new System.Drawing.Bitmap(waterPictureName);
                int wmWidth = imgWatermark.Width;
                int wmHeight = imgWatermark.Height;
                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                grPhoto.DrawImage(imgPhoto, new System.Drawing.Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, System.Drawing.GraphicsUnit.Pixel);
                System.Drawing.Bitmap bmWatermark = new System.Drawing.Bitmap(bmPhoto);
                bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
                System.Drawing.Graphics grWatermark = System.Drawing.Graphics.FromImage(bmWatermark);
                System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
                System.Drawing.Imaging.ColorMap[] remapTable = new System.Drawing.Imaging.ColorMap[]
				{
					new System.Drawing.Imaging.ColorMap
					{
						OldColor = System.Drawing.Color.FromArgb(255, 0, 255, 0),
						NewColor = System.Drawing.Color.FromArgb(0, 0, 0, 0)
					}
				};
                imageAttributes.SetRemapTable(remapTable, System.Drawing.Imaging.ColorAdjustType.Bitmap);
                float[][] array = new float[5][];
                float[][] arg_22A_0 = array;
                int arg_22A_1 = 0;
                float[] array2 = new float[5];
                array2[0] = 1f;
                arg_22A_0[arg_22A_1] = array2;
                float[][] arg_241_0 = array;
                int arg_241_1 = 1;
                array2 = new float[5];
                array2[1] = 1f;
                arg_241_0[arg_241_1] = array2;
                float[][] arg_258_0 = array;
                int arg_258_1 = 2;
                array2 = new float[5];
                array2[2] = 1f;
                arg_258_0[arg_258_1] = array2;
                float[][] arg_26B_0 = array;
                int arg_26B_1 = 3;
                array2 = new float[5];
                array2[3] = alpha;
                arg_26B_0[arg_26B_1] = array2;
                array[4] = new float[]
				{
					0f,
					0f,
					0f,
					0f,
					1f
				};
                float[][] colorMatrixElements = array;
                System.Drawing.Imaging.ColorMatrix wmColorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);
                imageAttributes.SetColorMatrix(wmColorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
                int xPosOfWm;
                int yPosOfWm;
                switch (position)
                {
                    case ImagePosition.LeftTop:
                        xPosOfWm = 10;
                        yPosOfWm = 10;
                        break;
                    case ImagePosition.LeftBottom:
                        xPosOfWm = 10;
                        yPosOfWm = phHeight - wmHeight - 10;
                        break;
                    case ImagePosition.RightTop:
                        xPosOfWm = phWidth - wmWidth - 10;
                        yPosOfWm = 10;
                        break;
                    case ImagePosition.RigthBottom:
                        xPosOfWm = phWidth - wmWidth - 10;
                        yPosOfWm = phHeight - wmHeight - 10;
                        break;
                    case ImagePosition.TopMiddle:
                        xPosOfWm = (phWidth - wmWidth) / 2;
                        yPosOfWm = 10;
                        break;
                    case ImagePosition.BottomMiddle:
                        xPosOfWm = (phWidth - wmWidth) / 2;
                        yPosOfWm = phHeight - wmHeight - 10;
                        break;
                    case ImagePosition.Center:
                        xPosOfWm = (phWidth - wmWidth) / 2;
                        yPosOfWm = (phHeight - wmHeight) / 2;
                        break;
                    default:
                        xPosOfWm = 10;
                        yPosOfWm = phHeight - wmHeight - 10;
                        break;
                }
                grWatermark.DrawImage(imgWatermark, new System.Drawing.Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight), 0, 0, wmWidth, wmHeight, System.Drawing.GraphicsUnit.Pixel, imageAttributes);
                imgPhoto = bmWatermark;
                grPhoto.Dispose();
                grWatermark.Dispose();
                imgPhoto.Save(targetImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgPhoto.Dispose();
                imgWatermark.Dispose();
                result = targetImage.Replace(PicturePath, "");
            }
        }
        return result;
    }
    public string DrawWords(string sourcePicture, string waterWords, float alpha, ImagePosition position, string PicturePath)
    {
        string result;
        if (sourcePicture == string.Empty || waterWords == string.Empty || (double)alpha == 0.0 || PicturePath == string.Empty)
        {
            result = sourcePicture;
        }
        else
        {
            string sourcePictureName = PicturePath + sourcePicture;
            string fileExtension = System.IO.Path.GetExtension(sourcePictureName).ToLower();
            if (!System.IO.File.Exists(sourcePictureName) || (fileExtension != ".gif" && fileExtension != ".jpg" && fileExtension != ".png"))
            {
                result = sourcePicture;
            }
            else
            {
                string targetImage = sourcePictureName.Replace(System.IO.Path.GetExtension(sourcePictureName), "") + "_0703.jpg";
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(sourcePictureName);
                int phWidth = imgPhoto.Width;
                int phHeight = imgPhoto.Height;
                System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(phWidth, phHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
                System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                grPhoto.DrawImage(imgPhoto, new System.Drawing.Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, System.Drawing.GraphicsUnit.Pixel);
                int[] sizes = new int[]
				{
					16,
					14,
					12,
					10,
					8,
					6,
					4
				};
                System.Drawing.Font crFont = null;
                System.Drawing.SizeF crSize = default(System.Drawing.SizeF);
                for (int i = 0; i < 7; i++)
                {
                    crFont = new System.Drawing.Font("arial", (float)sizes[i], System.Drawing.FontStyle.Bold);
                    crSize = grPhoto.MeasureString(waterWords, crFont);
                    if ((ushort)crSize.Width < (ushort)phWidth)
                    {
                        break;
                    }
                }
                int yPixlesFromBottom = (int)((double)phHeight * 0.05);
                float wmHeight = crSize.Height;
                float wmWidth = crSize.Width;
                float xPosOfWm;
                float yPosOfWm;
                switch (position)
                {
                    case ImagePosition.LeftTop:
                        xPosOfWm = wmWidth / 2f;
                        yPosOfWm = wmHeight / 2f;
                        break;
                    case ImagePosition.LeftBottom:
                        xPosOfWm = wmWidth;
                        yPosOfWm = (float)phHeight - wmHeight - 10f;
                        break;
                    case ImagePosition.RightTop:
                        xPosOfWm = (float)phWidth - wmWidth - 10f;
                        yPosOfWm = wmHeight;
                        break;
                    case ImagePosition.RigthBottom:
                        xPosOfWm = (float)phWidth - wmWidth - 10f;
                        yPosOfWm = (float)phHeight - wmHeight - 10f;
                        break;
                    case ImagePosition.TopMiddle:
                        xPosOfWm = (float)(phWidth / 2);
                        yPosOfWm = wmWidth;
                        break;
                    case ImagePosition.BottomMiddle:
                        xPosOfWm = (float)(phWidth / 2);
                        yPosOfWm = (float)phHeight - wmHeight - 10f;
                        break;
                    case ImagePosition.Center:
                        xPosOfWm = (float)(phWidth / 2);
                        yPosOfWm = (float)(phHeight / 2);
                        break;
                    default:
                        xPosOfWm = wmWidth;
                        yPosOfWm = (float)phHeight - wmHeight - 10f;
                        break;
                }
                System.Drawing.StringFormat StrFormat = new System.Drawing.StringFormat();
                StrFormat.Alignment = System.Drawing.StringAlignment.Center;
                int m_alpha = System.Convert.ToInt32(256f * alpha);
                System.Drawing.SolidBrush semiTransBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(m_alpha, 0, 0, 0));
                grPhoto.DrawString(waterWords, crFont, semiTransBrush2, new System.Drawing.PointF(xPosOfWm + 1f, yPosOfWm + 1f), StrFormat);
                System.Drawing.SolidBrush semiTransBrush3 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(153, 255, 255, 255));
                grPhoto.DrawString(waterWords, crFont, semiTransBrush3, new System.Drawing.PointF(xPosOfWm, yPosOfWm), StrFormat);
                imgPhoto = bmPhoto;
                grPhoto.Dispose();
                imgPhoto.Save(targetImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgPhoto.Dispose();
                result = targetImage.Replace(PicturePath, "");
            }
        }
        return result;
    }
}
