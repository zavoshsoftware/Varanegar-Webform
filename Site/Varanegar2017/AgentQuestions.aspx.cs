using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class AgentQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProvince();

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var city = db.City.ToList();

                    ddlCity.DataSource = city;
                    ddlCity.DataValueField = "CityID";
                    ddlCity.DataTextField = "CityName";

                    ddlCity.DataBind();
                }

                Page.Title = "درخواست نمایندگی | نرم افزار جامع پخش و فروشگاهی ورانگر";
                Page.MetaDescription =
                    "برای دریافت نمایندگی از شرکت ورانگر پیشرو در شهر خود فرم زیر را تکمیل نمایید. ورانگر اولین و بزرگترین تولید کننده و ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی می باشد";

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CreateAgentReq();
            }
        }
        public void CreateAgentReq()
        {
            try
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    AgentQuestionaries agent = new AgentQuestionaries();

                    agent.Id = Guid.NewGuid();
                    agent.FullName = txtName.Text;
                    agent.NationalCode = txtNationalCode.Text;
                    agent.BirthCerId = txtBirthCerId.Text;
                    agent.BirthPlace = txtBirthPlace.Text;
                    agent.fk_CityId = Convert.ToInt32(ddlCity.SelectedValue);
                    agent.Phone = txtHomePhone.Text;
                    agent.Mobile = txtMobile.Text;
                    agent.Email = txtEmail.Text;
                    agent.PostalCode = txtPostal.Text;
                    agent.HomeAddress = txtHomeAddress.Text;

                    if (!string.IsNullOrEmpty(txtCompanyName.Text))
                        agent.IsCompany = true;
                    agent.CompanyName = txtCompanyName.Text;
                    agent.CompanyPhone = txtCompanyPhone.Text;
                    agent.CompanyOwnership = ddlOwnership.SelectedItem.Text;
                    agent.CompanyAddress = txtCompanyAddress.Text;
                    agent.CompanyPostalCode = txtPostalCode.Text;
                    agent.CompanyArea = txtarea.Text;
                    agent.CompanyEmployeeNumber = txtEmployeNumb.Text;

                    agent.IsSellSoftwar = returnBoolean(ddlIsAgent.SelectedValue);
                    agent.SellSoftwareDesc = txtSoftwareBefore.Text;
                    agent.IsInsurance = returnBoolean(ddlInsurance.SelectedValue);
                    agent.IsAgent = returnBoolean(ddlIsAgent.SelectedValue);
                    agent.IsAgentDesc = txtIsAgent.Text;
                    agent.IsHighSpeedInternet = returnBoolean(ddlInternet.SelectedValue);
                    agent.IsCommercialPlace = returnBoolean(ddlCommercialPlace.SelectedValue);
                    agent.IsCommercialPlaceDesc = txtCommercialPlace.Text;
                    agent.VaranegarSoftwareIntroduce = ddlVaranegarSoftwareIntroduce.SelectedItem.Text;
                    agent.HowKnowUs = ddlHowKnowUs.SelectedItem.Text;
                    agent.ReasonForDo = txtReasonForDo.Text;

                    agent.IsDelete = false;
                    agent.Ip = Request.UserHostName;

                    System.Web.HttpBrowserCapabilities browser = Request.Browser;
                    agent.Browser = browser.Type;
                    agent.Os = FindUserInfo.UserOS();
                    agent.RegisterDate = DateTime.Now;

                    db.AgentQuestionaries.Add(agent);
                    db.SaveChanges();

                    if (!string.IsNullOrEmpty(txtPlaceName1.Text))
                        CreateAgentPreviousJob(agent.Id, txtPlaceName1.Text, txtIndustryType1.Text, Convert.ToInt32(txtStartDate1.Text), Convert.ToInt32(txtEndDate1.Text),txtPost1.Text, txtdesc1.Text);
                    if (!string.IsNullOrEmpty(txtPlaceName2.Text))
                        CreateAgentPreviousJob(agent.Id, txtPlaceName2.Text, txtIndustryType2.Text, Convert.ToInt32(txtStartDate2.Text), Convert.ToInt32(txtEndDate2.Text), txtPost2.Text, txtdesc2.Text);
                    if (!string.IsNullOrEmpty(txtPlaceName3.Text))
                        CreateAgentPreviousJob(agent.Id, txtPlaceName3.Text, txtIndustryType3.Text, Convert.ToInt32(txtStartDate3.Text), Convert.ToInt32(txtEndDate3.Text), txtPost3.Text, txtdesc3.Text);

                    pnlSuccess.Visible = true;
                    pnlError.Visible = false;

                    string link = "https://www.varanegar.com/showagentinfo.aspx?type=5e71e865-c73a-4094-b4cd-328973b479c4&&id=" + agent.Id;



                    string emailBody = @"<table><tr><td>تاریخ</td><td>" + agent.RegisterDate + @"</td></tr>
<tr><td>Ip</td><td>" + agent.Ip + @"</td></tr>
<tr><td>نام</td><td>" + agent.FullName + @"</td></tr></table>
<br/>
کاربر گرامی یک درخواست نمایندگی در وب سایت ثبت گردیده است. جهت مشاهده اطلاعات این درخواست بر روی لینک زیر کلیک نمایید.
<br/>
<a href='"+ link+"'>مشاهده درخواست</a>";

                   List<string> emailList = SendEmail.ReturnEmailList(15);

                   SendEmail.Send(emailList, "درخواست نمیاندگی", emailBody);
                }
            }
            catch (Exception e)
            {
                pnlSuccess.Visible = false;
                pnlError.Visible = true;
            }
        }
        public Boolean returnBoolean(string bit)
        {
            switch (bit)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    return false;
            }
        }
        public void CreateAgentPreviousJob(Guid fkAgentId, string PlaceName, string IndustryType, int startYear, int FinishYear,string Post, string Desc)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                AgentPreviousJobs agentpreviousjob = new AgentPreviousJobs();
                agentpreviousjob.id = Guid.NewGuid();
                agentpreviousjob.fk_AgentId = fkAgentId;
                agentpreviousjob.JobPlaceName = PlaceName;
                agentpreviousjob.IndustryType = IndustryType;
                agentpreviousjob.JobStartYear = startYear;
                agentpreviousjob.JobFinishDate = FinishYear;
                agentpreviousjob.JobDescription = Desc;
                agentpreviousjob.JobPost = Post;
                db.AgentPreviousJobs.Add(agentpreviousjob);
                db.SaveChanges();
            }
        }
        public void LoadProvince()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                ddlProvince.DataSource = db.Province.ToList();
                ddlProvince.DataValueField = "ProvinceID";
                ddlProvince.DataTextField = "ProvinceName";
                ddlProvince.DataBind();
            }
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            int provinceId = Convert.ToInt32(ddlProvince.SelectedValue);
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var city = db.City.Where(a => a.ProvinceID == provinceId).ToList();
                ddlCity.DataSource = city;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }
        }
    }
}