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
    public partial class EmailSetting : System.Web.UI.Page
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
                var pg = (from u in db.EmailRecieverRoles
                          where u.IsDelete == false
                          select u).ToList();

                ddlGroup.Items.Clear();
                ddlGroup.Items.Add(new ListItem("نقش دریافت کننده ", "-1"));
                foreach (var t in pg)
                    ddlGroup.Items.Add(new ListItem(t.Title, t.EmailRecieverRoleID.ToString()));
            }
        }
        public void LoadForm()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                if (Request.QueryString["id"] == null)
                {
                    var n = (from u in db.Emails
                        join a in db.EmailRecieverRoles
                            on u.fk_RecieverRoleID equals a.EmailRecieverRoleID
                        where u.IsDelete == false
                        select new
                        {
                            u.EmailTitle,
                            u.EmailId,
                            a.Title
                        }).ToList();
                    grdTable.DataSource = n;
                    grdTable.DataBind();

                    CheckEmptyData(n.Count());
                }
                else
                {
                    int groupid = Convert.ToInt32(Request.QueryString["id"]);

                    var n = (from u in db.Emails
                             join a in db.EmailRecieverRoles
                                 on u.fk_RecieverRoleID equals a.EmailRecieverRoleID
                             where u.IsDelete == false&&u.fk_RecieverRoleID==groupid
                             select new
                             {
                                 u.EmailTitle,
                                 u.EmailId,
                                 a.Title
                             }).ToList();
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
            if (Request.QueryString["id"] == null)
            {
                ddlGroup.SelectedValue = "-1";

            }
            else
            {
                int groupid = Convert.ToInt32(Request.QueryString["id"]);
                ddlGroup.SelectedValue = groupid.ToString();

            }
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    var n = (from u in db.EmailRecieverRoles where u.EmailRecieverRoleID == id select u).FirstOrDefault();

                    Response.Redirect("EmailRoles.aspx?id=" + n.groupdid);
                }
            }
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int EmailId =Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["EmailId"] = EmailId;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(EmailId);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.Emails where u.EmailId == EmailId select u).FirstOrDefault();

                            lblDelete.Text = n.EmailTitle;
                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(int EmailId)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Emails where u.EmailId == EmailId select u).FirstOrDefault();

                txtTitle.Text = n.EmailTitle;
                ddlGroup.SelectedValue = n.fk_RecieverRoleID.ToString();
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
                Emails pg = new Emails();

                pg.EmailTitle = txtTitle.Text;
                pg.IsDelete = false;
                pg.fk_RecieverRoleID = Convert.ToInt32(ddlGroup.SelectedValue);

                db.Emails.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            int EmailId = Convert.ToInt32(ViewState["EmailId"].ToString());
           
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Emails where u.EmailId == EmailId select u).FirstOrDefault();

                n.EmailTitle = txtTitle.Text;
                n.fk_RecieverRoleID = Convert.ToInt32(ddlGroup.SelectedValue);

                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            int EmailId = Convert.ToInt32(ViewState["EmailId"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Emails where u.EmailId == EmailId select u).FirstOrDefault();

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

     
        protected void cvProGroup_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlGroup.SelectedIndex != 0;
        }
    }
}