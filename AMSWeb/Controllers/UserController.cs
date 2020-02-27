using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AMSWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            Session["userName"] = AMSUtilities.Common.UserDetails.GetFullName(User.Identity);
            return RedirectToAction("ManageAssets", "Asset");          
        }
    }
}