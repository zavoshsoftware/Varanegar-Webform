using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "درباره ما | نرم افزار فروش و پخش مویرگی ورانگر";
            Page.MetaDescription = "درباره ورانگر | "+"ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
            if (!Page.IsPostBack)
            {
                loadTextsAndImages();
                LoadManagers();
            }
        
        }
        public void loadTextsAndImages()
        {
            LoadSections();
        }

        public void LoadSections()
        {
            //section1 
            List<string> firstItem = TextData.ReturnTextTitleAndBody(7);
            ltAbout1.Text = firstItem[0];
            ltAbout2.Text = firstItem[1];
            //Section1 Images
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Images where u.fk_ImageGroupID == 1&&u.IsActive==true select u).ToList();
                rptSection1.DataSource = n;
                rptSection1.DataBind();
                
            }

            //section3
            List<string> item2 = TextData.ReturnTextTitleAndBody(8);
            ltAbout3.Text = item2[0];
            ltAbout4.Text = item2[1];

            //Section3 Images
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Images where u.ImageID == 4 && u.IsActive == true select u).FirstOrDefault();

                ScriptManager.RegisterStartupScript(this, GetType(), "asdcas",
                    "$('#aboutDivBG1').css('background-image', 'url(/Uploads/Images/" + n.ImgUrlAddress + ")');", true);

            }
        }

        public void LoadManagers()
        {
         
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Managers where u.IsDelete == false orderby u.Priority select u).ToList();
                rptmanager.DataSource = n;
                rptmanager.DataBind();
            }
        }
    }
}