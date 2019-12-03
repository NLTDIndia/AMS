using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Enums;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public class ComponentAssetMappingService : IComponentAssetMappingService
    {
        private readonly IComponentAssetMappingRepository _componentAssetMappingRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IComponentsService _componentsService;

        public ComponentAssetMappingService(IComponentAssetMappingRepository componentAssetMappingRepository, IAssetRepository assetRepository, IEmployeeService employeeService, IComponentsService componentsService)
        {
            _componentAssetMappingRepository = componentAssetMappingRepository;
            _assetRepository = assetRepository;
            _employeeService = employeeService;
            _componentsService = componentsService;


        }
        public int CreateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping)
        {
            ComponentAssetMapping componentMapping = new ComponentAssetMapping
            {
              ComponentID = componentAssetMapping.ComponentID,
              AssignedAssetID = componentAssetMapping.AssignedAssetID,
              ActualAssetID  = componentAssetMapping.ActualAssetID,
              ComponentStatusId = componentAssetMapping.ComponentStatusId,
              CreatedBy = componentAssetMapping.CreatedBy,
              CreatedDate= componentAssetMapping.CreatedDate,
              AssignedBy= componentAssetMapping.AssignedBy,
              AssignedDate=componentAssetMapping.AssignedDate,
              ComponentTypeID = componentAssetMapping.ComponentTypeID
            };
            var objcomponentMapping = this._componentAssetMappingRepository.CreateComponentAssetMapping(componentMapping);

            return objcomponentMapping.ID;
        }
        public int UpdateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping)
        {
            ComponentAssetMapping componentAsset = _componentAssetMappingRepository.GetComponentAssetMappingByID(componentAssetMapping.ID);
            if (componentAssetMapping.ID == 0)
            {
                componentAssetMapping.CreatedDate = DateTime.Now;
                componentAssetMapping.CreatedBy = (int)componentAssetMapping.AssignedBy;
                componentAssetMapping.ComponentTypeID = componentAssetMapping.ComponentTypeID;
                componentAssetMapping.ID=CreateComponentAssetMapping(componentAssetMapping);
            }
            else if (componentAsset != null)
            {
                componentAsset.ComponentID = componentAssetMapping.ComponentID;
                componentAsset.AssignedAssetID = componentAssetMapping.AssignedAssetID;
                componentAsset.ActualAssetID = componentAssetMapping.ActualAssetID;
                componentAsset.ComponentStatusId = componentAssetMapping.ComponentStatusId;
                componentAsset.AssignedBy = componentAssetMapping.AssignedBy;
                componentAsset.AssignedDate = componentAssetMapping.AssignedDate;
                componentAsset.ComponentTypeID = componentAssetMapping.ComponentTypeID;
                _componentAssetMappingRepository.UpdateComponentAssetMapping(componentAsset);
            }
            return componentAssetMapping.ID;
        }

        public List<ComponentAssetMappingModel> GetComponentAssetMappingsByAssetID(int assetID)
        {
            var componentAssets = _componentAssetMappingRepository.GetComponentAssetMappingsByAssetID(assetID);
            if (componentAssets != null && componentAssets.Count > 0)
            {
                return componentAssets.Select(cam => new ComponentAssetMappingModel
                {
                   ID=cam.ID,
                   ComponentID = cam.ComponentID,
                   AssignedAssetID = cam.AssignedAssetID,
                   ActualAssetID = cam.ActualAssetID,
                   ComponentStatusId = cam.ComponentStatusId,
                   AssignedBy = cam.AssignedBy,
                   AssignedDate = cam.AssignedDate,
                   ComponentTypeID=cam.Components.ComponentTypeID,
                   AssetCategoryId = cam.Assets.AssetTypes.AssetCategoryID,
                }).ToList();
            }
            else
            {
                return new List<ComponentAssetMappingModel> { };
            }
        }

        public List<ComponentAssetMappingModel> GetComponentAssetMappings()
        {
            var getComponents = this._componentAssetMappingRepository.GetComponentAssetMappings();
            List<ComponentAssetMappingModel> getAllComponents = new List<ComponentAssetMappingModel>();
            getComponents.ForEach(componentmapping =>
            {
                ComponentAssetMappingModel componentsViewModel = new ComponentAssetMappingModel();
                componentsViewModel.ID = componentmapping.ID;
                componentsViewModel.ComponentName = componentmapping.Components.ComponentName;
                componentsViewModel.ComponentID = componentmapping.ComponentID;
                componentsViewModel.ComponentTypeName = componentmapping.ComponentType.Name;
                componentsViewModel.AssignedAssetID = componentmapping.AssignedAssetID;
                componentsViewModel.ComponentStatusId = componentmapping.ComponentStatusId;               
                if (componentsViewModel.AssignedAssetID != null && componentsViewModel.ComponentStatusId == (int)ComponentTrackingStatus.Assign)
                {
                    if(componentmapping.Assets1 != null)
                    {
                        componentsViewModel.AssetName = componentmapping.Assets1.AssetName;
                    }
                    else if(componentmapping.Assets != null)
                    {
                        componentsViewModel.AssetName = componentmapping.Assets.AssetName;
                    }
                }
                getAllComponents.Add(componentsViewModel);
            });
            
            return getAllComponents;
        }
        public ComponentAssetMappingModel GetComponentByID(int id)
        {
            var componentmapping = _componentAssetMappingRepository.GetComponentAssetMappingByID(id);
            if (componentmapping != null)
            {
              
                return GetComponentModel(componentmapping);;
            }
            else
            {
                return new ComponentAssetMappingModel { };
            }
        }
      
        public ComponentAssetMappingModel UnassignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            ComponentAssetMapping unassignComponents = _componentAssetMappingRepository.GetComponentAssetMappingByID(componentAssetMappingModel.ID);
            if (unassignComponents != null)
            {
                unassignComponents.ComponentStatusId = Convert.ToInt32(AMSUtilities.Enums.ComponentTrackingStatus.Unassign);
                unassignComponents.AssignedAssetID = null;
            }
            _componentAssetMappingRepository.UpdateComponentAssetMapping(unassignComponents);
             return componentAssetMappingModel;
        }
        public ComponentAssetMappingModel GetComponentModel(ComponentAssetMapping componentmapping)
        {

            var componentStatusID = componentmapping.ComponentStatusId;

            ComponentAssetMappingModel componetModel = new ComponentAssetMappingModel
            {
                ID = componentmapping.ID,
                ComponentName = componentmapping.Components.ComponentName,
                ComponentID = componentmapping.ComponentID,
                ComponentTypeID = componentmapping.Components.ComponentTypeID,
                ComponentTypeName = componentmapping.Components.ComponentType.Name,

            };
            if (componentStatusID == (int)AMSUtilities.Enums.ComponentTrackingStatus.Assign)
            {
                if (componentmapping.Assets != null)
                {
                    componetModel.AssetName = componentmapping.Assets.AssetName;
                }
                else if (componentmapping.Assets1 != null)
                {
                    componetModel.AssetName = componentmapping.Assets1.AssetName;
                }

            }

            return componetModel;
        }
        public SelectList GetDropdownAssets(int ID,int selectedId = -1)
        {
            var AssignedAssetIDlist = _componentAssetMappingRepository.GetComponentAssetMappings().Where(cp => cp.ComponentID == ID && cp.ComponentStatusId == (int)ComponentTrackingStatus.Assign).Select(cps=> cps.AssignedAssetID).ToList();
                      
              var   Assets = _assetRepository.GetAssets().Where(ast => !AssignedAssetIDlist.Contains(ast.ID)).ToList();
            
            List<SelectListItem> AssetsItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Asset", Value = "" } };
            
              
            if (Assets != null && Assets.Count > 0)
            {
                
                Assets.ForEach(at =>
                {                    
                    AssetsItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.AssetName, Value = at.ID.ToString() });
                });
            }

            return new SelectList(AssetsItems, "Value", "Text");
        }
        public int CreateComponentMapping(ComponentAssetMappingModel componentAssetMappingModel)
        {
            ComponentAssetMapping componentMapping = new ComponentAssetMapping
            {
                ComponentID = componentAssetMappingModel.ComponentID,
                ComponentStatusId = componentAssetMappingModel.ComponentStatusId,
                CreatedBy = componentAssetMappingModel.CreatedBy,
                CreatedDate = componentAssetMappingModel.CreatedDate,
                ComponentTypeID = componentAssetMappingModel.ComponentTypeID
            };
            var createComponentMapping = this._componentAssetMappingRepository.CreateComponentAssetMapping(componentMapping);

            return createComponentMapping.ID;
        }

        public ComponentAssetMappingModel GetComponentAssetMappingByComponentID(int id)
        {
            if(id != 0)
            {
                var componentmapping = _componentAssetMappingRepository.GetComponentAssetMappingsByComponentID(id).FirstOrDefault();
                if (componentmapping != null)
                {

                    return GetComponentModel(componentmapping); 
                }
                else
                {

                    var comp = _componentsService.GetComponentsById(id);
                    ComponentAssetMappingModel newmodel = new ComponentAssetMappingModel()
                    {
                        ComponentID = comp.ID,
                        ComponentTypeID = comp.ComponentTypeID,
                        ComponentName = comp.ComponentName,
                        ComponentTypeName = comp.ComponentTypeName
                    };


                    return newmodel;
                }
            }
            else
            {
                return new ComponentAssetMappingModel { };
            }
            
        }
        public ComponentAssetMappingModel AssignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            ComponentAssetMapping assigncomponents = new ComponentAssetMapping
            {
                ComponentID = componentAssetMappingModel.ComponentID,
                AssignedAssetID = componentAssetMappingModel.AssignedAssetID,
                AssignedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                AssignedDate = DateTime.Now,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                CreatedDate = DateTime.Now,
                ComponentTypeID = componentAssetMappingModel.ComponentTypeID,
                ComponentStatusId = Convert.ToInt32(AMSUtilities.Enums.ComponentTrackingStatus.Assign),
            };

            _componentAssetMappingRepository.CreateComponentAssetMapping(assigncomponents);
            return componentAssetMappingModel;
        }
    }
}
