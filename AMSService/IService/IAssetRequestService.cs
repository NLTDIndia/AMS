using System.Web.Mvc;

namespace AMSService.Service
{
    public interface IAssetRequestService
    {
        SelectList GetDropdownAssetRequest(int selectedId = -1);
    }
}