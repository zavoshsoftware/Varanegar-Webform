using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
namespace Varanegar
{
    /// <summary>
    /// Summary description for ImgHandler
    /// </summary>
    public class ImgHandler : IHttpHandler
    {
        public ImgHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void ProcessRequest(HttpContext context)
        {
            string imagePath = context.Request.QueryString["image"];

            // split the string on periods and read the last element, this is to ensure we have
            // the right ContentType if the file is named something like "image1.jpg.png"
            string[] imageArray = imagePath.Split('.');

            if (imageArray.Length <= 1)
            {
                throw new HttpException(404, "Invalid photo name.");
            }
            else
            {
                if (File.Exists(imagePath))
                {
                    //--------------- Dynamically changing image size --------------------------  
                    context.Response.Clear();
                    context.Response.ContentType = getContentType(imagePath);
                    // Set image height and width to be loaded on web page
                    byte[] buffer = getResizedImage(imagePath, 100, 100);
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

        byte[] getResizedImage(String path, int width, int height)
        {
            Bitmap imgIn = new Bitmap(path);
            double y = imgIn.Height;
            double x = imgIn.Width;

            double factor = 1;
            if (width > 0)
            {
                factor = width / x;
            }
            else if (height > 0)
            {
                factor = height / y;
            }
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

            // Set DPI of image (xDpi, yDpi)
            imgOut.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(imgOut);
            g.Clear(Color.White);
            g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)),
              new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            imgOut.Save(outStream, getImageFormat(path));
            return outStream.ToArray();
        }

        string getContentType(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }

        ImageFormat getImageFormat(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return ImageFormat.Bmp;
                case ".gif": return ImageFormat.Gif;
                case ".jpg": return ImageFormat.Jpeg;
                case ".png": return ImageFormat.Png;
                default: break;
            }
            return ImageFormat.Jpeg;
        }

       
    }
}