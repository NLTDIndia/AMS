using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class AssetPurchaseOrderMappingRepository : BaseRepository<AssetPurchaseOrderMapping>, IAssetPurchaseOrderMappingRepository
    {
        public AssetPurchaseOrderMapping CreateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping)
        {
            return Insert(assetPurchaseOrderMapping);
        }

        public AssetPurchaseOrderMapping UpdateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping)
        {
            return Update(assetPurchaseOrderMapping);
        }

        public List<AssetPurchaseOrderMapping> GetAssetPurchaseOrderMappings()
        {
            return GetAll();
        }

        public AssetPurchaseOrderMapping GetAssetPurchaseOrderMappingByID(int assetPurchaseOrderMappingID)
        {
            return GetByID(assetPurchaseOrderMappingID);
        }
    }
}