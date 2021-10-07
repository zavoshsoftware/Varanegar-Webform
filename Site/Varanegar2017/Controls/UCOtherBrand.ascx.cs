using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Controls
{
    public partial class UCOtherBrand : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            int textId = Convert.ToInt32(WebConfigurationManager.AppSettings["brandTextId"]);

            using (VaranegarEntities db = new VaranegarEntities())
            {
                Texts texts = db.Texts.Where(current => current.TextID == textId).FirstOrDefault();

                if (texts != null)
                {
                    ltTitle.Text = texts.TextTitle;
                    ltDescription.Text = texts.TextBody;
                }
            }
        
        }
    }
}