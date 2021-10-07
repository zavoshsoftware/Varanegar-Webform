using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowServiceStep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadInfo();
            }

        }
        public void LoadInfo()
        {
            if (Page.RouteData.Values["ServiceStepName"] != null)
            {
                string ServiceStepName = Page.RouteData.Values["ServiceStepName"].ToString();
                //LoadPhoneSection(ServiceStepName);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.ServiceSteps
                             where a.ServiceStepName == ServiceStepName && a.IsDelete == false
                             select a).FirstOrDefault();

                    ltTitle.Text = n.ServiceStepTitle;
                    ltText.Text = n.SmallDesc;
                    ltTitleHeader.Text = n.ServiceStepTitle;
                    ltServiceDesc.Text = n.ServiceStepDesc;
                    ScriptManager.RegisterStartupScript(this, GetType(), "PageScript121",
                    "$('#imageSectionDiv').css('background', 'url(/Uploads/Service/" + n.ServiceStepImage + ") no-repeat center center / cover');", true);

                    var m = (from a in db.Services
                             where a.ServiceID == n.fk_ServiceID && a.IsDelete == false
                             select a).FirstOrDefault();

                    hlService.NavigateUrl = "~/services/" + m.ServiceName;
                    ltlhlServiceTitle.Text = m.ServiceTitle;

                    Page.Title = n.ServiceStepTitle + " | ورانگر پیشرو";
                    Page.MetaDescription = n.ServiceStepTitle + " | ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";

                }
            }
        }

        //public void LoadPhoneSection(string ServiceStepName)
        //{
        //    if (ServiceStepName == "call-center-support-services")
        //    {

        //        lt_gp1_P1.Text = ReturnTextTitle(12);
        //        lt_gp1_P2.Text = ReturnTextTitle(13);
        //        lt_gp1_P3.Text = ReturnTextTitle(14);
        //        string Email1 = ReturnTextTitle(15);
        //        hl_gp1_P4.Text = Email1;
        //        hl_gp1_P4.NavigateUrl = "mailto:" + Email1;

        //        ///////////////////////////////////////

        //        lt_gp2_P1.Text = ReturnTextTitle(16);
        //        lt_gp2_P2.Text = ReturnTextTitle(17);
        //        lt_gp2_P3.Text = ReturnTextTitle(18);
        //        string Email2 = ReturnTextTitle(19);
        //        hl_gp2_P4.Text = Email2;
        //        hl_gp2_P4.NavigateUrl = "mailto:" + Email2;
        //        //////////////////////////////////////////

        //        lt_gp3_P1.Text = ReturnTextTitle(20);
        //        lt_gp3_P2.Text = ReturnTextTitle(21);
        //        lt_gp3_P3.Text = ReturnTextTitle(22);
        //        string Email3 = ReturnTextTitle(23);
        //        hl_gp3_P4.Text = Email3;
        //        hl_gp3_P4.NavigateUrl = "mailto:" + Email3;

        //        ///////////////////////////////////////

        //        lt_gp4_P1.Text = ReturnTextTitle(24);
        //        lt_gp4_P2.Text = ReturnTextTitle(25);
        //        lt_gp4_P3.Text = ReturnTextTitle(26);
        //        string Email4 = ReturnTextTitle(27);
        //        hl_gp4_P4.Text = Email4;
        //        hl_gp4_P4.NavigateUrl = "mailto:" + Email4;

        //        pnlPhone.Visible = true;
        //    }
        //    else
        //        pnlPhone.Visible = false;
        //}

        public string ReturnTextTitle(int TextId)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                return (db.Texts.Where(a => a.TextID == TextId).Select(a => a.TextTitle).FirstOrDefault());
            }
        }
    }
}