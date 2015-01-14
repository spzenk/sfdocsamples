using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebChat.Common
{
    /// <summary>
    /// MAnejo de Excepciones propias de epiron
    /// </summary>
    public class SecPortalException : ApplicationException
    {



        // Summary:
        //     Assembly.
        public string AssemblyLocation { get; set; }
        //
        // Summary:
        //     Class.
        public string Class { get; set; }
        //public String 
        public String ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the connection.
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Gets or sets the name or network address of the instance of SQL Server to
        ///     connect to.
        /// </summary>
        public string DatabaseServerName { get; set; }
        /// <summary>
        /// Message.
        /// </summary>
        //protected string mMsg;
        /// <summary>
        /// Excepcion tecnica.
        /// </summary>
        /// <param name="pmsg">Mensaje del error.</param>
        /// <param name="pinner">Excepcion original.</param>
        public SecPortalException(string pmsg, Exception pinner)
            : base(pmsg, pinner)
        {
            //mMsg = pmsg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        public static SecPortalException ProcessException(Exception ex, Type sourceObjectType, String message, String connectionString)
        {
            SecPortalException exception = null;

            if (typeof(SecPortalException) == ex.GetType())
                return (SecPortalException)ex;
            if (ex == null)
            {
                exception = new SecPortalException(message, null);
            }
            else
            {
                if (ex is System.Data.SqlClient.SqlException && exception == null)
                {
                    //if (((SqlException)ex).ErrorCode.Equals(-2146232060))
                    exception = new SecPortalException(String.Concat("SqlException : ", message, "\r\n", ex.Message), ex);

                    exception.ErrorCode = ((SqlException)ex).ErrorCode.ToString();
                }

                if (ex.GetType().Name.Contains("Pop3Exception") && exception == null)
                {

                    exception = new SecPortalException(String.Concat("Pop3Exception : ", message, "\r\n", ex.Message), ex);
                }
            }

            if (exception == null && ex != null)
            {
                exception = new SecPortalException(String.Concat(message, "\r\n", ex.Message), ex);
            }

            if (!String.IsNullOrEmpty(connectionString))
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionString);
                exception.DatabaseServerName = sqlBuilder.DataSource;
                exception.DatabaseName = sqlBuilder.InitialCatalog;
            }
            if (sourceObjectType != null)
            {
                exception.AssemblyLocation = sourceObjectType.Assembly.Location;
                exception.Class = sourceObjectType.Name;
            }
            return exception;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sourceObject"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static SecPortalException ProcessException(Exception ex, Type sourceObjectType, string connectionString)
        {
            SecPortalException exception = SecPortalException.ProcessException(ex, sourceObjectType, String.Empty, connectionString);
            return exception;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="sourceObject"></param>
        /// <returns></returns>
        public static SecPortalException ProcessException(Exception ex, object sourceObject)
        {
            return SecPortalException.ProcessException(ex, sourceObject.GetType(), String.Empty, String.Empty);
        }

        public static String ProcessJsonResult(Exception ex, Controller controller)
        {
            StringBuilder strErorMessage = new StringBuilder(ex.Message);
            if (typeof(Fwk.Exceptions.FunctionalException) == ex.GetType())
            {
                
            }
            if (typeof(SecPortalException) == ex.GetType())
            {

                strErorMessage.AppendLine(String.Concat("Clase origen :", ((SecPortalException)ex).Class));
                strErorMessage.AppendLine(String.Concat("Controller: ", controller.ControllerContext.RouteData.Values["controller"]));
                strErorMessage.AppendLine(String.Concat("Controller action: ", controller.ControllerContext.RouteData.Values["action"]));
                strErorMessage.AppendLine(String.Concat("Origen :", ex.Source));
            }

            

            //JsonResult res = Controller.Json(new { Result = "ERROR", Message = ex.Message });
            return strErorMessage.ToString();
        }

    }
}
