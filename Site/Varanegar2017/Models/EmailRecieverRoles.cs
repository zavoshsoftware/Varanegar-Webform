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
    
    public partial class EmailRecieverRoles
    {
        public EmailRecieverRoles()
        {
            this.ContactUsForm = new HashSet<ContactUsForm>();
            this.DemoRequests = new HashSet<DemoRequests>();
            this.Emails = new HashSet<Emails>();
        }
    
        public int EmailRecieverRoleID { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<int> groupdid { get; set; }
    
        public virtual ICollection<ContactUsForm> ContactUsForm { get; set; }
        public virtual ICollection<DemoRequests> DemoRequests { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
    }
}
