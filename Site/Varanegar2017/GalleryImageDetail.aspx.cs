using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class GalleryImageDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProductGroups();
            LoadVideoInfo();
        }
        public void LoadProductGroups()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.GalleryGroups
                         where a.IsDelete == false
                         orderby a.Priority
                         select a).ToList();

                rptGalleryGroup.DataSource = n;
                rptGalleryGroup.DataBind();
            }
        }

        public void LoadVideoInfo()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                if (Page.RouteData.Values["galleryImageId"] != null)
                {
                    Guid galleryImageId = new Guid(Page.RouteData.Values["galleryImageId"].ToString());

                    var gall = db.GalleryImages.Find(galleryImageId);

                    if (gall != null)
                    {
                        pnlVideo.Visible = true;
                        pnlImage.Visible = false;
                        ltDesc.Text = gall.VideoLink;
                        imgDesc.Visible = false;
                        ltTitle.Text = gall.Title;
                        ltProTitle.Text = gall.Title;
                        ltbannerText.Text = gall.Summery;
                        ltTitle2.Text = gall.Title;
                        Page.Title =gall.Title;
                        Page.MetaDescription = gall.Title+ " | رسانه ورانگر | " + "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
                    }
                    else
                    {
                        GalleryGroups gallery = db.GalleryGroups.Find(galleryImageId);
                        pnlVideo.Visible = false;
                        pnlImage.Visible = true;

                        List<GalleryImages> galleryImages =
                            db.GalleryImages.Where(
                                current => current.IsDelete == false && current.fk_GalleryId == galleryImageId).ToList();

                        rptImages.DataSource = galleryImages;
                        rptImages.DataBind();

                        ltTitle.Text = gallery.Title;
                        ltProTitle.Text = gallery.Title;
                        ltTitle2.Text = gallery.Title;

                        Page.Title = gallery.Title;
                        Page.MetaDescription = gallery.Title + " | رسانه ورانگر | " + "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
                    }
                }
            }
        }
    }
}