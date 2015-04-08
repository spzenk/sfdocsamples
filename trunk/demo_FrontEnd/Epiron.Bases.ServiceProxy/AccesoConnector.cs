using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fwk.Exceptions;

namespace Epiron.Bases.ServiceProxy
{
    public class AccesoConnector
    {
        private static string _AccesoConnectorURL = string.Empty;
        static AccesoConnector()
        {
            _AccesoConnectorURL = System.Configuration.ConfigurationManager.AppSettings["AccesoConnectorURL"];

            if (ConfigurationManager.AppSettings["AccesoConnectorURL"] != null)
                _AccesoConnectorURL = ConfigurationManager.AppSettings["AccesoConnectorURL"];
            else
                throw new TechnicalException("Falta configurar en la aplicacion cliente [AccesoConnectorURL] ");

        }
        public static System.Data.DataTable ValidarAplicacion(string Par_Event_Tag, System.Guid Par_AppInstanceGUID, string Par_LoginHost, string Par_LoginIP)
        {
            System.Data.DataTable dttResult = null;

            try
            {
                using (Epiron.Bases.ServiceProxy.wsAcceso wService = new Epiron.Bases.ServiceProxy.wsAcceso())
                {
                    //if (_Proxy != null)
                    //    wService.Proxy = _Proxy;
                    //if (_Credentials != null)
                    //    wService.Credentials = _Credentials;

                    wService.Url = _AccesoConnectorURL;
                    dttResult = wService.ValidarAplicacion(Par_Event_Tag, Par_AppInstanceGUID, Par_LoginHost, Par_LoginIP);
                }
            }
            catch (Exception ex)
            {
                throw SetEx(ex);
            }

            return dttResult;
        }

        public static System.Data.DataTable TiposAutenticacion(string Par_Event_Tag, System.Guid Par_AppInstanceGUID, string Par_LoginHost, string Par_LoginIP, System.Guid guidintercambio)
        {
            System.Data.DataTable dttResult = null;
            try
            {
                using (Epiron.Bases.ServiceProxy.wsAcceso wService = new Epiron.Bases.ServiceProxy.wsAcceso())
                {
                    //if (_Proxy != null)
                    //    wService.Proxy = _Proxy;
                    //if (_Credentials != null)
                    //    wService.Credentials = _Credentials;

                    wService.Url = _AccesoConnectorURL;
                    dttResult = wService.TiposAutenticacion(Par_Event_Tag, Par_AppInstanceGUID, Par_LoginHost, Par_LoginIP, guidintercambio);
                }
            }

            catch (Exception ex)
            {
                throw SetEx(ex);
            }


            return dttResult;
        }

        public static System.Data.DataTable UserAutenticacion(
            string Par_Event_Tag,
            System.Guid Par_AppInstanceGUID,
            string Par_LoginHost,
            string Par_LoginIP,
            System.Guid Par_AutTypeGUID,
            string Par_UserName, string Par_UserKey,
            System.Guid Par_DomainGUID,
            System.Guid guidintercambio)
        {
            System.Data.DataTable dttResult = null;
            try
            {
                using (Epiron.Bases.ServiceProxy.wsAcceso wService = new Epiron.Bases.ServiceProxy.wsAcceso())
                {
                    //if (_Proxy != null)
                    //    wService.Proxy = _Proxy;
                    //if (_Credentials != null)
                    //    wService.Credentials = _Credentials;

                    wService.Url = _AccesoConnectorURL;
                    dttResult = wService.UserAutenticacion(Par_Event_Tag, Par_AppInstanceGUID, Par_LoginHost, Par_LoginIP, Par_AutTypeGUID, Par_UserName, Par_UserKey, Par_DomainGUID, guidintercambio);
                }
            }
            catch (Exception ex)
            {
                throw SetEx(ex);
            }

            return dttResult;
        }

        public static DataTable DominioInstancia(Guid pAppInstanceGuid, string pAuthenticationType)
        {
            System.Data.DataTable dttResult = null;
            try
            {
                using (Epiron.Bases.ServiceProxy.wsAcceso wService = new Epiron.Bases.ServiceProxy.wsAcceso())
                {
                    //if (_Proxy != null)
                    //    wService.Proxy = _Proxy;
                    //if (_Credentials != null)
                    //    wService.Credentials = _Credentials;

                    wService.Url = _AccesoConnectorURL;
                    dttResult = wService.DominioInstancia(pAppInstanceGuid, pAuthenticationType);
                }
            }
            catch (Exception ex)
            {
                throw SetEx(ex);
            }
            return dttResult;
        }

        public static DataTable MenuPermisos(string par_Event_Tag, Guid appInstanceGuid, Guid domainGuid, Guid oGuidMenuPermiso, Guid interUserGuid)
        {
            System.Data.DataTable dttResult = null;
            try
            {
                using (Epiron.Bases.ServiceProxy.wsAcceso wService = new Epiron.Bases.ServiceProxy.wsAcceso())
                {
                    //if (_Proxy != null)
                    //    wService.Proxy = _Proxy;
                    //if (_Credentials != null)
                    //    wService.Credentials = _Credentials;

                    wService.Url = _AccesoConnectorURL;
                    dttResult = wService.MenuPermisos(par_Event_Tag, appInstanceGuid, domainGuid, oGuidMenuPermiso, interUserGuid);
                }
            }
            catch (Exception ex)
            {
                throw SetEx(ex);
            }
            return dttResult;
        }


        static TechnicalException SetEx(Exception ex)
        {
            TechnicalException te = new TechnicalException(String.Concat("Error al intentar acceder al servidor de autenticación : ", ex.Message));
            ExceptionHelper.SetTechnicalException<AccesoConnector>(te);
            te.ErrorId = "WSACCESO";

            return te;
        }
    }
}
