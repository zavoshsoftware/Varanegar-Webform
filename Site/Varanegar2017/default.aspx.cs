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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMenuItems();
                LoadBlogItems();
                customerGroupDS();
                customerDS();
                loadTexts();
                SliderDS();
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
        #region texts
        public void loadTexts()
        {
            LoadSections();
        }
        public void LoadSections()
        {
            //section2 
            List<string> firstItem = TextData.ReturnTextTitleAndBody(2);
            ltText1.Text = firstItem[0];
            ltText2.Text = firstItem[1];

            List<string> secondItem = TextData.ReturnTextTitleAndBody(3);
            ltText3.Text = secondItem[0];
            ltText4.Text = secondItem[1];

            List<string> thirdItem = TextData.ReturnTextTitleAndBody(4);
            ltText5.Text = thirdItem[0];
            ltText6.Text = thirdItem[1];

            List<string> Item2 = TextData.ReturnTextTitleAndBody(5);
            lttext7.Text = Item2[0];
            lttext8.Text = Item2[1];

            //section7

            List<string> Item3 = TextData.ReturnTextTitleAndBody(35);
            ltText9.Text = Item3[0];
            ltText10.Text = Item3[1];
        }
        #endregion
        public void customerGroupDS()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CustomerGroups
                         where u.IsDelete == false
                         orderby u.CustomerGroupID
                         select u).ToList();
                rptCategories.DataSource = n;
                rptCategories.DataBind();

            }
        }
        public void SliderDS()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Sliders
                         where u.IsDelete == false&&u.IsActive
                         orderby u.Priority
                         select u).ToList();
                rptSlider.DataSource = n;
                rptSlider.DataBind();
            }
        }
        public void customerDS()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Customers
                         join cg in db.CustomerGroups
                         on u.fk_CustomerGroupID equals cg.CustomerGroupID
                         where u.IsDelete == false && u.IsInHome == true
                         orderby u.Priority
                         select new
                         {
                             u.CustomersID,
                             u.CustomerName,
                             u.CustomerTitle,
                             cg.CustomerGroupName,
                             cg.CustomerGroupTitle,
                             u.ImgLogo
                         }).ToList();
                rptCustomers.DataSource = n;
                rptCustomers.DataBind();

            }
        }
        public void LoadMenuItems()
        {
            ProductGroupsSetting();
              LoadSolutions();
            LoadServices();
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
        public void LoadBlogItems()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var m = (from a in db.Blogs.AsEnumerable()
                         join aa in db.BlogGroups
                         on a.fk_BlogGroupID equals aa.BlogGroupID
                         where a.IsDelete == false
                         orderby a.SubmitDate descending
                         select new
                         {
                             a.BlogTitle,
                             a.BlogName,
                             a.BlogImage,
                             a.summeryText,
                             a.Visit,
                             a.SubmitDate,
                             aa.BlogGroupName
                         }).ToList();

                rptBlog.DataSource = m.Take(3);
                rptBlog.DataBind();
            }
        }
        public void ProductGroupsSetting()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.ProductGroups
                         where a.IsDelete == false && a.IsActive==true
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
                             where aa.fk_ProductGroupID == ProductGroupID && aa.IsDelete == false &&
                             aa.IsActive == true
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