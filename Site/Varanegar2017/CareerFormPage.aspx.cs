using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class CareerFormPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "پیوستن به ما | نرم افزار فروش و پخش مویرگی ورانگر ";
            Page.MetaDescription = "پیوستن به تیم ورانگر | "+"ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
            if (!Page.IsPostBack)
            {
                LoadSections();
            }
            var now = DateTime.Now;
            var today = (now.Date).ToString();

            txtStartDate.Attributes["onclick"] = "PersianDatePicker.Show(this,'" + today + "');";
        }

        public void LoadSections()
        {
            //section1 
            List<string> firstItem = TextData.ReturnTextTitleAndBody(9);

            ltSection2.Text = firstItem[0];
            ltSection1.Text = firstItem[1];

            //section3 
            List<string> Item2 = TextData.ReturnTextTitleAndBody(10);

            ltSection3title.Text = Item2[0];
            ltSection3Body.Text = Item2[1];
            //section4 
            List<string> Item3 = TextData.ReturnTextTitleAndBody(11);

            ltSection4title.Text = Item3[0];
            ltSection4body.Text = Item3[1];

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Images where u.ImageID == 8 && u.IsActive == true select u).FirstOrDefault();

                ScriptManager.RegisterStartupScript(this, GetType(), "asdcas",
                    "$('#teamBG').css('background-image', 'url(/Uploads/Images/" + n.ImgUrlAddress + ")');", true);


                var m = (from u in db.Images where u.ImageID == 9 && u.IsActive == true select u).FirstOrDefault();

                ScriptManager.RegisterStartupScript(this, GetType(), "hjnkj",
                    "$('#expertBG').css('background-image', 'url(/Uploads/Images/" + m.ImgUrlAddress + ")');", true);


            }
        }

        protected void btnStartForm_Click(object sender, EventArgs e)
        {
            pnlCareerInfo.Visible = false;
            pnlForm1.Visible = true;

            ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
            "$('html,body').animate({ 'scrollTop': 0 }, 1000);", true);
        }
        protected void btnFinishForm1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlForm1.Visible = false;
                pnlForm2.Visible = true;
            }
        }
        protected void btnFinishForm2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlForm2.Visible = false;
                pnlForm3.Visible = true;
            }
        }
        protected void btnFinishForm3_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlForm3.Visible = false;
                pnlForm4.Visible = true;
            }
        }
        protected void btnFinishForm4_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                InsertIntoTable();
                btnPerviousFrom4.Enabled = false;



            }
        }
        public void InsertIntoTable()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                CareerForm cfEnter = new CareerForm();
                //FirstStep
                cfEnter.careerID = Guid.NewGuid();
                cfEnter.FirstName = txtFirstName.Text;
                cfEnter.LastName = txtLastName.Text;
                cfEnter.FatherName = txtFathedName.Text;
                cfEnter.NationalSHCode = txtNationalSHID.Text;
                cfEnter.NationalCode = txtNationalID.Text;
                cfEnter.birthDate = returnBirthDate();
                cfEnter.BirthPlace = txtBirthPlace.Text;
                cfEnter.Email = txtEmail.Text;
                cfEnter.Phone = txtPhone.Text;
                cfEnter.Mobile = txtMobile.Text;
                cfEnter.marriage = Convert.ToInt32(ddlMarriage.SelectedValue);
                cfEnter.childrenNumb = txtChildren.Text;
                cfEnter.HomeStatus = Convert.ToInt32(ddlHome.SelectedValue);
                cfEnter.IsInsurance = ReturnBooleanStatus(ddlInsurance);
                cfEnter.MilitaryStatus = Convert.ToInt32(ddlMilitary.SelectedValue);
                cfEnter.Address = txtAddress.Text;
                //SecondStep
                cfEnter.ExpertOn = Convert.ToInt32(ddlExpert.SelectedValue);
                cfEnter.languagesRate = Convert.ToInt32(ddlLang.SelectedValue);
                cfEnter.degree = Convert.ToInt32(ddlDegree.SelectedValue);
                cfEnter.familiarIndustry = Convert.ToInt32(ddlIntroduce.SelectedValue);
                cfEnter.howtoFind = Convert.ToInt32(ddlIntroducrVaranegar.SelectedValue);
                cfEnter.major = txtMajor.Text;
                cfEnter.History = txtHistory.Text;
                cfEnter.Software = txtSw.Text;
                cfEnter.OtherExpertTitle = txtOtherExpert.Text;
                cfEnter.OtherFamiliar = txtOhetFamiliar.Text;
                //ThirdStep
                cfEnter.OvertimeWork = ReturnBooleanStatus(ddlOvertimeWork);
                cfEnter.NightWork = ReturnBooleanStatus(ddlNightWork);
                cfEnter.missionWork = ReturnBooleanStatus(ddlmissionWork);
                cfEnter.WeekendWork = ReturnBooleanStatus(ddlWeekendWork);
                cfEnter.Surgery = ReturnBooleanStatus(ddlSurgery);
                cfEnter.Conviction = ReturnBooleanStatus(ddlConviction);
                cfEnter.Smoking = ReturnBooleanStatus(ddlSmoking);
                cfEnter.Warranty = ReturnBooleanStatus(ddlWarranty);
                //ForthStep

                string new_filename = string.Empty;

                if (fuResume.HasFile)
                {
                    string original_filename = Path.GetFileName(fuResume.PostedFile.FileName);

                    new_filename =
                        Guid.NewGuid().ToString() +
                        Path.GetExtension(original_filename);

                    string new_filepath = Server.MapPath("~/Uploads/Resume/" + new_filename);
                    fuResume.PostedFile.SaveAs(new_filepath);
                }

                cfEnter.WorkingType = Convert.ToInt32(ddlWorkingType.SelectedValue);
                cfEnter.sallary = txtSallary.Text;
                cfEnter.StartDate = txtStartDate.Text;
                cfEnter.resumeFile = new_filename;
                cfEnter.FinalDesc = txtDesc.Text;

                cfEnter.IsVisited = false;
                cfEnter.RegisterDate = DateTime.Now;
                cfEnter.Os = FindUserInfo.UserOS();
                cfEnter.Ip = Request.UserHostAddress;
                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                cfEnter.Browser = browser.Type;
                cfEnter.IsDelete = false;

                db.CareerForm.Add(cfEnter);
                db.SaveChanges();

                ScriptManager.RegisterStartupScript(this, GetType(), "PageScriptsuccess",
                     "SuccessMessages();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "PageScriptGoTop",
                   "$('html,body').animate({ 'scrollTop': 0 }, 1000);", true);


                pnlForm4.Visible = false;
                pnlSuccess.Visible = true;

                string resumeLink = null;
                if (!string.IsNullOrEmpty(new_filename))
                    resumeLink = "<a href=/Uploads/Resume/" + new_filename + @">دانلود</a>";
                string emailBody = @"<table><tr><td>تاریخ</td><td>" + cfEnter.RegisterDate + @"</td></tr>
                <tr><td>Ip</td><td>" + cfEnter.Ip + @"</td></tr>
                <tr><td>نام</td><td>" + cfEnter.FirstName + @"</td></tr>
                <tr><td>نام خانوادگی</td><td>" + cfEnter.LastName + @"</td></tr>
                <tr><td>نام پدر</td><td>" + cfEnter.FatherName + @"</td></tr>
                <tr><td>شماره شناسنامه</td><td>" + cfEnter.NationalSHCode + @"</td></tr>
                
                <tr><td>کد ملی</td><td>" + cfEnter.NationalCode + @"</td></tr>
                <tr><td>تاریخ تولد</td><td>" + cfEnter.birthDate + @"</td></tr>
                <tr><td>محل تولد</td><td>" + cfEnter.BirthPlace + @"</td></tr>
                <tr><td>ایمیل</td><td>" + cfEnter.Email + @"</td></tr>
                <tr><td>تلفن</td><td>" + cfEnter.Phone + @"</td></tr>
                <tr><td>موبایل</td><td>" + cfEnter.Mobile + @"</td></tr>
                <tr><td>وضعیت تاهل</td><td>" + ddlMarriage.SelectedItem.Text + @"</td></tr>
                <tr><td>تعداد فرزندان</td><td>" + cfEnter.childrenNumb + @"</td></tr>
                <tr><td>وضعیت مسکن</td><td>" + ddlHome.SelectedItem.Text + @"</td></tr>
                <tr><td>بیمه تامین اجتماعی هستید؟</td><td>" + ddlInsurance.SelectedItem.Text + @"</td></tr>
                <tr><td>وضعیت نظام وظیفه؟</td><td>" + ddlMilitary.SelectedItem.Text + @"</td></tr>
                <tr><td>آدرس</td><td>" + cfEnter.Address + @"</td></tr>
                </table>
                <hr />
                <table><tr><td>تخصص</td><td>" + ddlExpert.SelectedItem.Text + @"</td></tr>
                <tr><td>تسلط به زبان انگلیسی</td><td>" + ddlLang.SelectedItem.Text + @"</td></tr>
                <tr><td>مقطع تحصیلی</td><td>" + ddlDegree.SelectedItem.Text + @"</td></tr>
                <tr><td>میزان آشنایی با صنعت پخش</td><td>" + ddlIntroduce.SelectedItem.Text + @"</td></tr>
                <tr><td>چگونه با ورانگر آشنا شدید</td><td>" + ddlIntroducrVaranegar.SelectedItem.Text + @"</td></tr>
                <tr><td>رشته تحصیلی</td><td>" + cfEnter.major + @"</td></tr>
                <tr><td>سوابق کاری</td><td>" + cfEnter.History + @"</td></tr>
                <tr><td>با چه نرم افزارهایی آشنایی دارید</td><td>" + cfEnter.Software + @"</td></tr> 
                </table>
<hr />
<table><tr><td>مايليد در زمان اضافه كار، كار كنيد؟</td><td>" + ddlOvertimeWork.SelectedItem.Text + @"</td></tr>
<tr><td>مايليد در شيفت شب كار كنيد؟</td><td>" + ddlNightWork.SelectedItem.Text + @"</td></tr>
<tr><td>مايليد به ماموريت‌هاي داخل كشور برويد؟</td><td>" + ddlmissionWork.SelectedItem.Text + @"</td></tr>
<tr><td>مايليد در تعطيلات آخر هفته فعاليت داشته باشيد؟</td><td>" + ddlWeekendWork.SelectedItem.Text + @"</td></tr>
<tr><td>آيا نقص عضو يا عمل جراحي يا بيماري دارید؟</td><td>" + ddlSurgery.SelectedItem.Text + @"</td></tr>
<tr><td>آيا سابقه محكوميت كيفري داشته‌ايد؟</td><td>" + ddlConviction.SelectedItem.Text + @"</td></tr>
<tr><td>آيا دخانيات مصرفي مي‌كنيد؟</td><td>" + ddlSmoking.SelectedItem.Text + @"</td></tr>
<tr><td>آيا ضامن براي ضمانت كار خود داريد؟</td><td>" + ddlWarranty.SelectedItem.Text + @"</td></tr> 
</table>
<hr />
<table><tr><td>نوع همکاری</td><td>" + ddlWorkingType.SelectedItem.Text + @"</td></tr>
<tr><td>ميزان حقوق درخواستي (ريال)</td><td>" + cfEnter.sallary + @"</td></tr>
<tr><td>تاریخ شروع همکاری</td><td>" + cfEnter.StartDate + @"</td></tr>
<tr><td>توضیحات</td><td>" + cfEnter.FinalDesc + @"</td></tr>
 <tr><td>رزومه</td><td>" + resumeLink + @"</td></tr>
</table>";

                List<string> emailList = SendEmail.ReturnEmailList(2);

                SendEmail.Send(emailList, "پیوستن به ما", emailBody);

                SendEmail.SendToUser_User(txtEmail.Text, "پیوستن به ما");
            }
        }

        #region Help Methods
        public string returnBirthDate()
        {
            return ddlYear.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + ddlDay.SelectedValue;
        }
        public Nullable<Boolean> ReturnBooleanStatus(DropDownList ddlID)
        {
            if (ddlID.SelectedValue != "0")
            {
                if (ddlID.SelectedValue == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return null;
        }
        #endregion
        #region Validator
        protected void cvBirthDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string day = ddlDay.SelectedValue;
            string month = ddlMonth.SelectedValue;
            string year = ddlYear.SelectedValue;

            if (day == "0" || month == "0" || year == "0")
            {
                args.IsValid = false;
            }

        }

        protected void cvMariage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlMarriage.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }

        protected void cvHome_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlHome.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }

        protected void cvInsu_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlInsurance.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }
        protected void cvExpert_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlExpert.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }

        protected void cvDegree_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlDegree.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }

        protected void cvIntrod_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlIntroduce.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }

        protected void cvIntroVaranegar_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlIntroducrVaranegar.SelectedValue == "0")
            {
                args.IsValid = false;
            }
        }
        protected void cvWorkType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlWorkingType.SelectedValue == "0")
            {
                args.IsValid = false;
                imgCaptcha.ImageUrl = "~/captcha/CaptchaGenerator.aspx";
            }
        }
        protected void reCaptchaValid_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((txtCaptcha.Text.ToString() != Session["randomStr"].ToString()))
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;
            imgCaptcha.ImageUrl = "~/captcha/CaptchaGenerator.aspx";

        }
        #endregion

        protected void btnPerviousFrom2_OnClick(object sender, EventArgs e)
        {
            pnlForm1.Visible = true;
            pnlForm2.Visible = false;
        }

        protected void btnPerviousFrom3_OnClick(object sender, EventArgs e)
        {
            pnlForm2.Visible = true;
            pnlForm3.Visible = false;
        }

        protected void btnPerviousFrom4_OnClick(object sender, EventArgs e)
        {
            pnlForm3.Visible = true;
            pnlForm4.Visible = false;
        }

        protected void ddlExpert_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExpert.SelectedValue == "5")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "werddsvgfc",
                    "$('#txtexpertbox').css('display','block');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sdwfvbsd",
                  "$('#txtexpertbox').css('display','none');", true);
            }
            if (ddlIntroducrVaranegar.SelectedValue == "6")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "werddsvgfc2",
                    "$('#txtFamiliar').css('display','block');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sdfgwfvbsd",
                  "$('#txtFamiliar').css('display','none');", true);
            }
        }

        protected void ddlIntroducrVaranegar_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIntroducrVaranegar.SelectedValue == "6")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "werddsvgfc2",
                    "$('#txtFamiliar').css('display','block');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sdfgwfvbsd",
                  "$('#txtFamiliar').css('display','none');", true);
            }
            if (ddlExpert.SelectedValue == "5")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "werddsvgfc",
                    "$('#txtexpertbox').css('display','block');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sdwfvbsd",
                  "$('#txtexpertbox').css('display','none');", true);
            }
        }

        protected void cvSalary_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            int myInt;
            if (int.TryParse(txtSallary.Text, out myInt)) //if user input is a number then
            {
                args.IsValid = true;
            }
            else args.IsValid = false;
        }

        protected void cvStartDate_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvSallaryEmpty_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtSallary.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvCaptchaEmpty_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtCaptcha.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}