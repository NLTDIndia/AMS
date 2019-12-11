using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class AssetRepository : BaseRepository<Assets>, IAssetRepository
    {
        public Assets CreateAsset(Assets asset)
        {
            return Insert(asset);
        }

        public Assets UpdateAsset(Assets asset)
        {
            return Update(asset);
        }

        public List<Assets> GetAssets()
        {
            return GetAll();
        }

        public Assets GetAssetByID(int assetID)
        {
            return GetByID(assetID);
        }
    }
}