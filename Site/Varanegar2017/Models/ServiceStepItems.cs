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
    
    public partial class ServiceStepItems
    {
        public System.Guid ServiceStepItemID { get; set; }
        public string ServiceStepItemTitle { get; set; }
        public string En_ServiceStepItemTitle { get; set; }
        public Nullable<System.Guid> fk_ServiceStepID { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
    
        public virtual ServiceSteps ServiceSteps { get; set; }
    }
}