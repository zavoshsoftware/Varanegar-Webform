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
    public partial class GalleryGroupSetting : System.Web.UI.Page
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
                    var n = (from u in db.GalleryGroups
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
            txtPri.Text = string.Empty;
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
                            var n = (from u in db.GalleryGroups where u.Id == Id select u).FirstOrDefault();
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
                var n = (from u in db.GalleryGroups where u.Id == Id select u).FirstOrDefault();

                txtTitle.Text = n.Title;
                txtPri.Text = n.Priority.ToString();
                ViewState["GImage"] = n.ImageUrl;

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
            using (VaranegarEntities db = new VaranegarEntities())
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

                GalleryGroups pg = new GalleryGroups();
                pg.Id = Guid.NewGuid();
                pg.ImageUrl = new_filename;
                pg.Title = txtTitle.Text;
                pg.Priority = Convert.ToInt32(txtPri.Text);
                pg.IsDelete = false;
                db.GalleryGroups.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid Id = new Guid(ViewState["Id"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
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
                var n = (from u in db.GalleryGroups where u.Id == Id select u).FirstOrDefault();

                n.ImageUrl = ViewState["GImage"].ToString();
                n.Title = txtTitle.Text;
                n.Priority = Convert.ToInt32(txtPri.Text);
                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            Guid Id = new Guid(ViewState["Id"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.GalleryGroups where u.Id == Id select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;

                var m = (from a in db.GalleryImages
                         where a.fk_GalleryId == Id && a.IsDelete == false
                         select a).ToList();

                foreach (var item in m)
                {
                    item.IsDelete = true;
                    item.DeleteDate = DateTime.Now;
                }

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