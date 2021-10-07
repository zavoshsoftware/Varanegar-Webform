using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin.SuperAdmin
{
    public partial class ServiceSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }
        public void LoadForm()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Services
                         where u.IsDelete == false                         
                         orderby u.Priority
                         select u).ToList();
                grdTable.DataSource = n;
                grdTable.DataBind();

                CheckEmptyData(n.Count());
            }
        }
        public void CheckEmptyData(int DataCounter)
        {
            if (DataCounter == 0)
                pnlEmptyForm.Visible = true;
            else
                pnlEmptyForm.Visible = false;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ViewState["btn"] = "Insert";
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrio.Text = string.Empty;
            reDesc.Text = string.Empty;
            txtEN_Title.Text = string.Empty;
            reEN_Desc.Text = null;
            txtHeader.Text = string.Empty;
            txtHeaderEn.Text = string.Empty;
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid ServiceID = new Guid(e.CommandArgument.ToString());
            ViewState["ServiceID"] = ServiceID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(ServiceID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.Services where u.ServiceID == ServiceID select u).FirstOrDefault();
                         
                            lblDelete.Text = n.ServiceTitle;
                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid ServiceID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Services where u.ServiceID == ServiceID select u).FirstOrDefault();

                txtTitle.Text = n.ServiceTitle;
                txtName.Text = n.ServiceName;
                txtEN_Title.Text = n.En_ServiceTitle;
                reDesc.Text = n.ServiceDesc;
                reEN_Desc.Text = n.En_ServiceDesc;
                txtPrio.Text = n.Priority.ToString();
                txtHeader.Text = n.SmallDesc;
                txtHeaderEn.Text = n.En_SmallDesc;
                ViewState["GImage"] = n.HeaderImg;
                imgEditImages.ImageUrl = "~/Uploads/Service/" + n.HeaderImg;
            }
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
                mvSetting.SetActiveView(vwList);
                pnlSuccess.Visible = true;
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
                Services pg = new Services();

                pg.ServiceID = Guid.NewGuid();
                pg.ServiceTitle = txtTitle.Text;
                pg.En_ServiceTitle = txtEN_Title.Text;
                pg.ServiceName = txtName.Text;
                pg.ServiceDesc = reDesc.Text;
                pg.En_ServiceDesc = reEN_Desc.Text;
                pg.IsDelete = false;
                pg.Priority = Convert.ToInt32(txtPrio.Text);
                pg.SubmitDate = DateTime.Now;
                pg.SmallDesc = txtHeader.Text;
                pg.En_SmallDesc = txtHeaderEn.Text;
                pg.HeaderImg = new_filename;
                db.Services.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid ServiceID = new Guid(ViewState["ServiceID"].ToString());
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
                var n = (from u in db.Services where u.ServiceID == ServiceID select u).FirstOrDefault();

                n.ServiceTitle = txtTitle.Text;
                n.En_ServiceTitle = txtEN_Title.Text;
                n.ServiceName = txtName.Text;
                n.SmallDesc = txtHeader.Text;
                n.En_SmallDesc = txtHeaderEn.Text;
                n.ServiceDesc = reDesc.Text;
                n.En_ServiceDesc = reEN_Desc.Text;
                n.Priority = Convert.ToInt32(txtPrio.Text);
                n.LastUpdateDate = DateTime.Now;
                n.HeaderImg = ViewState["GImage"].ToString();
                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid ServiceID = new Guid(ViewState["ServiceID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Services where u.ServiceID == ServiceID select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;

                db.SaveChanges();

                LoadForm();
                pnlSuccess.Visible = true;
            }
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
            pnlSuccess.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
            pnlSuccess.Visible = false;
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
                    Guid ServiceID = new Guid(ViewState["ServiceID"].ToString());

                    var m = (from u in db.Services where u.ServiceID == ServiceID select u).FirstOrDefault();

                    if (m.ServiceName == txtName.Text)
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
    }
}