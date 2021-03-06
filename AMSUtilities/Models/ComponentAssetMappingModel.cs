﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class ComponentAssetMappingModel
    {
        public int ID { get; set; }
        public string ComponentTypeName { get; set; }
        public int ComponentID { get; set; }
        public int ComponentTypeID { get; set; }

        [Required(ErrorMessage = "Asset is required")]
        public int? AssignedAssetID { get; set; }

        public int? ActualAssetID { get; set; }
        public DateTime? AssignedDate { get; set; }
        public int? AssignedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ComponentStatusId { get; set; }
        public int AssetCategoryId { get; set; }
        public SelectList Assets { get; set; }
        public SelectList Components { get; set; }
        public SelectList ComponentStatus { get; set; }
        public string ComponentName { get; set; }
        public string AssetName { get; set; }
    }
}