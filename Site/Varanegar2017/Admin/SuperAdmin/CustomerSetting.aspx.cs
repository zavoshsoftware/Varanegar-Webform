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
    public partial class CustomerSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
                DropDownBind();
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
            if (Request.QueryString["ID"] == null)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Customers
                             join a in db.CustomerGroups
                             on u.fk_CustomerGroupID equals a.CustomerGroupID
                             where u.IsDelete == false                           
                             orderby u.submitDate descending
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 a.CustomerGroupTitle,
                                 u.ImgLogo
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
            }

            else
            {
                Guid ID = new Guid(Request.QueryString["ID"].ToString());
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Customers
                             join a in db.CustomerGroups
                             on u.fk_CustomerGroupID equals a.CustomerGroupID
                             where u.IsDelete == false && u.fk_CustomerGroupID == ID
                             orderby u.submitDate descending
                       
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 a.CustomerGroupTitle,
                                 u.ImgLogo
                             }).ToList();




                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();

                }
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
            txtName.Text = string.Empty;
            ddlProductGroup.SelectedValue = "-1";
            txtENTitle.Text = string.Empty;
            reDesc.Text = string.Empty;
            reEN_Desc.Text = string.Empty;
            chkInHome.Checked = false;
        }

        public void DropDownBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.CustomerGroups
                          where u.IsDelete == false
                          orderby u.CustomerGroupID
                          select u).ToList();
                ddlProductGroup.Items.Clear();
                ddlProductGroup.Items.Add(new ListItem("گروه مشتری ", "-1"));
                foreach (var t in pg)
                    ddlProductGroup.Items.Add(new ListItem(t.CustomerGroupTitle, t.CustomerGroupID.ToString()));
            }
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

                string new_filepath = Server.MapPath("~/Uploads/Customers/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
           
            Guid CustomersID = new Guid(ViewState["CustomersID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();

                p.CustomerTitle = txtTitle.Text;
                p.En_CustomerTitle = txtENTitle.Text;
                p.CustomerName = txtName.Text;
                p.En_SuccessHistory = reEN_Desc.Text;
                p.SuccessHistory = reDesc.Text;
                p.fk_CustomerGroupID = new Guid(ddlProductGroup.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.IsInHome = chkInHome.Checked;
                p.ImgLogo = ViewState["GImage"].ToString();
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

                string new_filepath = Server.MapPath("~/Uploads/Customers/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
           
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Customers p = new Customers();

                p.CustomersID = Guid.NewGuid();
                p.CustomerTitle = txtTitle.Text;
                p.En_CustomerTitle = txtENTitle.Text;
                p.CustomerName = txtName.Text;
                p.En_SuccessHistory = reEN_Desc.Text;
                p.SuccessHistory = reDesc.Text;
                p.fk_CustomerGroupID = new Guid(ddlProductGroup.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.IsInHome = chkInHome.Checked;
                p.ImgLogo = new_filename;
                p.IsDelete = false;
                p.submitDate = DateTime.Now;

                db.Customers.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
                Response.Redirect("Default.aspx");
            else
            {
                Response.Redirect("CustomerGroupSetting.aspx");
            }

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid CustomersID = new Guid(ViewState["CustomersID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();

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
                Guid CustomersID = new Guid(e.CommandArgument.ToString());
                ViewState["CustomersID"] = CustomersID;
                ViewState["btn"] = "Update";

                DropDownBind();
                FillViewEdit(CustomersID);
            }
            else if (e.CommandName == "DoDelete")
            {
                Guid CustomersID = new Guid(e.CommandArgument.ToString());
                ViewState["CustomersID"] = CustomersID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();
                    lblDelete.Text = n.CustomerTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(Guid CustomersID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();
                txtTitle.Text = n.CustomerTitle;
                txtName.Text = n.CustomerName;
                ddlProductGroup.SelectedValue = n.fk_CustomerGroupID.ToString();
                txtENTitle.Text = n.En_CustomerTitle;
                reEN_Desc.Text = n.En_SuccessHistory;
                reDesc.Text = n.SuccessHistory;
                chkInHome.Checked =Convert.ToBoolean(n.IsInHome);
                ViewState["GImage"] = n.ImgLogo;
                imgEditImages.ImageUrl = "~/Uploads/Customers/" + n.ImgLogo;

                mvSetting.SetActiveView(vwEdit);
            }
        }

        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Customers where u.CustomerName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid CustomersID = new Guid(ViewState["CustomersID"].ToString());

                    var m = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();

                    if (m.CustomerName == txtName.Text)
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
            args.IsValid = ddlProductGroup.SelectedIndex != 0;
        } 

        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }
    }
}