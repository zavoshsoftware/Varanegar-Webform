using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin.SuperAdmin
{
    public partial class BlogGroupsSetting : System.Web.UI.Page
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
                var n = (from u in db.BlogGroups
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
            txtPri.Text = string.Empty;
            txtEN_Title.Text = string.Empty;

            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid BlogGroupID = new Guid(e.CommandArgument.ToString());
            ViewState["BlogGroupID"] = BlogGroupID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(BlogGroupID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.BlogGroups where u.BlogGroupID == BlogGroupID select u).FirstOrDefault();
                            lblDelete.Text = n.BlogGroupTitle;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid BlogGroupID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.BlogGroups where u.BlogGroupID == BlogGroupID select u).FirstOrDefault();

                txtTitle.Text = n.BlogGroupTitle;
                txtName.Text = n.BlogGroupName;
                txtEN_Title.Text = n.En_BlogGroupTitle;
                txtPri.Text = n.Priority.ToString();

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
                BlogGroups pg = new BlogGroups();

                pg.BlogGroupID = Guid.NewGuid();
                pg.BlogGroupTitle = txtTitle.Text;
                pg.En_BlogGroupTitle = txtEN_Title.Text;
                pg.BlogGroupName = txtName.Text;
                pg.Priority = Convert.ToInt32(txtPri.Text);

                pg.IsDelete = false;

                db.BlogGroups.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid BlogGroupID = new Guid(ViewState["BlogGroupID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.BlogGroups where u.BlogGroupID == BlogGroupID select u).FirstOrDefault();

                n.BlogGroupTitle = txtTitle.Text;
                n.En_BlogGroupTitle = txtEN_Title.Text;
                n.BlogGroupName = txtName.Text;
                n.Priority = Convert.ToInt32(txtPri.Text);


                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid BlogGroupID = new Guid(ViewState["BlogGroupID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.BlogGroups where u.BlogGroupID == BlogGroupID select u).FirstOrDefault();

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
                var n = (from u in db.BlogGroups where u.BlogGroupName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid BlogGroupID = new Guid(ViewState["BlogGroupID"].ToString());

                    var m = (from u in db.BlogGroups where u.BlogGroupID == BlogGroupID select u).FirstOrDefault();

                    if (m.BlogGroupName == txtName.Text)
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