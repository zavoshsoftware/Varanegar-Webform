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
    public partial class ImageSetting : System.Web.UI.Page
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
            if (Request.QueryString["ID"] != null)
            {
                int ID = int.Parse(Request.QueryString["ID"].ToString());

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Images where u.ImageID == ID select u).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                }
            }
            else if (Request.QueryString["groupid"] != null)
            {
                int ID = int.Parse(Request.QueryString["groupid"].ToString());

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Images where u.fk_ImageGroupID == ID select u).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();

                }

            }
            mvSetting.SetActiveView(vwList);
        }

       


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                    UpdateForm();
                LoadForm();
            }
        }

        public void UpdateForm()
        {
            int ImageID = int.Parse(ViewState["ImageID"].ToString());
         
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Images/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }
           
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Images where u.ImageID == ImageID select u).FirstOrDefault();

                n.ImageTitle = txtTitle.Text;
                n.LastUpdateUserID = FindUserInfo.OnlineUserID();
                n.ImgLastUpdateDate = DateTime.Now;
                n.ImgUrlAddress = ViewState["GImage"].ToString();
                n.Priority = Convert.ToInt32(txtPrio.Text);
                n.IsActive = chkActive.Checked;
                db.SaveChanges();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }

        protected void grdTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        int ImageID = int.Parse(e.CommandArgument.ToString());
                        ViewState["ImageID"] = ImageID;
                        
                        FillForm();

                        break;
                    }
            }
        }

        public void FillForm()
        {

            int ImageID = int.Parse(ViewState["ImageID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Images where u.ImageID == ImageID select u).FirstOrDefault();

                txtTitle.Text = n.ImageTitle;
                ViewState["GImage"] = n.ImgUrlAddress;
                txtPrio.Text = n.Priority.ToString();
                chkActive.Checked=Convert.ToBoolean(n.IsActive);

            }
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}