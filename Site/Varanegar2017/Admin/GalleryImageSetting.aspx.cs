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
    public partial class GalleryImageSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
                DropDownBind();
            }
        }
        public void DropDownBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.GalleryGroups
                          where u.IsDelete == false
                          orderby u.Priority
                          select u).ToList();
                ddlGroup.Items.Clear();
                ddlGroup.Items.Add(new ListItem("گروه گالری ", "-1"));
                foreach (var t in pg)
                    ddlGroup.Items.Add(new ListItem(t.Title, t.Id.ToString()));
            }
        }
        public void LoadForm()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                //var n = (from u in db.GalleryImages
                //         join aa in db.GalleryGroups
                //         on u.fk_GalleryId equals aa.Id
                //         where u.IsDelete == false
                //         orderby u.SubmitDate descending
                //         select new
                //         {
                //             u.Id,
                //             u.Title,
                //             u.Priority,
                //             GalleryGroupTitle = aa.Title
                //         }).ToList();
                var n = db.GalleryImages.Where(current => current.IsDelete == false).ToList();
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
            txtPrio.Text = string.Empty;
            txtSummery.Text = string.Empty;
            txtVideoLink.Text = string.Empty;
            ddlGroup.SelectedValue = "-1";
            ViewState["GImage"] = null;
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid Id = new Guid(e.CommandArgument.ToString());
            ViewState["Id"] = Id;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(Id);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.GalleryImages where u.Id == Id select u).FirstOrDefault();

                            lblDelete.Text = n.Title;
                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid Id)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.GalleryImages where u.Id == Id select u).FirstOrDefault();

                txtTitle.Text = n.Title;

                txtPrio.Text = n.Priority.ToString();
                txtSummery.Text = n.Summery;
                txtVideoLink.Text = n.VideoLink;

                ViewState["GImage"] = n.ImageUrl;
                imgEditImages.ImageUrl = "~/Uploads/Gallery/" + n.ImageUrl;
                if (!string.IsNullOrEmpty(n.fk_GalleryId.ToString()))
                    ddlGroup.SelectedValue = n.fk_GalleryId.ToString();
                else
                    ddlGroup.SelectedValue = "-1";

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

                string new_filepath = Server.MapPath("~/Uploads/Gallery/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                GalleryImages pg = new GalleryImages();

                pg.Id = Guid.NewGuid();
                pg.Title = txtTitle.Text;
                if (!string.IsNullOrEmpty(txtVideoLink.Text))
                    pg.VideoLink = txtVideoLink.Text;
                else
                    pg.VideoLink = null;
                pg.ImageUrl = new_filename;
                pg.Priority = Convert.ToInt32(txtPrio.Text);
                pg.Summery = txtSummery.Text;

                if (ddlGroup.SelectedValue != "-1")
                    pg.fk_GalleryId = new Guid(ddlGroup.SelectedValue);
                else
                    pg.fk_GalleryId = null;

                pg.SubmitDate = DateTime.Now;
                pg.IsDelete = false;
                db.GalleryImages.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid Id = new Guid(ViewState["Id"].ToString());
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Gallery/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.GalleryImages where u.Id == Id select u).FirstOrDefault();

                pg.Title = txtTitle.Text;
                if (!string.IsNullOrEmpty(txtVideoLink.Text))
                    pg.VideoLink = txtVideoLink.Text;
                else
                    pg.VideoLink = null;
                pg.ImageUrl = ViewState["GImage"].ToString();
                pg.Priority = Convert.ToInt32(txtPrio.Text);
                pg.Summery = txtSummery.Text;

                if (ddlGroup.SelectedValue != "-1")
                    pg.fk_GalleryId = new Guid(ddlGroup.SelectedValue);
                else
                    pg.fk_GalleryId = null;

                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            Guid Id = new Guid(ViewState["Id"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.GalleryImages where u.Id == Id select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;

                db.SaveChanges();
                mvSetting.SetActiveView(vwList);

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



    }
}