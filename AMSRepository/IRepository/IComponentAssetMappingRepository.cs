using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IComponentAssetMappingRepository
    {
        ComponentAssetMapping CreateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
        ComponentAssetMapping GetComponentAssetMappingByID(int componentAssetMappingID);
        List<ComponentAssetMapping> GetComponentAssetMappings();
        List<ComponentAssetMapping> GetComponentAssetMappingsByAssetID(int assetID);
        List<ComponentAssetMapping> GetComponentAssetMappingsByComponentID(int componentId);
        ComponentAssetMapping UpdateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
    }
}