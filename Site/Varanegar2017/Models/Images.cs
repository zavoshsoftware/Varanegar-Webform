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
    
    public partial class Images
    {
        public int ImageID { get; set; }
        public string ImageTitle { get; set; }
        public string ImgUrlAddress { get; set; }
        public Nullable<System.DateTime> ImgLastUpdateDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
        public Nullable<int> fk_ImageGroupID { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ImageGroups ImageGroups { get; set; }
        public virtual Users Users { get; set; }
    }
}
