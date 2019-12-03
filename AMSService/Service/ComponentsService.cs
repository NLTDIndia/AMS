using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMSUtilities.Models;
using AMSRepository.Models;
using AMSRepository.Repository;
using System.Web.Mvc;
using System.Web;

namespace AMSService.Service
{
    public class ComponentsService : IComponentsService
    {
       private readonly IComponentsRepository _componentRepository;
       private readonly IEmployeeService _employeeService;
       private readonly IComponentTypeService _componentTypeService;
       private readonly IComponentAssetMappingService _componentAssetMappingService;
       public ComponentsService(IComponentsRepository componentsRepository, IEmployeeService employeeService, IComponentTypeService componentTypeService,IComponentAssetMappingService componentAssetMappingService)
        {
            _componentRepository = componentsRepository;
            _employeeService = employeeService;
            _componentTypeService = componentTypeService;
            _componentAssetMappingService = componentAssetMappingService;
        }
        public List<ComponentsModel> GetActiveComponents()
        {
            var components = _componentRepository.GetComponents().Where(fet=>fet.ComponentType.IsActive==true).ToList();
            ComponentsModel componentsModel = new ComponentsModel();
            if (components != null && components.Count > 0)
            {
                return components.Select(ac => new ComponentsModel
                {
                    ID=ac.ID,
                    ComponentName = ac.ComponentName,
                    Description = ac.Description,
                    ComponentTypeID=ac.ComponentTypeID
                }).ToList();
            }
            else
            {
                return new List<ComponentsModel> { };
            }
        }
        public int createComponents(ComponentsModel componentsModel)
        {

             var components = _componentRepository.CreateComponent(new Components
                {
                    ComponentName = componentsModel.ComponentName,
                    ComponentTypeID = componentsModel.ComponentTypeID,
                    Description = componentsModel.Description,
                    CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                    CreatedDate = DateTime.Now,

                });
                
           
            return componentsModel.ID;
        }
        public string UpdateComponents(ComponentsModel componentsModel)
        {

            Components UpdateComponents = _componentRepository.GetComponentsByID(componentsModel.ID);

            if (UpdateComponents != null)
            {
                UpdateComponents.ID = componentsModel.ID;
                UpdateComponents.ComponentName = componentsModel.ComponentName;
                UpdateComponents.ComponentTypeID = componentsModel.ComponentTypeID;
                UpdateComponents.Description = componentsModel.Description;
            }
            _componentRepository.UpdateComponent(UpdateComponents);
            return componentsModel.ToString();
        }
        public int GetLoginEmployeeId()
        {
            return _employeeService.GetEmployeeId();
        }
        public List<ComponentsModel> AllActiveComponents()
        {
            var components = _componentRepository.AllActiveComponents();

            if (components != null && components.Count > 0)
            {
                return components.Select(ac => new ComponentsModel
                {
                    ComponentName = ac.ComponentName

                }).ToList();
            }
            else
            {
                return new List<ComponentsModel> { };
            }
        }

        public List<ComponentsModel> GetAllComponents()
        {
            var getComponents = this._componentRepository.GetComponents();
            List<ComponentsModel> getAllComponents = new List<ComponentsModel>();
            getComponents.ForEach(components =>
            {
                ComponentsModel componentsViewModel = new ComponentsModel();
                componentsViewModel.ID = components.ID;
                componentsViewModel.ComponentName = components.ComponentName;
                componentsViewModel.ComponentTypeID = components.ComponentTypeID;
                componentsViewModel.ComponentTypeName = components.ComponentType.Name;
                componentsViewModel.Description = components.Description;
                componentsViewModel.AssignedCount = components.ComponentAssetMapping.Where(cap => cap.ComponentStatusId == (int)AMSUtilities.Enums.ComponentStatus.Assign).Count();
                componentsViewModel.UnAssignedCount = components.ComponentAssetMapping.Where(cap => cap.ComponentStatusId == (int)AMSUtilities.Enums.ComponentStatus.Unassign).Count();
                getAllComponents.Add(componentsViewModel);
            });
            return getAllComponents;

        }

        public ComponentsModel GetComponentsById(int id)
        {
            var getComponentsbyID = _componentRepository.GetComponentsByID(id);
            if (getComponentsbyID != null)
            {
                var ddltypes = _componentTypeService.GetDropdownComponentTypes();
                return GetComponents(getComponentsbyID, ddltypes);
            }
            else
            {
                _componentTypeService.GetDropdownComponentTypes();
                return new ComponentsModel { };
            }
        }

        public ComponentsModel GetComponents(Components componentsModel, SelectList ddltypes)
        {
            ComponentsModel componetModel = new ComponentsModel
            {
                ID = componentsModel.ID,
                ComponentName = componentsModel.ComponentName,              
                Description = componentsModel.Description,
                ComponentType = ddltypes,
                ComponentTypeID = componentsModel.ComponentTypeID,
                ComponentTypeName = componentsModel.ComponentType.Name,
            };

            return componetModel;
        }
    }
}
