using AMSRepository.Repository;
using AMSRepository.Models;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AMSService.Service
{
    public class EmployeeAssetMappingService : IEmployeeAssetMappingService
    {
        private readonly IEmployeeAssetMappingRepository _employeeAssetMappingRepository;
        private readonly IEmployeeService _employeeService;
        public EmployeeAssetMappingService(IEmployeeAssetMappingRepository employeeAssetMappingRepository, IEmployeeService employeeService)
        {
            _employeeAssetMappingRepository = employeeAssetMappingRepository;
            _employeeService = employeeService;
        }

        public List<EmployeeAssetMappingModel> GetEmployeeAssetMappingsModel()
        {
            var employeeAssetMappings = _employeeAssetMappingRepository.GetEmployeeAssetMappings();
            if (employeeAssetMappings != null && employeeAssetMappings.Count > 0)
            {
                return employeeAssetMappings.Select(eam => new EmployeeAssetMappingModel
                {
                    ID = eam.ID,
                    EmployeeID = eam.EmployeeID,
                    EmployeeName =eam.Employee.EmployeeName,
                    AssetID = eam.AssetID,
                    AssetName = eam.Assets.AssetName,
                    CreatedDate = eam.CreatedDate,
                    CreatedBy = eam.CreatedBy

                }).ToList();
            }
            else
            {
                return new List<EmployeeAssetMappingModel> { };
            }
        }

        public List<EmployeeAssetMappingModel> GetEmployeeAssetMappingsDetails()
        {
            int EmployeeID = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID;
            var employeeAssetMappings = _employeeAssetMappingRepository.GetEmployeeAssetMappings().Where(eam => eam.EmployeeID == EmployeeID).ToList();
            if (employeeAssetMappings != null && employeeAssetMappings.Count > 0)
            {
                return employeeAssetMappings.Select(eam => new EmployeeAssetMappingModel
                {
                    ID = eam.ID,
                    EmployeeID = eam.EmployeeID,
                    EmployeeName = eam.Employee.EmployeeName,
                    AssetID = eam.AssetID,
                    AssetName = eam.Assets.AssetName,
                    CreatedDate = eam.CreatedDate,
                    CreatedBy = eam.CreatedBy

                }).ToList();
            }
            else
            {
                return new List<EmployeeAssetMappingModel> { };
            }
        }

    }
}
