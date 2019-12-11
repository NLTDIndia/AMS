using AMSRepository.Models;
using System.Collections.Generic;
using System.Linq;

namespace AMSRepository.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public Employee CreateEmployee(Employee employee)
        {
            return Insert(employee);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return Update(employee);
        }

        public List<Employee> GetEmployees()
        {
            return GetAll();
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            return GetByID(employeeID);
        }

        public Employee GetEmployeeByCorpID(string cortpId)
        {
            var corpEmployee = context.Employee.Where(fet => fet.CorpId.ToLower().Equals(cortpId)).FirstOrDefault();
            return corpEmployee;
        }
    }
}