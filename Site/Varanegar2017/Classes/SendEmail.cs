using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Varanegar2017.Models;

namespace Varanegar.Classes
{
    public static class SendEmail
    {
        public static void Send(List<string> emails, string subject, string mainBody)
        {
            try
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("site@varanegar.com");

                    foreach (var item in emails)
                    {
                        mail.To.Add(item);
                    }

                    DateTime today = DateTime.Today;

                    mail.Body = ReturnEmailBody(subject, mainBody);
                    mail.Subject = subject;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("162.144.130.238");

                    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("site@varanegar.com","site@899!$");
                    mail.Headers.Add("Message-Id",
                        String.Concat("<", DateTime.Now.ToString("yyMMdd"), ".", DateTime.Now.ToString("HHmmss"),
                            "site@varanegar.com>"));

                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = basicAuthenticationInfo;

                    mail.Priority = MailPriority.Normal;

                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void SendToUser_User(string email, string subject)
        {
            try
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress("site@varanegar.com");

                    mail.To.Add(email);

                    DateTime today = DateTime.Today;

                    mail.Body = ReturnEmailBody_User(subject);
                    mail.Subject = subject;

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("162.144.130.238");

                    System.Net.NetworkCredential basicAuthenticationInfo =
                        new System.Net.NetworkCredential("site@varanegar.com",
                            "site@899!$");
                    mail.Headers.Add("Message-Id",
                        String.Concat("<", DateTime.Now.ToString("yyMMdd"), ".", DateTime.Now.ToString("HHmmss"),
                            "site@varanegar.com>"));

                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = basicAuthenticationInfo;

                    mail.Priority = MailPriority.Normal;

                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static List<string> ReturnEmailList(int EmailRoleID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Emails
                         where a.fk_RecieverRoleID == EmailRoleID &&a.IsDelete==false
                         select a).ToList();
                List<string> emails = new List<string>();

                foreach (var item in n)
                {
                    emails.Add(item.EmailTitle);
                }
                return emails;
            }
        }
        public static string ReturnEmailBody(string subject, string EmailMainBody)
        {


            string Body = @" 
    <div style='padding: 5px; direction: rtl;'>
       
<div style='float:right;'>
<img src='http://www.varanegar.com/images/vlogo1.png' />
</div>
<p style='clear:both;'></p>
                        <div class='vcenter'>
                            <h2>شرکت ورانگر پیشرو</h2><h3>" +
                                                       subject
                                                       +
@"
                            </h3>
                            <p>
                                کاربر گرامی این ایمیل از طرف وب سایت ورانگر پیشرو برای شما ارسال شده است <br/>
                                و حاوی اطلاعات فرم 
" + subject + @"
سایت ورانگر می باشد.

                                
                            </p>
<br/>
" +
EmailMainBody
+ @"
                       
    </div>";

            return Body;
        }

        public static string ReturnEmailBody_User(string subject)
        {


            string Body = @"  
<div style='float:right;'>
<img src='http://www.varanegar.com/images/vlogo1.png' />
</div>
<p style='clear:both;'></p>
    <div style='padding: 5px; direction: rtl; font-family:tahoma;'>
                            <h2>شرکت ورانگر پیشرو</h2>                        
<p style='font-family:tahoma;' direction: rtl; >
                 .با تشکر از ارتباط شما با شرکت ورانگر پیشرو، درخواست شما دریافت شد 
                            </p>
<br/>
 
<a style=' font-family:tahoma; border-radius: 2px; padding: 5px; text-decoration:none; font-weight: 500; background-color: #8ec165; border-color: #8ec165; color: #fff !important;' href='http://www.varanegar.com/Product/sales-and-distribution-software'>نرم افزار فروش و پخش مویرگی</a>
<a style=' font-family:tahoma; border-radius: 2px; padding: 5px; text-decoration:none; font-weight: 500; background-color: #8ec165; border-color: #8ec165; color: #fff !important;' href='http://www.varanegar.com/Product/chain-store-and-retail-software'>نرم افزار فروشگاه زنجیره ای</a>

<a style=' font-family:tahoma; border-radius: 2px; padding: 5px; text-decoration:none; font-weight: 500; background-color: #8ec165; border-color: #8ec165; color: #fff !important;' href='http://www.varanegar.com/Product/management-solutions/sales-and-distribution-bi-solution'>نرم افزار هوش تجاری</a>
<a style=' font-family:tahoma; border-radius: 2px; padding: 5px; text-decoration:none; font-weight: 500; background-color: #8ec165; border-color: #8ec165; color: #fff !important;' href='http://www.varanegar.com/Product/financial-software'>نرم افزار مالی و حسابداری</a>
<br/>

<hr/>
<b style='font-family:tahoma;'>اطلاعات تماس:</b>
<br/>
<p  style='font-family:tahoma;'>
آدرس: تهران، ونک پارک، خیابان شیراز جنوبی، انتهای کوچه آقاعلیخانی شرقی، 
پلاک2، ساختمان ورانگر
<br/>
تلفن تماس: ۰۲۱-۸۷۱۳۴
  </p>  </div>";

            return Body;
        }
    }
}