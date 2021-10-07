using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.IO;
using Varanegar2017.Models;

namespace MashadCarpet.Admin.SuperAdmin
{
    public partial class ProductSetting : System.Web.UI.Page
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
                    var n = (from u in db.Products
                             join a in db.ProductGroups
                             on u.fk_ProductGroupID equals a.ProductGroupID
                             where u.IsDelete == false
                             orderby u.Priority
                             select
                             new
                             {
                                 u.ProductTitle,
                                 u.ProductName,
                                 u.ProductID,
                                 a.ProductGroupTitle,
                                 u.En_ProductTitle
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
                    var n = (from u in db.Products
                             join a in db.ProductGroups
                             on u.fk_ProductGroupID equals a.ProductGroupID
                             where u.IsDelete == false&&u.fk_ProductGroupID==ID
                             orderby u.Priority
                             select
                             new
                             {
                                 u.ProductTitle,
                                 u.ProductName,
                                 u.ProductID,
                                 a.ProductGroupTitle,
                                 u.En_ProductTitle
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
            DropDownBind();
        }
        public void ResetForm()
        {
            txtTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            ddlProductGroup.SelectedValue = "-1";
            txtENTitle.Text = string.Empty;
            reDesc.Text = string.Empty;
            reEN_Desc.Text = string.Empty;
            txtPrio.Text = string.Empty;
            txtSummery.Text = string.Empty;
            txtSummery_En.Text = string.Empty;
            imgEditImages.Visible = false; imgEditImages.ImageUrl = "";

        }

        public void DropDownBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.ProductGroups
                          where u.IsDelete == false && u.fk_ProductGroupID == null
                          orderby u.ProductGroupID
                          select u).ToList();
                ddlProductGroup.Items.Clear();
                ddlProductGroup.Items.Add(new ListItem("گروه محصول ", "-1"));
                foreach (var t in pg)
                    ddlProductGroup.Items.Add(new ListItem(t.ProductGroupTitle, t.ProductGroupID.ToString()));
                if (Request.QueryString["ID"] != null)
                {
                    string ID = (Request.QueryString["ID"].ToString());

                    ddlProductGroup.SelectedValue = ID;
                }
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

                string new_filepath = Server.MapPath("~/Uploads/Product/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
         
            Guid ProductID = new Guid(ViewState["ProductID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Products where u.ProductID == ProductID select u).FirstOrDefault();

                p.ProductTitle = txtTitle.Text;
                p.En_ProductTitle = txtENTitle.Text;
                p.ProductName = txtName.Text.ToLower();
                p.En_ProductDesc = reEN_Desc.Text;
                p.ProductDesc = reDesc.Text;
                p.fk_ProductGroupID = new Guid(ddlProductGroup.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.ProductSumery = txtSummery.Text;
                p.En_ProductSumery = txtSummery_En.Text;
                p.ProductImage = ViewState["GImage"].ToString();
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

                string new_filepath = Server.MapPath("~/Uploads/Product/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Products p = new Products();

                p.ProductID = Guid.NewGuid();
                p.ProductTitle = txtTitle.Text;
                p.En_ProductTitle = txtENTitle.Text;
                p.ProductName = txtName.Text.ToLower();
                p.En_ProductDesc = reEN_Desc.Text;
                p.ProductDesc = reDesc.Text;
                p.fk_ProductGroupID = new Guid(ddlProductGroup.SelectedValue);
                p.LastUpdateDate = DateTime.Now;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.IsDelete = false;
                p.submitDate = DateTime.Now;
                p.ProductSumery = txtSummery.Text;
                p.En_ProductSumery = txtSummery_En.Text;
                p.ProductImage = new_filename;

                db.Products.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
                Response.Redirect("Default.aspx");
            else
            {
                Response.Redirect("ProductGroupSetting.aspx");
            }

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid ProductID = new Guid(ViewState["ProductID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Products where u.ProductID == ProductID select u).FirstOrDefault();

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
                Guid ProductID = new Guid(e.CommandArgument.ToString());
                ViewState["ProductID"] = ProductID;
                ViewState["btn"] = "Update";

               
                FillViewEdit(ProductID);
            }
            else if (e.CommandName == "DoDelete")
            {
                Guid ProductID = new Guid(e.CommandArgument.ToString());
                ViewState["ProductID"] = ProductID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Products where u.ProductID == ProductID select u).FirstOrDefault();
                    lblDelete.Text = n.ProductTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(Guid ProductID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Products where u.ProductID == ProductID select u).FirstOrDefault();
                txtTitle.Text = n.ProductTitle;
                txtName.Text = n.ProductName;
                ddlProductGroup.SelectedValue = n.fk_ProductGroupID.ToString();
                txtENTitle.Text = n.En_ProductTitle;
                reEN_Desc.Text = n.En_ProductDesc;
                reDesc.Text = n.ProductDesc;
                txtPrio.Text = n.Priority.ToString();
              txtSummery.Text=  n.ProductSumery ;
              txtSummery_En.Text = n.En_ProductSumery;
              ViewState["GImage"] = n.ProductImage;
              imgEditImages.ImageUrl = "~/Uploads/Product/" + n.ProductImage;
                mvSetting.SetActiveView(vwEdit);
            }
        }

        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Products where u.ProductName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid ProductID = new Guid(ViewState["ProductID"].ToString());

                    var m = (from u in db.Products where u.ProductID == ProductID select u).FirstOrDefault();

                    if (m.ProductName == txtName.Text)
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