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
    
    public partial class Users
    {
        public Users()
        {
            this.Images = new HashSet<Images>();
        }
    
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastFamily { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> fk_RoleID { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegisterIP { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    
        public virtual ICollection<Images> Images { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
