using GSD.Globalization;
using OfficeOpenXml.Packaging.Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Varanegar
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

            string JQueryVer = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{file}.js");
            routes.Ignore("{file}.txt");
            routes.Ignore("{file}.aspx");
            routes.Ignore("{file}.axd");
            routes.Ignore("{file}.css");
            routes.MapPageRoute("serivceSinglepageRout", "solution/specialty-food-distribution-solution", "~/SinglePage.aspx");

            routes.MapPageRoute("solutionRout", "solution/{SolutionName}", "~/ShowSolution.aspx");
            routes.MapPageRoute("serviceRout", "Services/{ServiceName}", "~/ShowService.aspx");
            routes.MapPageRoute("serviceSpetRout", "Services/{ServiceName}/{ServiceStepName}", "~/ShowServiceStep.aspx");

            routes.MapPageRoute("blogRout", "Blog/{BlogGroupName}", "~/BlogList.aspx");
            //routes.MapPageRoute("blogdetailRout", "BlogDetail/{BlogName}", "~/ShowBlog.aspx");
            routes.MapPageRoute("blogdetailRout", "Blog/{BlogGroupName}/{BlogName}", "~/ShowBlog.aspx");
            routes.MapPageRoute("bloglistRout", "Blog", "~/bloglist.aspx");
            routes.MapPageRoute("aboutRout", "about", "~/AboutUs.aspx");
            routes.MapPageRoute("contactRout", "contact", "~/ContactUs.aspx");
            
            routes.MapPageRoute("productGroupRout", "Product/{ProductGroupName}", "~/ShowProductGroup.aspx");
            routes.MapPageRoute("productRout", "Product/{ProductGroupName}/{ProductName}", "~/ShowProduct.aspx");

            routes.MapPageRoute("customerRout", "Customer/{CustomerName}", "~/ShowCustomer.aspx");
            routes.MapPageRoute("customerlistRout", "Customer", "~/CustomerList.aspx");

            routes.MapPageRoute("careerRout", "career", "~/CareerFormPage.aspx");
            routes.MapPageRoute("loginRout", "login", "~/login.aspx");
            routes.MapPageRoute("glanceRout", "varanegar-glance", "~/AtAGlance.aspx");
            routes.MapPageRoute("PartnerRout", "business-partners", "~/Partners.aspx");
            routes.MapPageRoute("DemoRout", "software-demo", "~/DemoReq.aspx");
            routes.MapPageRoute("InternshipRout", "internship", "~/Internship.aspx");
            routes.MapPageRoute("termsRout", "terms-and-conditions", "~/terms.aspx");
            routes.MapPageRoute("agentRout", "sales-agent", "~/AgentQuestions.aspx");
            routes.MapPageRoute("galleryimageRout", "gallery/{galleryImageId}", "~/GalleryImageDetail.aspx");
            routes.MapPageRoute("galleryRout", "gallery", "~/GalleryImageList.aspx");

            routes.MapPageRoute("seminarRegisterRout", "seminarregister", "~/SeminarRegister.aspx");

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //if (DateTime.Now.Hour == 15)
            //{
               
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var persianCulture = new PersianCulture();
            Thread.CurrentThread.CurrentCulture = persianCulture;
            Thread.CurrentThread.CurrentUICulture = persianCulture;

            //HttpContext context = HttpContext.Current;
            //context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
            //HttpContext.Current.Response.AppendHeader("Content-encoding", "gzip");
            //HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;

            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http://www.varanegar.com/services/education"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently"; 
                Response.StatusCode = 301;
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("http://www.varanegar.com/services/education", "http://www.varanegar.com/Services/training"));
               Response.End();
            
            }
            else if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("http://www.varanegar.com/products-and-solutions/distribution-and-sales-software"))
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                Response.StatusCode = 301;
                HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("http://www.varanegar.com/products-and-solutions/distribution-and-sales-software", "http://www.varanegar.com/Product/sales-and-distribution-software"));
                Response.End();

            }
        }
      
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}