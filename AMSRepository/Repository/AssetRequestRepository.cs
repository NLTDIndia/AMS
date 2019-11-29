using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
