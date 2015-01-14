using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace WebChat.Common.Security
{

    
    /// <summary>
    /// Administra los ticket de autenticacion y cokies de inicio de sesion del usuario .
    /// 
    /// En el caso de cookie no persistente, si el vale ha caducado, cookie también caducan, y el usuario 
    /// será redirigido a la página de inicio de sesión. En el otro lado, si el vale se marca como persistente, 
    /// donde se almacena la cookie en el cuadro de cliente, los exploradores utilizan la misma cookie de autenticación para iniciar 
    /// sesión en el sitio Web de cualquier momento. Sin embargo, podemos utilizar el método FormsAuthentication.SignOut 
    /// eliminar persistente o las cookies no persistentes de forma explícita.
    /// </summary>
    public static class HttpResponseBaseExtensions
    {
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userSession)
        {
            if (userSession != null)
                //Temporalmente almacena el usuario en context para esta peticion (request) .-
                HttpContext.Current.Items.Add("User", userSession);

            String userSession_to_json = JsonConvert.SerializeObject(userSession);

            #region old code
            /// In order to pickup the settings from config, we create a default cookie and use its values to create a 
            /// new one.
            //Commentado solucion anterior 17-junio-2014
            //var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
            //var ticket = FormsAuthentication.Decrypt(cookie.Value);

            //var newTicket = new FormsAuthenticationTicket(
            //    ticket.Version, 
            //    ticket.Name, 
            //    ticket.IssueDate, 
            //    ticket.Expiration,
            //    ticket.IsPersistent,
            //    userSession_to_json, 
            //    ticket.CookiePath);

            //Commentado solucion anterior 17-junio-2014
            /// Use existing cookie. Could create new one but would have to copy settings over...
            //cookie.Value = encTicket;
            //responseBase.Cookies.Add(cookie);
            #endregion

            //Crear vale de autenticación manualmente (ticket) que utiliza la autenticación de formularios para identificar un usuario autenticado
            //Estos valores se almacenan en una cookie de autenticación de formularios o de la dirección URL.
            //Al ser manual la generacion, la propiedad de tiempo de espera (timeOut) del vale reemplazará el valor establecido en el archivo de configuración
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(1,
                      name,
                      DateTime.Now,
                      DateTime.Now.AddMinutes(1),
                      true,
                      userSession_to_json,
                      FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(newTicket);


            responseBase.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return encTicket.Length;
        }
    }
}