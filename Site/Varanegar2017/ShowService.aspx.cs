using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadSolutionInfo();
                LoadServiceStepRepeater();
            }

        }
        public void LoadSolutionInfo()
        {
            if (Page.RouteData.Values["ServiceName"] != null)
            {
                string ServiceName = Page.RouteData.Values["ServiceName"].ToString();
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Services
                             where a.ServiceName == ServiceName && a.IsDelete == false
                             select a).FirstOrDefault();

                    ltTitle.Text = n.ServiceTitle;
                    ltText.Text = n.SmallDesc;
                    ltTitleHeader.Text = n.ServiceTitle;
                    ltServiceDesc.Text = n.ServiceDesc;
                    ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                    "$('#imageSectionDiv').css('background', 'url(../Uploads/Service/" + n.HeaderImg + ") no-repeat center center / cover');", true);


                    Page.Title = n.ServiceTitle + " | ورانگر پیشرو";
                    Page.MetaDescription = n.ServiceTitle + " | ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
               
                }
            }
        }
        public void LoadServiceStepRepeater()
        {
            if (Page.RouteData.Values["ServiceName"] != null)
            {
                string ServiceName = Page.RouteData.Values["ServiceName"].ToString();
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from aa in db.ServiceSteps
                             join a in db.Services
                             on aa.fk_ServiceID equals a.ServiceID
                             where a.ServiceName == ServiceName && aa.IsDelete == false
                             orderby aa.Priority
                             select new
                             {
                                 aa.ServiceStepName,
                                 aa.ServiceStepTitle,
                                 a.ServiceName
                             }).ToList();

                    rptServiceSteps.DataSource = n;
                    rptServiceSteps.DataBind();
                }
            }
        }

      
    }
}