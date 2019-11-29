using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IAssetRequestRepository
    {
        AssetRequest CreateAssetRequest(AssetRequest assetRequest);
        AssetRequest GetAssetRequestByID(int assetRequestID);
        List<AssetRequest> GetAssetRequests();
        AssetRequest UpdateAssetRequest(AssetRequest assetRequest);
    }
}