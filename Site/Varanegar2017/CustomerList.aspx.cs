using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "مشتریان ورانگر | نرم افزار فروش و پخش مویرگی ";
                Page.MetaDescription = "لیست مشتریان ورانگر | "+"ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
               
                customerGroupDS();
                customerDS();
            }
        }
        public void customerGroupDS()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.CustomerGroups
                         where u.IsDelete == false
                         orderby u.CustomerGroupID
                         select u).ToList();
                rptCategories.DataSource = n;
                rptCategories.DataBind();

            }
        }

        public void customerDS()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Customers
                         join cg in db.CustomerGroups
                         on u.fk_CustomerGroupID equals cg.CustomerGroupID
                         where u.IsDelete == false
                         orderby u.Priority
                         select new
                        {
                             u.CustomersID,
                             u.CustomerName,
                             u.CustomerTitle,
                             cg.CustomerGroupName,
                             cg.CustomerGroupTitle,
                             u.ImgLogo,
                         }).ToList();
                rptCustomers.DataSource = n;
                rptCustomers.DataBind();

            }
        }
    }
}