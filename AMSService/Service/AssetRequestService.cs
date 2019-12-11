using AMSRepository.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class AssetRequestService : IAssetRequestService
    {
        private readonly IAssetRequestRepository _assetRequestRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AssetRequestService(IAssetRequestRepository assetRequestRepository, IEmployeeRepository employeeRepository)
        {
            _assetRequestRepository = assetRequestRepository;
            _employeeRepository = employeeRepository;
        }

        public SelectList GetDropdownAssetRequest(int selectedId = -1)
        {
            List<SelectListItem> AssetRequestItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Employee", Value = "" } };
            var AssetRequests = _assetRequestRepository.GetAssetRequests();
            if (AssetRequests != null && AssetRequests.Count > 0)
            {
                AssetRequests.ForEach(at =>
                {
                    var EmployeeName = _employeeRepository.GetEmployeeByID(at.RequestedBy).EmployeeName;
                    AssetRequestItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = EmployeeName + ' ' + at.RequestedAsset, Value = at.ID.ToString() });
                });
            }

            return new SelectList(AssetRequestItems, "Value", "Text");
        }
    }
}