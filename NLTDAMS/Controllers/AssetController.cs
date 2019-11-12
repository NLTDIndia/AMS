using AMSService.IService;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using AMSUtilities.Models;
using AMSUtilities.Enums;

namespace NLTDAMS.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public ActionResult ManageAssets()
        {
            var Assets = _assetService.GetAssets();
            return View(Assets);
        }

        [HttpPost]
        public ActionResult AssignAsset(AssetModel assetModel)
        {
            int Id = _assetService.AssignAsset(assetModel);

            if (Id != 0)
            {
                TempData["Message"] = "Asset assigned successfully.";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("ManageAssets");
            }
            else
            {
                var Assets = _assetService.GetAssets();
                TempData["Message"] = "Asset not assigned.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View("ManageAssets", Assets);
            }
        }

        [HttpPost]
        public ActionResult UnassignAsset(AssetModel assetModel)
        {
            _assetService.UnassignAsset(assetModel);
            TempData["Message"] = "Asset unassigned successfully.";
            TempData["MessageType"] = (int)AlertMessageTypes.Success;
            return RedirectToAction("ManageAssets");
        }

        public ActionResult AssignAsset(int Id)
        {
            var Assets = _assetService.GetAssetByID(Id);
            return PartialView("../Shared/_AssignAsset", Assets);
        }

        public ActionResult UnassignAsset(int Id)
        {
            var Assets = _assetService.GetAssetByID(Id);
            return PartialView("../Shared/_UnassignAsset", Assets);
        }
    }
}