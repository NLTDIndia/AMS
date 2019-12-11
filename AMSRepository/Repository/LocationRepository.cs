using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public Location CreateLocation(Location location)
        {
            return Insert(location);
        }

        public Location UpdateLocation(Location location)
        {
            return Update(location);
        }

        public List<Location> GetLocations()
        {
            return GetAll();
        }

        public Location GetLocationByID(int locationID)
        {
            return GetByID(locationID);
        }
    }
}