using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Varanegar.ErrorPages
{
    public partial class _404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            //    string urlSite = "http://localhost:6487";


            //    #region ProductPages

            //    RedirectingPages(urlSite + "/products-and-solutions/distribution-and-sales-software.html", urlSite + "/Product/sales-and-distribution-software");


            //    RedirectingPages(urlSite + "/products-and-solutions/sales-target-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/sales-commission-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/festival-of-sale-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/quota-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/construction-software-series.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/software-review.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/door-sales-software-factory.html", urlSite + "/Product/sales-and-distribution-software");

            //    RedirectingPages(urlSite + "/products-and-solutions/hot-selling-console-software.html", urlSite + "/Product/sales-and-distribution-software/mobile-based-online-hot-sales");
            //    RedirectingPages(urlSite + "/products-and-solutions/independent-sales-office-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/software-sales-line.html", urlSite + "/Product/sales-and-distribution-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/sms-software.html", urlSite + "/Product/sales-and-distribution-software");
            //    //خزانه داری
            //    RedirectingPages(urlSite + "/products-and-solutions/treasury-software.html", urlSite + "/Product/financial-software/treasury-and-cash-management");
            //    //حسابداری انبار
            //    RedirectingPages(urlSite + "/products-and-solutions/inventory-accounting-software.html", urlSite + "/Product/sales-and-distribution-software/warehouse-management-and-inventory-accounting");

            //    //حسابداری خرید
            //    RedirectingPages(urlSite + "/products-and-solutions/buying-accounting-software.html", urlSite + "/Product/financial-software/purchasing-and-accounts-payable");

            //    //نرم افزار سفارش گیری آنلاین
            //    RedirectingPages(urlSite + "/products-and-solutions/ordering-software-online.html", urlSite + "/Product/sales-and-distribution-software/mobile-based-online-ordering");

            //    //مسیریابی آنلاین
            //    RedirectingPages(urlSite + "/products-and-solutions/online-visitor-tracking-software-and-commodity.html", urlSite + "/Product/sales-and-distribution-software/mobile-based-online-distribution");
            //    //نرم افزار کنسول ارتباطی
            //    RedirectingPages(urlSite + "/products-and-solutions/tablet-pdt-software-console-connection.html", urlSite + "/Product/sales-and-distribution-software/mobile-based-online-ordering");
            //    //کنترل ناوگان توزیع و پخش
            //    RedirectingPages(urlSite + "/products-and-solutions/avl-system.html", urlSite + "/Product/sales-and-distribution-software/mobile-based-online-distribution");




            //    RedirectingPages(urlSite + "/products-and-solutions/retail-sales-software-pos.html", urlSite + "/Product/chain-store-and-retail-software");

            //    RedirectingPages(urlSite + "/products-and-solutions/financial-accounting-software.html", urlSite + "/Product/financial-software");
            //    RedirectingPages(urlSite + "/products-and-solutions/bi-software.html", urlSite + "/Product/management-solutions/sales-and-distribution-bi-solution");
            //    #endregion
            //    RedirectingPages(urlSite + "/services-and-training/services.html", urlSite);
            //    RedirectingPages(urlSite + "/services-and-training/consultation-and-supervision.html", urlSite + "/Services/deployment");

            //    RedirectingPages(urlSite + "/services-and-training/implementation-and-deployment.html", urlSite + "/Services/deployment");
            //    RedirectingPages(urlSite + "/services-and-training/after-sales-service.html", urlSite + "/Services/support");
            //    RedirectingPages(urlSite + "/services-and-training/personal-services.html", urlSite + "/Services/support/on-site-support-services");

            //    RedirectingPages(urlSite + "/services-and-training/call-center.html", urlSite + "/Services/support/call-center-support-services");
            //    RedirectingPages(urlSite + "/services-and-training/e-ticket-service.html", urlSite + "/Services/support/off-line-support-e-ticket");
            //    RedirectingPages(urlSite + "/services-and-training/e-support-service.html", urlSite + "/Services/support/online-support-e-support");

            //    RedirectingPages(urlSite + "/services-and-training/customer-portal.html", urlSite + "/Services/support/customer-portal");

            //    RedirectingPages(urlSite + "/services-and-training/sms-system.html", urlSite + "/Services/support/sms-service");
            //    RedirectingPages(urlSite + "/services-and-training/education.html", urlSite + "/Services/education");


            //    RedirectingPages(urlSite + "/newsroom", urlSite + "/blog");

            //    RedirectingPages(urlSite + "/solutions", urlSite);

            //    RedirectingPages(urlSite + "/contact-us.html", urlSite + "/contact");
            //    RedirectingPages(urlSite + "/about-us.html", urlSite + "/about");
            //    RedirectingPages(urlSite + "/about-us/varanegar-at-a-glance.html", urlSite + "/varanegar-glance");
            //    RedirectingPages(urlSite + "/about-us/our-successful-clients.html", urlSite + "/customer");
            //    RedirectingPages(urlSite + "/about-us/varanegar-pronouns.html", urlSite + "/about");
          
            }
        }
        //public void RedirectingPages(string OldPage, string NewPage)
        //{
        //    string LasURL = HttpContext.Current.Request.Url.ToString().ToLower();
        //    if (LasURL.Contains(OldPage.ToString().ToLower()))
        //    {
        //        HttpContext.Current.Response.Status = "301 Moved Permanently";
        //        Response.StatusCode = 301;

        //        HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace(LasURL, NewPage));
        //    }
        //}
    }
}