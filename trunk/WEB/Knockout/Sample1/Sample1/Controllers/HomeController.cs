using Sample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
      
    }
}
