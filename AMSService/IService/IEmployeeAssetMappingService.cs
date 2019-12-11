using AMSUtilities.Models;
using System.Collections.Generic;

namespace AMSService.Service
{
    public interface IEmployeeAssetMappingService
    {
        List<EmployeeAssetMappingModel> GetEmployeeAssetMappingsDetails();

        List<EmployeeAssetMappingModel> GetEmployeeAssetMappingsModel();

        //int CreateEmployeeAssetMapping(EmployeeAssetMappingModel EmployeeAssetMappingModel);
        //void DeleteEmployeeAssetMapping(int Id);
    }
}