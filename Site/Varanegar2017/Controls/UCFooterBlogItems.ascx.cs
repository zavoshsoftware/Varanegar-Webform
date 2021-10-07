using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar.Controls
{
    public partial class UCFooterBlogItems : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var m = (from a in db.Blogs.AsEnumerable()
                             join aa in db.BlogGroups
                                on a.fk_BlogGroupID equals aa.BlogGroupID
                             where a.IsDelete == false
                             orderby a.SubmitDate descending 
                             select new
                             {
                                 aa.BlogGroupName,
                                 a.BlogTitle,
                                 a.BlogName,
                                 a.BlogImage,
                                 a.summeryText,
                                 a.Visit,
                                 a.SubmitDate
                             }).ToList();

                  

                    rptFooterBlog.DataSource = m.Take(3);
                    rptFooterBlog.DataBind();
                }
            }
        }
    }
}