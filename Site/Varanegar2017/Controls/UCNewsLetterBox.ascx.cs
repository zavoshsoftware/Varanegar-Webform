using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar.Controls
{
    public partial class UCNewsLetterBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //    ViewState["cp"] = "0";

        }
        protected void lbNewsLetter_Click(object sender, EventArgs e)
        {

            pnlSuccess.Visible = false;
            if (Page.IsValid)
            {
                //if (IsValidUser())
                //{
                if (IsFirstTimeEmail())

                {
                    using (VaranegarEntities db = new VaranegarEntities())
                    {
                        NewsLetters nlEnter = new NewsLetters();
                        nlEnter.email = txtNewsletter.Text;
                        nlEnter.IsDelete = false;
                        nlEnter.OS = FindUserInfo.UserOS();
                        nlEnter.SubmitIP = Request.UserHostAddress;
                        System.Web.HttpBrowserCapabilities browser = Request.Browser;
                        nlEnter.Browser = browser.Type;
                        nlEnter.SubmitDate = DateTime.Now;

                        db.NewsLetters.Add(nlEnter);
                        db.SaveChanges();
                        pnlSuccess.Visible = true;
                    }
                }
                //}
                //else
                //{
                //    pnlCaptcha.Visible = true;
                //    imgCaptcha.ImageUrl = "~/Captcha/CaptchaGeneratorForNewsletter.aspx";
                //    ViewState["cp"] = "1";
                //}
            }
        }
        public Boolean IsFirstTimeEmail()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                if (!string.IsNullOrEmpty(txtNewsletter.Text))
                {
                    var n = (from a in db.NewsLetters
                             where a.email == txtNewsletter.Text && a.IsDelete == false
                             select a).FirstOrDefault();

                    if (n != null)
                        return false;
                    else
                        return true;
                }
                return false;
            }
        }
        //protected void cvNewsletter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    using (VaranegarEntities db = new VaranegarEntities())
        //    {
        //        if (!string.IsNullOrEmpty(txtNewsletter.Text))
        //        {
        //            var n = (from a in db.NewsLetters
        //                     where a.email == txtNewsletter.Text && a.IsDelete == false
        //                     select a).FirstOrDefault();

        //            if (n != null)
        //                args.IsValid = false;
        //            else
        //                args.IsValid = true;
        //        }
        //    }
        //}
        //public Boolean IsValidUser()
        //{
        //    using (VaranegarEntities db = new VaranegarEntities())
        //    {
        //        string ip = Request.UserHostAddress;
        //        DateTime LastHour = DateTime.Now.AddHours(-1);
        //        if (ViewState["cp"].ToString() != "1")
        //        {
        //            if (!string.IsNullOrEmpty(txtNewsletter.Text))
        //            {
        //                var n = (from a in db.NewsLetters
        //                         where a.SubmitIP == ip && a.SubmitDate >= LastHour
        //                         select a).ToList();

        //                if (n.Count() > 4)
        //                    return false;
        //                else
        //                    return true;
        //            }
        //            else
        //                return false;
        //        }
        //        else
        //        {
        //            if ((txtCaptcha.Text.ToString() == Session["newsletter"].ToString()))
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //}

        //protected void cvCaptcha_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if ((txtCaptcha.Text.ToString() != Session["newsletter"].ToString()))
        //    {
        //        args.IsValid = false;
        //    }
        //    else
        //        args.IsValid = true;
        //}
    }
}