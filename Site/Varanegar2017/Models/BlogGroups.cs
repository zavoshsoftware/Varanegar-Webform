//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Varanegar2017.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogGroups
    {
        public BlogGroups()
        {
            this.Blogs = new HashSet<Blogs>();
        }
    
        public System.Guid BlogGroupID { get; set; }
        public string BlogGroupTitle { get; set; }
        public string En_BlogGroupTitle { get; set; }
        public string BlogGroupName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<int> Priority { get; set; }
    
        public virtual ICollection<Blogs> Blogs { get; set; }
    }
}
