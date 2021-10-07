using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar.ErrorPages
{
    public partial class Oops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string LasURL = Request.Url.ToString().ToLower();
                //if (LasURL.Contains("/products-and-solutions/distribution-and-sales-software.html"))
                //{
                //    HttpContext.Current.Response.Status = "301 Moved Permanently";
                //    Response.StatusCode = 301;

                //    HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("http://localhost:6487/products-and-solutions/distribution-and-sales-software.html", "http://localhost:6487/Product/sales-distribution-solution"));

                //}
                Log_ErrorInsert();
                
            }
        }

        public void Log_ErrorInsert()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Log_Errors leIn = new Log_Errors();

                leIn.ErrorDate = DateTime.Now;
                leIn.ErrorIp = Request.UserHostAddress;
                leIn.OS = FindUserInfo.UserOS();
                if (Request.UrlReferrer != null)
                    leIn.RefrallPage = Request.UrlReferrer.ToString();
                else
                    leIn.RefrallPage = "ورود مستقیم";
                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                leIn.browser = browser.Type;

                db.Log_Errors.Add(leIn);
                db.SaveChanges();

            }
        }
    }
}