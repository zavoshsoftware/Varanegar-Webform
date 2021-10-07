using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Varanegar2017.Models;

namespace Varanegar.Classes
{
    public static class TextData
    {
        public static List<string> ReturnTextTitleAndBody(int textID)
        {
            using (VaranegarEntities db = new VaranegarEntities())
            {
                var n = (from a in db.Texts
                         where a.TextID == textID
                         select a).FirstOrDefault();

                List<string> returnList = new List<string>();
                returnList.Add(n.TextTitle);
                returnList.Add(n.TextBody);

                return returnList;
            }
        }
    }
}