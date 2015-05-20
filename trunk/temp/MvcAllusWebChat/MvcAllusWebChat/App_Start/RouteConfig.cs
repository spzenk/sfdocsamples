using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebChat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name: "Default",
            //    url: "",
            //    defaults: new { controller = "Chat", action = "index" }
            //);

            routes.MapRoute(
              name: "chat",
              url: "{controller}/{action}/",
              defaults: new { controller = "Chat", action = "Chatfrm" }
          );
        }
    }
}