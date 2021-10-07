using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Varanegar.Classes
{

    //public  class SearchResultModel
    //{
    //    public int id { get; set; }
    //    public  string Title { get; set; }
    //    public  string SmallText { get; set; }
    //    public  string UrlAddress { get; set; }

    //    public void SearchResultModel()
    //    {
            
    //    }
    //    public  void SearchResultModel(string title, string small, string url)
    //    {
    //        Title = title;
    //        SmallText = small;
    //        UrlAddress = url;
    //    }
        
    //}
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string SmallText { get; set; }
        public string UrlAddress { get; set; }
        public SearchResultModel()
        {
        }

        public SearchResultModel(string _Title, string _SmallText, string _UrlAddress)
        {
            UrlAddress = _UrlAddress;
            Title = _Title;
            SmallText = _SmallText;
        }
    }
}