using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;


namespace Varanegar
{
    public partial class ShowCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadInfo();
            }
        }
        public void LoadInfo()
        {
            if (Page.RouteData.Values["CustomerName"] != null)
            {
                string CustomerName = Page.RouteData.Values["CustomerName"].ToString();
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Customers
                             where a.CustomerName == CustomerName && a.IsDelete == false
                             select a).FirstOrDefault();

                    ltTitle.Text = n.CustomerTitle;
                    //ltText.Text = n.SmallDesc;
                    ltTitleHeader.Text = n.CustomerTitle;
                    ltTitleAgain.Text = n.CustomerTitle;
                    ltHistory.Text = n.SuccessHistory;
                    imgCustomer.ImageUrl = "/Uploads/Customers/" + n.ImgLogo;
                    ltBraanchNumber.Text = n.BranchNumber.ToString();
                    ltStartDate.Text = ReturnMonth(Convert.ToInt32(n.StartMonth)) + " " + n.StartYear.ToString();
                    ltFinishDate.Text = ReturnMonth(Convert.ToInt32(n.FinishMonth)) + " " + n.FinishYear.ToString();
                    LoadProvince(n.CustomersID);

                    Page.Title = n.CustomerTitle + " | مشتریان ورانگر " + "| ورانگر پیشرو";
                    Page.MetaDescription = n.CustomerTitle + " | برای مشاهده اطلاعات مربوط به " + n.CustomerTitle + " کلیک نمایید. شرکت ورانگر ارائه دهنده نرم افزار های پخش مویرگی و نرم افزار فروشگاهی می باشد.";

                    //Next Previous Button

                    if (n != null)
                    {
                        var next = (db.Customers.OrderBy(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.Priority > n.Priority && a.IsDelete == false)).FirstOrDefault();


                        if (next != null)
                        {
                            hlNext.NavigateUrl = "/customer/" + next.CustomerName;
                        }
                        else
                        {
                            var equalPrio = (db.Customers.OrderBy(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.Priority == n.Priority && a.IsDelete == false)).FirstOrDefault();

                            if (equalPrio != null)
                                hlNext.NavigateUrl = "/customer/" + equalPrio.CustomerName;
                            else
                            {
                                var smallestRow = (db.Customers.OrderBy(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.IsDelete == false)).FirstOrDefault();
                                hlNext.NavigateUrl = "/customer/" + smallestRow.CustomerName;
                            }
                        }

                        var prev = (db.Customers.OrderBy(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.Priority < n.Priority && a.IsDelete == false)).FirstOrDefault();
                        if (prev != null)
                        {
                            hlPerv.NavigateUrl = "/customer/" + prev.CustomerName;
                        }
                        else
                        {
                            var equalPrio = (db.Customers.OrderBy(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.Priority == n.Priority && a.IsDelete == false)).FirstOrDefault();

                            if (equalPrio != null)
                                hlPerv.NavigateUrl = "/customer/" + equalPrio.CustomerName;
                            else
                            {
                                var biggestRow = (db.Customers.OrderByDescending(a => a.Priority).Where(a => a.CustomersID != n.CustomersID && a.IsDelete == false)).FirstOrDefault();
                                hlPerv.NavigateUrl = "/customer/" + biggestRow.CustomerName;
                            }
                        }
                    }
                }
            }
        }

        public void LoadProvince(Guid CustomerID)
        {
            List<Province> proList = new List<Province>();
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Rel_Customer_Province
                         where a.fk_CustomerID == CustomerID
                         select a).ToList();

                foreach (var item in n)
                {
                    var m = (from a in db.Province
                             where a.ProvinceID == item.fk_ProvinceID
                             select a).FirstOrDefault();

                    if (m != null)
                    {
                        proList.Add(m);
                    }
                }

                rptProv.DataSource = proList;
                rptProv.DataBind();
            }
        }
        public string ReturnMonth(int MonthID)
        {
            switch (MonthID)
            {
                case 1:
                    {
                        return "فروردین";
                        break;
                    }
                case 2:
                    {
                        return "اردیبهشت";
                        break;
                    }
                case 3:
                    {
                        return "خرداد";
                        break;
                    }
                case 4:
                    {
                        return "تیر";
                        break;
                    }
                case 5:
                    {
                        return "مرداد";
                        break;
                    }
                case 6:
                    {
                        return "شهریور";
                        break;
                    }
                case 7:
                    {
                        return "مهر";
                        break;
                    }
                case 8:
                    {
                        return "آبان";
                        break;
                    }
                case 9:
                    {
                        return "آذر";
                        break;
                    }
                case 10:
                    {
                        return "دی";
                        break;
                    }
                case 11:
                    {
                        return "بهمن";
                        break;
                    }
                case 12:
                    {
                        return "اسفند";
                        break;
                    }
                default:
                    return "";
            }
        }
    }
}