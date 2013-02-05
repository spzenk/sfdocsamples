using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using Allus.Keepcon.Import;
using Keepcon;
using Fwk.Logging;

namespace Allus.Keepcon
{
    /// <summary>
    /// Componente q realiza llamadas al servicio web REST de keepcon
    /// Componente q almacena en BD los resultados de las llamadas al servicio web REST de keepcon
    /// </summary>
    public class KeepconSvc
    {
        //Enviando / obteniendo contenidos a moderar
        static string url_send_content_asynk = "http://service.keepcon.com/input/contentSet";
        /// <summary>
        ///URL servicio web REST al cual el cliente enviará el contenido a moderar
        /// </summary>
        static string url_send_content_synk = "http://sync.keepcon.com/synchronic/moderate";
        /// <summary>
        /// URL servicio web REST donde consumir los resultados.
        /// </summary>
        static string url_get_result = "http://service.keepcon.com/output/contentSet?contextName={0}&clientACK=true";

        /// <summary>
        /// URL Serivico web REST de ACK
        /// </summary>
        static string url_ack = "http://service.keepcon.com:63081/output/contentSet/ack/{0}";


        static string user;
        static string password;
        static WebProxy Proxy = null;
        /// <summary>
        /// Tamaño del lote a enviar
        /// </summary>
        static int kc_batch = 30;

        static KeepconSvc()
        {
            bool result = true;
            //user = "MovistarPostDemo";
            //password = "k33pc0n12112012";

            try
            {


                if (string.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "kc_user")))
                    throw new Exception("La propiedad Engine.kc_user no puede ser nula");
                else
                    user = Convert.ToString(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "kc_user"));

                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "kc_password") != null)
                    password = Convert.ToString(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "kc_password"));

                result = Int32.TryParse(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "kc_batch"), out kc_batch);
                if (!result)
                    throw new Exception("La propiedad Engine.kc_batch no es correcta");


                if (Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Enabled") != null)
                    if (Convert.ToBoolean(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Enabled")))
                    {

                        if (string.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "UserName")))
                            throw new Exception("La propiedad Proxy.UserName no puede ser nula");

                        if (string.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Password")))
                            throw new Exception("La propiedad Proxy.Password no puede ser nula");

                        int port;
                        result = Int32.TryParse(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Port"), out port);
                        if (!result)
                            throw new Exception("La propiedad Proxy.Port no es correcta");


                        if (string.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Domain")))
                            throw new Exception("La propiedad Proxy.Domain no puede ser nula");

                        if (string.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Host")))
                            throw new Exception("La propiedad Proxy.Host no puede ser nula");

                        Proxy = new WebProxy(Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Host"), port);

                        Proxy.Credentials = new System.Net.NetworkCredential(
                            Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "UserName"),
                            Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Password"),
                            Fwk.Configuration.ConfigurationManager.GetProperty("Proxy", "Domain"));
                    }

            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al leer configuración en Helper()", ex);
                te.ErrorId = "1";
                throw te;

            }

        }

        public static void Init()
        { }

        /// <summary>
        /// 
        /// Envia contenido a keepcont
        /// Establece el tiempo de envio a cada post y almacena el resultado de envio
        /// </summary>
        /// <param name="import"></param>
        /// <returns>
        /// Como respuesta al envío, Keepcon envia una respuesta confirmando que se
        /// recibió con éxito un lote de contenidos, junto con el identificador de lote
        /// asignado a dicho envío. response.setId , response.status
        /// 
        /// Puede retornar status= ERROR con lo cual se retorna errorMessage = descripcion del error
        /// </returns>
        internal static string SendContent(Allus.Keepcon.Import.Import import)
        {
            DateTime datetime = System.DateTime.Now;
            string result = string.Empty;
            //try
            //{
                //if (import.Contents.Count == 1)
                //    result = HttpPUT(url_send_content_synk, import.GetXml());
                //else
                    result = HttpPUT(url_send_content_asynk, import.GetXml());
            //}
            //catch (Exception ex)
            //{
            //    return Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            //}

            //TODO: Es obligatorio implementar un mecanismo de reintentos. si result = ERROR
            Response response = (Response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Response), result);
            if (!response.Status.Equals("ERROR"))
                Set_SendedTime(import, response, datetime);
            else
            {
                //Registrar el error

            }
            return result;
        }

        /// <summary>
        /// Llamada al servicio  web REST de keepcon donde consumir los resultados.
        /// </summary>
        /// <returns></returns>
        internal static string RetriveResult()
        {
            //try
            //{
                return HttpPUT(string.Format(url_get_result, user), string.Empty);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        /// <summary>
        /// Llamada al servicio  web REST de keepcon donde consumir los resultados.
        /// </summary>
        /// <param name="contextName">[account-name] es el nombre de la cuenta de su empresa. Pero si la empresatiene dos contexto va el nombre del contexto</param>
        /// <returns>Retorna un objeto Export</returns>
        public static Allus.Keepcon.Export.Export RetriveResult_2(string contextName)
        {
            Allus.Keepcon.Export.Export import = null;
            try
            {
                string result = HttpPUT(string.Format(url_get_result, contextName), string.Empty);
                if (result.Contains("free"))
              
                    Helper.Audit_Result(result);
                
                if (!String.IsNullOrEmpty(result))
                    import = Export.Export.SetXml(result);

                return import;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Envia a Keepcon un ACK confirmando la correcta recepción
        /// del lote de resultados. En caso de que Keepcon no haya recibido el ACK dentro
        /// de los 5 minutos de haber consultado el lote, se volverá a enviar el mismo lote
        /// en el próximo llamado.
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        internal static string SendASK(string setId)
        {
            try
            {
                return HttpPUT(string.Format(url_ack, setId), string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Realiza llamadas web REST 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="inputData"></param>
        /// <param name="pTimeout"></param>
        /// <returns></returns>
        static String HttpPUT(string url, string inputData, int? pTimeout = null)
        {

            Uri wUrl = new Uri(url);
            string wXmlRes = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(wUrl);
            req.KeepAlive = false;

            if (pTimeout.HasValue)
            {
                req.Timeout = pTimeout.Value;
                req.ServicePoint.ConnectionLeaseTimeout = pTimeout.Value;
                req.ServicePoint.MaxIdleTime = pTimeout.Value;
                req.ServicePoint.MaxIdleTime = pTimeout.Value;
                req.ReadWriteTimeout = pTimeout.Value;
            }

            if (Proxy != null)
            {
                req.Proxy = Proxy;
            }



            req.Method = "PUT";
            req.ContentType = "";//"application/x-www-form-urlencoded";

            req.Credentials = new NetworkCredential(user, password);

            UTF8Encoding wEncoding = new UTF8Encoding();

           
            
            Byte[] wByte = wEncoding.GetBytes(inputData);
            req.ContentLength = wByte.Length;
            using (Stream wRequestStream = req.GetRequestStream())
            {
                wRequestStream.Write(wByte, 0, wByte.Length);
                wRequestStream.Flush();
                wRequestStream.Close();
            }

            using (HttpWebResponse wResponse = (HttpWebResponse)req.GetResponse())
            {
                StreamReader wReader = new StreamReader(wResponse.GetResponseStream());
                wXmlRes = Fwk.HelperFunctions.FileFunctions.GetTextFromReader(wReader);


            }
            return wXmlRes;
        }



        #region DATA

        /// <summary>
        /// Retorna post retorna un batch = kc_batch
        /// </summary>
        /// <param name="takeNumber"></param>
        /// <returns></returns>
        internal static List<KeepconPost> RetrivePost_To_Send()
        {
            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {

                var x = from s in dc.KeepconPost where s.keepcon_send_date.HasValue == false select s;
                return x.Take(kc_batch).ToList<KeepconPost>();

            }
        }
        public static List<String> Retrive_All_ContentType_To_Send()
        {
            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {

                var x = (from s in dc.KeepconPost 
                        where 
                        s.keepcon_send_date.HasValue &&
                        String.IsNullOrEmpty(s.keepcon_result_setId)
                        select s.KeepconCustomerCare).Distinct();
                return x.ToList<String>();

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //internal static List<KeepconPost> Update_Sended_Post()
        //{
        //    using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
        //    {
        //        var x = from s in dc.KeepconPost where s.keepcon_send_date.HasValue == false select s;
        //        return x.ToList<KeepconPost>();

        //    }
        //}


        #endregion

        /// <summary>
        /// Almacena resultado de moderacion
        /// </summary>
        /// <param name="export"></param>
        internal static void SaveResult(Export.Export export)
        {
            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {
                foreach (Export.Content c in export.Contents)
                {
                    var post = dc.KeepconPost.Where(s => s.PostID.Equals(c.Id)).FirstOrDefault();
                    post.keepcon_result_resived_date = System.DateTime.Now;
                    post.keepcon_moderator_date = Fwk.HelperFunctions.DateFunctions.UnixLongTimeToDateTime(c.ModerationDate);
                    post.keepcon_moderator_decision = c.ModerationDecision;
                    post.keepcon_result_setId = export.SetId;
                    post.keepcon_moderator = c.ModeratorName;

                }
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Establece la bandera keepcon_ack par aindicar q al lote de post con un determinado set result id se le envio el ACK
        /// </summary>
        /// <param name="setId">Lote resultado</param>
        internal static void SaveResult_ACK(string setId)
        {
            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {

                foreach (KeepconPost wKeepconPost in dc.KeepconPost.Where(p => p.keepcon_result_setId.Equals(setId)))
                {
                    wKeepconPost.keepcon_ack = true;
                }
                dc.SaveChanges();
            }
        }

        static void Set_SendedTime(Import.Import import, Response response, DateTime datetime)
        {

            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {
                foreach (Import.Content c in import.Contents)
                {
                    var post = dc.KeepconPost.Where(s => s.PostID.Equals(c.Id)).FirstOrDefault();
                    post.keepcon_send_date = datetime;
                    post.keepcon_send_setId = response.SetGuid;
                }
                dc.SaveChanges();
            }
        }


        static void Save_KeepcontLogs(int id, DateTime keepcon_send_date, string keepcon_error_message, LogType logType)
        {

            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {

                KeepconLogs wKeepconLogs = new KeepconLogs();
                wKeepconLogs.id = id;
                wKeepconLogs.keepcon_send_date = keepcon_send_date;
                wKeepconLogs.keepcon_error_message = keepcon_error_message;
                wKeepconLogs.logtype = (int)logType;
                dc.KeepconLogs.AddObject(wKeepconLogs);
                dc.SaveChanges();
            }
        }

        public static KeepconPost GetPostById(int postId)
        {
            using (BB_MovistarSM_LogsEntities dc = new BB_MovistarSM_LogsEntities())
            {

                return dc.KeepconPost.Where(s => s.PostID == postId).FirstOrDefault < KeepconPost>();
                

            }
        }
    }


    public enum KeepconSvcStatusEnum
    {
        SENDED = 0,
        PROCCESSED = 1
    }


    public enum LogType
    {
        Post = 0,
        Message = 1,
        Mail = 3
    }
}
