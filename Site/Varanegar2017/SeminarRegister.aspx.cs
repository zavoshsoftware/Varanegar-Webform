using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar2017
{
    public partial class SeminarRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                Page.Title = "ثبت نام در سمینار و برنامه های آموزشی | نرم افزار جامع پخش و فروشگاهی";
                Page.MetaDescription =
                    "برای مشاهده دمو نرم افزار های ورانگر فرم زیر را تکمیل نمایید. ورانگر اولین و بزرگترین تولید کننده و ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی می باشد";
            }

        }

        protected void btnSubmitReq_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SubmitData();
                pnlSuccess.Visible = true;
            }
        }

        public void SubmitData()
        {
            if (Page.IsValid)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    SeminarRequests srEnter = new SeminarRequests();
                    srEnter.Name = txtName.Text;
                    srEnter.CompanyName = txtCompany.Text;
                    srEnter.Phone = txtPhone.Text;
                    srEnter.Mobile = txtMobile.Text;
                    srEnter.Email = txtEmail.Text;
                    srEnter.IsDelete = false;
                    srEnter.Ip = Request.UserHostName;
                    srEnter.NationalId = txtNationalId.Text;
                    srEnter.CustomerCode = txtCustomerCode.Text;

                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    srEnter.Browser = browser.Type;
                    srEnter.Os = FindUserInfo.UserOS();
                    srEnter.RegisterDate = DateTime.Now;
                    db.SeminarRequests.Add(srEnter);
                    db.SaveChanges();



                    string emailBody = @"<table><tr><td>تاریخ</td><td>" + srEnter.RegisterDate + @"</td></tr>
                    <tr><td>Ip</td><td>" + srEnter.Ip + @"</td></tr>
                    <tr><td>نام</td><td>" + srEnter.Name + @"</td></tr>
                    <tr><td>نام شرکت / سازمان</td><td>" + srEnter.CompanyName + @"</td></tr>
                    <tr><td>تلفن ثابت</td><td>" + srEnter.Phone + @"</td></tr>
                    <tr><td>ایمیل</td><td>" + srEnter.Email + @"</td></tr>
                    <tr><td>تلفن همراه</td><td>" + srEnter.Mobile + @"</td></tr>
                    <tr><td>کدملی</td><td>" + srEnter.NationalId + @"</td></tr>
<tr><td>شماره مشتری</td><td>" + srEnter.CustomerCode + @"</td></tr></table>";


                    //List<string> emailList = SendEmail.ReturnEmailList(Convert.ToInt32(ddlProduct.SelectedValue));
                    List<string> emailList = new List<string>();
                    emailList.Add("marketing@varanegar.com");
                    SendEmail.Send(emailList, "ثبت نام در سمینار و برنامه های آموزشی ", emailBody);

                    SendEmail.SendToUser_User(txtEmail.Text, "ثبت نام در سمینار و برنامه های آموزشی ورانگر");
                }
            }
        }

        protected void reCaptchaValid_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ctrlGoogleReCaptcha.Validate())
            {
                //submit form success
                args.IsValid = true;
            }
            else
            {
                //captcha challenge failed
                args.IsValid = false;
            }
        }

       
        protected void cvCustomerCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
            if (txtCustomerCode.Text.Length >= 7)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cvPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (txtPhone.Text.Length == 8|| txtPhone.Text.Length==11)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}