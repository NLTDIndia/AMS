using AMSRepository.Models;
using System.Collections.Generic;
using System.Linq;

namespace AMSRepository.Repository
{
    public class HardwareAssetRepository : BaseRepository<HardwareAssets>, IHardwareAssetRepository
    {
        public List<HardwareAssets> GetHardwareAssets()
        {
            return GetAll();
        }

        public HardwareAssets CreateHardwareAsset(HardwareAssets hardwareAsset)
        {
            return Insert(hardwareAsset);
        }

        public HardwareAssets UpdateHardwareAsset(HardwareAssets hardwareAsset)
        {
            return Update(hardwareAsset);
        }

        public HardwareAssets GetHardwareAssetByID(int hardwareAssetID)
        {
            return GetByID(hardwareAssetID);
        }

        public HardwareAssets GetHardwareAssetByAssetID(int assetID)
        {
            return context.HardwareAssets.Where(fet => fet.AssetID == assetID).FirstOrDefault();
        }
    }
}