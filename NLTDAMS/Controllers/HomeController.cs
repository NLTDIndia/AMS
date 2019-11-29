using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMSUtilities.Common;
using System.Reflection;
using System.Resources;
using System.Globalization;
using Unity;
using AMSService.Service;
using log4net;

namespace NLTDAMS.Controllers
{
    public class HomeController : Controller
    {
        ILog _logger;
        IAssetService _assetService;
        IEmployeeAssetMappingService _employeeAssetMappingService;

        public HomeController(IAssetService assetService, ILog logger, IEmployeeAssetMappingService employeeAssetMappingService)
        {
            _logger = logger;
            _assetService = assetService;
            _employeeAssetMappingService = employeeAssetMappingService;


        }
        //readonly IAssetService assetServices = UnityConfig.Container.Resolve<IAssetService>();
        ResourceManager rm = new ResourceManager("NLTDAMS.Properties.Resources", Assembly.GetExecutingAssembly());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmployeeAssetDetails()
        {
            var employeeAssetMappingComponents = _employeeAssetMappingService.GetEmployeeAssetMappingsDetails();
            return View(employeeAssetMappingComponents);
        }
    }
}