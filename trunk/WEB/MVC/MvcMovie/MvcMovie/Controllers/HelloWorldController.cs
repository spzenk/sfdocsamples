using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome()
        //{
        //    return "<h1>Este es el metodo Welcome..</h1>";
        //}

        public ActionResult Welcome(string name)
        {
            ViewBag.Message = "pepe";
            ViewBag.Name = name;
            ViewBag.Repetir = 6;
            //return string.Concat("<div>  <h1>Este es el metodo Welcome.. con parametro </h1>",name,"</div>");
            return View();
        } 

    }
}
