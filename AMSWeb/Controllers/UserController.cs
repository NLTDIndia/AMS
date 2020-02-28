using AMSService.Service;
using System.Web.Mvc;

namespace AMSWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public UserController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: User
        public ActionResult Index()
        {            
            var corpid = _employeeService.ValidateUser();
            Session["userName"] = _employeeService.GetEmployeeByCorpId(corpid.CorpId).EmployeeName;
            Session["CorpID"] = corpid.CorpId; 
            return RedirectToAction("ManageAssets", "Asset");         

        }
    }
}