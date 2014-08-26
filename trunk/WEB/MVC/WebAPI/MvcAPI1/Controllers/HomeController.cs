using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using MvcAPI.Connector;

namespace MvcAPI1.Controllers
{
    public class HomeController : Controller
    {
        IPMOFilerepository repository = null;

        public HomeController()
        {
            //ChannelFactory<MvcAPI.Connector.ServiceReference1.IWCFAPIServiceChannel> chanel = new ChannelFactory<MvcAPI.Connector.ServiceReference1.IWCFAPIServiceChannel>("tcp");
            //chanel.Open
            repository = new PMOFilerepository();
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RetrivePMOList()
        {
            List<MvcAPI.Connector.ServiceReference1.PMOFile> pmoList = null;
            try
            {
                pmoList = repository.RetrivePMOList().ToList();

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
            return Json(pmoList, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public JsonResult RetrivePMOListParamas(string param)
        {
            MvcAPI.Connector.ServiceReference1.PMOContract pMOContract = null;
            try
            {
                pMOContract = repository.RetrivePMOListParamas(param);

            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
            return Json(pMOContract.PMOFileList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
