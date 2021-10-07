using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar.Admin
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
                             orderby u.Priority
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 a.CustomerGroupTitle,
                                 u.ImgLogo,
                                 u.Priority,
                                 u.IsInHome
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
                             orderby u.Priority
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 a.CustomerGroupTitle,
                                 u.ImgLogo,
                                 u.Priority,
                                 u.IsInHome
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();

                }
            }

            if (Request.QueryString["type"] != null)
            {
                if (Request.QueryString["type"] == "Recycle")
                {
                    using (VaranegarEntities db = new VaranegarEntities())
                    {
                        var n = (from u in db.Customers
                                 join a in db.CustomerGroups
                                 on u.fk_CustomerGroupID equals a.CustomerGroupID
                                 where u.IsDelete == true
                                 orderby u.Priority
                                 select
                                 new
                                 {
                                     u.CustomerTitle,
                                     u.CustomerName,
                                     u.CustomersID,
                                     a.CustomerGroupTitle,
                                     u.ImgLogo,
                                     u.Priority,
                                     u.IsInHome
                                 }).ToList();

                        grdTable.DataSource = n;
                        grdTable.DataBind();
                        datasourceCounter = n.Count();
                    }
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
            txtBranchNumber.Text = string.Empty;
            chkInHome.Checked = false;
            txtPri.Text = String.Empty;
            txtName.Enabled = true;
            ddlStartYear.SelectedValue = "0";
            ddlStartMonth.SelectedValue = "0";
            ddlFinishMonth.SelectedValue = "0";
            ddlFinishYear.SelectedValue = "0";
            imgEditImages.ImageUrl = "";

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
          //  string thumbnailUrl = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Customers/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
              //  thumbnailUrl = Utils.CreateThumbnail(new_filepath, "~/Uploads/Customers/Thumbs/", 115, 115);

                ViewState["GImage"] = new_filename;
            //    ViewState["GImage_thubm"] = thumbnailUrl;

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
                p.Priority = Convert.ToInt32(txtPri.Text);
             //   p.ImgLogo_Thumb = ViewState["GImage_thubm"].ToString();
                p.StartMonth = Convert.ToInt32(ddlStartMonth.SelectedValue);
                p.StartYear = Convert.ToInt32(ddlStartYear.SelectedValue);

                p.FinishMonth = Convert.ToInt32(ddlFinishMonth.SelectedValue);
                p.FinishYear = Convert.ToInt32(ddlFinishYear.SelectedValue);
                p.BranchNumber = Convert.ToInt32(txtBranchNumber.Text);

                db.SaveChanges();
            }
        }
        public void InsertForm()
        {
            string new_filename = string.Empty;
        //    string thumbnailUrl = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Customers/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
          //      thumbnailUrl = Utils.CreateThumbnail(new_filepath, "~/Uploads/Customers/Thumbs/",115,115);
          //      ViewState["GImage_thubm"] = thumbnailUrl;
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
              //  p.ImgLogo_Thumb = thumbnailUrl;
                p.IsDelete = false;
                p.submitDate = DateTime.Now;
                p.Priority = Convert.ToInt32(txtPri.Text);
                p.StartMonth = Convert.ToInt32(ddlStartMonth.SelectedValue);
                p.StartYear = Convert.ToInt32(ddlStartYear.SelectedValue);

                p.FinishMonth = Convert.ToInt32(ddlFinishMonth.SelectedValue);
                p.FinishYear = Convert.ToInt32(ddlFinishYear.SelectedValue);
                p.BranchNumber = Convert.ToInt32(txtBranchNumber.Text);

                db.Customers.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["ID"] == null && Request.QueryString["type"] == null)
                Response.Redirect("Default.aspx");

            else if (Request.QueryString["ID"] != null)
            {
                Response.Redirect("CustomerGroupSetting.aspx");
            }

            else if (Request.QueryString["type"] != null)
            {
                Response.Redirect("~/Admin/CustomerSetting.aspx");
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
                //txtName.Enabled = false;
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
            else if (e.CommandName == "recycle")
            {
                Guid CustomersID = new Guid(e.CommandArgument.ToString());

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Customers where u.CustomersID == CustomersID select u).FirstOrDefault();

                    n.IsDelete = false;
                    n.DeleteDate = DateTime.Now;
                    db.SaveChanges();
                    LoadForm();
                }
            }
            else if (e.CommandName == "Province")
            {
                LoadProvinces();
                Guid CustomersID = new Guid(e.CommandArgument.ToString());
                ViewState["CustomersID"] = CustomersID;
                mvSetting.SetActiveView(vwProvince);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Rel_Customer_Province where u.fk_CustomerID == CustomersID select u).ToList();
                    foreach (ListItem item in cblProvince.Items)
                    {
                        item.Selected = false;
                    }

                    foreach (var rel in n)
                    {
                        foreach (ListItem tt in cblProvince.Items)
                        {
                            int proid = Convert.ToInt32(tt.Value);
                            if (rel.fk_ProvinceID == proid)
                            {
                                tt.Selected = true;
                                break;
                            }
                        }
                    }
                    mvSetting.SetActiveView(vwProvince);
                }
            }
        }

        public void LoadProvinces()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Province select u).ToList();

                cblProvince.Items.Clear();
                foreach (var i in n)
                    cblProvince.Items.Add(new ListItem(i.ProvinceName, i.ProvinceID.ToString()));
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
                chkInHome.Checked = Convert.ToBoolean(n.IsInHome);

            //    ViewState["GImage_thubm"] = n.ImgLogo_Thumb;

                ViewState["GImage"] = n.ImgLogo;
                imgEditImages.ImageUrl = "~/Uploads/Customers/" + n.ImgLogo;
                txtBranchNumber.Text = n.BranchNumber.ToString();
                txtPri.Text = n.Priority.ToString();

                if (n.StartMonth != null)
                    ddlStartMonth.SelectedValue = n.StartMonth.ToString();
                if (n.StartYear != null)
                    ddlStartYear.SelectedValue = n.StartYear.ToString();

                if (n.FinishMonth != null)
                    ddlFinishMonth.SelectedValue = n.FinishMonth.ToString();
                if (n.FinishYear != null)
                    ddlFinishYear.SelectedValue = n.FinishYear.ToString();

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

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                if (txtSearch.Text != null)
                {
                    int datasourceCounter = 0;

                    var n = (from u in db.Customers
                             join a in db.CustomerGroups
                             on u.fk_CustomerGroupID equals a.CustomerGroupID
                             where u.CustomerTitle.Contains(txtSearch.Text)&& u.IsDelete == false
                             orderby u.Priority
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 a.CustomerGroupTitle,
                                 u.ImgLogo,
                                 u.Priority,
                                 u.IsInHome
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                    CheckEmptyData(datasourceCounter);
                }
            }
        }

        protected void btnShowAll_OnClick(object sender, EventArgs e)
        {
            LoadForm();
        }

        protected void grdTable_OnDataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow r in grdTable.Rows)
            {
                HiddenField hfValue = (HiddenField)r.FindControl("hfValue");
                LinkButton lbDelete = (LinkButton)r.FindControl("lbDelete");

                LinkButton lbRecycle = (LinkButton)r.FindControl("lbRecycle");

                Guid ID = new Guid(hfValue.Value);

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Customers
                             where a.CustomersID == ID
                             select a).FirstOrDefault();

                    if (n.IsDelete == false)
                    {
                        lbDelete.Visible = true;
                        lbRecycle.Visible = false;
                    }
                    else
                    {
                        lbDelete.Visible = false;
                        lbRecycle.Visible = true;
                    }
                }
            }
        }

        protected void btnSubmitProvince_OnClick(object sender, EventArgs e)
        {
            Guid cusID = new Guid(ViewState["CustomersID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Rel_Customer_Province
                         where a.fk_CustomerID == cusID
                         select a).ToList();

                foreach (var item in n)
                {
                    db.Rel_Customer_Province.Remove(item);
                }
                foreach (ListItem chk in cblProvince.Items)
                {
                    if (chk.Selected)
                    {
                        int ProvinceID = Convert.ToInt32(chk.Value);

                        Rel_Customer_Province RelEnter = new Rel_Customer_Province();

                        RelEnter.fk_CustomerID = cusID;

                        RelEnter.fk_ProvinceID = ProvinceID;

                        db.Rel_Customer_Province.Add(RelEnter);
                        db.SaveChanges();
                    }
                }
            }
            mvSetting.SetActiveView(vwList);
            
        }

        protected void btnCanceleProvince_OnClick(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }
    }
}