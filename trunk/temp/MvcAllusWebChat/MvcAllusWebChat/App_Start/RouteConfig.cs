﻿using System;
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
            //    url: "{controller}/{action}/{tk}",
            //    defaults: new { controller = "EpironChatVersion1", action = "SelectionTestChatEpiron", tk = UrlParameter.Optional }
            //);

            routes.MapRoute(
              name: "chat",
              url: "{controller}/{action}/",
              defaults: new { controller = "EpironChatVersion1", action = "Chatfrm" }
          );
        }
    }
}