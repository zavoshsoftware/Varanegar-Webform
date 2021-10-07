using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Varanegar
{
    public partial class GaranegarGlance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScriptblogdetail",
                 "$('#bloglistheaderImage').css('background', 'url(/images/slide_1.jpg) no-repeat center center / cover');", true);

            }
        }
    }
}