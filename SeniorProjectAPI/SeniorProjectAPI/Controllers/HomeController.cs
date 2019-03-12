using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProjectAPI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Managers")]
        public ActionResult CompanySecrets()
        {
            return View();
        }

        [Authorize(Users="redmond\\swalther")]
        public ActionResult UserSecrets()
        {
            return view();
        }
    }
}
