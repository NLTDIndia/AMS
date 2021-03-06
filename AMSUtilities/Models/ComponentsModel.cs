﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class ComponentsModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Component Type Required")]
        [Display(Name = "Component Type")]
        public int ComponentTypeID { get; set; }

        [Required(ErrorMessage = "Component Name Required")]
        [Display(Name = "Component Name")]
        [Remote("IsComponentNameExist", "Components", AdditionalFields = "ID, ComponentTypeID", ErrorMessage = "Component name already exists")]
        public string ComponentName { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [Display(Name = "Component Type")]
        public string ComponentTypeName { get; set; }

        public string AssetTypeName { get; set; }
        public SelectList ComponentType { get; set; }

        [Display(Name = "Assigned Count")]
        public int AssignedCount { get; set; }

        public int UnAssignedCount { get; set; }
    }
}