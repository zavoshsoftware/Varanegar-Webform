using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;
using Varanegar.Classes;

namespace Varanegar
{
    public partial class SearchResult : System.Web.UI.Page
    {
        List<SearchResultModel> SearchResultList = new List<SearchResultModel>();
        List<Guid> IdList = new List<Guid>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if ((Request.QueryString["searchquery"]) != null)
                {
                    if (Request.QueryString["searchquery"] != "")
                    {
                        Page.Title =Request.QueryString["searchquery"]+ " | ورانگر پیشرو";
                        Page.MetaDescription = "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
               
                        pnlEmpty.Visible = false;
                        string SearchQuery = Request.QueryString["searchquery"];
                        LoadSerachResult(SearchQuery);
                        Log_ErrorInsert(SearchQuery);
                    }
                    else
                    {
                        pnlEmpty.Visible = true;
                        Page.Title = " ورانگر پیشرو | نرم افزار فروش و پخش مویرگی ";
                        Page.MetaDescription = "ورانگر پیشرو اولین و بزرگترین ارائه دهنده نرم افزارهای تخصصی و یکپارچه فروش و پخش مویرگی، نرم افزار فروشگاه و داشبورد هوش تجاری می باشد";
               
                    }
                }
                else
                {
                    Response.Redirect("~/ErrorPages/404.aspx");
                }
            }
        }

        public void LoadSerachResult(string SearchQuery)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
               
                    txtSearch.Text = SearchQuery;
                    ltSearchQuery.Text = SearchQuery;
                    if (SearchQuery.Contains(" "))
                    {
                        SearchResultList = CreateProductGroupResults(SearchQuery);
                        SearchResultList.AddRange(CreateProductResults(SearchQuery));
                        SearchResultList.AddRange(CreateNewsResults(SearchQuery));

                        string[] searchWordList = SearchQuery.Split(' ');

                        foreach (var item in searchWordList)
                        {
                            SearchResultList.AddRange(CreateProductGroupResults(item));
                            SearchResultList.AddRange(CreateProductResults(item));
                            SearchResultList.AddRange(CreateNewsResults(item));
                        }
                    }
                    else
                    {
                        SearchResultList = CreateProductGroupResults(SearchQuery);
                        SearchResultList.AddRange(CreateProductResults(SearchQuery));
                        SearchResultList.AddRange(CreateNewsResults(SearchQuery));
                    }

                    if (SearchResultList.Count > 0)
                    {
                        rptSearchResult.DataSource = SearchResultList;
                        rptSearchResult.DataBind();
                        pnlEmpty.Visible = false;
                    }
                    else
                    {
                        pnlEmpty.Visible = true;
                    }
                }
              
            
        }

        public List<SearchResultModel> CreateProductGroupResults(String SearchQuery)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                List<SearchResultModel> LocalSearchResultList = new List<SearchResultModel>();

                var n = (from a in db.ProductGroups
                         where a.IsDelete == false &&
                               (a.ProductGroupTitle.Contains(SearchQuery) ||
                                a.ProductGroupSummery.Contains(SearchQuery) ||
                                a.ProductGroupDesc.Contains(SearchQuery))
                         select new
                        {
                            a.ProductGroupID,
                            a.ProductGroupTitle,
                            a.ProductGroupSummery,
                            a.ProductGroupName
                        }).ToList();

                foreach (var item in n)
                {
                    if (!IdList.Contains(item.ProductGroupID))
                    {
                        IdList.Add(item.ProductGroupID);
                        LocalSearchResultList.Add(new SearchResultModel(item.ProductGroupTitle, item.ProductGroupSummery,
                            "/Product/" + item.ProductGroupName));
                    }
                }
                return LocalSearchResultList;
            }
        }
        public List<SearchResultModel> CreateProductResults(String SearchQuery)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                List<SearchResultModel> LocalSearchResultList = new List<SearchResultModel>();

                var n = (from a in db.Products
                         join aa in db.ProductGroups on a.fk_ProductGroupID equals aa.ProductGroupID
                         where a.IsDelete == false &&
                               (a.ProductTitle.Contains(SearchQuery) ||
                                a.ProductSumery.Contains(SearchQuery) ||
                                a.ProductDesc.Contains(SearchQuery))
                         select new
                         {
                             a.ProductID,
                             a.ProductName,
                             a.ProductSumery,
                             a.ProductTitle,
                             aa.ProductGroupName
                         }).ToList();

                foreach (var item in n)
                {
                    if (!IdList.Contains(item.ProductID))
                    {
                        IdList.Add(item.ProductID);
                        LocalSearchResultList.Add(new SearchResultModel(item.ProductTitle, item.ProductSumery,
                            "/Product/" + item.ProductGroupName + "/" + item.ProductName));
                    }
                }
                return LocalSearchResultList;
            }
        }
        public List<SearchResultModel> CreateNewsResults(String SearchQuery)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                List<SearchResultModel> LocalSearchResultList = new List<SearchResultModel>();

                var n = (from a in db.Blogs
                         join aa in db.BlogGroups on a.fk_BlogGroupID equals aa.BlogGroupID
                         where a.IsDelete == false &&
                               (a.BlogTitle.Contains(SearchQuery) ||
                                a.summeryText.Contains(SearchQuery) ||
                                a.BlogBody.Contains(SearchQuery))
                         select new
                         {
                             a.BlogID,
                             a.BlogName,
                             a.summeryText,
                             a.BlogTitle,
                             aa.BlogGroupName
                         }).ToList();

                foreach (var item in n)
                {
                    if (!IdList.Contains(item.BlogID))
                    {
                        IdList.Add(item.BlogID);
                        LocalSearchResultList.Add(new SearchResultModel(item.BlogTitle, item.summeryText,
                            "/Blog/" + item.BlogGroupName + "/" + item.BlogName));
                    }
                }
                return LocalSearchResultList;
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            SearchResultList.Clear();
            IdList.Clear();
            Response.Redirect("~/SearchResult.aspx?searchquery=" + txtSearch.Text);
        }
        public void Log_ErrorInsert(string searchQuery)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                Log_SearchQueries leIn = new Log_SearchQueries();

                leIn.SearchQuery = searchQuery;
                leIn.SearchDate = DateTime.Now;
                leIn.SearchIp = Request.UserHostAddress;
                leIn.OS = FindUserInfo.UserOS();
                if (Request.UrlReferrer != null)
                    leIn.RefrallPage = Request.UrlReferrer.ToString();
                else
                    leIn.RefrallPage = "ورود مستقیم";
                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                leIn.browser = browser.Type;

                db.Log_SearchQueries.Add(leIn);
                db.SaveChanges();

            }
        }
    }
}