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
    public partial class BlogSetting : System.Web.UI.Page
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
                var pg = (from u in db.BlogGroups
                          where u.IsDelete == false
                          orderby u.Priority
                          select u).ToList();
                ddlGroup.Items.Clear();
                ddlGroup.Items.Add(new ListItem("گروه وبلاگ ", "-1"));
                foreach (var t in pg)
                    ddlGroup.Items.Add(new ListItem(t.BlogGroupTitle, t.BlogGroupID.ToString()));
            }
        }
        public void LoadForm()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Blogs
                         where u.IsDelete == false
                         orderby u.SubmitDate descending 
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
            reDesc2.Text = string.Empty;
            txtEN_Title.Text = string.Empty;
            reEN_Desc2.Text = null;
            txtSummery.Text = string.Empty;
            txtSummery_En.Text = string.Empty;
            ddlGroup.SelectedValue = "-1";
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid BlogID = new Guid(e.CommandArgument.ToString());
            ViewState["BlogID"] = BlogID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(BlogID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.Blogs where u.BlogID == BlogID select u).FirstOrDefault();

                            lblDelete.Text = n.BlogTitle;
                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid BlogID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Blogs where u.BlogID == BlogID select u).FirstOrDefault();

                txtTitle.Text = n.BlogTitle;
                txtName.Text = n.BlogName;
                txtEN_Title.Text = n.En_BlogTitle;
                reDesc2.Text = n.BlogBody;
                reEN_Desc2.Text = n.En_BlogBody;
                txtPrio.Text = n.Priority.ToString();
                txtSummery.Text = n.summeryText;
                txtSummery_En.Text = n.En_summeryText;
                ViewState["GImage"] = n.BlogImage;
                imgEditImages.ImageUrl = "~/Uploads/Blog/" + n.BlogImage;
                ddlGroup.SelectedValue = n.fk_BlogGroupID.ToString();
                JQDatePicker1.Date = n.SubmitDate;
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

                string new_filepath = Server.MapPath("~/Uploads/Blog/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                Blogs pg = new Blogs();

                pg.BlogID = Guid.NewGuid();
                pg.BlogTitle = txtTitle.Text;
                pg.En_BlogTitle = txtEN_Title.Text;
                pg.BlogName = txtName.Text;
                pg.BlogBody = reDesc2.Text;
                pg.En_BlogBody = reEN_Desc2.Text;
                pg.IsDelete = false;
                pg.Priority = Convert.ToInt32(txtPrio.Text);
                pg.SubmitDate = DateTime.Now;
                pg.Visit = 0;
                pg.BlogImage = new_filename;
                pg.summeryText = txtSummery.Text;
                pg.En_summeryText = txtSummery_En.Text;
                pg.fk_BlogGroupID = new Guid(ddlGroup.SelectedValue);
                db.Blogs.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid BlogID = new Guid(ViewState["BlogID"].ToString());
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Blog/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Blogs where u.BlogID == BlogID select u).FirstOrDefault();

                n.BlogTitle = txtTitle.Text;
                n.En_BlogTitle = txtEN_Title.Text;
                n.BlogName = txtName.Text;

                n.BlogBody = reDesc2.Text;
                n.En_BlogBody = reEN_Desc2.Text;
                n.Priority = Convert.ToInt32(txtPrio.Text);
                n.LastUpdateDate = DateTime.Now;
                n.BlogImage = ViewState["GImage"].ToString();
                n.fk_BlogGroupID = new Guid(ddlGroup.SelectedValue);

                n.summeryText = txtSummery.Text;
                n.En_summeryText = txtSummery_En.Text;
                n.SubmitDate = JQDatePicker1.Date;
                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid BlogID = new Guid(ViewState["BlogID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Blogs where u.BlogID == BlogID select u).FirstOrDefault();

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
                var n = (from u in db.Blogs where u.BlogName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid BlogID = new Guid(ViewState["BlogID"].ToString());

                    var m = (from u in db.Blogs where u.BlogID == BlogID select u).FirstOrDefault();

                    if (m.BlogName == txtName.Text)
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
        protected void cvProGroup_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlGroup.SelectedIndex != 0;
        }
    }
}