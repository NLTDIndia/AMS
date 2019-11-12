
namespace AMSUtilities.Models
{
    using System;
    using System.Collections.Generic;

    public partial class HardwareAssetModel
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
        public string Model { get; set; }
        public string ServiceTag { get; set; }
        public string Manufacturer { get; set; }
        public System.DateTime WarrantyStartDate { get; set; }
        public System.DateTime WarrantyEndDate { get; set; }
        public string InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public string InvoiceFilePath { get; set; }

    }
}
