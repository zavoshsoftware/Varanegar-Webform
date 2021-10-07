using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrganizationalMaturityAssessment.Admin.SuperAdmin
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FindUserInfo();
            }
            FindActiveMenu();
        }
        public void FindActiveMenu()
        {
            string strPage = Page.AppRelativeVirtualPath;

            if (strPage == "~/Admin/Default.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                "AddCurrent('#default');", true);
            }

            if (strPage == "~/Admin/CustomerGroupSetting.aspx" || strPage == "~/Admin/CustomerSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                "AddCurrent('#cus');", true);

            }
            if (strPage == "~/Admin/SolutionGroupSetting.aspx" || strPage == "~/Admin/SolutionSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#sol');", true);

            }
            if (strPage == "~/Admin/ProductGroupSetting.aspx" || strPage == "~/Admin/ProductSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#pro');", true);

            }

            if (strPage == "~/Admin/ServiceSetting.aspx" || strPage == "~/Admin/ServiceStepsSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#ser');", true);

            }
            if (strPage == "~/Admin/BlogGroupsSetting.aspx" || strPage == "~/Admin/BlogSetting.aspx" || strPage == "~/Admin/commentSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#blo');", true);
            }
            if (strPage.Contains("textsetting.aspx"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#txt');", true);
            }

            if (strPage.Contains("Email"))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                 "AddCurrent('#email');", true);
            }


            else if (strPage == "~/Admin/contactForms.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
  "AddCurrent('#conta');", true);

            }

            else if (strPage == "~/Admin/UserSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
  "AddCurrent('#userli');", true);

            }

            else if (strPage == "~/Admin/CareerListSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
  "AddCurrent('#careerli');", true);

            }

            else if (strPage == "~/Admin/ManagerSetting.aspx")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
  "AddCurrent('#managerli');", true);

            }

        }

        public void FindUserInfo()
        {
            //using (zavoshOfficeEntities db = new zavoshOfficeEntities())
            //{
            //    if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    {
            //        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

            //        var n = (from a in db.Users
            //                 where a.UserID == UserID
            //                 select a).FirstOrDefault();

            //        lblUserName.Text = n.Name + " " + n.Family;
            //    }
            //}
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}