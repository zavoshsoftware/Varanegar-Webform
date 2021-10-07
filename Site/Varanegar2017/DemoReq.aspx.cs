using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class DemoReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadFamiliarDropDown();
                LoadDropDownReciever();
                Page.Title = "دمو نرم افزار ورانگر | نرم افزار جامع پخش و فروشگاهی";
                Page.MetaDescription =
                    "برای مشاهده دمو نرم افزار های ورانگر فرم زیر را تکمیل نمایید. ورانگر اولین و بزرگترین تولید کننده و ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی می باشد";
            }
        }

        public void LoadFamiliarDropDown()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.FamiliarMethods
                         where a.IsDelete == false
                         select a).ToList();
                ddlfamiliar.Items.Clear();
                ddlfamiliar.Items.Add(new ListItem("نحوه آشنایی با ورانگر", "0"));
                foreach (var t in n)
                    ddlfamiliar.Items.Add(new ListItem(t.FamiliarMethodTitle, t.FamiliarMethodID.ToString()));
            }
        }
        protected void cvFamiliarToVaranegar_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlfamiliar.SelectedValue == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
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
                    DemoRequests drEnter = new DemoRequests();
                    drEnter.Name = txtName.Text;
                    drEnter.CompanyName = txtCompanyName.Text;
                    drEnter.Post = txtPost.Text;
                    drEnter.Field = txtField.Text;
                    drEnter.Phone = txtPost.Text;
                    drEnter.Mobile = txtMobile.Text;
                    drEnter.Email = txtEmail.Text;
                    drEnter.fk_FamiliarMethodID = Convert.ToInt32(ddlfamiliar.SelectedValue);
                    drEnter.FinalDesc = txtDesc.Text;
                    drEnter.IsDelete = false;
                    drEnter.Ip = Request.UserHostName;

                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    drEnter.Browser = browser.Type;
                    drEnter.Os = FindUserInfo.UserOS();
                    drEnter.RegisterDate = DateTime.Now;
                    drEnter.IsVisited = false;
                    drEnter.fk_RecieverID = Convert.ToInt32(ddlProduct.SelectedValue);
                    db.DemoRequests.Add(drEnter);
                    db.SaveChanges();



                    string emailBody = @"<table><tr><td>تاریخ</td><td>" + drEnter.RegisterDate + @"</td></tr>
<tr><td>Ip</td><td>" + drEnter.Ip + @"</td></tr>
<tr><td>نام</td><td>" + drEnter.Name + @"</td></tr>
<tr><td>نام شرکت / سازمان</td><td>" + drEnter.CompanyName + @"</td></tr>
<tr><td>پست</td><td>" + drEnter.Post + @"</td></tr>
<tr><td>زمینه فعالیت</td><td>" + drEnter.Field + @"</td></tr>
<tr><td>تلفن ثابت</td><td>" + drEnter.Phone + @"</td></tr>
<tr><td>نحوه آشنایی با ورانگر</td><td>" + ddlfamiliar.SelectedItem.Text + @"</td></tr>
<tr><td>نام نرم افزار</td><td>" + ddlProduct.SelectedItem.Text + @"</td></tr>
<tr><td>ایمیل</td><td>" + drEnter.Email + @"</td></tr>
<tr><td>تلفن همراه</td><td>" + drEnter.Mobile + @"</td></tr>
<tr><td>توضیحات</td><td>" + drEnter.FinalDesc + @"</td></tr></table>";

                    List<string> emailList = SendEmail.ReturnEmailList(Convert.ToInt32(ddlProduct.SelectedValue));

                    SendEmail.Send(emailList, "درخواست دمو", emailBody);

                    SendEmail.SendToUser_User(txtEmail.Text, "درخواست دمو");
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

        protected void cvProduct_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlProduct.SelectedValue == "0")
                args.IsValid = false;
            else
            {
                args.IsValid = true;
            }
        }
        public void LoadDropDownReciever()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.EmailRecieverRoles
                         where a.IsDelete == false && a.groupdid ==2

                         select a).ToList();

                ddlProduct.Items.Clear();
                ddlProduct.Items.Add(new ListItem("نرم افزار مورد نظر", "0"));
                foreach (var t in n)
                    ddlProduct.Items.Add(new ListItem(t.Title, t.EmailRecieverRoleID.ToString()));
            }
        }
    }
}