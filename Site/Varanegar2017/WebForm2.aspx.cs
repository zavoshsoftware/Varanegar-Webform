using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Blogs
                    where a.IsDelete == false
                    select a).ToList();

                foreach (var r in n)
                {
                    if (r.BlogName.Contains(" "))
                    {
                        r.BlogName = r.BlogName.Replace(' ', '-').ToLower();
                        db.SaveChanges();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ctrlGoogleReCaptcha.Validate())
            {
                //submit form success
                lblStatus.Text = "Success";
            }
            else
            {
                //captcha challenge failed
                lblStatus.Text = "Captcha Failed!! Please try again!!";
            }
        }
    }
}