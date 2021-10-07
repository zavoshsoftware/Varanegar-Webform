using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowProductGroup : System.Web.UI.Page
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
            if (Page.RouteData.Values["ProductGroupName"] != null)
            {
                string ProductGroupName = Page.RouteData.Values["ProductGroupName"].ToString();
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.ProductGroups
                             where a.ProductGroupName == ProductGroupName && a.IsDelete == false
                             select a).FirstOrDefault();

                    ltProTitle.Text = n.ProductGroupTitle;
                    ltTitle2.Text = n.ProductGroupTitle;
                    ltTitle.Text = n.ProductGroupTitle;

                    ltbannerText.Text = n.ProductGroupSummery;
                    if (Request.QueryString["Draft"] != null)
                    {
                        if (Request.QueryString["Draft"] == "true")
                        {
                            if (n.IsDraft == true)
                            {
                                ltDesc.Text = n.ProductGroupDesc_Draft;
                            }
                            else
                            {
                                ltDesc.Text = n.ProductGroupDesc;
                            }
                        }
                        else
                        {
                            ltDesc.Text = n.ProductGroupDesc;
                        }
                    }
                    else
                    {
                        ltDesc.Text = n.ProductGroupDesc;
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                    "$('#imageSectionDiv').css('background', 'url(../uploads/productgroup/" + n.ProductGroupImage + ") no-repeat center center / cover');", true);

                    LoadProducts(n.ProductGroupID);

                    if (ProductGroupName == "chain-store-and-retail-software")
                    {
                        Page.Title = "نرم افزار فروشگاهی | نرم افزار فروشگاه زنجیره ای | ورانگر پیشرو";
                        Page.MetaDescription = "نرم افزار فروشگاهی ورانگر جهت مدیریت هریک از نیازهای فروشگاه ها روانه بازار شده است، نرم افزار فروشگاهی ورانگر کلیه عملیات مربوط به انبار و فروش و صندوق ها و دریافت و پرداخت در فروشگاه را مدیریت می نماید";
                    }
                    else
                    {
                        Page.Title = n.ProductGroupTitle + " | ورانگر پیشرو";
                        Page.MetaDescription = n.ProductGroupTitle + " ورانگر اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاهی و داشبورد هوش تجاری می باشد";
                    }
                }
            }
        }
        public void LoadProducts(Guid ProductGroupID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var m = (from a in db.Products
                         join aa in db.ProductGroups on a.fk_ProductGroupID equals aa.ProductGroupID
                         where a.fk_ProductGroupID == ProductGroupID && a.IsDelete == false
                         select new
                         {
                             a.ProductName,
                             a.ProductTitle,
                             a.ProductSumery,
                             aa.ProductGroupName,
                             a.ProductImage_Thumb
                         }).ToList();
                if (m.Count() > 0)
                {
                    rptPro.DataSource = m;
                    rptPro.DataBind();
                }
                else
                    pnlProducts.Visible = false;
            }
        }

        //protected void lbSearch_OnClick(object sender, EventArgs e)
        //{
        //    if (txtSearch.Text!=null)
        //    {
        //        Response.Redirect("~/SearchResult.aspx?searchquery=" + txtSearch.Text);
        //    }
        //}
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
                             where a.fk_ProductGroupID == ProGroupID && a.IsDelete == false&&a.IsActive==true
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
                    where a.IsDelete == false && a.IsActive == true 
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