using System;

namespace AMSUtilities.Models
{
    public class AssetTrackerModel
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int? EmpID { get; set; }
        public int AssetStatusID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Remarks { get; set; }
    }
}