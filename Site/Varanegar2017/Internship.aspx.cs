using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class Internship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "دوره های کارآموزی شرکت ورانگر پیشرو";
            Page.MetaDescription = "از دارندگان مدرک کارشناسی در رشته های مهندسی در شرکت ورانگر دعوت به گذراندن دوره کارآموزی می گردد. در طی این فرآیند شرکت کنندگان با حداقل چهار زیر سیستم نرم افزاری شرکت ورانگر(شامل: فروش، انبار ، توزیع و مالی) آشنا شده";

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Texts where u.TextID == 36 select u).FirstOrDefault();

                if (n != null)
                    lblDescription.Text = n.TextBody;
            }
        }
    }
}