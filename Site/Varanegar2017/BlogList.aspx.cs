using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class BlogList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "اخبار ورانگر | نرم افزار فروش و پخش مویرگی ";
                Page.MetaDescription ="اخبار مربوط به شرکت ورانگر را از این بخش دنبال نمایید | "+ "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
      
                LoadBlogList();
                rptPageCountBind();
            }
        }
        public void LoadBlogItems()
        {

            string BlogGroupName = Page.RouteData.Values["BlogGroupName"].ToString();

            using (VaranegarEntities db = new VaranegarEntities())
            {
                var m = (from a in db.Blogs.AsEnumerable()
                         join aa in db.BlogGroups
                         on a.fk_BlogGroupID equals aa.BlogGroupID
                         where aa.BlogGroupName == BlogGroupName && a.IsDelete == false
                         orderby a.SubmitDate descending
                         select new
                         {
                             aa.BlogGroupName,
                             BlogTitle = a.BlogTitle.Length > 80 ? a.BlogTitle.Substring(0, 80) + " ..." : a.BlogTitle,
                             a.BlogName,
                             a.BlogImage,
                             summeryText = a.summeryText.Length > 130 ? a.summeryText.Substring(0, 130) + " ..." : a.summeryText,
                             a.Visit,
                             a.SubmitDate
                         }).ToList();

                rptBlogs.DataSource = m;
                rptBlogs.DataBind();
            }


        }
        public void LoadBlogList()
        {


            if (Page.RouteData.Values["BlogGroupName"] != null)
            {
                string BlogGroupName = Page.RouteData.Values["BlogGroupName"].ToString();

                using (VaranegarEntities db = new VaranegarEntities())
                {
                    if (BlogGroupName != "all")
                    {
                        var n = (from a in db.BlogGroups
                                 where a.BlogGroupName == BlogGroupName && a.IsDelete == false
                                 select a).FirstOrDefault();

                        ltSolutionTitle.Text = n.BlogGroupTitle;
                        lttitle.Text = n.BlogGroupTitle;
                        LoadBlogItems();

                    }
                    else
                    {
                        ShowAllBlogItems();
                    }
                }
            }
            else
            {
                ShowAllBlogItems();
            }
        }
        public void ShowAllBlogItems()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                int pID = ReturnPageID();

                ltSolutionTitle.Text = "اخبار و تازه ها";
                lttitle.Text = "همه";

                var m = (from a in db.Blogs.AsEnumerable()
                         join aa in db.BlogGroups
                        on a.fk_BlogGroupID equals aa.BlogGroupID
                         where a.IsDelete == false
                         orderby a.SubmitDate descending
                         select new
                         {
                             aa.BlogGroupName,
                             BlogTitle = a.BlogTitle.Length > 80 ? a.BlogTitle.Substring(0, 80) + " ..." : a.BlogTitle,
                             a.BlogName,
                             a.BlogImage,
                             summeryText = a.summeryText.Length > 130 ? a.summeryText.Substring(0, 130) + " ..." : a.summeryText,
                             a.Visit,
                             a.SubmitDate
                         }).ToList().Skip((pID - 1) * 10).Take(10);

                rptBlogs.DataSource = m;
                rptBlogs.DataBind();
            }
        }


        # region Paging

        public void rptPageCountBind()
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from u in db.Blogs
                        where u.IsDelete==false
                         select u).ToList();

                int ocjCount = n.Count();
                if ((ocjCount % 10) >= 1)
                {
                    int PageCount = Convert.ToInt32(Math.Round(Convert.ToDecimal(ocjCount / 10)));
                    List<int> p = new List<int>();

                    for (int i = 1; i <= PageCount + 1; i++)
                    {
                        p.Add(i);
                    }
                    var m = (from a in p
                             select new
                             {
                                 pageid = a.ToString()
                             }).ToList();
                    rptPageNum.DataSource = m;
                    rptPageNum.DataBind();
                }
                else
                {
                    int PageCount = Convert.ToInt32(Math.Round(Convert.ToDecimal(ocjCount / 10)));
                    List<int> p = new List<int>();

                    for (int i = 1; i < PageCount + 1; i++)
                    {
                        p.Add(i);
                    }
                    var m = (from a in p
                             select new
                             {
                                 pageid = a.ToString()
                             }).ToList();
                    rptPageNum.DataSource = m;
                    rptPageNum.DataBind();
                }
            }
        }
        public int ReturnPageID()
        {
            if (Request.QueryString["pageid"] != null)
            {
                int pID = Convert.ToInt32(Request.QueryString["pageid"].ToString());
                return pID;
            }
            else
                return 1;
        }
        protected void rptPageNum_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int pID = ReturnPageID();

                Label lblPageNum = (Label)e.Item.FindControl("lblPageNum");

                HiddenField hfPageID = (HiddenField)e.Item.FindControl("hfPageID");

                int PageID = Convert.ToInt32(hfPageID.Value);

                if (PageID == pID)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                        "AddCurrentToPaging('#" + PageID + "');", true);
                    //lblPageNum.BackColor = System.Drawing.ColorTranslator.FromHtml("#CBC6B5");
                    //lblPageNum.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "PageScript",
                    // "AddCurrent('#c')", true);
                }
            }
        }
        protected void rptPageNum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string pageid = e.CommandArgument.ToString();
            if (Page.RouteData.Values["BlogGroupName"] != null)
            {
                string BlogGroupName = Page.RouteData.Values["BlogGroupName"].ToString();
                Response.Redirect("/Blog/" + BlogGroupName + "?pageid=" + pageid);
            }
            else
            {

                Response.Redirect("/Blog?pageid=" + pageid);
            }

        }
        #endregion
    }
}