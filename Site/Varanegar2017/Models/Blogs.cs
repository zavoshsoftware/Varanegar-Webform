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
    
    public partial class Blogs
    {
        public Blogs()
        {
            this.BlogComments = new HashSet<BlogComments>();
        }
    
        public System.Guid BlogID { get; set; }
        public Nullable<System.Guid> fk_BlogGroupID { get; set; }
        public string BlogTitle { get; set; }
        public string En_BlogTitle { get; set; }
        public string BlogName { get; set; }
        public string BlogImage { get; set; }
        public string BlogBody { get; set; }
        public string En_BlogBody { get; set; }
        public Nullable<int> Visit { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public string summeryText { get; set; }
        public string En_summeryText { get; set; }
    
        public virtual ICollection<BlogComments> BlogComments { get; set; }
        public virtual BlogGroups BlogGroups { get; set; }
    }
}