using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using Fwk.SocialNetworks.Data;
using Fwk.Logging;
using Fwk.HelperFunctions;
using Fwk.Logging.Targets;
using Fwk.Exceptions;
using System.Net.Mail;


namespace Fwk.SocialNetworks
{
    public class Helper
    {
        public  static  string SocialNetworksServiceName = "SocialNetworks listener service";
        static Boolean logOnFile = false;
        /// <summary>
        ///Determina si se permite o continua logueando o no
        ///
        /// </summary>
        static bool log = true;
        static string MailSender;
        static string[] MailRecipients;
        static Helper()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["logOnFile"]!=null)
                logOnFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["logOnFile"]);

            if (System.Configuration.ConfigurationManager.AppSettings["SocialNetworksServiceName"] != null)
                SocialNetworksServiceName = System.Configuration.ConfigurationManager.AppSettings["SocialNetworksServiceName"].ToString() ;

            if (System.Configuration.ConfigurationManager.AppSettings["MailSender"] != null)
                MailSender = System.Configuration.ConfigurationManager.AppSettings["MailSender"].ToString();

            try
            {
            if (System.Configuration.ConfigurationManager.AppSettings["MailRecipients"] != null)
                MailRecipients = System.Configuration.ConfigurationManager.AppSettings["MailRecipients"].ToString().Split(';');
            }
            catch
            {
                Log(string.Empty,"MailRecipients no esta correctamente configurado", EventType.Warning);
            }
            
        }

        #region [Schema Methods]
  
 

        /// <summary>
        /// Este es el que deserealiza posta
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        internal static fql_query_response DeserializeResponse(TextReader pReader, out error_response error)
        {
            fql_query_response wResponses = null;
            error = null;
            string xml = Fwk.HelperFunctions.FileFunctions.GetTextFromReader(pReader);
            if (xml.Contains("<error_response"))
                error = (error_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(error_response), xml);
            else
                wResponses = (fql_query_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(fql_query_response), xml);

            //  XmlSerializer wSerializer = new XmlSerializer(typeof(fql_query_response));
            //wResponses = (fql_query_response)wSerializer.Deserialize(pReader);

            return wResponses;
        }

    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pReader"></param>
        internal static Exception MapErrorAndThrowException(error_response wError)
        {
            //error_response wError = DeserializeError(pReader);
 
            return new Exception(string.Concat("Error: ", wError.error_msg[0], " (cod: ", wError.error_code[0], ")."));
        }
        #endregion


        /// <summary>
        /// Crea una entrada en el visor de eventos
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        internal static void Log(string source , string msg, EventType eventType)
        {
            Event ev = new Event();
            ev.LogType = eventType;
            ev.Source = string.Concat(SocialNetworksServiceName, " ", source);
            ev.Message.Text = msg;
            try
            {
                if(log)
                    StaticLogger.Log(TargetType.WindowsEvent, ev, string.Empty, string.Empty);
            }
            catch (System.Security.SecurityException)
            {
                log = false;//Por problemas de seguridad no se permite loguear mas en el visor de eventos
            }

            Audit(source, msg);
            SendMail(source, msg);
        }
        internal static void Log(string source, Exception ex)
        {
            ///TODO: agregar   ex.StackTrace)a GetAllMessageException
            Log(source, string.Concat(ExceptionHelper.GetAllMessageException(ex), "\r\n-----------StackTrace------------------\r\n ", ex.StackTrace), EventType.Error);
        }
        /// <summary>
        /// Crea una entrada en log.xml
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        internal static void Audit(string source, string msg)
        {
            if (!logOnFile) return;

            Event ev = new Event();
            ev.LogType = EventType.Audit;
            ev.Source = string.Concat (SocialNetworksServiceName," ",source);
            ev.Message.Text = msg;
            StaticLogger.Log(ev, string.Empty, DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'));
        }

        /// <summary>
        /// Envia el error por mail de acuerdo a las direcciones configuradas.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        private static void SendMail(string source, string error)
        {
            if (string.IsNullOrEmpty(MailSender) || MailRecipients.Length == 0)
                return;

            //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            MailMessage wMailMessage = new MailMessage() { Body = error, Subject = source };
            //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            wMailMessage.From = new MailAddress(MailSender);
            //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            foreach (string recipient in MailRecipients)
            {
                wMailMessage.To.Add(new MailAddress(recipient));
            }
            //Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
            //obtenidas en la seccion mailSettings del archivo de configuracion.
            SmtpClient wSmtpClient = new SmtpClient();
            //Envia el correo electronico.
            try
            {
                wSmtpClient.Send(wMailMessage);
            }
            catch { }
        }

    }
    public class Constants
    {
        internal static readonly Int32 SocialNetworkID = 1;

        internal static readonly String Cnnstring = ConfigurationManager.ConnectionStrings["socialnet"].ConnectionString;

        public  static readonly DateTime LogSince = new DateTime(2010, 8, 20);
    }
    public class Enums
    {
        public enum SocialNetwork { Facebook = 1, Twitter = 2 }
    }
}