using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface ILocationRepository
    {
        Location CreateLocation(Location location);

        Location GetLocationByID(int locationID);

        List<Location> GetLocations();

        Location UpdateLocation(Location location);
    }
}