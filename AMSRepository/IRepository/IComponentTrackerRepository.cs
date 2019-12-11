using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IComponentTrackerRepository
    {
        ComponentTracker CreateComponentTracker(ComponentTracker componentTracker);

        ComponentTracker GetComponentTrackerByID(int componentTrackerID);

        List<ComponentTracker> GetComponentTrackers();

        ComponentTracker UpdateComponentTracker(ComponentTracker componentTracker);
    }
}