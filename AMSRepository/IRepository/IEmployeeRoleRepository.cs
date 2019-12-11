using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IEmployeeRoleRepository
    {
        EmployeeRole CreateEmployeeRole(EmployeeRole employeeRole);

        EmployeeRole GetEmployeeRoleByID(int employeeRoleID);

        List<EmployeeRole> GetEmployeeRoles();

        EmployeeRole UpdateEmployeeRole(EmployeeRole employeeRole);
    }
}