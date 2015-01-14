using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Ambas funcionan =
        /// http://localhost:30250/test/chat/?tk=page1
        /// http://localhost:30250/test/chat/page2
        ///  routes.MapRoute(
           ///     name: "Default",
              ///  url: "{controller}/{action}/{tk}",
                ///defaults: new { controller = "EpironChat", action = "Index", tk = UrlParameter.Optional }
        ///);
        /// Esto es debido a Ropute
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chat(string tk)

        {
            if (String.IsNullOrEmpty(tk))
                return View("Index");
            if (tk.CompareTo("page1")==0)
                return View("page1");
            if (tk.CompareTo("page2")==0)
                return View("page2");

            return View();
        }
        [HttpGet]
        public ActionResult Dialogs(string tk)
        {
        

            return View();
        }
    }
}
