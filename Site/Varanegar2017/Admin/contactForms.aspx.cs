using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class contactForms : System.Web.UI.Page
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
                var n = (from u in db.ContactUsForm
                         join a in db.EmailRecieverRoles 
                         on u.fk_RecieverID equals a.EmailRecieverRoleID
                         where u.IsDelete == false
                         orderby u.CommentDate
                         select new
                         {
                             u.fk_RecieverID,
                             u.CommentDate,
                             u.contactid,
                             u.Email,
                             a.Title,
                             u.Mobile,
                             u.Name,
                           
                         }).ToList();

                grdTable.DataSource = n;
                grdTable.DataBind();
                datasourceCounter = n.Count();
            }

            CheckEmptyData(datasourceCounter);
            mvSetting.SetActiveView(vwList);
        }      
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        } 
     
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid contactid = new Guid(ViewState["contactid"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ContactUsForm where u.contactid == contactid select u).FirstOrDefault();

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
                Guid contactid =new Guid(e.CommandArgument.ToString());
                ViewState["contactid"] = contactid;
                ViewState["btn"] = "Update";

                FillViewEdit(contactid);
            }
            else if (e.CommandName == "DoDelete")
            {
                Guid contactid = new Guid(e.CommandArgument.ToString());
                ViewState["contactid"] = contactid;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.ContactUsForm where u.contactid == contactid select u).FirstOrDefault();
                    lblDelete.Text = n.Name;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(Guid contactid)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ContactUsForm where u.contactid == contactid select u).FirstOrDefault();

                var r = (from a in db.ContactUsFormRecievers
                         where a.RecieverID == n.fk_RecieverID && a.IsDelete == false
                         select a).FirstOrDefault();

                lblEmail.Text = n.Email;
                lblMessage.Text = n.CommentBody;
                lblMobile.Text = n.Mobile;
                lblName.Text = n.Name;
                lblReciever.Text = r.RecieverTitle;
                lblSubmitDate.Text = n.CommentDate.ToString();
               

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