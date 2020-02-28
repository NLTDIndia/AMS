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
            bool issessionNull = session.getname();
            if (issessionNull == true)
            {
                var corpid = _employeeService.ValidateUser();
                Session["userName"] = _employeeService.GetEmployeeByCorpId(corpid.CorpId).EmployeeName;
                Session["CorpID"] = corpid.CorpId;
                return RedirectToAction("ManageAssets", "Asset");
            }
            else
            {
                return RedirectToAction("ManageAssets", "Asset");
            }
          

        }


       
    }
}
