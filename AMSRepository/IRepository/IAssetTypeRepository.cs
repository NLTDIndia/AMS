using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IAssetTypeRepository
    {
        AssetTypes CreateAssetType(AssetTypes assetType);

        List<AssetTypes> GetAssetTypes();

        AssetTypes GetAssetTypeByID(int assetTypeID);

        AssetTypes UpdateAssetType(AssetTypes assetType);
    }
}