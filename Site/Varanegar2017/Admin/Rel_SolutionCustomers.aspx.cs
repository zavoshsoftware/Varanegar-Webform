using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class Rel_SolutionCustomers : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var m = (from a in db.Solutions
                             where a.SolutionID == id && a.IsDelete == false
                             select a).FirstOrDefault();
                    lblsolutionTitle.Text = m.SolutionTitle;

                    var n = (from aa in db.Rel_Solutions_Customers
                             join u in db.Customers
                             on aa.fk_CustomerID equals u.CustomersID
                             where u.IsDelete == false && aa.fk_SolutionID == id
                             orderby u.submitDate descending
                             select
                             new
                             {
                                 u.CustomerTitle,
                                 u.CustomerName,
                                 u.CustomersID,
                                 aa.SolutionCustomerID,
                                 u.ImgLogo
                             }).ToList();

                    grdTable.DataSource = n;
                    grdTable.DataBind();
                    datasourceCounter = n.Count();
                }
            }

            else
            {
                Response.Redirect("~/admin/SolutionSetting.aspx");
            }

            CheckEmptyData(datasourceCounter);

        }
        public void DropDownBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var pg = (from u in db.Customers
                          where u.IsDelete == false

                          select u).ToList();
                ddlCustomers.Items.Clear();
                ddlCustomers.Items.Add(new ListItem("لیست مشتریان", "-1"));
                foreach (var t in pg)
                    ddlCustomers.Items.Add(new ListItem(t.CustomerTitle, t.CustomersID.ToString()));
            }
        }

        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }

        protected void grdTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "DoDelete")
            {
                Guid SolutionCustomerID = new Guid(e.CommandArgument.ToString());
                ViewState["SolutionCustomerID"] = SolutionCustomerID;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from aa in db.Rel_Solutions_Customers
                             join u in db.Customers
                            on aa.fk_CustomerID equals u.CustomersID
                             where aa.SolutionCustomerID == SolutionCustomerID
                             select new
                             {
                                 u.CustomerTitle
                             }).FirstOrDefault();
                    lblDelete.Text = n.CustomerTitle;
                    pnlDelete.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    Rel_Solutions_Customers a = new Rel_Solutions_Customers();
                    a.fk_CustomerID = new Guid(ddlCustomers.SelectedValue);
                    a.fk_SolutionID = id;
                    a.SolutionCustomerID = Guid.NewGuid();

                    db.Rel_Solutions_Customers.Add(a);
                    db.SaveChanges();
                    LoadForm();
                    ddlCustomers.SelectedValue = "-1";
                    pnlSuccess.Visible = true;
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Guid SolutionCustomerID = new Guid(ViewState["SolutionCustomerID"].ToString());
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Rel_Solutions_Customers
                         where a.SolutionCustomerID == SolutionCustomerID
                         select a).FirstOrDefault();
                db.Rel_Solutions_Customers.Remove(n);
                db.SaveChanges();
                LoadForm();
                pnlSuccess.Visible = true;
                pnlDelete.Visible = false;

            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            pnlDelete.Visible = false;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlCustomers.SelectedValue=="-1")
            {
                args.IsValid = false;
            }
        }
    }
}
