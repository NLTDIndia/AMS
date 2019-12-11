using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IAssetPurchaseOrderMappingRepository
    {
        AssetPurchaseOrderMapping CreateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping);

        AssetPurchaseOrderMapping GetAssetPurchaseOrderMappingByID(int assetPurchaseOrderMappingID);

        List<AssetPurchaseOrderMapping> GetAssetPurchaseOrderMappings();

        AssetPurchaseOrderMapping UpdateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping);
    }
}