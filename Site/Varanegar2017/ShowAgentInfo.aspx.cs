using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowAgentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["type"] != null && Request.QueryString["Id"] != null)
                {
                    string type = Request.QueryString["type"].ToString();
                    string Id = Request.QueryString["Id"].ToString();

                    if (type == "5e71e865-c73a-4094-b4cd-328973b479c4")
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            Guid AgentId = new Guid(Id);
                            var agent = db.AgentQuestionaries.Where(a => a.IsDelete == false && a.Id == AgentId).FirstOrDefault();
                            if (db.AgentQuestionaries.Where(a => a.IsDelete == false && a.Id == AgentId).Any())
                            {
                                mvAgentInfo.SetActiveView(vwInfo);
                                FillViewEdit(AgentId);
                            }
                            else
                                mvAgentInfo.SetActiveView(vwError);
                        }
                    }
                    else
                        mvAgentInfo.SetActiveView(vwError);
                }
                else 
                        mvAgentInfo.SetActiveView(vwError);
            }
        }
        public void FillViewEdit(Guid AgentId)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.AgentQuestionaries where u.Id == AgentId select u).FirstOrDefault();

                lblEmail.Text = n.Email;
                lblAddress.Text = n.HomeAddress;
                lblMobile.Text = n.Mobile;
                lblPhone.Text = n.Phone;
                lblName.Text = n.FullName;
                lblNationalCode.Text = n.NationalCode;
                lblBirthCerId.Text = n.BirthCerId;
                lblBirthCerPlace.Text = n.BirthPlace;
                lblCity.Text = db.City.Where(a => a.CityID == n.fk_CityId).FirstOrDefault().CityName;
                lblPostalCode.Text = n.PostalCode;

                //// Part 2
                lblCompanyName.Text = n.CompanyName;
                lblCompanyPhone.Text = n.CompanyPhone;
                lblCompanyOwnership.Text = n.CompanyOwnership;
                lblCompanyAddress.Text = n.CompanyAddress;
                lblCompanyPostalCode.Text = n.CompanyPostalCode;
                lblArea.Text = n.CompanyArea;
                lblEmployee.Text = n.CompanyEmployeeNumber;

                //// Part 3
                var agentPreviousJob = db.AgentPreviousJobs.OrderBy(a => a.id).Where(a => a.fk_AgentId == AgentId).ToList();
                if (agentPreviousJob.Count() == 1)
                {
                    var v = agentPreviousJob.FirstOrDefault();
                    lblplaceName1.Text = v.JobPlaceName;
                    lblIndustry1.Text = v.IndustryType;
                    lblStartdate1.Text = v.JobStartYear.ToString();
                    lblFinishDate1.Text = v.JobFinishDate.ToString();
                    lblPost1.Text = v.JobPost;
                    lbljobDesc1.Text = v.JobPost;

                }
                if (agentPreviousJob.Count() == 2)
                {
                    var v = agentPreviousJob.FirstOrDefault();
                    lblplaceName1.Text = v.JobPlaceName;
                    lblIndustry1.Text = v.IndustryType;
                    lblStartdate1.Text = v.JobStartYear.ToString();
                    lblFinishDate1.Text = v.JobFinishDate.ToString();
                    lblPost1.Text = v.JobPost;
                    lbljobDesc1.Text = v.JobPost;

                    var v2 = agentPreviousJob.Skip(1).FirstOrDefault();
                    lblplaceName2.Text = v2.JobPlaceName;
                    lblIndustry2.Text = v2.IndustryType;
                    lblStartdate2.Text = v2.JobStartYear.ToString();
                    lblFinishDate2.Text = v2.JobFinishDate.ToString();
                    lblPost2.Text = v2.JobPost;
                    lbljobDesc2.Text = v2.JobPost;

                    pnlJob2.Visible = true;
                }
                else if (agentPreviousJob.Count() == 3)
                {
                    var v = agentPreviousJob.FirstOrDefault();
                    lblplaceName1.Text = v.JobPlaceName;
                    lblIndustry1.Text = v.IndustryType;
                    lblStartdate1.Text = v.JobStartYear.ToString();
                    lblFinishDate1.Text = v.JobFinishDate.ToString();
                    lblPost1.Text = v.JobPost;
                    lbljobDesc1.Text = v.JobPost;

                    var v2 = agentPreviousJob.Skip(1).FirstOrDefault();
                    lblplaceName2.Text = v2.JobPlaceName;
                    lblIndustry2.Text = v2.IndustryType;
                    lblStartdate2.Text = v2.JobStartYear.ToString();
                    lblFinishDate2.Text = v2.JobFinishDate.ToString();
                    lblPost2.Text = v2.JobPost;
                    lbljobDesc2.Text = v2.JobPost;

                    var v3 = agentPreviousJob.Skip(1).FirstOrDefault();
                    lblplaceName3.Text = v3.JobPlaceName;
                    lblIndustry3.Text = v3.IndustryType;
                    lblStartdate3.Text = v3.JobStartYear.ToString();
                    lblFinishDate3.Text = v3.JobFinishDate.ToString();
                    lblPost3.Text = v3.JobPost;
                    lbljobDesc3.Text = v3.JobPost;
                    pnlJob3.Visible = true;
                    pnlJob2.Visible = true;
                }

                //// Part 4
                lblSoftwareBefore.Text = ConvertBooleanToYesNo(n.IsSellSoftwar);
                lblSoftwareBeforeDesc.Text = n.SellSoftwareDesc;
                lblIsAgent.Text = ConvertBooleanToYesNo(n.IsAgent);
                lblIsAgentDesc.Text = n.IsAgentDesc;
                lblCommercialPlace.Text = ConvertBooleanToYesNo(n.IsCommercialPlace);
                lblCommercialPlaceDesc.Text = n.IsCommercialPlaceDesc;

                lblInsurance.Text = ConvertBooleanToYesNo(n.IsInsurance);
                lblInternet.Text = ConvertBooleanToYesNo(n.IsHighSpeedInternet);
                lblVaranegarSoftwareIntroduce.Text = n.VaranegarSoftwareIntroduce;
                lblHowKnowUs.Text = n.HowKnowUs;
                lblReason.Text = n.ReasonForDo;
            }
        }
        public string ConvertBooleanToYesNo(Nullable<Boolean> item)
        {
            switch (item)
            {
                case true:
                    return "بله";
                case false:
                    return "خیر";
                default:
                    return "خیر";
            }
        }
    }
}