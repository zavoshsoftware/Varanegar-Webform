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
    
    public partial class Resumes
    {
        public System.Guid resumeid { get; set; }
        public string resumeFile { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public string submitIP { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
    }
}
