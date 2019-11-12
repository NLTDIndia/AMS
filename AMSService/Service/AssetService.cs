using AMSRepository.Models;
using AMSRepository.Repository;
using AMSService.IService;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeAssetMappingRepository _employeeAssetMappingRepository;
        private readonly IAssetTrackerService _assetTrackerService;

        public AssetService(AssetRepository assetRepository, 
            IEmployeeService employeeService,
            IEmployeeAssetMappingRepository employeeAssetMappingRepository, 
            IAssetTrackerService assetTrackerService)
        {
            _assetRepository = assetRepository;
            _employeeService = employeeService;
            _employeeAssetMappingRepository = employeeAssetMappingRepository;
            _assetTrackerService = assetTrackerService;
        }

        public List<AssetModel> GetAssets()
        {
            List<AssetModel> assetModels = new List<AssetModel>();
            var assets = _assetRepository.GetAssets();
            if (assets != null && assets.Count > 0)
            {
                var ddlEmployees = _employeeService.GetDropdownEmployees();
                return assets.Select(asset => GetAssetModel(asset, ddlEmployees)).ToList();
            }
            else
            {
                return new List<AssetModel> { };
            }
        }

        public AssetModel GetAssetByID(int Id)
        {
            var asset = _assetRepository.GetAssetByID(Id);
            if (asset != null)
            {
                var ddlEmployees = _employeeService.GetDropdownEmployees();
                return GetAssetModel(asset, ddlEmployees);
            }
            else
            {
                return new AssetModel { };
            }
        }

        public int AssignAsset(AssetModel assetModel)
        {
            
            EmployeeAssetMappingModel employeeAssetMappingModel = new EmployeeAssetMappingModel
            {
                EmployeeID = assetModel.EmployeeID,
                AssetID = assetModel.ID,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID
            };

            var employeeAssetMapping = _employeeAssetMappingRepository.CreateEmployeeAssetMapping(new EmployeeAssetMapping
            {
                AssetID = assetModel.ID,
                EmployeeID = assetModel.EmployeeID,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,

            });

            if (employeeAssetMapping !=null && employeeAssetMapping.ID != 0)
            {
                int id = _assetTrackerService.CreateAssetTracker(new AssetTrackerModel
                {
                    AssetID = assetModel.ID,
                    EmpID = assetModel.EmployeeID,
                    AssetStatusID = (int)AssetTrackingStatus.Assign,
                    CreatedDate = DateTime.Now,
                    CreatedBy = employeeAssetMappingModel.CreatedBy,
                    Remarks = assetModel.Remarks
                });
                if (id != 0)
                {
                    assetModel.AssetStatusID = (int)AssetTrackingStatus.Assign;
                    id = UpdateAsset(assetModel);
                }
            }


            return assetModel.ID;
        }

        public void UnassignAsset(AssetModel assetModel)
        {
            
            if (assetModel.ID != 0 && assetModel.EmployeeID != 0)
            {
                var employeeAssetMapping = _employeeAssetMappingRepository.GetEmployeeAssetMappings().Where(m => m.AssetID == assetModel.ID && m.EmployeeID == assetModel.EmployeeID).First();

                if(employeeAssetMapping!=null)
                {
                    _employeeAssetMappingRepository.DeleteEmployeeAssetMappingByID(employeeAssetMapping.ID);
                }
            }            

            int id = _assetTrackerService.CreateAssetTracker(new AssetTrackerModel
            {
                AssetID = assetModel.ID,
                EmpID = assetModel.EmployeeID,
                AssetStatusID = (int)AssetTrackingStatus.Unassign,
                CreatedDate = DateTime.Now,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                Remarks = assetModel.Remarks
            });

            if (id != 0)
            {
                assetModel.AssetStatusID = (int)AssetTrackingStatus.Unassign;
                id = UpdateAsset(assetModel);
            }
        }

        public int UpdateAsset(AssetModel assetModel)
        {
            Assets asset = _assetRepository.GetAssetByID(assetModel.ID);
            if (asset != null)
            {
                asset.AssetName = assetModel.AssetName;
                asset.AssetTypeID = assetModel.AssetTypeID;
                asset.SerialNumber = assetModel.SerialNumber;
                asset.AssetStatusID = assetModel.AssetStatusID;
                asset.CreatedDate = assetModel.CreatedDate;
                asset.CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID;
            }

            _assetRepository.UpdateAsset(asset);

            return asset.ID;
        }

        private AssetModel GetAssetModel(Assets asset, SelectList ddlEmployees)
        {
            AssetModel assetModel = new AssetModel
            {
                ID = asset.ID,
                AssetName = asset.AssetName,
                AssetTypeID = asset.AssetTypeID,
                AssetType = asset.AssetTypes.Description,
                SerialNumber = asset.SerialNumber,
                AssetStatusID = asset.AssetStatusID,
                AssetStatus = asset.AssetStatus.Description,
                CreatedDate = asset.CreatedDate,
                CreatedBy = asset.CreatedBy,
                GetEmployees = ddlEmployees
            };

            var employeeAssetMapping = asset.EmployeeAssetMapping.Where(eam => eam.AssetID == asset.ID).FirstOrDefault();

            if (employeeAssetMapping != null)
            {
                assetModel.EmployeeID = employeeAssetMapping.EmployeeID;
                assetModel.EmployeeName = employeeAssetMapping.Employee.EmployeeName;
            }

            return assetModel;
        }
    }
}
