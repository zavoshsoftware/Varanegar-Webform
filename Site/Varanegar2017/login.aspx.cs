using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Thinktecture.IdentityModel.Client;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "ورود | نرم افزار فروش و پخش مویرگی ";
                Page.MetaDescription =
                    "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";

                ScriptManager.RegisterStartupScript(this, GetType(), "PageScriptblog",
                    "$('#bloglistheaderImage').css('background', 'url(/images/slide_1.jpg) no-repeat center center / cover');",
                    true);

                ltTitle.Text = "ورود";
                ltbannerText.Text = "نام کاربری و کلمه عبور را وارد نمایید";
            }
        }

        protected void cvLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from us in db.Users
                         where us.Email == txtEmail.Text && us.Password == txtPass.Text
                         select us
                    ).FirstOrDefault();
                args.IsValid = n != null;

                if (args.IsValid)
                {
                    ViewState["UserID"] = n.UserID;
                }
                else
                {
                    //     Insert_Log_LoginAttemp(false);
                }
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                FormsAuthentication.SetAuthCookie(ViewState["UserID"].ToString(), false);
                int UserID = Convert.ToInt32(ViewState["UserID"].ToString());
                //Insert_Log_LoginAttemp(true);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Users
                             where a.UserID == UserID
                             select a).FirstOrDefault();

                    if (n.fk_RoleID == 1)
                        Response.Redirect("~/admin");
                    else if (n.fk_RoleID == 3)
                    {
                        Response.Redirect("~/admin/superadmin");

                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");

                    }
                }




            }
        }

        //protected void Button1_OnClick(object sender, EventArgs e)
        //{
        //    string servserURI = "http://217.218.53.70:5051/oauth/token";
        //    var oauthClient = new OAuth2Client(new Uri(servserURI));
        //    var client = new HttpClient();
        //    client.Timeout = TimeSpan.FromHours(1);
        //    var oauthresult = oauthClient.RequestResourceOwnerPasswordAsync("admin", "1234", "79A0D598-0BD2-45B1-BAAA-0A9CF9EFF240,79A0D598-0BD2-45B1-BAAA-0A9CF9EFF240").Result; //, "foo bar"

        //    if (oauthresult.AccessToken != null)
        //    {
        //        client.SetBearerToken(oauthresult.AccessToken);
        //    }
        //}
    }
}