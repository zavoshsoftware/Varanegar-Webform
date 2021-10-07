using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class EmailRoles : System.Web.UI.Page
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
                if (Request.QueryString["id"] != null)
                {
                    int groupid = Convert.ToInt32(Request.QueryString["id"]);

                    var n = (from u in db.EmailRecieverRoles
                             where u.IsDelete == false && u.groupdid == groupid
                             select u).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();

                    CheckEmptyData(n.Count());
                }
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

            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int EmailRecieverRoleID = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["EmailRecieverRoleID"] = EmailRecieverRoleID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(EmailRecieverRoleID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.EmailRecieverRoles where u.EmailRecieverRoleID == EmailRecieverRoleID select u).FirstOrDefault();
                            lblDelete.Text = n.Title;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(int EmailRecieverRoleID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.EmailRecieverRoles where u.EmailRecieverRoleID == EmailRecieverRoleID select u).FirstOrDefault();

                txtTitle.Text = n.Title;


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
            if (Request.QueryString["id"] != null)
            {
                int groupid = Convert.ToInt32(Request.QueryString["id"]);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    EmailRecieverRoles pg = new EmailRecieverRoles();


                    pg.Title = txtTitle.Text;
                    pg.IsDelete = false;
                    pg.groupdid = groupid;
                    db.EmailRecieverRoles.Add(pg);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateForm()
        {
            int EmailRecieverRoleID = Convert.ToInt32(ViewState["EmailRecieverRoleID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.EmailRecieverRoles where u.EmailRecieverRoleID == EmailRecieverRoleID select u).FirstOrDefault();

                n.Title = txtTitle.Text;

                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            int EmailRecieverRoleID = Convert.ToInt32(ViewState["EmailRecieverRoleID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.EmailRecieverRoles where u.EmailRecieverRoleID == EmailRecieverRoleID select u).FirstOrDefault();

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
    }
}