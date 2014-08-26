using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace MvcAPI1.Controllers
{
    public class HomeController : Controller
    {
        public MvcAPI.Connector.ServiceReference1.WCFAPIServiceClient svcClient = null;

        public HomeController()
        {
            //ChannelFactory<MvcAPI.Connector.ServiceReference1.IWCFAPIServiceChannel> chanel = new ChannelFactory<MvcAPI.Connector.ServiceReference1.IWCFAPIServiceChannel>("tcp");
            //chanel.Open
            svcClient = new MvcAPI.Connector.ServiceReference1.WCFAPIServiceClient("tcp");
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RetrivePMOList()
        {
            MvcAPI.Connector.ServiceReference1.PMOFile[] pmoList = null;
            try
            {
                pmoList = svcClient.RetrivePMOList();

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
            return Json(pmoList, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
