using AMSRepository.Models;
using AMSUtilities.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AMSService.Service
{
    public interface IComponentsService
    {
        List<ComponentsModel> GetActiveComponents();

        int createComponents(ComponentsModel componentsModel);

        int UpdateComponents(ComponentsModel componentsModel);

        List<ComponentsModel> AllActiveComponents();

        List<ComponentsModel> GetAllComponents();

        ComponentsModel GetComponentsById(int id);

        ComponentsModel GetComponents(Components componentsModel, SelectList ddltypes);
    }
}