using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fwk.Exceptions;
using Fwk.Security.Cryptography;

namespace Epiron.Back.Bases
{
   
    public class Common
    {
        public const string CnnStringName = "epironDashboard";
        public static string CnnString_Entities = string.Empty;
        public static string CnnString = string.Empty;
        static Boolean logOnFile = false;
        public static ISymetriCypher ISymetriCypher;
        public static string SEED_K = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";//"sec.key";

        //Clave de Conexion
        public readonly static string EpironConnectionStringKey = "EpironConnectionString";
        public readonly static string EpironConnectionReportsStringKey = "EpironConnectionStringReports";
        public readonly static string ApplicationName = "Epiron";
       // public readonly static string ConfigServiceNameKey = null;
        

    

        
        /// <summary>
        /// Clave de Instancia de Aplicación
        /// </summary>
        public static string ApplicationInstanceGUIDKey = null;
        /// <summary>
        /// Dirección IP
        /// </summary>
        public static string IpAddressKey = null;
        
        /// <summary>
        /// InfoServiceName
        /// </summary>
        public static string InfoServiceNamekey = null;

        static  Common(){
            if (ConfigurationManager.AppSettings["ApplicationInstanceGUID"] != null)
                ApplicationInstanceGUIDKey = ConfigurationManager.AppSettings["ApplicationInstanceGUID"];
            else
                throw new TechnicalException( "Falta configurar en la aplicacion cliente [ApplicationInstanceGUID] ");


            if (ConfigurationManager.AppSettings["InfoServiceName"] != null)
                InfoServiceNamekey = ConfigurationManager.AppSettings["InfoServiceName"];
            else
                throw new TechnicalException("Falta configurar en la aplicacion cliente [InfoServiceName] ");


            if (ConfigurationManager.AppSettings["IpAddress"] != null)
                IpAddressKey = ConfigurationManager.AppSettings["IpAddress"];
            else
                throw new TechnicalException("Falta configurar en la aplicacion cliente [IpAddress] ");


                
        }



        
      
    }
}
