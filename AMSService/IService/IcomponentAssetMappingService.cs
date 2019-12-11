using AMSRepository.Models;
using AMSUtilities.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AMSService.Service
{
    public interface IComponentAssetMappingService
    {
        ComponentAssetMappingModel AssignComponents(ComponentAssetMappingModel componentAssetMappingModel);

        int CreateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);

        int CreateComponentMapping(ComponentAssetMappingModel componentAssetMappingModel);

        List<ComponentAssetMappingModel> GetComponentAssetMappings();

        List<ComponentAssetMappingModel> GetComponentAssetMappingsByAssetID(int assetID);

        ComponentAssetMappingModel GetComponentByID(int id);

        ComponentAssetMappingModel GetComponentModel(ComponentAssetMapping componentmapping);

        SelectList GetDropdownAssets(int ID, int selectedId = -1);

        ComponentAssetMappingModel UnassignComponents(ComponentAssetMappingModel componentAssetMappingModel);

        int UpdateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);

        ComponentAssetMappingModel GetComponentAssetMappingByComponentID(int id);
    }
}