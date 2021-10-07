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
    public partial class SliderSetting : System.Web.UI.Page
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
                var n = (from u in db.Sliders
                         where u.IsDelete == false
                         orderby u.Priority
                         select
                        u).ToList();

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
            txtPrio.Text = string.Empty;
            txtBigText.Text = string.Empty;
            txtLinkAddress.Text = string.Empty;
            txtSmallText.Text = string.Empty;
            txtTitle.Text = string.Empty;
            imgEditImages.Visible = false; imgEditImages.ImageUrl = "";
            chbActiveSlider.Checked = false;
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
            string thumbnailUrl = string.Empty;
            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Slider/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);

                ViewState["GImage"] = new_filename;
            }

            int SliderID =Convert.ToInt32(ViewState["SliderID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Sliders where u.SliderID == SliderID select u).FirstOrDefault();

                p.SliderTitle = txtTitle.Text;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.BigText = txtBigText.Text;
                p.IsActive = chbActiveSlider.Checked;
                p.IsDelete = false;
                p.LinkAddress = txtLinkAddress.Text;
                p.LinkText=txtLinkTitle.Text;
                p.SliderImageUrl = ViewState["GImage"].ToString();
                p.SmallText=txtSmallText.Text;
                
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

                string new_filepath = Server.MapPath("~/Uploads/Slider/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);


                ViewState["GImage"] = new_filename;
            }
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Sliders p = new Sliders();

                p.SliderTitle = txtTitle.Text;
                p.Priority = Convert.ToInt32(txtPrio.Text);
                p.BigText = txtBigText.Text;
                p.IsActive = chbActiveSlider.Checked;
                p.LinkAddress = txtLinkAddress.Text;
                p.LinkText = txtLinkTitle.Text;
                p.SliderImageUrl = new_filename;
                p.SmallText = txtSmallText.Text;
                p.IsDelete = false;
                db.Sliders.Add(p);
                db.SaveChanges();
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
           
                Response.Redirect("Default.aspx");
 
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int SliderID =Convert.ToInt32(ViewState["SliderID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Sliders where u.SliderID == SliderID select u).FirstOrDefault();

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
                int SliderID = Convert.ToInt32(e.CommandArgument.ToString());

                ViewState["SliderID"] = SliderID;
                ViewState["btn"] = "Update";


                FillViewEdit(SliderID);
            }
            else if (e.CommandName == "DoDelete")
            {
                int SliderID = Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["SliderID"] = SliderID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Sliders where u.SliderID == SliderID select u).FirstOrDefault();
                    lblDelete.Text = n.SliderTitle;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
            else if (e.CommandName == "recycle")
            {
                int SliderID = Convert.ToInt32(e.CommandArgument.ToString());
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Sliders where u.SliderID == SliderID select u).FirstOrDefault();

                    n.IsDelete = false;
                    n.DeleteDate = DateTime.Now;
                    db.SaveChanges();
                    LoadForm();
                }
            }
        }

        public void FillViewEdit(int SliderID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.Sliders where u.SliderID == SliderID select u).FirstOrDefault();


                txtTitle.Text = p.SliderTitle;
                txtPrio.Text= p.Priority.ToString();
                txtBigText.Text=p.BigText;
                chbActiveSlider.Checked= p.IsActive ;

                txtLinkAddress.Text= p.LinkAddress ;
                txtLinkTitle.Text= p.LinkText ;
                ViewState["GImage"]=    p.SliderImageUrl ;
                txtSmallText.Text= p.SmallText  ;

                 

            
                imgEditImages.ImageUrl = "~/Uploads/Slider/Thumbs/" + p.SliderImageUrl;
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