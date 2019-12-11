using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IHardwareAssetRepository
    {
        HardwareAssets CreateHardwareAsset(HardwareAssets assets);

        HardwareAssets GetHardwareAssetByID(int hardwareAssetID);

        List<HardwareAssets> GetHardwareAssets();

        HardwareAssets UpdateHardwareAsset(HardwareAssets asset);

        HardwareAssets GetHardwareAssetByAssetID(int assetID);
    }
}