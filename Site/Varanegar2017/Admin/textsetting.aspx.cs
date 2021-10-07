using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class textsetting : System.Web.UI.Page
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
                    var n = (from u in db.Texts where u.TextID == ID select u).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();

                }


            }
            else if (Request.QueryString["GroupID"] != null)
            {
                int ID = int.Parse(Request.QueryString["GroupID"].ToString());

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.Texts where u.groupid == ID select u).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();

                }

            }
            mvSetting.SetActiveView(vwList);
        }

        public void EmptyForm()
        {

            txtTitle.Text = string.Empty;

            txtEN_Title.Text = string.Empty;
            reDesc.Text = null;
            reDescEn.Text = null;


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
            int TextID = int.Parse(ViewState["TextID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Texts where u.TextID == TextID select u).FirstOrDefault();

                n.TextTitle = txtTitle.Text;
                n.TextBody = reDesc.Text;
                n.En_TextTitle = txtEN_Title.Text;
                n.En_TextTitle = reDescEn.Text;
                n.LastUpdateDate = DateTime.Now;

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
                        int TextID = int.Parse(e.CommandArgument.ToString());
                        ViewState["TextID"] = TextID;

                        FillForm();

                        break;
                    }


            }
        }

        public void FillForm()
        {

            int TextID = int.Parse(ViewState["TextID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Texts where u.TextID == TextID select u).FirstOrDefault();

                txtTitle.Text = n.TextTitle;
                reDesc.Text = n.TextBody;
                txtEN_Title.Text = n.En_TextTitle;
                reDescEn.Text = n.En_TextTitle;
            }
            mvSetting.SetActiveView(vwEdit);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }




    }
}