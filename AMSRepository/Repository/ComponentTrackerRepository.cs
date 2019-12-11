using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class ComponentTrackerRepository : BaseRepository<ComponentTracker>, IComponentTrackerRepository
    {
        public ComponentTracker CreateComponentTracker(ComponentTracker componentTracker)
        {
            return Insert(componentTracker);
        }

        public ComponentTracker UpdateComponentTracker(ComponentTracker componentTracker)
        {
            return Update(componentTracker);
        }

        public List<ComponentTracker> GetComponentTrackers()
        {
            return GetAll();
        }

        public ComponentTracker GetComponentTrackerByID(int componentTrackerID)
        {
            return GetByID(componentTrackerID);
        }
    }
}