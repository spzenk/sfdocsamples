using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Logic;

namespace WebChat.Controllers
{
    public class EpironChatEmailController : Controller
    {
        //
        // GET: /EpironChatEmail/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(string cellPhone, string email, string emailBody, bool toTheClientFlag)
        {
            try
            {

                EmailHelper wEmailHelper = new EmailHelper(new Guid("8f482c36-993f-4751-9299-e3e2be1b8d68"), 1);
                wEmailHelper.SentEmail(emailBody, toTheClientFlag);

                return Json(new { Result = "OK"});
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex) });
            }
            
           
        }

    }
}
