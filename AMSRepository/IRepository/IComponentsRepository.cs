using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IComponentsRepository
    {
        List<Components> AllActiveComponents();

        Components CreateComponent(Components component);

        List<Components> GetComponents();

        Components GetComponentsByID(int componentID);

        Components UpdateComponent(Components component);
    }
}