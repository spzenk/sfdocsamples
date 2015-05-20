using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Xml.Serialization;
using System.IO;
using System.Configuration;

using Fwk.Logging;
using Fwk.HelperFunctions;
using Fwk.Logging.Targets;
using Fwk.Exceptions;
using System.Net.Mail;
using System.Net;
using System.Data.Linq;
using System.Reflection;
using System.Diagnostics;

using WebChat.Logic.DAC;




namespace WebChat.Common
{
    public class Helper
    {
        //static bool WindowsEventFail = false;
        //public static string Application { get; set; }
        //public static ServiceInstance_Struct Instance { get; set; }
        //static bool performLog = true;
        //public static String email_log_body = "Email_Log.htm";

        static Helper()
        {
            //Fwk.HelperFunctions.DateFunctions.BeginningOfTimes = new DateTime(1753, 1, 1);

            //string fullFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Email_Log.htm");
            //email_log_body = Fwk.HelperFunctions.FileFunctions.OpenTextFile(fullFileName);

        }
        #region Log audit EpironEvent

        /// <summary>
        /// 
        /// </summary>
        /// <param name="epironEvent"></param>
        /// <param name="sendMail"></param>
        /// <param name="auditMailSetting">Si es un proceso y Audit_MailSendMail=false, se intentara enviar desde el la instancia del servicio. (configuracion en la master)</param>
        //public static void Log(EpironEvent epironEvent, bool sendMail, AuditMailSetting_Struct auditMailSetting)
        public static void Log(string pMessage)
        {
            #region Crea un Log Objeto
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Machine = Environment.MachineName;
            //epironEvent.AppId = Helper.Application;
            epironEvent.LogDate = System.DateTime.Now;
            epironEvent.User = Environment.UserName;
            epironEvent.Message.Text = pMessage;
            //epironEvent.ServiceInstanceUnique = Helper.Instance.ServiceInstanceUnique;
            #endregion

            try
            {

                //if (performLog)
                    LogDAC.Write(epironEvent);
                //else
                //Log_NonDatabase(epironEvent);//PAra el caso donde ya no se puede almacenar en BD el error
            }
            catch (System.Exception ex)//Puede q se llene el log de windows
            {
                //performLog = false;
                //Log_NonDatabase(epironEvent, ex);
            }
            //Si Instance.SendMail =false es por que no esta configurado las opciones de envio en Master.ServiceInstance
            //if (sendMail & auditMailSetting != null)
            //    SendMail(epironEvent, auditMailSetting);
        }

        /*
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="epironEvent"></param>
        /// <param name="ex"></param>
        /// <param name="sendMail"></param>
        /// <param name="auditMailSetting"></param>
        public static void Log(EpironEvent epironEvent, Exception ex, bool sendMail, AuditMailSetting_Struct auditMailSetting)
        {
            epironEvent.Message.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            epironEvent.LogType = EventType.Error;
            if (String.IsNullOrEmpty(epironEvent.Source))
                epironEvent.Source = ex.Source;
            Log(epironEvent, sendMail, auditMailSetting);
        }*/
        #endregion
        /*

        #region Log audit Fwk Event

        public static void Log(string source, string msg, EventType eventType, bool sendMail, AuditMailSetting_Struct auditMailSetting)
        {
            #region Crea un Log Objeto
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Source = source;
            epironEvent.Message.Text = msg;
            epironEvent.LogType = eventType;
            #endregion

            Log(epironEvent, sendMail, auditMailSetting);
        }
        /// <summary>
        /// Crea una entrada en el visor de eventos
        /// </summary>
        /// <param name="source"></param>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        /// <param name="sendMail">Determina si en este Log se enviara un e-mail </param>
        public static void Log(string source, string msg, EventType eventType, bool sendMail)
        {
            #region Crea un Log Objeto
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Source = source;
            epironEvent.Message.Text = msg;
            epironEvent.LogType = eventType;
            #endregion
            Log(epironEvent, sendMail, Instance.AuditMailSetting);
        }
        public static void Log(string source, Exception ex, bool sendMail)
        {
            #region Crea un Log Objeto
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Source = source;

            #endregion

            Log(epironEvent, ex, sendMail, Helper.Instance.AuditMailSetting);
        }

        public static void Log(string source, Exception ex, AuditMailSetting_Struct auditMailSetting)
        {
            #region Crea un Log Objeto
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Source = source;
            #endregion
            Log(epironEvent, ex, true, auditMailSetting);
        }

        #endregion


        #region Log_NonDatabase
        /// <summary>
        /// intenta almacenar los evcentos en visor de sucesos y/o log.xml
        /// </summary>
        /// <param name="originalEvent">El evento real q se intento loguear</param>
        /// <param name="someError">Error producido por mecanismos de logueo</param>
        public static void Log_NonDatabase(Event originalEvent, Exception someError = null)
        {
            Event someOtherEvent = GetEcentFromException(someError);
            try
            {
                if (WindowsEventFail == false)
                {
                    StaticLogger.Log(TargetType.WindowsEvent, originalEvent, string.Empty, string.Empty);
                    if (someOtherEvent != null)
                        StaticLogger.Log(TargetType.WindowsEvent, someOtherEvent, string.Empty, string.Empty);
                }
                else
                {
                    Log_FileSystem(originalEvent);
                    Log_FileSystem(someOtherEvent);
                }
            }
            catch (System.Security.SecurityException ex)
            {
                WindowsEventFail = true;
                Log_FileSystem(ex);
                Log_FileSystem(someOtherEvent);
                Log_FileSystem(originalEvent);
            }
            catch (System.ComponentModel.Win32Exception e)//Puede q se llene el log de windows
            {
                WindowsEventFail = true;
                Log_FileSystem(e);
                Log_FileSystem(someOtherEvent);
                Log_FileSystem(originalEvent);
            }
        }

        /// <summary>
        /// Intenta almacenar eventos en file system
        /// </summary>
        /// <param name="ev"></param>
        public static void Log_FileSystem(Event ev)
        {
            if (ev == null) return;

            try
            {
                //StaticLogger.Log(TargetType.File, ev,
                //       string.Format(Helper.Instance.LogFileFullName, DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'))
                //       , string.Empty);

            }
            catch (System.Security.SecurityException ex)
            {
                TechnicalException te = new TechnicalException("No hay permisos para escrivir en el event log", ex);
                te.ErrorId = "2000";
                te.Source = ex.Source;
                throw te;
            }
        }
        /// <summary>
        /// Intenta almacenar eventos/errores en file system
        /// </summary>
        /// <param name="ev"></param>
        public static void Log_FileSystem(Exception ex)
        {
            if (ex == null) return;
            Event ev = new Event();
            ev.LogType = EventType.Error;
            ev.Source = ex.Source;
            ev.User = Environment.UserName;
            ev.Machine = Environment.MachineName;
            ev.AppId = Helper.Application;
            ev.Message.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            ev.LogDate = System.DateTime.Now;
            Log_FileSystem(ev);
        }


        static Event GetEcentFromException(Exception ex)
        {
            Event ev = new Event();
            ev.LogType = EventType.Error;
            ev.Source = ex.Source;
            ev.User = Environment.UserName;
            ev.Machine = Environment.MachineName;
            ev.AppId = Helper.Application;
            ev.Message.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            ev.LogDate = System.DateTime.Now;

            return ev;
        }
        /// <summary>
        /// Envia el error por mail de acuerdo a las direcciones configuradas.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        public static void SendMail(string source, string message, AccountsInstancesServicesBE pAccountsInstancesServicesBE)
        {
            EpironEvent epironEvent = new EpironEvent();
            epironEvent.Source = source;
            epironEvent.Message.Text = message;
            epironEvent.Machine = Environment.MachineName;
            epironEvent.AppId = Helper.Application;
            epironEvent.LogDate = System.DateTime.Now;
            epironEvent.User = Environment.UserName;
            epironEvent.ServiceInstanceUnique = Helper.Instance.ServiceInstanceUnique;
            epironEvent.AsiDetailUnique = pAccountsInstancesServicesBE.AsiDetailUnique;
            epironEvent.AccountDetailUnique = pAccountsInstancesServicesBE.AccountDetailUnique;
            
            SendMail(epironEvent, Helper.Instance.AuditMailSetting);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="error"></param>
        /// <param name="auditMailSetting"></param>
        public static void SendMail(EpironEvent epironEvent, AuditMailSetting_Struct auditMailSetting)
        {
            //Si es false se intentara enviar con La configuracion de la master 
            //Puede que AuditMailSetting_Struct = Helper.Instance.AuditMailSetting y las dos comprobaciones seria innesesarias: pero por cuestiones de rapido desarrollo
            //y mator control de esta funcionalidad se realiza aqui
            if (auditMailSetting.IsServiceInstance == false && auditMailSetting.Audit_MailSendMail == false)
            {
                if (Helper.Instance.AuditMailSetting.Audit_MailSendMail)
                    auditMailSetting = Helper.Instance.AuditMailSetting;
                else
                    return;
            }
            try
            {
                if (auditMailSetting.Audit_MailSendMail == false) return;
                VerifySendMail(auditMailSetting);

                #region Setting e-mail SmtpClient
                string body = GeneratEmailBody(epironEvent);
                //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
                System.Net.Mail.MailMessage wMailMessage = new System.Net.Mail.MailMessage() { Body = body, Subject = String.Concat("Error epiron :", epironEvent.Source) };

                wMailMessage.IsBodyHtml = true;

                //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
                wMailMessage.From = new MailAddress(auditMailSetting.Audit_MailSender);

                //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
                foreach (string recipient in auditMailSetting.MAIL_Recipients)
                {
                    wMailMessage.To.Add(new MailAddress(recipient));
                }

                var smtpclient = new SmtpClient(auditMailSetting.Audit_MailSMTP_SERVER, auditMailSetting.Audit_MailSMPT_PORT.Value)
                {

                    Credentials = new NetworkCredential(auditMailSetting.Audit_MailUserName, auditMailSetting.Audit_MailPassword),
                    EnableSsl = auditMailSetting.Audit_MailEnableSSL.Value
                };
                #endregion


                smtpclient.Send(wMailMessage);
            }
            catch (Exception ex)
            {
                //Intenta enviar si y solo si el error se produjo de una cuenta y no del service instance
                if (auditMailSetting.IsServiceInstance == false)
                    SendMail(epironEvent, Helper.Instance.AuditMailSetting);

                //Loguea la ocurrencia de error tecnico de envio de e-mail
                Log(epironEvent, ex, false, null);
            }
        }

        private static void VerifySendMail(AuditMailSetting_Struct auditMailSetting)
        {
            if (auditMailSetting.IsServiceInstance) return;

            EpironException ex = null;


            if (string.IsNullOrEmpty(auditMailSetting.Audit_MailSender))
                ex = new EpironException("Falta MailSender", null);
            if (string.IsNullOrEmpty(auditMailSetting.Audit_MailRecipients))
                ex = new EpironException("Falta MailRecipients", null);

            if (string.IsNullOrEmpty(auditMailSetting.Audit_MailPassword))
                ex = new EpironException("Falta MailPassword", null);

            if (string.IsNullOrEmpty(auditMailSetting.Audit_MailSMTP_SERVER))
                ex = new EpironException("Falta MailSMTP_SERVER", null);


            if (string.IsNullOrEmpty(auditMailSetting.Audit_MailUserName))
                ex = new EpironException("Falta MailUserName", null);

            if (auditMailSetting.Audit_MailSMPT_PORT.HasValue == false)
                ex = new EpironException("Falta MailSMPT_PORT", null);

            if (auditMailSetting.Audit_MailEnableSSL.HasValue == false)
                ex = new EpironException("Falta MailEnableSSL", null);


            if (ex != null) throw ex;

        }

        #endregion



        public static byte[] ConvertStreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUrl"></param>
        /// <param name="pProxy"></param>
        /// <param name="pTimeout"></param>
        public static void HttpPost(Uri pUrl, IWebProxy pProxy, int? pTimeout = null)
        {
            HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(pUrl);
            wRequest.KeepAlive = false;

            if (pTimeout.HasValue)
            {
                wRequest.Timeout = pTimeout.Value;
                wRequest.ServicePoint.ConnectionLeaseTimeout = pTimeout.Value;
                wRequest.ServicePoint.MaxIdleTime = pTimeout.Value;
                wRequest.ServicePoint.MaxIdleTime = pTimeout.Value;
                wRequest.ReadWriteTimeout = pTimeout.Value;
            }

            if (pProxy != null) 
            {
                wRequest.Proxy = pProxy;
            }

            ASCIIEncoding wEncoding = new ASCIIEncoding();
            Byte[] wByte = wEncoding.GetBytes(pUrl.ToString());

            wRequest.Method = "POST";
            wRequest.ContentType = "application/x-www-form-urlencoded";
            wRequest.ContentLength = wByte.Length;

            using (Stream wRequestStream = wRequest.GetRequestStream())
            {
                wRequestStream.Write(wByte, 0, wByte.Length);
                wRequestStream.Flush();
                wRequestStream.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUrl"></param>
        /// <param name="pProxy"></param>
        public static StreamReader HttpPost(Uri pUrl, WebProxy pProxy)
        {
            HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(pUrl);

            if (pProxy != null)
            {
                wRequest.Proxy = pProxy;
            }

            ASCIIEncoding wEncoding = new ASCIIEncoding();
            Byte[] wByte = wEncoding.GetBytes(pUrl.ToString());

            wRequest.Method = "POST";
            wRequest.ContentType = "application/x-www-form-urlencoded";
            wRequest.ContentLength = wByte.Length;

            Stream wRequestStream = wRequest.GetRequestStream();
            wRequestStream.Write(wByte, 0, wByte.Length);
            wRequestStream.Close();

            return HttpGet(pUrl, pProxy);
        }

        /// <summary>
        /// Se conecta a la URI y te devuelve un reader para leer los resultados de la consulta.
        /// </summary>
        public static StreamReader HttpGet(Uri pUrl, WebProxy pProxy)
        {
            HttpWebRequest wRequest = (HttpWebRequest)WebRequest.Create(pUrl);

            if (pProxy != null)
            {
                wRequest.Proxy = pProxy;
            }

            HttpWebResponse wResponse = (HttpWebResponse)wRequest.GetResponse();

            StreamReader wReader = new StreamReader(wResponse.GetResponseStream());

            return wReader;
        }

        /// <summary>
        /// Genera un html con el epironEvent desde un template
        /// </summary>
        /// <param name="epironEvent"></param>
        /// <returns></returns>
        static String GeneratEmailBody(EpironEvent epironEvent)
        {
            StringBuilder BODY = new StringBuilder(email_log_body);
            BODY.Replace("$instancename$", Helper.Instance.InstanceName);
            BODY.Replace("$ServiceInstanceUnique$", epironEvent.ServiceInstanceUnique.ToString());
            BODY.Replace("$source$", epironEvent.Source);
            BODY.Replace("$message$", epironEvent.Message.Text);

            if (epironEvent.AsiDetailUnique.HasValue)
                BODY.Replace("$asidetailunique$", epironEvent.AsiDetailUnique.ToString());
            else
                BODY.Replace("$asidetailunique$", "");

            if (epironEvent.AccountDetailUnique.HasValue)
                BODY.Replace("$accountdetailunique$", epironEvent.AccountDetailUnique.ToString());
            else
                BODY.Replace("$accountdetailunique$", "");

            return BODY.ToString();
        }

        /// <summary>
        /// Genera una Exception.
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static void GeneratedException(String pMessage, Object pObject, String pSourceName)
        {
            Exception ex = new Exception(pMessage);
            EpironException e = EpironException.ProcessException(ex, pObject);
            e.Source = pSourceName;
            throw e;
        }

    }



    /// <summary>
    /// Busca la imágen del usuario de una red social en Byte[]
    /// </summary>
    public class WebFunctions
    {
        public static byte[] GetBytesFromUrl(string url, AccountsInstancesServicesBE pAccountServiceInstance)
        {
            byte[] b = null;

            WebResponse myResp = null;
            try
            {
                if (String.IsNullOrEmpty(url))
                    return null;

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);

                //Creo proxy
                WebProxy myProxy = new WebProxy(pAccountServiceInstance.Proxy.ProxyHost, pAccountServiceInstance.Proxy.ProxyPort);
                myProxy.Credentials = new System.Net.NetworkCredential(pAccountServiceInstance.Proxy.ProxyUserName, pAccountServiceInstance.Proxy.ProxyPassword, pAccountServiceInstance.Proxy.ProxyDomain);

                myReq.Proxy = myProxy;

                myResp = myReq.GetResponse();

                Stream stream = myResp.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    b = br.ReadBytes(500000);
                    br.Close();
                }
                myResp.Close();
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
    */
    }
}