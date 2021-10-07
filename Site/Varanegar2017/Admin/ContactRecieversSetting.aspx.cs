using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class ContactRecieversSetting : System.Web.UI.Page
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
                    var n = (from u in db.ContactUsFormRecievers
                                 where u.IsDelete==false
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
            txtEmail.Text = string.Empty;
            txtPrio.Text = string.Empty;
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
            int RecieverID =Convert.ToInt32(ViewState["RecieverID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.ContactUsFormRecievers where u.RecieverID == RecieverID select u).FirstOrDefault();

                p.RecieverTitle = txtTitle.Text;
                p.RecieverEmail = txtEmail.Text;
                p.Priority = Convert.ToInt32(txtPrio.Text);
               
                db.SaveChanges();
            }
        }
        public void InsertForm()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                ContactUsFormRecievers p = new ContactUsFormRecievers();

                p.RecieverTitle = txtTitle.Text;
                p.RecieverEmail = txtEmail.Text;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.IsDelete = false;
                db.ContactUsFormRecievers.Add(p);
                db.SaveChanges();

                EmailRecieverRoles aa = new EmailRecieverRoles();
                aa.Title = "تماس با ما - " + txtTitle.Text;
                aa.IsDelete = false;
                db.EmailRecieverRoles.Add(aa);

                Emails aaa =new Emails();
                aaa.EmailTitle = txtEmail.Text;
                aaa.fk_RecieverRoleID = aa.EmailRecieverRoleID;
                aaa.IsDelete = false;



            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
                Response.Redirect("Default.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int RecieverID =Convert.ToInt32(ViewState["RecieverID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ContactUsFormRecievers where u.RecieverID == RecieverID select u).FirstOrDefault();

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
                int RecieverID =Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["RecieverID"] = RecieverID;
                ViewState["btn"] = "Update";
                 
                FillViewEdit(RecieverID);
            }
            else if (e.CommandName == "DoDelete")
            {
                int RecieverID = Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["RecieverID"] = RecieverID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ContactUsFormRecievers where u.RecieverID == RecieverID select u).FirstOrDefault();
                    lblDelete.Text = n.RecieverTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(int RecieverID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ContactUsFormRecievers where u.RecieverID == RecieverID select u).FirstOrDefault();
                
                txtTitle.Text = n.RecieverTitle;
                txtEmail.Text = n.RecieverEmail;
                txtPrio.Text = n.Priority.ToString();
                mvSetting.SetActiveView(vwEdit);
            }
        }
        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }
    }
}