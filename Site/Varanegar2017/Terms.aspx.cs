using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Varanegar
{
    public partial class Terms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                  "$('#imageSectionDiv').css('background', 'url(../Uploads/Product/55adb731-39ee-44b4-8d6a-525733bb7c66.jpg) no-repeat center center / cover');", true);

        }
    }
}