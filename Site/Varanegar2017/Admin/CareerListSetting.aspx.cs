using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class CareerListSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }
        public void CheckEmptyData(int DataCounter)
        {
            if (DataCounter == 0)
                pnlEmptyForm.Visible = true;
            else
                pnlEmptyForm.Visible = false;
        }
        public void LoadForm()
        {
            int datasourceCounter = 0;
           
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.CareerForm                             
                             where u.IsDelete == false
                             orderby u.RegisterDate descending
                             select
                             new
                             {
                                u.FirstName,
                                u.LastName,
                                u.careerID,
                                u.RegisterDate
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
           
            CheckEmptyData(datasourceCounter);
            mvSetting.SetActiveView(vwList);
        }
      
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }

        public void ShowDetails()
        {

            Guid careerID = new Guid(ViewState["careerID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.CareerForm where u.careerID == careerID select u).FirstOrDefault();

               
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid careerID = new Guid(ViewState["careerID"].ToString()); 

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CareerForm where u.careerID == careerID select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
            LoadForm();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }

        protected void grdTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDetail")
            {
                Guid careerID = new Guid(e.CommandArgument.ToString());
                ViewState["careerID"] = careerID;

                FillViewEdit(careerID);
            }
            else if (e.CommandName == "DoDelete")
            {
                Guid careerID = new Guid(e.CommandArgument.ToString());
                ViewState["careerID"] = careerID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.CareerForm where u.careerID == careerID select u).FirstOrDefault();

                    lblDelete.Text = n.FirstName;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(Guid careerID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CareerForm where u.careerID == careerID select u).FirstOrDefault();

                lblAddress.Text = n.Address;
                lblBirthDay.Text = n.birthDate;
                lblBirthPlace.Text = n.BirthPlace;
                lblChildrenNumb.Text = n.childrenNumb;
                lblEmail.Text = n.Email;
                lblFatherName.Text = n.FatherName;
                lblFirstName.Text = n.FirstName;
                lblHome.Text = ReturnHomeStatus(Convert.ToInt32(n.HomeStatus));
                lblInsurance.Text =ReturnBooleanStatus(Convert.ToBoolean(n.IsInsurance));
                lblLastName.Text = n.LastName;
                lblMarriage.Text = ReturnMarriageStatus(Convert.ToInt32(n.marriage));
                lblMilitery.Text = ReturnMilitaryStatus(Convert.ToInt32(n.MilitaryStatus));  
                lblMobile.Text = n.Mobile;
                lblNationalId.Text = n.NationalCode;
                lblNationalShID.Text = n.NationalSHCode;
                lblPhone.Text = n.Phone;
               // Part 2

                lblExpertOn.Text = ReturnExpertOnStatus(Convert.ToInt32(n.ExpertOn));
                lblLang.Text = ReturnLangStatus(Convert.ToInt32(n.languagesRate));
                lblDegree.Text = ReturnDegreeStatus(Convert.ToInt32(n.degree));
                lblMajor.Text = n.major;
                lblintro.Text = ReturnIntroduceStatus(Convert.ToInt32(n.familiarIndustry));
                lblIntroVaranegar.Text = ReturnHowIntroduce(Convert.ToInt32(n.howtoFind));
                lblSoftware.Text = n.Software;
                lblHistory.Text = n.History;
                // Part 3

                lblovertime.Text = ReturnBooleanStatus(Convert.ToBoolean(n.OvertimeWork));
                lblNight.Text = ReturnBooleanStatus(Convert.ToBoolean(n.NightWork));
                lblMission.Text = ReturnBooleanStatus(Convert.ToBoolean(n.missionWork));
                lblWeekend.Text = ReturnBooleanStatus(Convert.ToBoolean(n.WeekendWork));
                lblSmoking.Text = ReturnBooleanStatus(Convert.ToBoolean(n.Smoking));
                lblWarr.Text = ReturnBooleanStatus(Convert.ToBoolean(n.Warranty));
                lblSurg.Text = ReturnBooleanStatus(Convert.ToBoolean(n.Surgery));
                lblCon.Text = ReturnBooleanStatus(Convert.ToBoolean(n.Conviction));

                // Part 4
                lblWorkingType.Text = ReturnWorkType(Convert.ToInt32(n.WorkingType));
                lblSallary.Text = n.sallary;
                lblStartWork.Text = n.StartDate;
                lblDesc.Text = n.FinalDesc;
                 
                if(string.IsNullOrEmpty(n.resumeFile))
                {
                    hlResume.Enabled = false;
                    hlResume.Text = "رزومه ای بارگزاری نشده است";
                }
                else
                {
                    hlResume.NavigateUrl = "~/Uploads/Resume/" + n.resumeFile;
                }


                mvSetting.SetActiveView(vwEdit);
            }
        }
        public string ReturnWorkType(int id)
        { 

            switch (id)
            {
                case 1:
                    return "تمام وقت";
                    break;
                case 2:
                    return "ساعتی";
                    break;
                case 3:
                    return "پروژه ای";
                    break;
                case 4:
                    return "پیمانکاری";
                    break;
                
                default:
                    return "";
                    break;
            }
        }
        public string ReturnHowIntroduce(int id)
        {
            switch (id)
            {
                case 1:
                    return "وب سایت ورانگر";
                    break;
                case 2:
                    return "توصیه دیگران";
                    break;
                case 3:
                    return "بنر های تبلیغاتی";
                    break;
                case 4:
                    return "جراید و روزنامه ها";
                    break;
                case 5:
                    return "دوستان";
                    break;
                case 6:
                    return "سایر";
                    break;

                default:
                    return "";
                    break;
            }
        }
        public string ReturnIntroduceStatus(int id)
        {  
            switch (id)
            {
                case 1:
                    return "خوب";
                    break;
                case 2:
                    return "متوسط";
                    break;
                case 3:
                    return "ضعیف";
                    break;
                case 4:
                    return "آشنایی ندارم";
                    break;             

                default:
                    return "";
                    break;
            }
        }
        public string ReturnDegreeStatus(int DegreeID)
        { 
            switch (DegreeID)
            {
                case 1:
                    return "دکتری";
                    break;
                case 2:
                    return "کارشناسی ارشد";
                    break;
                case 3:
                    return "کارشناسی";
                    break;
                case 4:
                    return "کاردانی";
                    break;
                case 5:
                    return "دیپلم";
                    break;
                       case 6:
                    return "زیر دیپلم";
                    break;

                default:
                    return "";
                    break;
            }
        }
        public string ReturnLangStatus(int LangID)
        { 
            switch (LangID)
            {
                case 1:
                    return "عالی";
                    break;
                case 2:
                    return "خوب";
                    break;
                case 3:
                    return "متوسط";
                    break;
                case 4:
                    return "ضعیف";
                    break;
                
                default:
                    return "";
                    break;
            }
        }
        public string ReturnExpertOnStatus(int ExpertID)
        {
            switch (ExpertID)
            {
                case 1:
                    return "بازاریابی";
                    break;
                case 2:
                    return "برنامه نویسی";
                    break;
                case 3:
                    return "فروش";
                    break;
                case 4:
                    return "پشتیبانی";
                    break;
                case 5:
                    return "سایر";
                    break;

                default:
                    return "";
                    break;
            }
        }
        public string ReturnMilitaryStatus(int MilitaryStatus)
        {
            switch (MilitaryStatus)
            {
                case 1:
                    return "انجام شده";
                    break;
                case 2:
                    return "معافیت تحصیلی";
                    break;
                case 3:
                    return "معافیت کفالت";
                    break;
                case 4:
                    return "معافیت پزشکی";
                    break;

                default:
                    return "";
                    break;
            }
        }
         
        public string ReturnHomeStatus(int StatusID)
        {
            switch (StatusID)
            {
                case 1:
                      return "منزل والدین";
                        break;                   
                case 2:
                              return "منزل شخصی";
                        break;
                         case 3:
                      return "استیجاری";
                        break;                   
                case 4:
                              return "غیره";
                        break;
                    
                default:
                        return "";
                    break;
            }
        }
        public string ReturnMarriageStatus(int marriage)
        {
            switch (marriage)
            {
                case 1:
                    return "مجرد";
                    break;
                case 2:
                    return "متاهل";
                    break;
                case 3:
                    return "متارکه کرده";
                    break;                
                default:
                    return "";
                    break;
            }
        }
        public string ReturnBooleanStatus(Boolean id)
        {
            switch (id)
            {
                case true:
                    return "بلی";
                    break;
                case false:
                    return "خیر";
                    break; 
                default:
                    return "";
                    break;
            }
        }
        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }
    }
}