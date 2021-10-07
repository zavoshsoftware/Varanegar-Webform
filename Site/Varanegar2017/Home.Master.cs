using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMenuItems();
                FindActiveMenu();
                LoadBlogCategories();
            }
        }

        public void LoadBlogCategories()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                List<BlogGroups> blogGroupses = (from u in db.BlogGroups
                                                 where u.IsDelete == false
                                                 orderby u.SubmitDate
                                                 select u).ToList();
                rptBlogGroup.DataSource = blogGroupses;
                rptBlogGroup.DataBind();

            }
        }
        public void FindActiveMenu()
        {
            string strPage = Page.AppRelativeVirtualPath.ToLower();

            if (strPage.Contains("showproductgroup.aspx") || strPage.Contains("showproduct.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script11",
                    "AddCurrent('#proli');", true);
            }

            else if (strPage.Contains("careerformpage.aspx") )
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script12",
                    "AddCurrent('#careerli');", true);
            }

            else if (strPage.Contains("showservice.aspx") && strPage.Contains(("ShowServiceStep")))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script13",
                    "AddCurrent('#serviceli');", true);
            }
            else if (strPage.Contains("aboutus.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script14",
                    "AddCurrent('#aboutli');", true);
            }

            else if (strPage.Contains("contactus.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script15",
                    "AddCurrent('#contactli');", true);
            }
            else if (strPage.Contains("customerlist.aspx") || strPage.Contains("showcustomer.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script16",
                    "AddCurrent('#customerli');", true);
            }

            else if (strPage.Contains("bloglist.aspx") || strPage.Contains("showblog.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script17",
                    "AddCurrent('#blogli');", true);
            }
            else if (!strPage.Contains("/default.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script18",
                   "$('li').removeClass('active');", true);
            }
        }

        public void LoadMenuItems()
        {
            ProductGroupsSetting();
           LoadSolutions();
            LoadServices();
        }
        public void ProductGroupsSetting()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.ProductGroups
                         where a.IsDelete == false && a.IsActive == true
                         orderby a.Priority
                         select a).ToList();

                rptProductGroups.DataSource = n;
                rptProductGroups.DataBind();
            }
        }

        protected void rptProductGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfProductGroupId = (HiddenField)e.Item.FindControl("hfProductGroupId");
                Repeater rptProducts = (Repeater)e.Item.FindControl("rptProducts");

                Guid ProductGroupID = new Guid(hfProductGroupId.Value);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from aa in db.Products
                             join a in db.ProductGroups
                             on aa.fk_ProductGroupID equals a.ProductGroupID
                             where aa.fk_ProductGroupID == ProductGroupID && aa.IsDelete == false&&
                             aa.IsActive==true
                             orderby aa.Priority
                             select new
                             {
                                 aa.ProductName,
                                 aa.ProductTitle,
                                 a.ProductGroupName
                             }).ToList();

                    rptProducts.DataSource = n;
                    rptProducts.DataBind();
                }
            }
        }
        public void LoadSolutions()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Solutions
                         where a.IsDelete == false
                         orderby a.Priority
                         select a).ToList();

                rptSolutions.DataSource = n;
                rptSolutions.DataBind();
            }
        }

        public void LoadServices()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Services
                         where a.IsDelete == false
                         orderby a.Priority

                         select a).ToList();

                rptServices.DataSource = n;
                rptServices.DataBind();
            }
        }
        //public void LoadSolutions(Repeater rptID, Guid fk_solutionGroupID)
        //{
        //    using (VaranegarEntities db = new VaranegarEntities())
        //    {
        //        var n = (from a in db.Solutions
        //                 where a.fk_SolutionGroupID == fk_solutionGroupID && a.IsDelete == false
        //                 orderby a.Priority
        //                 select a).ToList();

        //        rptID.DataSource = n;
        //        rptID.DataBind();
        //    }
        //}
        //protected void rptSolutionGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        Repeater rptSolutions = (Repeater)e.Item.FindControl("rptSolutions");
        //        HiddenField hfSolutionGroup = (HiddenField)e.Item.FindControl("hfSolutionGroup");
        //        Guid SolutionGroupID = new Guid(hfSolutionGroup.Value);

        //        LoadSolutions(rptSolutions, SolutionGroupID);
        //    }
        //}

        protected void rptServices_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfServiceId = (HiddenField)e.Item.FindControl("hfServiceId");
                Repeater rptServiceSteps = (Repeater)e.Item.FindControl("rptServiceSteps");

                Guid ServiceId = new Guid(hfServiceId.Value);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from aa in db.ServiceSteps
                             join a in db.Services
                             on aa.fk_ServiceID equals a.ServiceID
                             where aa.fk_ServiceID == ServiceId && aa.IsDelete == false
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
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchResult.aspx?searchquery=" + txtSearch.Text);
        }
    }
}