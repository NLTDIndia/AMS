using AMSService.Service;
using System.Web.Mvc;
using AMSWeb.Models;

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
            var session = UserSession.Instance;
            bool isSessionNull = session.GetSession();
            if (isSessionNull == true)
            {
                var corpId = _employeeService.ValidateUser();
                Session["userName"] = _employeeService.GetEmployeeByCorpId(corpId.CorpId).EmployeeName;
                Session["CorpID"] = corpId.CorpId;
                return RedirectToAction("ManageAssets", "Asset");
            }
            else
            {
                return RedirectToAction("ManageAssets", "Asset");
            }
          

        }


       
    }
}
