using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class AssetRequestRepository : BaseRepository<AssetRequest>, IAssetRequestRepository
    {
        public AssetRequest CreateAssetRequest(AssetRequest assetRequest)
        {
            return Insert(assetRequest);
        }

        public AssetRequest UpdateAssetRequest(AssetRequest assetRequest)
        {
            return Update(assetRequest);
        }

        public List<AssetRequest> GetAssetRequests()
        {
            return GetAll();
        }

        public AssetRequest GetAssetRequestByID(int assetRequestID)
        {
            return GetByID(assetRequestID);
        }
    }
}