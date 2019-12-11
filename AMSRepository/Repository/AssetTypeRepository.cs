using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class AssetTypeRepository : BaseRepository<AssetTypes>, IAssetTypeRepository
    {
        public AssetTypes CreateAssetType(AssetTypes assetType)
        {
            return Insert(assetType);
        }

        public AssetTypes UpdateAssetType(AssetTypes assetType)
        {
            return Update(assetType);
        }

        public List<AssetTypes> GetAssetTypes()
        {
            return GetAll();
        }

        public AssetTypes GetAssetTypeByID(int assetTypeID)
        {
            return GetByID(assetTypeID);
        }
    }
}