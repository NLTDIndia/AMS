//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMSRepository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SoftwareAssets
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public string ProductName { get; set; }
        public string LicenceNumber { get; set; }
        public Nullable<System.DateTime> LicencePurchaseDate { get; set; }
        public Nullable<System.DateTime> LicenceExpiryDate { get; set; }
        public string Comment { get; set; }
    
        public virtual Assets Assets { get; set; }
    }
}
