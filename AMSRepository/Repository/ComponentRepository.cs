using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class ComponentRepository : BaseRepository<Components>, IComponentRepository
    {
        public Components CreateComponent(Components component)
        {
            return Insert(component);
        }

        public Components UpdateComponent(Components component)
        {
            return Update(component);
        }

        public List<Components> GetComponents()
        {
            return GetAll();
        }

        public Components GetComponentsByID(int componentID)
        {
            return GetByID(componentID);
        }
    }
}