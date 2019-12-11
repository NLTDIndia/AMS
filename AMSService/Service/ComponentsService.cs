using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class ComponentsService : IComponentsService
    {
        private readonly IComponentsRepository _componentRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IComponentTypeService _componentTypeService;

        public ComponentsService(IComponentsRepository componentsRepository, IEmployeeService employeeService, IComponentTypeService componentTypeService)
        {
            _componentRepository = componentsRepository;
            _employeeService = employeeService;
            _componentTypeService = componentTypeService;
        }

        public List<ComponentsModel> GetActiveComponents()
        {
            var components = _componentRepository.GetComponents().Where(fet => fet.ComponentType.IsActive == true).ToList();
            ComponentsModel componentsModel = new ComponentsModel();
            if (components != null && components.Count > 0)
            {
                return components.Select(ac => new ComponentsModel
                {
                    ID = ac.ID,
                    ComponentName = ac.ComponentName,
                    Description = ac.Description,
                    ComponentTypeID = ac.ComponentTypeID
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
            componentsModel.ID = components.ID;

            return componentsModel.ID;
        }

        public int UpdateComponents(ComponentsModel componentsModel)
        {
            Components UpdateComponents = _componentRepository.GetComponentsByID(componentsModel.ID);

            if (UpdateComponents != null)
            {
                UpdateComponents.ID = componentsModel.ID;
                UpdateComponents.ComponentName = componentsModel.ComponentName;
                UpdateComponents.ComponentTypeID = componentsModel.ComponentTypeID;
                UpdateComponents.Description = componentsModel.Description;
            }
            UpdateComponents = _componentRepository.UpdateComponent(UpdateComponents);
            componentsModel.ID = UpdateComponents.ID;
            return componentsModel.ID;
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
                ComponentsModel componentsViewModel = new ComponentsModel
                {
                    ID = components.ID,
                    ComponentName = components.ComponentName,
                    ComponentTypeID = components.ComponentTypeID,
                    ComponentTypeName = components.ComponentType.Name,
                    Description = components.Description,
                    AssignedCount = components.ComponentAssetMapping.Where(cap => cap.ComponentStatusId == (int)AMSUtilities.Enums.ComponentStatus.Assign).Count(),
                    AssetTypeName = components.ComponentType.AssetTypes.Description
                };
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