using Sample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using Fwk.Security.Cryptography;
namespace Sample1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Person()
        {
            return View();
        }
        public Person GetPerson()
        {
            Person p = new Person();
            p.Age = 33;
            p.Name = "Angeline";
            p.Surname = "Junckitoscky";
            p.BDate = DateTime.Now;


            return p;
        }

        public ActionResult cripto()
        {

            return View();
        }
        public JsonResult Encriptar(string txt)
        {
            try
            {
                var encriptedText = SymetricCypherFactory.Cypher().Encrypt(txt);
                return Json(new { Result = "ok", Message = encriptedText });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}
