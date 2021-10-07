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
    public partial class SolutionSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
              //  DropDownBind();

            }
        }
        //public void DropDownBind()
        //{
        //    using (VaranegarEntities db = new VaranegarEntities())
        //    {
        //        var pg = (from u in db.SolutionGroups
        //                  where u.IsDelete == false
        //                  orderby u.Priority
        //                  select u).ToList();
        //        ddlSolutionGroup.Items.Clear();
        //        ddlSolutionGroup.Items.Add(new ListItem("گروه راهکار ", "-1"));
        //        foreach (var t in pg)
        //            ddlSolutionGroup.Items.Add(new ListItem(t.SolutionGroupTitle, t.SolutionGroupID.ToString()));
        //    }
        //}
        public void CheckEmptyData(int DataCounter)
        {
            if (DataCounter == 0)
                pnlEmptyForm.Visible = true;
            else
                pnlEmptyForm.Visible = false;
        }
        public void LoadForm()
        {

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Solutions
                         where u.IsDelete == false
                         orderby u.Priority
                         select u).ToList();

                grdTable.DataSource = n;
                grdTable.DataBind();
                CheckEmptyData(n.Count());
                mvSetting.SetActiveView(vwList);
            }
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
            txtName.Text = string.Empty;
            txtImageTxt.Text = string.Empty;
            txtENTitle.Text = string.Empty;
            reDesc.Text = string.Empty;
            reEN_Desc.Text = string.Empty;
            resupp.Text = string.Empty;
            txtPri.Text = string.Empty;
            txtImageTxtEn.Text = string.Empty;
            imgEditImages.ImageUrl = "";
           // ddlSolutionGroup.SelectedValue = "-1";
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

                string new_filepath = Server.MapPath("~/Uploads/Solution/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            Guid SolutionID = new Guid(ViewState["SolutionID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Solutions where u.SolutionID == SolutionID select u).FirstOrDefault();

                p.SolutionTitle = txtTitle.Text;
                p.En_SolutionTitle = txtENTitle.Text;
                p.SolutionName = txtName.Text;
                p.ImgBannerFile = ViewState["GImage"].ToString();
                p.BannerText = txtImageTxt.Text;
                p.En_BannerText = txtImageTxtEn.Text;
           //     p.fk_SolutionGroupID = new Guid(ddlSolutionGroup.SelectedValue);
                p.En_ProblemDesc = reEN_Desc.Text;
                p.ProblemDesc = reDesc.Text;
                p.Priority = Convert.ToInt32(txtPri.Text);
                p.ProductInSupply = resupp.Text;

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

                string new_filepath = Server.MapPath("~/Uploads/Solution/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                Solutions p = new Solutions();

                p.SolutionID = Guid.NewGuid();
                p.SolutionTitle = txtTitle.Text;
                p.En_SolutionTitle = txtENTitle.Text;
                p.SolutionName = txtName.Text;
                p.BannerText = txtImageTxt.Text;
                p.En_BannerText = txtImageTxtEn.Text;
                p.En_ProblemDesc = reEN_Desc.Text;
                p.ProblemDesc = reDesc.Text;
                p.ImgBannerFile = new_filename;
                p.IsDelete = false;
           //     p.fk_SolutionGroupID = new Guid(ddlSolutionGroup.SelectedValue);
                p.Priority = Convert.ToInt32(txtPri.Text);
                p.ProductInSupply = resupp.Text;

                db.Solutions.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid SolutionID = new Guid(ViewState["SolutionID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Solutions where u.SolutionID == SolutionID select u).FirstOrDefault();

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
                Guid SolutionID = new Guid(e.CommandArgument.ToString());
                ViewState["SolutionID"] = SolutionID;
                ViewState["btn"] = "Update";
           //     DropDownBind();
                FillViewEdit(SolutionID);

            }
            else if (e.CommandName == "DoDelete")
            {
                Guid SolutionID = new Guid(e.CommandArgument.ToString());
                ViewState["SolutionID"] = SolutionID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Solutions where u.SolutionID == SolutionID select u).FirstOrDefault();
                    lblDelete.Text = n.SolutionTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(Guid SolutionID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Solutions where u.SolutionID == SolutionID select u).FirstOrDefault();


                txtTitle.Text = n.SolutionTitle;
                txtENTitle.Text = n.En_SolutionTitle;
                txtName.Text = n.SolutionName;
                ViewState["GImage"] = n.ImgBannerFile;
                txtImageTxt.Text = n.BannerText;
                txtImageTxtEn.Text = n.En_BannerText;
                reEN_Desc.Text = n.En_ProblemDesc;
                reDesc.Text = n.ProblemDesc;
                imgEditImages.ImageUrl = "~/Uploads/Solution/" + n.ImgBannerFile;
            //    if (n.fk_SolutionGroupID != null)
            //        ddlSolutionGroup.SelectedValue = n.fk_SolutionGroupID.ToString();
                txtPri.Text = n.Priority.ToString();
                resupp.Text = n.ProductInSupply;
                txtName.Enabled = false;
                mvSetting.SetActiveView(vwEdit);
            }
        }

        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Solutions where u.SolutionName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid SolutionID = new Guid(ViewState["SolutionID"].ToString());

                    var m = (from u in db.Solutions where u.SolutionID == SolutionID select u).FirstOrDefault();

                    if (m.SolutionName == txtName.Text)
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
        //protected void cvProGroup_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = ddlSolutionGroup.SelectedIndex != 0;
        //}

        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }
    }
}