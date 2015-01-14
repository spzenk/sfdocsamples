//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Routing;
//using System.Web.Security;
//using Newtonsoft.Json;

//namespace WebChat.Common.Security
//{
//    public class CustomAuthenticationAttribute : ActionFilterAttribute
//    {
//        public String OuthRuleName { get; set; }
//        ISecurityAdapter iSecurityAdapter;
//        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        /// <summary>
//        /// Método ejecutado justo antes de la ejecución de la acción
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public override void OnActionExecuted(ActionExecutedContext filterContext)
//        {
//            iSecurityAdapter = NinjectWebCommon.Get_Service<ISecurityAdapter>();


//            //[ModelBinder(typeof(UserDataModelBinder<UserData>))]
//            if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
//            {
//                UserSession wUserData = SiteHelper.Get_UserSession_From_Cookies(filterContext);
//                if (null == wUserData)
//                {
//                    //   throw new Exception("No inicio session correctemnete");
//                    filterContext.Result = new RedirectToRouteResult(
//                            new RouteValueDictionary { { "controller", "Home" }, { "action", "LogIn" } });
//                }

//                //TODO: Se podria armar un patron de nombre de regla con ControllerName+ActionNAme
//                //                String regla = filterContext.Controller.
//                if (!String.IsNullOrEmpty(OuthRuleName))
//                {
//                    iSecurityAdapter.ValidateUser(wUserData, OuthRuleName);
//                }
//            }
//            else
//            {

//                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "LogIn" } });
//                //filterContext.Controller.ViewBag.Message = "Debe iniciar sesion para poder ver esta pagina o relaizar esta acción";
//                filterContext.Controller.TempData["Message"] = "Debe iniciar sesion para poder ver esta pagina o relaizar esta acción";
//            }


//            base.OnActionExecuted(filterContext);

//            // Almacenamos el nombre del método
//            //log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ToString());

//        }

//    }
//}