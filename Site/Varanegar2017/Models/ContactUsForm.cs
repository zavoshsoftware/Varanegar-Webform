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
    
    public partial class ContactUsForm
    {
        public System.Guid contactid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> fk_RecieverID { get; set; }
        public string CommentBody { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
        public string CommentIP { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    
        public virtual EmailRecieverRoles EmailRecieverRoles { get; set; }
    }
}