using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin.SuperAdmin
{
    public partial class CustomerGroupSetting : System.Web.UI.Page
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
                var n = (from u in db.CustomerGroups
                         where u.IsDelete == false                         
                         orderby u.CustomerGroupID
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
          
            txtEN_Title.Text = string.Empty;
           
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid CustomerGroupID = new Guid(e.CommandArgument.ToString());
            ViewState["CustomerGroupID"] = CustomerGroupID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(CustomerGroupID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.CustomerGroups where u.CustomerGroupID == CustomerGroupID select u).FirstOrDefault();
                            lblDelete.Text = n.CustomerGroupTitle;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid CustomerGroupID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CustomerGroups where u.CustomerGroupID == CustomerGroupID select u).FirstOrDefault();

                txtTitle.Text = n.CustomerGroupTitle;
                txtName.Text = n.CustomerGroupName;
                txtEN_Title.Text = n.En_CustomerGroupTitle;
               
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
                CustomerGroups pg = new CustomerGroups();

                pg.CustomerGroupID = Guid.NewGuid();
                pg.CustomerGroupTitle = txtTitle.Text;
                pg.En_CustomerGroupTitle = txtEN_Title.Text;
                pg.CustomerGroupName = txtName.Text;
               
                pg.IsDelete = false;
               
                db.CustomerGroups.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid CustomerGroupID = new Guid(ViewState["CustomerGroupID"].ToString());
          
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CustomerGroups where u.CustomerGroupID == CustomerGroupID select u).FirstOrDefault();

                n.CustomerGroupTitle = txtTitle.Text;
                n.En_CustomerGroupTitle = txtEN_Title.Text;
                n.CustomerGroupName = txtName.Text;
        

                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid CustomerGroupID = new Guid(ViewState["CustomerGroupID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CustomerGroups where u.CustomerGroupID == CustomerGroupID select u).FirstOrDefault();

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
                var n = (from u in db.CustomerGroups where u.CustomerGroupName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid CustomerGroupID = new Guid(ViewState["CustomerGroupID"].ToString());

                    var m = (from u in db.CustomerGroups where u.CustomerGroupID == CustomerGroupID select u).FirstOrDefault();

                    if (m.CustomerGroupName == txtName.Text)
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