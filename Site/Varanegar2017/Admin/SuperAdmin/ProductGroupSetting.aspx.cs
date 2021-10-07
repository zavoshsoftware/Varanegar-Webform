 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace MashadCarpet.Admin.SuperAdmin
{
    public partial class mainProductGroupSetting : System.Web.UI.Page
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
                var n = (from u in db.ProductGroups
                         where u.IsDelete == false
                         && u.fk_ProductGroupID == null
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
            txtPrio.Text = string.Empty;
            reDesc.Text = string.Empty;
            txtSummery.Text = string.Empty;
             txtSummery_En.Text = string.Empty;
            txtEN_Title.Text = string.Empty;
            reEN_Desc.Text = null;   
            imgEditImages.Visible = false;        
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid ProductGroupID = new Guid(e.CommandArgument.ToString());
            ViewState["ProductGroupID"] = ProductGroupID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        mvSetting.SetActiveView(vwEdit);
                        ViewState["btn"] = "Update";
                        FillViewEdit(ProductGroupID);
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.ProductGroups where u.ProductGroupID == ProductGroupID select u).FirstOrDefault();
                            lblDelete.Text = n.ProductGroupTitle;

                            mvSetting.SetActiveView(vwDelete);
                        }
                        break;
                    }
            }
        }

        public void FillViewEdit(Guid ProductGroupID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ProductGroups where u.ProductGroupID == ProductGroupID select u).FirstOrDefault();
               
                txtTitle.Text = n.ProductGroupTitle;
                txtName.Text = n.ProductGroupName;
                txtEN_Title.Text = n.En_ProductGroupTitle;
                reDesc.Text = n.ProductGroupDesc;
                reEN_Desc.Text = n.En_ProductGroupDesc;
                ViewState["GImage"] = n.ProductGroupImage;
                txtPrio.Text = n.Priority.ToString();
                txtSummery.Text = n.ProductGroupSummery;
                txtSummery_En.Text = n.En_ProductGroupSummery;

                imgEditImages.ImageUrl = "~/Uploads/ProductGroup/" + n.ProductGroupImage;
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
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/ProductGroup/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
           

            using (VaranegarEntities db = new VaranegarEntities())
            {
                ProductGroups pg = new ProductGroups();

                pg.ProductGroupID = Guid.NewGuid();
                pg.ProductGroupTitle = txtTitle.Text;
                pg.En_ProductGroupTitle = txtEN_Title.Text;
                pg.ProductGroupName = txtName.Text.ToLower();
                pg.ProductGroupImage = new_filename;
                pg.ProductGroupDesc = reDesc.Text;
                pg.En_ProductGroupDesc = reEN_Desc.Text;
                pg.IsDelete = false;
                pg.Priority = Convert.ToInt32(txtPrio.Text);
                pg.En_ProductGroupSummery = txtSummery_En.Text;
                pg.ProductGroupSummery = txtSummery.Text;

                db.ProductGroups.Add(pg);
                db.SaveChanges();
            }

        }

        public void UpdateForm()
        {
            Guid ProductGroupID = new Guid(ViewState["ProductGroupID"].ToString());
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/ProductGroup/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
        
         
            
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ProductGroups where u.ProductGroupID == ProductGroupID select u).FirstOrDefault();

                n.ProductGroupTitle = txtTitle.Text;
                n.En_ProductGroupTitle = txtEN_Title.Text;
                n.ProductGroupName = txtName.Text.ToLower();
                n.ProductGroupImage = ViewState["GImage"].ToString();
                n.ProductGroupDesc = reDesc.Text;
                n.En_ProductGroupDesc = reEN_Desc.Text;              
                n.Priority = Convert.ToInt32(txtPrio.Text);
                n.En_ProductGroupSummery = txtSummery_En.Text;
                n.ProductGroupSummery = txtSummery.Text;
                db.SaveChanges();
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid ProductGroupID = new Guid(ViewState["ProductGroupID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.ProductGroups where u.ProductGroupID == ProductGroupID select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;

                db.SaveChanges();

                LoadForm();
                pnlSuccess.Visible = true;
                mvSetting.SetActiveView(vwList);
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
                var n = (from u in db.ProductGroups where u.ProductGroupName == txtName.Text && u.IsDelete == false select u).FirstOrDefault();

                if (ViewState["btn"].ToString() == "Insert")
                {
                    args.IsValid = n == null;
                }
                else if (ViewState["btn"].ToString() == "Update")
                {
                    Guid ProductGroupID = new Guid(ViewState["ProductGroupID"].ToString());

                    var m = (from u in db.ProductGroups where u.ProductGroupID == ProductGroupID select u).FirstOrDefault();

                    if (m.ProductGroupName == txtName.Text)
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