using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadInfo();
                LoadProductGroups();
            }
        }
        public void LoadInfo()
        {
            if (Page.RouteData.Values["ProductGroupName"] != null && Page.RouteData.Values["ProductName"] != null)
            {
                string ProductGroupName = Page.RouteData.Values["ProductGroupName"].ToString();
                string ProductName = Page.RouteData.Values["ProductName"].ToString();

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.ProductGroups
                             where a.ProductGroupName == ProductGroupName && a.IsDelete == false
                             select a).FirstOrDefault();
                    if (n != null)
                    {
                        var m = (from a in db.Products
                                 where a.ProductName == ProductName && a.IsDelete == false
                                 select a).FirstOrDefault();
                        if (m != null)
                        {
                            ltlProGroupID.Text = n.ProductGroupTitle;
                            hlProductGroup.NavigateUrl = "~/product/" + n.ProductGroupName;
                            ltProTitle.Text = m.ProductTitle;
                            ltProTitle2.Text = m.ProductTitle;
                            ltTitle.Text = m.ProductTitle;

                            ltbannerText.Text = m.ProductSumery;
                            if (string.IsNullOrEmpty(m.ProductDesc))
                            {
                                pnlNoData.Visible = true;
                            }
                            else
                                ltDesc.Text = m.ProductDesc;

                            ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                            "$('#imageSectionDiv').css('background', 'url(/Uploads/Product/" + m.ProductImage + ") no-repeat center center / cover');", true);

                            LoadOtherProducts(n.ProductGroupID, m.ProductID);


                            Page.Title = m.ProductTitle +" | "+n.ProductGroupTitle;
                            Page.MetaDescription =n.ProductGroupTitle+"، "+m.ProductTitle+ "، ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروش فروشگاهی، مالی و داشبورد هوش تجاری می باشد";
               
                        }
                    }
                }
            }
        }
        public void LoadOtherProducts(Guid ProductGroupID, Guid ProductID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {

                var m = (from a in db.Products
                         join aa in db.ProductGroups on a.fk_ProductGroupID equals aa.ProductGroupID
                         where a.fk_ProductGroupID == ProductGroupID && a.IsDelete == false
                         && a.ProductID != ProductID
                         select new
                         {
                             a.ProductName,
                             a.ProductTitle,
                             a.ProductSumery,
                             aa.ProductGroupName,
                             a.ProductImage_Thumb
                         }).ToList();

                rptPro.DataSource = m;
                rptPro.DataBind();
            }
        }
        protected void rptProductGroup_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfProgroupID = (HiddenField)e.Item.FindControl("hfProgroupID");

                Repeater rptProducts = (Repeater)e.Item.FindControl("rptProducts");

                Guid ProGroupID = new Guid(hfProgroupID.Value);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Products
                             join aa in db.ProductGroups on a.fk_ProductGroupID equals aa.ProductGroupID
                             where a.fk_ProductGroupID == ProGroupID && a.IsDelete == false && a.IsActive == true
                             orderby a.Priority

                             select new
                             {
                                 a.ProductID,
                                 a.ProductTitle,
                                 a.ProductName,
                                 aa.ProductGroupName
                             }).ToList();

                    rptProducts.DataSource = n;
                    rptProducts.DataBind();
                }
            }
        }

        public void LoadProductGroups()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.ProductGroups
                         where a.IsDelete == false &&a.IsActive==true
                         orderby a.Priority
                         select new
                         {
                             a.ProductGroupID,
                             a.ProductGroupTitle,
                             a.ProductGroupName
                         }).ToList();

                rptProductGroup.DataSource = n;
                rptProductGroup.DataBind();
            }
        }
    }
}