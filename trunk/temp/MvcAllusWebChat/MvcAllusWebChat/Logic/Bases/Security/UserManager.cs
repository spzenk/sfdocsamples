using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace WebChat.Common.Security
{

    public static class UserManager
    {
        /// <summary>
        /// Returns the User from the Context.User.Identity by decrypting the forms auth ticket and returning the user object.
        /// </summary>
        public static UserSession User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // The user is authenticated. Return the user from the forms auth ticket.
                    return ((SecPortalPrincipal)(HttpContext.Current.User)).User;
                }
                else if (HttpContext.Current.Items.Contains("User"))
                {
                    // The user is not authenticated, but has successfully logged in.
                    return (UserSession)HttpContext.Current.Items["User"];
                }
                else
                {
                    return null;
                }
            }
        }

   

     
        /// <summary>
        /// Clears the user session, clears the forms auth ticket, expires the forms auth cookie.
        /// </summary>
        /// <param name="session">HttpSessionStateBase</param>
        /// <param name="response">HttpResponseBase</param>
        public static void Logoff(HttpSessionStateBase session, HttpResponseBase response)
        {
            // Delete the user details from cache.
            session.Abandon();

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            response.Cookies.Add(cookie);
        }

        /// <summary>
        /// Administra los ticket de autenticacion y cokies de inicio de sesion del usuario .
        /// 
        /// En el caso de cookie no persistente, si el vale ha caducado, cookie también caducan, y el usuario 
        /// será redirigido a la página de inicio de sesión. En el otro lado, si el vale se marca como persistente, 
        /// donde se almacena la cookie en el cuadro de cliente, los exploradores utilizan la misma cookie de autenticación para iniciar 
        /// sesión en el sitio Web de cualquier momento. Sin embargo, podemos utilizar el método FormsAuthentication.SignOut 
        /// eliminar persistente o las cookies no persistentes de forma explícita.
        /// </summary>
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userSession)
        {
            if (userSession != null)
                //Temporalmente almacena el usuario en context para esta peticion (request) .-
                HttpContext.Current.Items.Add("User", userSession);

            String userSession_to_json = JsonConvert.SerializeObject(userSession);
         

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