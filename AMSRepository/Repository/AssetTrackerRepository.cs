using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class AssetTrackerRepository : BaseRepository<AssetTracker>, IAssetTrackerRepository
    {
        public AssetTracker CreateAssetTracker(AssetTracker assetTracker)
        {
            return Insert(assetTracker);
        }

        public AssetTracker UpdateAssetTracker(AssetTracker assetTracker)
        {
            return Update(assetTracker);
        }

        public List<AssetTracker> GetAssetTrackers()
        {
            return GetAll();
        }

        public AssetTracker GetAssetTrackerByID(int assetTrackerID)
        {
            return GetByID(assetTrackerID);
        }
    }
}