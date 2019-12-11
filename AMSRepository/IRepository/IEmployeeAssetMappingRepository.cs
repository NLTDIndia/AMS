using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IEmployeeAssetMappingRepository
    {
        EmployeeAssetMapping CreateEmployeeAssetMapping(EmployeeAssetMapping employeeAssetMapping);

        EmployeeAssetMapping GetEmployeeAssetMappingByID(int employeeAssetMappingID);

        List<EmployeeAssetMapping> GetEmployeeAssetMappings();

        EmployeeAssetMapping UpdateEmployeeAssetMapping(EmployeeAssetMapping employeeAssetMapping);

        void DeleteEmployeeAssetMappingByID(int employeeAssetMappingID);
    }
}