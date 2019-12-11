using AMSUtilities.Models;
using System.Collections.Generic;

namespace AMSService.Service
{
    public interface IHardwareAssetService
    {
        int CreateHardwareAsset(HardwareAssetModel hardwareAssetModel);

        List<HardwareAssetModel> GetAssetCategories();

        HardwareAssetModel GetHardwareAssetByAssetID(int assetID);

        int UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel);
    }
}