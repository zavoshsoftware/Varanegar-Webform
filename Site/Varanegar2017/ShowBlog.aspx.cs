using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class ShowBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IncreementVisitNumber();
                LoadSolutionInfo();
              //  LoadComments();
                LoadblogGroups();

            }
        }
        public void LoadSolutionInfo()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "PageScriptblogdetail",
                  "$('#bloglistheaderImage').css('background', 'url(/images/slide_1.jpg) no-repeat center center / cover');", true);

            if (Page.RouteData.Values["BlogName"] != null)
            {
                string BlogName = Page.RouteData.Values["BlogName"].ToString();

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Blogs
                        where a.BlogName == BlogName && a.IsDelete == false
                        select a).FirstOrDefault();

                    if (n != null)
                    {
                        ltSolutionTitle.Text = n.BlogTitle;
                        lttitle.Text = n.BlogTitle;
                        ltbannerText.Text = n.summeryText;

                        imgBlog.ImageUrl = "~/uploads/blog/" + n.BlogImage;
                        imgBlog.AlternateText = n.BlogTitle;
                        ltBlogTitle.Text = n.BlogTitle;
                        ltVisitnumb.Text = n.Visit.ToString();
                        if(n.SubmitDate!=null)
                        ltDate.Text = n.SubmitDate.Value.ToShortDateString();
                        ltbody.Text = n.BlogBody;


                        Page.Title =n.BlogTitle + " | ورانگر پیشرو";
                        Page.MetaDescription = n.summeryText;
               
                    }
                    else
                    {
                        Response.Redirect("~/ErrorPages/404.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/ErrorPages/404.aspx");
            }
        }
        public void IncreementVisitNumber()
        {
            if (Page.RouteData.Values["BlogName"] != null)
            {
                string BlogName = Page.RouteData.Values["BlogName"].ToString();

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Blogs
                        where a.BlogName == BlogName && a.IsDelete == false
                        select a).FirstOrDefault();
                    if (n != null)
                    {
                        n.Visit = n.Visit + 1;
                        db.SaveChanges();
                    }
                }
            }
        }
        #region comments
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        if (Page.RouteData.Values["BlogName"] != null)
        //        {
        //            string BlogName = Page.RouteData.Values["BlogName"].ToString();

        //            using (VaranegarEntities db = new VaranegarEntities())
        //            {
        //                var n = (from a in db.Blogs
        //                         where a.BlogName == BlogName && a.IsDelete == false
        //                         select a).FirstOrDefault();

        //                BlogComments bc = new BlogComments();

        //                bc.CommentID = Guid.NewGuid();
        //                bc.CommentBody = txtcomment.Text;
        //                bc.CommentDate = DateTime.Now;
        //                bc.CommentIP = Request.UserHostAddress;
        //                bc.Email = txtemail.Text;
        //                bc.fk_BlogID = n.BlogID;
        //                bc.IsDelete = false;
        //                bc.Name = txtname.Text;
        //                bc.IsValid = false;

        //                db.BlogComments.Add(bc);
        //                db.SaveChanges();
        //                pnlSuccess.Visible = true;
        //            }
        //        }
        //    }
        //}
        //public void LoadComments()
        //{
        //    if (Page.RouteData.Values["BlogName"] != null)
        //    {
        //        string BlogName = Page.RouteData.Values["BlogName"].ToString();

        //        using (VaranegarEntities db = new VaranegarEntities())
        //        {
        //            var n = (from a in db.Blogs
        //                     where a.BlogName == BlogName && a.IsDelete == false
        //                     select a).FirstOrDefault();

        //            var m = (from a in db.BlogComments
        //                     where a.fk_BlogID == n.BlogID
        //                     && a.IsDelete == false && a.IsValid == true
        //                     select a).ToList();

        //            rptComments.DataSource = m;
        //            rptComments.DataBind();
        //        }
        //    }
        //}
#endregion
        public void LoadblogGroups()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.BlogGroups
                         where a.IsDelete == false
                         orderby a.Priority
                         select a).ToList();

                rptCategory.DataSource = n;
                rptCategory.DataBind();


                var n2 = (from a in db.Blogs
                          join aa in db.BlogGroups
                               on a.fk_BlogGroupID equals aa.BlogGroupID
                         where   a.IsDelete == false
                         orderby a.Visit descending
                          select new
                          {
                              aa.BlogGroupName,
                              a.BlogTitle,
                              a.BlogName,
                              a.BlogImage,
                              a.summeryText,
                              a.Visit,
                              a.SubmitDate
                          }).Take(5).ToList();
                rptmostvisitBlogs.DataSource = n2;
                rptmostvisitBlogs.DataBind();
            }
        }
    }
}