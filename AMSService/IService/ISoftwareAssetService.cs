using AMSUtilities.Models;
using System.Collections.Generic;

namespace AMSService.Service
{
    public interface ISoftwareAssetService
    {
        int CreateSoftwareAsset(SoftwareAssetModel softwareAssetModel);

        List<SoftwareAssetModel> GetAssetCategories();

        int UpdateSoftwareAsset(SoftwareAssetModel softwareAssetModel);

        SoftwareAssetModel GetSoftwareAssetByAssetID(int assetID);
    }
}