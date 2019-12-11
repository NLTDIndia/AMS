using System;

namespace AMSUtilities.Models
{
    public class EmployeeAssetMappingModel
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}