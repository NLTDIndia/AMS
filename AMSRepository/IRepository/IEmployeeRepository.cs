using AMSRepository.Models;
using System.Collections.Generic;

namespace AMSRepository.Repository
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee(Employee employee);

        Employee GetEmployeeByID(int employeeID);

        List<Employee> GetEmployees();

        Employee UpdateEmployee(Employee employee);

        Employee GetEmployeeByCorpID(string cortpId);
    }
}