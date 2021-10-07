using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class commentSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }
        protected void grdProductGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid CommentID = new Guid(e.CommandArgument.ToString());
            ViewState["CommentID"] = CommentID;

            switch (e.CommandName)
            {
                case "DoEdit":
                    {
                        pnlCheck.Visible = true;
                        ViewState["btn"] = "Update";
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.BlogComments where u.CommentID == CommentID select u).FirstOrDefault();

                            txtComment.Text = n.CommentBody;
                        }
                        break;
                    }
                case "DoDelete":
                    {
                        using (VaranegarEntities db = new VaranegarEntities())
                        {
                            var n = (from u in db.BlogComments where u.CommentID == CommentID select u).FirstOrDefault();
                            pnlDelete.Visible = true;
                        }
                        break;
                    }
            }
        }
        protected void btnAgree_Click(object sender, EventArgs e)
        {

            Guid CommentID = new Guid(ViewState["CommentID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.BlogComments where u.CommentID == CommentID select u).FirstOrDefault();

                n.IsDelete = true;
                n.DeleteDate = DateTime.Now;

                db.SaveChanges();

                LoadForm();
                pnlDelete.Visible = false;
            }
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            pnlDelete.Visible = false;
        }


        public void LoadForm()
        {
            if (Request.QueryString["id"] != null)
            {
                Guid BlogID = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.BlogComments
                             join uu in db.Blogs
                             on u.fk_BlogID equals uu.BlogID
                             where u.IsDelete == false && u.fk_BlogID == BlogID
                             orderby u.CommentDate
                             select new
                             {
                                 u.CommentDate,
                                 u.Name,
                                 u.Email,
                                 uu.BlogTitle,
                                 u.CommentID, u.IsValid
                             }).ToList();
                    grdTable.DataSource = n;
                    grdTable.DataBind();

                    CheckEmptyData(n.Count());
                }
            }
            else
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.BlogComments
                             join uu in db.Blogs
                            on u.fk_BlogID equals uu.BlogID
                             where u.IsDelete == false
                             orderby u.CommentDate
                             select new
                             {
                                 u.CommentDate,
                                 u.Name,
                                 u.Email,
                                 uu.BlogTitle,
                                 u.CommentID
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();

                    CheckEmptyData(n.Count());
                }
            }
        }
        public void CheckEmptyData(int DataCounter)
        {
            if (DataCounter == 0)
                pnlEmptyForm.Visible = true;
            else
                pnlEmptyForm.Visible = false;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid CommentID = new Guid(ViewState["CommentID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.BlogComments where u.CommentID == CommentID select u).FirstOrDefault();

                n.IsValid = true;
                n.CommentBody = txtComment.Text;

                db.SaveChanges();

                LoadForm();
                pnlCheck.Visible = false;
            }
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            LoadForm();
            pnlCheck.Visible = false;
        }
    }
}