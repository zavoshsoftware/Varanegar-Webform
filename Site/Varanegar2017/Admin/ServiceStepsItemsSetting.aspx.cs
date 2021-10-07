using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class ServiceStepsItemsSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
                ResetForm();
            }
        }
        public void CheckEmptyData(int DataCounter)
        {
            if (DataCounter == 0)
                pnlEmptyForm.Visible = true;
            else
                pnlEmptyForm.Visible = false;
        }
        public void ResetForm()
        {
            txtItem.Text = string.Empty;
            txtPrio.Text = string.Empty;
            txtItemEn.Text = string.Empty;

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
             if (Request.QueryString["id"] != null)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var m = (from a in db.ServiceSteps
                             where a.ServiceStepID == id && a.IsDelete == false
                             select a).FirstOrDefault();

                      var o = (from a in db.Services
                             where a.ServiceID == m.fk_ServiceID
                             select a).FirstOrDefault();

                      Response.Redirect("~/admin/ServiceStepsSetting.aspx?id=" + o.ServiceID);
                }
            }
        }
        public void LoadForm()
        {
            int datasourceCounter = 0;
            if (Request.QueryString["id"] != null)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var m = (from a in db.ServiceSteps
                             where a.ServiceStepID == id && a.IsDelete == false
                             select a).FirstOrDefault();
                    lblStepTitle.Text = m.ServiceStepTitle;

                    var o = (from a in db.Services
                             where a.ServiceID == m.fk_ServiceID
                             select a).FirstOrDefault();
                    lblserviceTitle.Text = o.ServiceTitle;


                    var n = (from aa in db.ServiceStepItems                             
                             where aa.IsDelete == false && aa.fk_ServiceStepID == id
                             orderby aa.Priority descending
                             select
                             new
                             {
                               aa.ServiceStepItemTitle,
                               aa.ServiceStepItemID,
                               aa.En_ServiceStepItemTitle,
                               aa.Priority
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
            }

            else
            {
                Response.Redirect("~/admin/default.aspx");
            }

            CheckEmptyData(datasourceCounter);

        }
       

        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }

        protected void grdTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "DoDelete")
            {
                Guid ServiceStepItemID = new Guid(e.CommandArgument.ToString());
                ViewState["ServiceStepItemID"] = ServiceStepItemID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from aa in db.ServiceStepItems

                             where aa.ServiceStepItemID == ServiceStepItemID
                             select new
                             {
                                 aa.ServiceStepItemTitle
                             }).FirstOrDefault();
                    lblDelete.Text = n.ServiceStepItemTitle;
                    pnlDelete.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    ServiceStepItems a = new ServiceStepItems();
                    a.En_ServiceStepItemTitle = txtItemEn.Text ;
                    a.fk_ServiceStepID = id;
                    a.IsDelete =false;
                    if(!string.IsNullOrEmpty(txtPrio.Text))
                    a.Priority =Convert.ToInt32(txtPrio.Text);
                    
                    a.ServiceStepItemID = Guid.NewGuid();
                    a.ServiceStepItemTitle = txtItem.Text;
                    a.SubmitDate = DateTime.Now;

                    db.ServiceStepItems.Add(a);
                    db.SaveChanges();

                    LoadForm();
                    ResetForm();
                    pnlSuccess.Visible = true;
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid ServiceStepItemID = new Guid(ViewState["ServiceStepItemID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.ServiceStepItems
                         where a.ServiceStepItemID == ServiceStepItemID
                         select a).FirstOrDefault();
                db.ServiceStepItems.Remove(n);
                db.SaveChanges();
                LoadForm();
                pnlSuccess.Visible = true;
                pnlDelete.Visible = false;

            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            pnlDelete.Visible = false;
        }

     

      
    }
}