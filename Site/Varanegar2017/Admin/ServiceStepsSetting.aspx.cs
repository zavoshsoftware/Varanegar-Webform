using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class serviceitemssetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
                DropDownBind();
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
            if (Request.QueryString["ID"] == null)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ServiceSteps
                             join a in db.Services
                             on u.fk_ServiceID equals a.ServiceID
                             where u.IsDelete == false
                             orderby u.Priority
                             select
                             new
                             {
                                 u.Priority,
                                 a.ServiceTitle,
                                 u.ServiceStepImage,
                                 u.ServiceStepTitle,                                  
                                 u.ServiceStepID,
                                 u.ServiceStepName
 
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
            }

            else
            {
                Guid ID = new Guid(Request.QueryString["ID"].ToString());
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ServiceSteps
                             join a in db.Services
                             on u.fk_ServiceID equals a.ServiceID
                             where u.IsDelete == false && u.fk_ServiceID == ID
                             orderby u.Priority
                             select
                             new
                             {
                                 u.Priority,
                                 a.ServiceTitle,
                                 u.ServiceStepImage,
                                 u.ServiceStepTitle,
                                 u.ServiceStepID,
                                 u.ServiceStepName
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
            }
            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"] == "Recycle")
                {
                    using (VaranegarEntities db = new VaranegarEntities())
                    {
                        var n = (from u in db.ServiceSteps
                                 join a in db.Services
                                 on u.fk_ServiceID equals a.ServiceID
                                 where u.IsDelete == true
                                 orderby u.Priority
                                 select
                                 new
                                 {
                                     u.Priority,
                                     a.ServiceTitle,
                                     u.ServiceStepImage,
                                     u.ServiceStepTitle,
                                     u.ServiceStepID,
                                     u.ServiceStepName
                                 }).ToList();

                        grdTable.DataSource = n;
                        grdTable.DataBind();
                        datasourceCounter = n.Count();
                    }
                }
            }
            CheckEmptyData(datasourceCounter);
            mvSetting.SetActiveView(vwList);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            mvSetting.SetActiveView(vwEdit);
            ViewState["btn"] = "Insert";
            ResetForm();
        }
        public void ResetForm()
        {
            txtTitle.Text = string.Empty;
          txtName.Text=String.Empty;
           ddlServices.SelectedValue = "-1";
            txtENTitle.Text = string.Empty;
            reDesc.Text = string.Empty;
            reEN_Desc.Text = string.Empty;
            txtPrio.Text = string.Empty;
            txtHeader.Text=String.Empty;
            txtHeaderEn.Text=String.Empty;
        }

        public void DropDownBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.Services
                          where u.IsDelete == false  
                          orderby u.ServiceID
                          select u).ToList();
                ddlServices.Items.Clear();
                ddlServices.Items.Add(new ListItem("خدمات", "-1"));
                foreach (var t in pg)
                    ddlServices.Items.Add(new ListItem(t.ServiceTitle, t.ServiceID.ToString()));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ViewState["btn"].ToString() == "Update")
                    UpdateForm();
                else if (ViewState["btn"].ToString() == "Insert")
                    InsertForm();

                LoadForm();
            }

        }
        public void UpdateForm()
        {
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Service/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            Guid serviceStepID = new Guid(ViewState["ServiceStepID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.ServiceSteps where u.ServiceStepID == serviceStepID select u).FirstOrDefault();
                 
                p.ServiceStepTitle = txtTitle.Text;
                p.En_ServiceStepTitle = txtENTitle.Text;
                p.SmallDesc = txtHeader.Text;
                p.En_SmallDesc = txtHeaderEn.Text;
                p.En_ServiceStepDesc = reEN_Desc.Text;
                p.ServiceStepDesc = reDesc.Text;
                p.ServiceStepName = txtName.Text;
                p.fk_ServiceID = new Guid(ddlServices.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.ServiceStepImage = ViewState["GImage"].ToString();
                db.SaveChanges();
            }
        }
        public void InsertForm()
        {
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Service/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                ServiceSteps p = new ServiceSteps();

                p.ServiceStepID = Guid.NewGuid();
                p.ServiceStepTitle = txtTitle.Text;
                p.En_ServiceStepTitle = txtENTitle.Text;
                p.ServiceStepName = txtName.Text;
                p.En_ServiceStepDesc = reEN_Desc.Text;
                p.ServiceStepDesc = reDesc.Text;
                p.fk_ServiceID = new Guid(ddlServices.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.IsDelete = false;
                p.SubmitDate = DateTime.Now;
                p.ServiceStepImage = new_filename;
                p.SmallDesc = txtHeader.Text;
                p.En_SmallDesc = txtHeaderEn.Text;

                db.ServiceSteps.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
       

            if (Request.QueryString["ID"] == null && Request.QueryString["type"] == null)
                Response.Redirect("Default.aspx");

            else if (Request.QueryString["ID"] != null)
            {
                Response.Redirect("Servicesetting.aspx");
            }

            else if (Request.QueryString["type"] != null)
            {
                Response.Redirect("~/Admin/ServiceStepsSetting.aspx");
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid ServiceStepID = new Guid(ViewState["ServiceStepID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ServiceSteps where u.ServiceStepID == ServiceStepID select u).FirstOrDefault();

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
            if (e.CommandName == "DoEdit")
            {
            Guid ServiceStepID = new Guid(e.CommandArgument.ToString());
                ViewState["ServiceStepID"] = ServiceStepID;
                ViewState["btn"] = "Update";

                DropDownBind();
                FillViewEdit(ServiceStepID);
            }
            else if (e.CommandName == "DoDelete")
            {
            Guid ServiceStepID = new Guid(e.CommandArgument.ToString());
                ViewState["ServiceStepID"] = ServiceStepID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ServiceSteps where u.ServiceStepID == ServiceStepID select u).FirstOrDefault();
                    lblDelete.Text = n.ServiceStepTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
            else if (e.CommandName == "recycle")
            {
            Guid ServiceStepID = new Guid(e.CommandArgument.ToString());
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ServiceSteps where u.ServiceStepID == ServiceStepID select u).FirstOrDefault();

                    n.IsDelete = false;
                    n.DeleteDate = DateTime.Now;
                    db.SaveChanges();
                    LoadForm();
                }
            }
        }

        public void FillViewEdit(Guid ServiceStepID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ServiceSteps where u.ServiceStepID == ServiceStepID select u).FirstOrDefault();
                txtTitle.Text = n.ServiceStepTitle;
               
                ddlServices.SelectedValue = n.fk_ServiceID.ToString();
                txtENTitle.Text = n.En_ServiceStepTitle;
                reEN_Desc.Text = n.En_ServiceStepDesc;
                reDesc.Text = n.ServiceStepDesc;
                txtPrio.Text = n.Priority.ToString();
                ViewState["GImage"] = n.ServiceStepImage;
                txtName.Text = n.ServiceStepName;
                txtHeaderEn.Text = n.En_SmallDesc;
                txtHeader.Text = n.SmallDesc;
                txtName.Enabled = false;
                mvSetting.SetActiveView(vwEdit);
            }
        }
         
        protected void cvProGroup_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlServices.SelectedIndex != 0;
        }

        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }

        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Services where u.ServiceName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid ServiceStepID = new Guid(ViewState["ServiceStepID"].ToString());

                    var m = (from u in db.ServiceSteps where u.ServiceStepID == ServiceStepID select u).FirstOrDefault();
                   
                    if (m.ServiceStepName == txtName.Text)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = n == null;
                    }
                }
            }
        }

        protected void grdTable_OnDataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow r in grdTable.Rows)
            {
                HiddenField hfValue = (HiddenField)r.FindControl("hfValue");
                LinkButton lbDelete = (LinkButton)r.FindControl("lbDelete");

                LinkButton lbRecycle = (LinkButton)r.FindControl("lbRecycle");

                Guid ID = new Guid(hfValue.Value);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.ServiceSteps
                             where a.ServiceStepID == ID
                             select a).FirstOrDefault();

                    if (n.IsDelete == false)
                    {
                        lbDelete.Visible = true;
                        lbRecycle.Visible = false;
                    }
                    else
                    {
                        lbDelete.Visible = false;
                        lbRecycle.Visible = true;
                    }
                }
            }
        }
    }
}