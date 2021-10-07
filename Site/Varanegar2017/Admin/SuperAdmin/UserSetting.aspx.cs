using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin.SuperAdmin
{
    public partial class UserSetting : System.Web.UI.Page
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
                var n = (from u in db.Users
                         where u.IsDelete == false
                         orderby u.RegisterDate descending
                         select u).ToList();
                grdTable.DataSource = n;
                grdTable.DataBind();

                if (n.Count == 0)
                    pnlEmptyForm.Visible = true;
                else
                    pnlEmptyForm.Visible = false;
            }
            mvSetting.SetActiveView(vwList);
        }

        public void FillDDLRoles()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var m = (from u in db.Roles
                         select u).ToList();
                ddlRoles.Items.Clear();
                ddlRoles.Items.Add(new ListItem("نقش کاربر ", "-1"));
                foreach (var i in m)
                    ddlRoles.Items.Add(new ListItem(i.RoleTitle, i.RoleID.ToString()));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ViewState["btn"] = "Insert";
            EmptyForm();
            FillDDLRoles();
            mvSetting.SetActiveView(vwEdit);
        }
        public void EmptyForm()
        {
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtPhone.Text = string.Empty;
       
            txtFirstName.Text = string.Empty;
         
            txtMobile.Text = string.Empty;
            ddlRoles.SelectedValue = "-1";

        }
        protected void btnRet_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int UserID =Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["UserID"] = UserID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        ViewState["btn"] = "Update";

                        FillViewEdit(UserID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.Users where u.UserID == UserID select u).FirstOrDefault();
                            lblDelete.Text = n.Email;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }


        public void FillViewEdit(int UserID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Users where u.UserID == UserID select u).FirstOrDefault();
               
                  txtpass.Text = n.Password;
                
                txtEmail.Text = n.Email;
                txtFirstName.Text = n.FirstName;
                
                txtPhone.Text = n.Phone;
                FillDDLRoles();
                ddlRoles.SelectedValue = n.fk_RoleID.ToString();
                txtFamily.Text = n.LastFamily;
                
                txtMobile.Text = n.Mobile;

                mvSetting.SetActiveView(vwEdit);

            }
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ViewState["btn"].ToString() == "Update")
                    Update();
                else if (ViewState["btn"].ToString() == "Insert")
                    Insert();

                LoadForm();
                pnlSuccess.Visible = true;
            }
        }
        public void Insert()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Users u = new Users();
               
                u.Email = txtEmail.Text;
                u.Phone = txtPhone.Text;
                u.RegisterDate = DateTime.Now;
                u.Password = txtpass.Text;
                u.fk_RoleID = Convert.ToInt32(ddlRoles.SelectedValue);
                u.RegisterIP = Request.UserHostAddress;
                u.FirstName = txtFirstName.Text;
                u.Mobile = txtMobile.Text;
                u.IsDelete = false;
                u.LastFamily = txtFamily.Text;
                db.Users.Add(u);
                db.SaveChanges();
            }
        }

      
 
        public void Update()
        {
            int UserID = Convert.ToInt32(ViewState["UserID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var u = (from n in db.Users where n.UserID == UserID select n).FirstOrDefault();
                 
                   u.Password = txtpass.Text;
                
                u.FirstName = txtFirstName.Text;
                u.Email = txtEmail.Text;
                u.Phone = txtPhone.Text;
 
                u.fk_RoleID = Convert.ToInt32(ddlRoles.SelectedValue);
              
                u.Mobile = txtMobile.Text;
                u.LastFamily = txtFamily.Text;

                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            int UserID = Convert.ToInt32(ViewState["UserID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Users where u.UserID == UserID select u).FirstOrDefault();

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


        protected void cvRole_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlRoles.SelectedIndex != 0;
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Users where u.Email == txtEmail.Text && u.IsDelete != true select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    int UserID = Convert.ToInt32(ViewState["UserID"].ToString());

                    var m = (from u in db.Users where u.UserID == UserID && u.IsDelete != true select u).FirstOrDefault();

                    if (m.Email == txtEmail.Text)
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