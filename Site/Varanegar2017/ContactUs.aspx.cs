using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar.Classes;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "تماس با ورانگر | نرم افزار فروش و پخش مویرگی ";
                Page.MetaDescription = "اطلاعات تماس شرکت ورانگر پیشرو | "+"ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
                LoadDropDownReciever();
      
            }
        }
        public void LoadDropDownReciever()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.EmailRecieverRoles
                         where a.IsDelete == false&&a.groupdid==1
                         
                         select a).ToList();

                ddlReciever.Items.Clear();
                ddlReciever.Items.Add(new ListItem("دریافت کننده پیام شما ", "-1"));
                foreach (var t in n)
                    ddlReciever.Items.Add(new ListItem(t.Title, t.EmailRecieverRoleID.ToString()));
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    ContactUsForm bc = new ContactUsForm();

                    bc.contactid = Guid.NewGuid();
                    bc.CommentBody = txtcomment.Text;
                    bc.CommentDate = DateTime.Now;
                    bc.CommentIP = Request.UserHostAddress;
                    bc.Email = txtemail.Text;
                    bc.Mobile = txtPhone.Text;
                    if (ddlReciever.SelectedValue != "-1")
                        bc.fk_RecieverID = Convert.ToInt32(ddlReciever.SelectedValue);
                    bc.IsDelete = false;
                    bc.Name = txtname.Text;

                    db.ContactUsForm.Add(bc);
                    db.SaveChanges();
                    pnlSuccess.Visible = true;

                     
                    string emailBody = @"<table><tr><td>تاریخ</td><td>" + bc.CommentDate + @"</td></tr>
<tr><td>Ip</td><td>" + bc.CommentIP + @"</td></tr>
<tr><td>نام</td><td>" + bc.Name + @"</td></tr>
<tr><td>ایمیل</td><td>" + bc.Email + @"</td></tr>
<tr><td>تلفن تماس</td><td>" + bc.Mobile + @"</td></tr>
<tr><td>متن پیغام</td><td>" + bc.CommentBody + @"</td></tr></table>";

                    List<string> emailList = SendEmail.ReturnEmailList(Convert.ToInt32(ddlReciever.SelectedValue));

                    SendEmail.Send(emailList, "تماس با ما", emailBody);

                    SendEmail.SendToUser_User(txtemail.Text, "تماس با ما");

                }
            }
        }

      
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlReciever.SelectedValue == "-1")
                args.IsValid = false;
            else
                args.IsValid = true;
        }

    }
}