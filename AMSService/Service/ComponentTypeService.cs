﻿using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class ComponentTypeService : IComponentTypeService
    {
        private readonly IComponentTypeRepository _componentTypeRepository;
        private readonly IAssetCategoryService _assetCategoryService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IEmployeeService _employeeService;
        public ComponentTypeService(IComponentTypeRepository componentTypeRepository,
            IAssetCategoryService assetCategoryService,
            IAssetTypeService assetTypeService,
            IEmployeeService employeeService)
        {
            _componentTypeRepository = componentTypeRepository;
            _assetCategoryService = assetCategoryService;
            _assetTypeService = assetTypeService;
            _employeeService = employeeService;
        }

        public ComponentTypeModel GetComponentTypeModel(int? Id = null, int assetTypeId = -1, int? assetCategoryId = -1)
        {
            if (Id.HasValue)
            {
                ComponentType componentType = _componentTypeRepository.GetComponentTypeByID(Id.Value);
                if (componentType != null)
                {
                    return new ComponentTypeModel
                    {
                        ID = componentType.ID,
                        Name = componentType.Name,
                        IsActive = componentType.IsActive,
                        Mandatory = componentType.Mandatory,
                        AssetTypeID = componentType.AssetTypeID,
                        AssetTypes = _assetTypeService.GetDropdownAssetTypes(componentType.AssetTypes.AssetCategoryID, componentType.AssetTypeID),
                        ComponentCategory = componentType.ComponentCategory.Value,
                        ComponentCategories = GetComponentCategories(componentType.ComponentCategory.Value)
                    };
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
            else
            {
                return new ComponentTypeModel
                {
                    AssetTypes = _assetTypeService.GetDropdownAssetTypes(assetCategoryId, assetTypeId),
                    ComponentCategories = GetComponentCategories()

                };
            }
        }

        private static SelectList GetComponentCategories(int selectedId = -1)
        {
            return new SelectList(new List<SelectListItem> { 
                new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Component Category", Value = "" }, 
                new SelectListItem { Selected = selectedId == (int)ComponentCategory.Hardware ? true : false, Text = ComponentCategory.Hardware.ToString(), Value = Convert.ToString( (int)ComponentCategory.Hardware) }, 
                new SelectListItem { Selected = selectedId == (int)ComponentCategory.Software ? true : false, Text = ComponentCategory.Software.ToString(), Value = Convert.ToString( (int)ComponentCategory.Software) }
            }, "Value", "Text");
        }

        public ComponentTypeModel CreateComponentType(ComponentTypeModel componentTypeModel)
        {
            try
            {
                ComponentType ComponentType = new ComponentType
                {
                    Name = componentTypeModel.Name,
                    IsActive = componentTypeModel.IsActive,
                    Mandatory = componentTypeModel.Mandatory,
                    AssetTypeID = componentTypeModel.AssetTypeID,
                    ComponentCategory = componentTypeModel.ComponentCategory,
                    CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                    CreatedDate = DateTime.Now
                };
                _componentTypeRepository.CreateComponentType(ComponentType);
                return componentTypeModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ComponentTypeModel UpdateComponentType(ComponentTypeModel componentTypeModel)
        {

            ComponentType componentType = _componentTypeRepository.GetComponentTypeByID(componentTypeModel.ID);
            if (componentType != null)
            {
                componentType.Name = componentTypeModel.Name;
                componentType.AssetTypeID = componentTypeModel.AssetTypeID;
                componentType.ComponentCategory = componentTypeModel.ComponentCategory;
                componentType.IsActive = componentTypeModel.IsActive;
                componentType.Mandatory = componentTypeModel.Mandatory;

            }
            _componentTypeRepository.UpdateComponentType(componentType);
            return componentTypeModel;
        }

        public bool ComponentTypeStatus(int id, bool status)
        {
            ComponentType componentType = _componentTypeRepository.GetComponentTypeByID(id);
            if (componentType != null)
            {
                componentType.IsActive = status;
                _componentTypeRepository.UpdateComponentType(componentType);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ComponentTypeModel> GetComponentTypes()

        {
            var ComponentTypes = _componentTypeRepository.GetComponentTypes();
            return GetComponentTypesModel(ComponentTypes);

        }

        public List<ComponentTypeModel> GetActiveComponentTypes()

        {
            var ComponentTypes = _componentTypeRepository.GetComponentTypes().Where(ct => ct.IsActive == true).ToList();
            return GetComponentTypesModel(ComponentTypes);

        }

        public SelectList GetDropdownComponentTypes(int selectedId = -1)
        {
            List<SelectListItem> componenttypes = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Component Type", Value = "" } };
            var components = _componentTypeRepository.GetComponentTypes().Where(ct=>ct.IsActive== true).ToList();
            if (components != null && components.Count > 0)
            {
                components.ForEach(ct =>
                {
                    componenttypes.Add(new SelectListItem { Selected = selectedId == ct.ID ? true : false, Text = ct.Name + " - " + ct.AssetTypes.Description, Value = ct.ID.ToString() });
                });
            }

            return new SelectList(componenttypes, "Value", "Text");
        }

        private static List<ComponentTypeModel> GetComponentTypesModel(List<ComponentType> componentTypes)
        {
            if (componentTypes != null && componentTypes.Count > 0)
            {
                return componentTypes.Select(ct => new ComponentTypeModel
                {
                    ID = ct.ID,
                    Name = ct.Name,
                    IsActive = ct.IsActive,
                    Mandatory = ct.Mandatory,
                    AssetTypeID = ct.AssetTypeID,
                    AssetTypeName = ct.AssetTypes.Description,
                    ComponentCategory = ct.ComponentCategory.Value,
                    ComponentCategoryName = ct.ComponentCategory.Value == (int)ComponentCategory.Hardware ? ComponentCategory.Hardware.ToString() : ComponentCategory.Software.ToString()
                }).ToList();
            }
            else
            {
                return new List<ComponentTypeModel> { };
            }
        }
    }
}
