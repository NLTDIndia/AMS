using AMSRepository.Repository;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeModel GetEmployeeByCorpId(string corpId)
        {
            try
            {
                var employee = _employeeRepository.GetEmployees().Where(e => e.CorpId.ToLower() == corpId.ToLower()).FirstOrDefault();
                if (employee != null)
                {
                    return new EmployeeModel
                    {
                        ID = employee.ID,
                        EmployeeName = employee.EmployeeName,
                        EmployeeID = employee.EmployeeID,
                        CorpId = employee.CorpId,
                        EmployeeRoleID = employee.EmployeeRoleID,
                        ISActive = employee.ISActive,
                        MailID = employee.MailID,
                        SeatID = employee.SeatID
                    };
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SelectList GetDropdownEmployees(int selectedId = -1)
        {
            List<SelectListItem> EmployeesItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Employee", Value = "" } };
            var Employees = _employeeRepository.GetEmployees();
            if (Employees != null && Employees.Count > 0)
            {
                Employees.ForEach(at =>
                {
                    EmployeesItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.EmployeeName, Value = at.ID.ToString() });
                });
            }

            return new SelectList(EmployeesItems, "Value", "Text");
        }
    }
}
