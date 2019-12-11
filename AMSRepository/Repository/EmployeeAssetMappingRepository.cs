using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public class EmployeeAssetMappingRepository : BaseRepository<EmployeeAssetMapping>, IEmployeeAssetMappingRepository
    {
        public EmployeeAssetMapping CreateEmployeeAssetMapping(EmployeeAssetMapping employeeAssetMapping)
        {
            return Insert(employeeAssetMapping);
        }

        public EmployeeAssetMapping UpdateEmployeeAssetMapping(EmployeeAssetMapping employeeAssetMapping)
        {
            return Update(employeeAssetMapping);
        }

        public List<EmployeeAssetMapping> GetEmployeeAssetMappings()
        {
            return GetAll();
        }

        public EmployeeAssetMapping GetEmployeeAssetMappingByID(int employeeAssetMappingID)
        {
            return GetByID(employeeAssetMappingID);
        }

        public void DeleteEmployeeAssetMappingByID(int employeeAssetMappingID)
        {
            Delete(employeeAssetMappingID);
        }
    }
}