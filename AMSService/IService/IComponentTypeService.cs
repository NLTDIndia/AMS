using AMSUtilities.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AMSService.Service
{
    public interface IComponentTypeService
    {
        ComponentTypeModel CreateComponentType(ComponentTypeModel ComponentTypeModel);

        List<ComponentTypeModel> GetActiveComponentTypes();

        ComponentTypeModel GetComponentTypeModel(int? Id = null, int assetTypeId = -1, int? assetCategoryId = -1);

        List<ComponentTypeModel> GetComponentTypes();

        SelectList GetDropdownComponentTypes(int selectedId = -1);

        ComponentTypeModel UpdateComponentType(ComponentTypeModel ComponentTypeModel);

        bool ComponentTypeStatus(int id, bool status);
    }
}