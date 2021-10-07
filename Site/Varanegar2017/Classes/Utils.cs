using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
 
using System.Web.Routing;
using System.Web.SessionState;
//using eShop21;

namespace Varanegar.Classes
{
    public class Utils
    {
        public static string CreateThumbnail(string OriginalFileFullPath, string imageUploadPath,int maxWidth,int maxHeight)
        {
            //string imageUploadPath = "/Uploads/";
            string filename = string.Empty;

            if (File.Exists(OriginalFileFullPath))
            {
                Image img = Bitmap.FromFile(OriginalFileFullPath);
                Bitmap bmp = new Bitmap(img);

                bmp = BitmapManipulator.ThumbnailBitmap(bmp, maxWidth, maxHeight);

                string thumbfilename = Path.GetFileNameWithoutExtension(OriginalFileFullPath) + "_thumb" + Path.GetExtension(OriginalFileFullPath);

                string thumb_file_relative_path = imageUploadPath + thumbfilename;

                bmp.Save(HttpContext.Current.Server.MapPath(thumb_file_relative_path), System.Drawing.Imaging.ImageFormat.Jpeg);
                img.Dispose();
                bmp.Dispose();
                filename = thumbfilename;
            }
            return filename;
        }
    }

    //public class MyHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    //{
    //    public MyHttpControllerHandler(RouteData routeData): base(routeData)
    //    {
    //    }
    //}

    //public class MyHttpControllerRouteHandler : HttpControllerRouteHandler
    //{
    //    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new MyHttpControllerHandler(requestContext.RouteData);
    //    }
    //}
}