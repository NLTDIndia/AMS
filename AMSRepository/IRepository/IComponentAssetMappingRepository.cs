using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IComponentAssetMappingRepository
    {
        ComponentAssetMapping CreateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
        ComponentAssetMapping GetComponentAssetMappingByID(int componentAssetMappingID);
        List<ComponentAssetMapping> GetComponentAssetMappings();
        ComponentAssetMapping UpdateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
    }
}