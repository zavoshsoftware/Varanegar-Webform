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
    
    public partial class CustomerGroups
    {
        public CustomerGroups()
        {
            this.Customers = new HashSet<Customers>();
        }
    
        public System.Guid CustomerGroupID { get; set; }
        public string CustomerGroupTitle { get; set; }
        public string En_CustomerGroupTitle { get; set; }
        public string CustomerGroupName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
