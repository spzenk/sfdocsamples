using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TRIS.ViewModels;

namespace TRIS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            AutoMapper.Mapper.CreateMap<TRIS.BusinessObjects.Car, SimpleCarViewModel>();
            AutoMapper.Mapper.CreateMap<TRIS.BusinessObjects.Option, OptionViewModel>();
            AutoMapper.Mapper.CreateMap<TRIS.BusinessObjects.Car, CarViewModel>();
        }
    }
}