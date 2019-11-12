
namespace AMSUtilities.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SoftwareAssetModel
    {
        public int ID { get; set; }
        public int AssetCategoryId { get; set; }
        public int AssetTypeID { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<int> ParentAssetID { get; set; }
        public bool IsParentAsset { get; set; }
        public int AssetStatusID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int AssetID { get; set; }
        public string ProductName { get; set; }
        public string LicenceNumber { get; set; }
        public System.DateTime LicencePurchaseDate { get; set; }
        public System.DateTime LicenceExpiryDate { get; set; }
        public string InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public string InvoiceFilePath { get; set; }
    }
}
