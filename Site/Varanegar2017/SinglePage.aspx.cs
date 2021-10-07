using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Varanegar
{
    public partial class SinglePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "پخش مواد غذایی ورانگر | نرم افزار تخصصی پخش";
                Page.MetaDescription = "نرم افزار فروش و پخش مواد غذایی بسیاری از فعالیت های صنعت پخش را به صورت مکانیزه و خودکار کنترل و سازمان بندی می کند. شرکت ورانگر ارائه دهنده نرم افزار های تخصصی پخش و فروش فروشگاهی";
            }
        }
    }
}