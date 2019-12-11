using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IComponentTypeRepository
    {
        ComponentType CreateComponentType(ComponentType componentType);

        List<ComponentType> GetComponentTypes();

        ComponentType GetComponentTypeByID(int componentTypeID);

        ComponentType UpdateComponentType(ComponentType componentType);
    }
}