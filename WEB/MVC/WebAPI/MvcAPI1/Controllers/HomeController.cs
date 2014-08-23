using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAPI1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
