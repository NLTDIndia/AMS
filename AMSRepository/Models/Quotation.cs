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
    
    public partial class Quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation()
        {
            this.PurchaseOrder = new HashSet<PurchaseOrder>();
        }
    
        public int ID { get; set; }
        public int VendorID { get; set; }
        public int AssetRequestID { get; set; }
        public string QuotationFilePath { get; set; }
        public int QuotationStatusID { get; set; }
        public Nullable<System.DateTime> QuotationReceivedDate { get; set; }
    
        public virtual AssetRequest AssetRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual QuotationStatus QuotationStatus { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
