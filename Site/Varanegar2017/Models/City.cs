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
    
    public partial class City
    {
        public int CityID { get; set; }
        public int ProvinceID { get; set; }
        public string CityName { get; set; }
        public Nullable<bool> Center { get; set; }
        public string EN_CityName { get; set; }
        public string Rus_CityName { get; set; }
        public string China_CityName { get; set; }
    
        public virtual Province Province { get; set; }
    }
}
