using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class GalleryImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "رسانه ورانگر | نرم افزار فروش و پخش مویرگی ";
                Page.MetaDescription = "رسانه ورانگر | " + "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";

                ImagesBinding();
                VideoBinding();
            }
        }
        public void ImagesBinding()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.GalleryGroups
                         where u.IsDelete == false
                         orderby u.SubmitDate
                         select u).ToList();

                rptImages.DataSource = n;
                rptImages.DataBind();
            }
        }

        public void VideoBinding()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                List<GalleryImages> n = (from u in db.GalleryImages
                         where u.IsDelete == false && u.VideoLink!=null
                         orderby u.Priority select u).ToList();
                rptVideos.DataSource = n;
                rptVideos.DataBind();

            }
        }
    }
}