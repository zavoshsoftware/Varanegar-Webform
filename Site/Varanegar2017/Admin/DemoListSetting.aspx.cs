using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Admin
{
    public partial class DemoListSetting : System.Web.UI.Page
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
                var n = (from u in db.DemoRequests
                         join aa in db.EmailRecieverRoles on u.fk_RecieverID equals aa.EmailRecieverRoleID
                         where u.IsDelete == false
                         orderby u.RegisterDate descending
                         select
                         new
                         {
                             u.Name,
                             u.CompanyName,
                             u.Mobile,
                             u.Phone,
                             u.RequestID,
                             u.RegisterDate,
                             aa.Title
                         }).ToList();

                grdTable.DataSource = n;
                grdTable.DataBind();
                datasourceCounter = n.Count();
            }

            CheckEmptyData(datasourceCounter);
            mvSetting.SetActiveView(vwList);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvSetting.SetActiveView(vwList);
        }

        public void ShowDetails()
        {
            int RequestID = Convert.ToInt32(ViewState["RequestID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var p = (from u in db.DemoRequests where u.RequestID == RequestID select u).FirstOrDefault();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            int RequestID = Convert.ToInt32(ViewState["RequestID"].ToString());

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.DemoRequests where u.RequestID == RequestID select u).FirstOrDefault();

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
            int RequestID = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["RequestID"] = RequestID;

            if (e.CommandName == "DoDetail")
            {
                FillViewEdit(RequestID);
            }
            else if (e.CommandName == "DoDelete")
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from u in db.DemoRequests where u.RequestID == RequestID select u).FirstOrDefault();

                    lblDelete.Text = n.Name;
                    mvSetting.SetActiveView(vwDelete);
                }
            }
        }

        public void FillViewEdit(int RequestID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.DemoRequests where u.RequestID == RequestID select u).FirstOrDefault();

                lblName.Text = n.Name;
                lblCompanyName.Text = n.CompanyName;
                lblEmail.Text = n.Email;
                lblDesc.Text = n.FinalDesc;
                lblFamiliarMethodTitle.Text = ReturnFamiliarType(Convert.ToInt32(n.fk_FamiliarMethodID));
                lblMobile.Text = n.Mobile;
                lblField.Text = n.Field;
                lblPost.Text = n.Post;
                lblPhone.Text = n.Phone;

                mvSetting.SetActiveView(vwEdit);
            }
        }
        public string ReturnFamiliarType(int id)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.FamiliarMethods
                         where a.IsDelete == false && a.FamiliarMethodID == id
                         select a).FirstOrDefault();

                if (n != null)
                    return n.FamiliarMethodTitle;
                else
                {
                    return "";
                }
            }
        }
        protected void grdTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTable.PageIndex = e.NewPageIndex;
            LoadForm();
        }

        protected void btnExportToExcell_Click(object sender, EventArgs e)
        {
            Loadexcel();
        }
        public void Loadexcel()
        {
            string path = Server.MapPath("~/Uploads/Demo.xlsx");
            var newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete();
            }

            //ایجاد یک سری اطلاعات دلخواه
            var table = createDt();

            using (var package = new ExcelPackage(newFile))
            {
                // اضافه کردن یک ورک شیت جدید
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("درخواست دمو");

                //اضافه کردن یک جدول جدید از دیتاتیبل دریافتی
                worksheet.Cells["A1"].LoadFromDataTable(table, true, TableStyles.Dark9);

                //نمایش جمع ستون هزینه‌های ماه‌ها
                //var tbl = worksheet.Tables[0];
                ////زیر آخرین ردیف یک سطر اضافه می‌کند
                //tbl.ShowTotal = true;
                ////فرمول نحوه‌ی محاسبه جمع ستون انتساب داده می‌شود
                //tbl.Columns[1].TotalsRowFunction = RowFunctions.Sum;

                //تعیین عرض ستون‌های جدول
                worksheet.Column(1).Width = 14;
                worksheet.Column(2).Width = 12;
                worksheet.Column(3).Width = 30;
                worksheet.Column(4).Width = 30;
                worksheet.Column(5).Width = 20;
                //تنظیم متن هدر
                //   worksheet.HeaderFooter.oddHeader.CenteredText = "مثالی از نحوه‌ی استفاده از ایی پی پلاس";

                //می‌خواهیم سرستون‌ها در وسط ستون قرار گیرند
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["B1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //افزودن یک نمودار جدید به شیت جاری
                //var chart = worksheet.Drawings.AddChart("chart1", eChartType.Pie3D);
                //chart.Title.Text = "نمودار هزینه‌هاى سال";
                //chart.SetPosition(Row: 2, RowOffsetPixels: 5, Column: 3, ColumnOffsetPixels: 5);
                //chart.SetSize(PixelWidth: 320, PixelHeight: 360);
                //chart.Series.Add("B2:B13", "A2:A13");
                //chart.Style = eChartStyle.Style26;

                ////تنظیم یک سری خواص فایل نهایی
                //package.Workbook.Properties.Title = "مثالی از ایی پی پلاس";
                //package.Workbook.Properties.Author = "وحید";
                //package.Workbook.Properties.Subject = "ایجاد فایل اکسل بدون نرم افزار اکسل";

                //تنظیم نحوه‌ی نمایش فایل زمانیکه در نرم افزار اکسل گشوده می‌شود
                //    worksheet.View.PageLayoutView = true;
                worksheet.View.RightToLeft = true;

                // ذخیر سازی کلیه موارد اعمالی در فایل
                package.Save();
                Response.Redirect("~/Uploads/Demo.xlsx");
            }
        }

        private static DataTable createDt()
        {
            var table = new DataTable("لیست");
            table.Columns.Add("نام", typeof(string));
            table.Columns.Add("نام سازمان", typeof(string));
            table.Columns.Add("تاریخ ثبت", typeof(string));
            table.Columns.Add("واحد دریافت کننده", typeof(string));
            table.Columns.Add("شماره همراه ثبت کننده", typeof(string));
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.DemoRequests.AsEnumerable()
                         join aa in db.EmailRecieverRoles on u.fk_RecieverID equals aa.EmailRecieverRoleID
                         where u.IsDelete == false
                         orderby u.RegisterDate descending
                         select
                         new
                         {
                             u.Name,
                             u.CompanyName,
                             u.Mobile,
                             RegisterDate = u.RegisterDate.ToString(),
                             aa.Title
                         }).ToList();

                foreach (var item in n)
                {
                    table.Rows.Add(item.Name, item.CompanyName, item.RegisterDate, item.Title, item.Mobile);
                }
            }

            return table;
        }
        //public void GenerateExcel2007(string p_strPath, DataSet p_dsSrc)
        //{
        //    using (ExcelPackage objExcelPackage = new ExcelPackage())
        //    {
        //        ExcelWorksheet objExcelPackag;
        //        foreach (DataTable dtSrc in p_dsSrc.Tables)
        //        {
        //            //Create the worksheet    
        //            ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add(dtSrc.TableName);
        //            //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
        //            objWorksheet.Cells["A1"].LoadFromDataTable(dtSrc, true);
        //            objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 10));
        //            objWorksheet.Cells.AutoFitColumns();
        //            //Format the header    
        //            using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
        //            {
        //                objRange.Style.Font.Bold = true;
        //                objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //                objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        //                objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                //  objRange.Style.Fill.BackgroundColor.SetColor(Color.FromA#eaeaea);    
        //            }
        //        }

        //        //Write it back to the client    
        //        if (File.Exists(p_strPath))
        //            File.Delete(p_strPath);

        //        //Create excel file on physical disk    
        //        FileStream objFileStrm = File.Create(p_strPath);
        //        objFileStrm.Close();


        //        //Write content to excel file    
        //        File.WriteAllBytes(p_strPath, objExcelPackag - e.GetAsByteArray());
        //    }
        //}
    }
}