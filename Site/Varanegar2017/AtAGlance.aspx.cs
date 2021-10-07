using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class AtAGlance : System.Web.UI.Page
     {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "ورانگر در یک نگاه | نرم افزار فروش و پخش مویرگی ";
            Page.MetaDescription = "ورانگر در یک نگاه | " + "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
            if (!Page.IsPostBack)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = db.Texts.Where(a => a.groupid == 6 && a.TextID != 28).OrderBy(a => a.TextID).ToList();

                    rptTexts.DataSource = n;
                    rptTexts.DataBind();

                    var mn = db.Texts.Where(a=>a.TextID== 28).Select(a=>a.TextBody).FirstOrDefault();
                    ltText1.Text = mn;
                }
            }
        }
    }
}