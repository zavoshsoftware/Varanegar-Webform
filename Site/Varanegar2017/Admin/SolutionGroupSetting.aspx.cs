using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class SolutionGroupSetting : System.Web.UI.Page
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
                var n = (from u in db.SolutionGroups
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
            Guid SolutionGroupID = new Guid(e.CommandArgument.ToString());
            ViewState["SolutionGroupID"] = SolutionGroupID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(SolutionGroupID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.SolutionGroups where u.SolutionGroupID == SolutionGroupID select u).FirstOrDefault();
                            lblDelete.Text = n.SolutionGroupTitle;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid SolutionGroupID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.SolutionGroups where u.SolutionGroupID == SolutionGroupID select u).FirstOrDefault();

                txtTitle.Text = n.SolutionGroupTitle;
                txtName.Text = n.SolutionGroupName;
                txtEN_Title.Text = n.En_SolutionGroupTitle;
                txtPri.Text = n.Priority.ToString() ;
                txtName.Enabled = false;
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
                SolutionGroups pg = new SolutionGroups();

                pg.SolutionGroupID = Guid.NewGuid();
                pg.SolutionGroupTitle = txtTitle.Text;
                pg.En_SolutionGroupTitle = txtEN_Title.Text;
                pg.SolutionGroupName = txtName.Text;
                pg.Priority = Convert.ToInt32(txtPri.Text);

                pg.IsDelete = false;

                db.SolutionGroups.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid SolutionGroupID = new Guid(ViewState["SolutionGroupID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.SolutionGroups where u.SolutionGroupID == SolutionGroupID select u).FirstOrDefault();

                n.SolutionGroupTitle = txtTitle.Text;
                n.En_SolutionGroupTitle = txtEN_Title.Text;
                n.SolutionGroupName = txtName.Text;
                n.Priority = Convert.ToInt32(txtPri.Text);


                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid SolutionGroupID = new Guid(ViewState["SolutionGroupID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.SolutionGroups where u.SolutionGroupID == SolutionGroupID select u).FirstOrDefault();

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
                var n = (from u in db.SolutionGroups where u.SolutionGroupName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid SolutionGroupID = new Guid(ViewState["SolutionGroupID"].ToString());

                    var m = (from u in db.SolutionGroups where u.SolutionGroupID == SolutionGroupID select u).FirstOrDefault();

                    if (m.SolutionGroupName == txtName.Text)
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