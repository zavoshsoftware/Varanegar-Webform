using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class ManagerSetting : System.Web.UI.Page
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
                var n = (from u in db.Managers
                         where u.IsDelete == false
                         orderby u.Priority
                         select u).ToList();

                grdTable.DataSource = n;
                grdTable.DataBind();
                datasourceCounter = n.Count();
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
            txtDesc.Text = string.Empty;
            txtPost.Text = String.Empty;
            txtDesc_En.Text = string.Empty;
            txtTitle_En.Text = string.Empty;
            txtPost_En.Text = String.Empty;
            txtLinkedin.Text = String.Empty;
            txtEmail.Text = String.Empty;
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

                string new_filepath = Server.MapPath("~/Uploads/team/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            int ManagerID = Convert.ToInt32(ViewState["ManagerID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Managers where u.ManagerID == ManagerID select u).FirstOrDefault();

                p.ManagerTitle = txtTitle.Text;
                p.ManagerPost = txtPost.Text;
                p.ManagerDesc = txtDesc.Text;
                p.En_ManagerTitle = txtTitle_En.Text;
                p.En_ManagerPost = txtPost_En.Text;
                p.En_ManagerDesc = txtDesc_En.Text;
                p.ManagerImg = ViewState["GImage"].ToString();
                p.LastUpdateDate = DateTime.Now;
                p.UserLastUpdated = FindUserInfo.OnlineUserID();
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.LinkedinLink = txtLinkedin.Text;
                p.EmailLink = txtEmail.Text;
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

                string new_filepath = Server.MapPath("~/Uploads/team/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                Managers p = new Managers();

                p.ManagerTitle = txtTitle.Text;
                p.ManagerPost = txtPost.Text;
                p.ManagerDesc = txtDesc.Text;
                p.En_ManagerTitle = txtTitle_En.Text;
                p.En_ManagerPost = txtPost_En.Text;
                p.En_ManagerDesc = txtDesc_En.Text;
                p.SubmitDate = DateTime.Now;
                p.UserSubmited = FindUserInfo.OnlineUserID();
                p.IsDelete = false;
                p.ManagerImg = new_filename;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.LinkedinLink = txtLinkedin.Text;
                p.EmailLink = txtEmail.Text;

                db.Managers.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
                Response.Redirect("Default.aspx");
            else
            {
                Response.Redirect("CustomerGroupSetting.aspx");
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int ManagerID = Convert.ToInt32(ViewState["ManagerID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Managers where u.ManagerID == ManagerID select u).FirstOrDefault();

                n.IsDelete = true;
                n.deleteDate = DateTime.Now;
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
            int managerId =Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["ManagerID"] = managerId;

            if (e.CommandName == "DoEdit")
            {
                int ManagerID = Convert.ToInt32(ViewState["ManagerID"].ToString());
                ViewState["ManagerID"] = ManagerID;
                ViewState["btn"] = "Update";
                FillViewEdit(ManagerID);
            }
            else if (e.CommandName == "DoDelete")
            {
                int ManagerID = Convert.ToInt32(ViewState["ManagerID"].ToString());
                ViewState["ManagerID"] = ManagerID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Managers where u.ManagerID == ManagerID select u).FirstOrDefault();
                    lblDelete.Text = n.ManagerTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(int ManagerID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Managers where u.ManagerID == ManagerID select u).FirstOrDefault();

                txtTitle.Text = n.ManagerTitle;
                txtPost.Text = n.ManagerPost;
                txtDesc.Text = n.ManagerDesc;
                txtTitle_En.Text = n.En_ManagerTitle;
                txtPost_En.Text = n.En_ManagerPost;
                txtDesc_En.Text = n.En_ManagerDesc;
                ViewState["GImage"] = n.ManagerImg;
                txtPrio.Text = n.Priority.ToString();
                imgEditImages.ImageUrl = "~/Uploads/team/" + n.ManagerImg;
                txtLinkedin.Text = n.LinkedinLink;
                txtEmail.Text = n.EmailLink;


                mvSetting.SetActiveView(vwEdit);
            }
        }

    }
}