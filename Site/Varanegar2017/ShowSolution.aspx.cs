using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowSolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSolutionInfo();
            }
        }
        public void LoadSolutionInfo()
        {
            if (Page.RouteData.Values["SolutionName"] != null)
            {
                string SolutionName = Page.RouteData.Values["SolutionName"].ToString();
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Solutions
                             where a.SolutionName == SolutionName && a.IsDelete == false
                             select new
                             {
                                 a.BannerText,
                                 a.SolutionTitle,
                                 a.ProblemDesc,
                                 a.ImgBannerFile,
                                 a.SolutionID
                             }).FirstOrDefault();

                    ltSolutionTitle.Text ="راهکار "+ n.SolutionTitle;
                    ltSolutionTitleCu.Text= n.SolutionTitle;
                    ltProblemTitle.Text = n.SolutionTitle;
                    ltbannerText.Text = n.BannerText;
                    ltProblem.Text = n.ProblemDesc;
                    ltTitleSolution.Text = n.SolutionTitle;
                    ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                    "$('#imageSectionDiv').css('background', 'url(../Uploads/Solution/"+n.ImgBannerFile+") no-repeat center center / cover');", true);

                    Page.Title ="راهکار "+ n.SolutionTitle + " | ورانگر پیشرو";
                    Page.MetaDescription = "راهکار " + n.SolutionTitle + "، " + n.BannerText;
                    CustomerBind(n.SolutionID);
                }
            }
        }
        public void CustomerBind(Guid SolutionID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from aa in db.Rel_Solutions_Customers
                         join u in db.Customers
                         on aa.fk_CustomerID equals u.CustomersID
                         where u.IsDelete == false && aa.fk_SolutionID == SolutionID
                         orderby u.Priority
                         select
                         new
                         {
                             u.CustomerTitle,                            
                             u.CustomersID,
                             aa.SolutionCustomerID,
                             u.ImgLogo,
                             u.CustomerName
                         }).ToList();
                rptCustomers.DataSource = n;
                rptCustomers.DataBind();
            }
        }
    }
}