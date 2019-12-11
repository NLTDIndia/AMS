using AMSService.Service;
using log4net;
using System.Reflection;
using System.Resources;
using System.Web.Mvc;

namespace NLTDAMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IAssetService _assetService;
        private IEmployeeAssetMappingService _employeeAssetMappingService;

        public HomeController(IAssetService assetService, ILog logger, IEmployeeAssetMappingService employeeAssetMappingService)
        {
            _logger = logger;
            _assetService = assetService;
            _employeeAssetMappingService = employeeAssetMappingService;
        }

        //readonly IAssetService assetServices = UnityConfig.Container.Resolve<IAssetService>();
        private readonly ResourceManager rm = new ResourceManager("NLTDAMS.Properties.Resources", Assembly.GetExecutingAssembly());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeAssetDetails()
        {
            var employeeAssetMappingComponents = _employeeAssetMappingService.GetEmployeeAssetMappingsDetails();
            return View(employeeAssetMappingComponents);
        }
    }
}