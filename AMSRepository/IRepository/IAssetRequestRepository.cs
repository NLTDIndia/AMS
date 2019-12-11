using AMSRepository.Models;
using System.Collections.Generic;

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