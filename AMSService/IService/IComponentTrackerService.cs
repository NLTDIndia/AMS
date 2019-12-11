using AMSUtilities.Models;
using System.Collections.Generic;

namespace AMSService.Service
{
    public interface IComponentTrackerService
    {
        int CreateComponentTracker(ComponentTrackerModel componentTrackerModel);

        List<ComponentTrackerModel> GetAssetCategories();
    }
}