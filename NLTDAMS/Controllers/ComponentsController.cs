using AMSService.Service;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using log4net;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NLTDAMS.Controllers
{
    [Authorize(Roles = "IT")]
    public class ComponentsController : Controller
    {
        private IComponentsService _componentsService;
        private IComponentTypeService _componentTypeService;
        private IComponentAssetMappingService _componentAssetMappingService;
        private readonly ILog _logger;

        public ComponentsController(IComponentsService componentsService, IComponentTypeService componentTypeService, IComponentAssetMappingService componentAssetMappingService, ILog logger)
        {
            _componentsService = componentsService;
            _componentTypeService = componentTypeService;
            _componentAssetMappingService = componentAssetMappingService;
            _logger = logger;
        }

        // GET: Components
        public ActionResult Index()
        {
            var Components = _componentsService.GetAllComponents();
            return View(Components);
        }

        public ActionResult NewComponents()
        {
            ComponentsModel components = new ComponentsModel
            {
                ComponentType = _componentTypeService.GetDropdownComponentTypes()
            };
            return View(components);
        }

        [HttpPost]
        public ActionResult NewComponents(ComponentsModel components)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var componentexist =   _componentsService.GetAllComponents().Where(fetch => fetch.ComponentName.ToLower() == componentsModel.ComponentName.ToLower()).ToList().FirstOrDefault();
                    _componentsService.createComponents(components);
                    TempData["Message"] = "Component type created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("NewComponents");
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component type not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View("Index");
            }
        }

        public ActionResult UpdateComponents(int id)
        {
            return View(_componentsService.GetComponentsById(id));
        }

        [HttpPost]
        public ActionResult UpdateComponents(ComponentsModel componentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _componentsService.UpdateComponents(componentModel);
                    TempData["Message"] = "Component updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(componentModel);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(componentModel);
            }
        }

        public ActionResult AssignComponents(int ID)
        {
            ComponentAssetMappingModel componentAssetMappingModel = new ComponentAssetMappingModel()
            {
                Assets = _componentAssetMappingService.GetDropdownAssets(ID)
            };
            var components = _componentAssetMappingService.GetComponentAssetMappingByComponentID(ID);
            components.Assets = componentAssetMappingModel.Assets;

            return PartialView("../Shared/_AssignComponents", components);
        }

        [HttpPost]
        public ActionResult AssignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            var componentAssetMapping = _componentAssetMappingService.AssignComponents(componentAssetMappingModel);

            if (componentAssetMapping.ID != 0)
            {
                TempData["Message"] = "Component assigned successfully.";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Component not assigned.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(componentAssetMappingModel);
            }
        }

        public JsonResult IsComponentNameExist(string ComponentName, int? ID, int ComponentTypeID)
        {
            var validateName = _componentsService.GetAllComponents().Where(fet => fet.ComponentName.ToLower() == ComponentName.ToLower() && fet.ID != ID && fet.ComponentTypeID == ComponentTypeID).ToList();
            if (validateName.Count() > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}