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
using System.Security;
using Fwk.Security.Cryptography;



namespace Allus.Keepcon
{
    public class Helper
    {
        //internal static String Cnnstring = string.Empty;
        public static bool WsSecure = false;
        public static string ServiceName = "Keepcon test service";
        static Boolean logOnFile = false;


        static string logFileFullName;
     
        static Helper()
        {
            try
            {
                //Cnnstring = ConfigurationManager.ConnectionStrings["BB_MovistarSM_LogsEntities"].ConnectionString;
                logFileFullName = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "{0}_LogFile.xml");

                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "LogOnFile") != null)
                    logOnFile = Convert.ToBoolean(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "LogOnFile"));

                
        
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al leer configuración en Helper()", ex);
                te.ErrorId = "1";
                throw te;

            }
        }

        static bool sendWindowsEvent_ok= true;
        /// <summary>
        /// Crea una entrada en el visor de eventos
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void Log(string source, string msg, EventType eventType, bool sendWindowsEvent)
        {
            Event ev = new Event();
            ev.LogType = eventType;
            ev.Source = source;
            ev.Message.Text = msg;
            ev.LogDate = System.DateTime.Now;

            try
            {
                if (sendWindowsEvent && sendWindowsEvent_ok)
                    StaticLogger.Log(TargetType.WindowsEvent, ev, string.Empty, string.Empty);
            }
            catch (System.Security.SecurityException se)
            {
                sendWindowsEvent_ok = false;
                Event ev1 = new Event();
                ev1.LogType = EventType.Warning;
                ev1.Source = ServiceName;
                ev1.Message.Text = string.Concat("problemas de seguridad no se permite loguear mas en el visor de eventos\r\n", ExceptionHelper.GetAllMessageException(se));
                ev1.LogDate = System.DateTime.Now;

                Audit(ev1);
            }
            catch (System.ComponentModel.Win32Exception we)//Puede q se llene el log de windows
            {
                sendWindowsEvent_ok = false;
                Event ev1 = new Event();
                ev1.LogType = EventType.Warning;
                ev1.Source = ServiceName;
                ev1.Message.Text = string.Concat("Problemas para crear logs en el visor de eventos, puede que este lleno\r\n", ExceptionHelper.GetAllMessageException(we));
                ev1.LogDate = System.DateTime.Now;

                Audit(ev1);
            }

            Audit(ev);
            //SendMail(source, msg);
        }


        public static void Log(string source, Exception ex, bool sendWindowsEvent)
        {
            ///TODO: agregar   ex.StackTrace)a GetAllMessageException
            Log(source, string.Concat(ExceptionHelper.GetAllMessageException(ex), "\r\n-----------StackTrace------------------\r\n ", ex.StackTrace), EventType.Error, sendWindowsEvent);
        }
        internal static string GetLogMessage(Exception ex)
        {
            return string.Concat("\r\n", ExceptionHelper.GetAllMessageException(ex), "\r\n-----------StackTrace------------------\r\n ", ex.StackTrace);
        }
        /// <summary>
        /// Crea una entrada en log.xml
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void Audit(Event ev)
        {
            if (!logOnFile) return;

            StaticLogger.Log(TargetType.File, ev,
                      string.Format(logFileFullName, DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'))
                      , string.Empty);
        }

        /// <summary>
        /// Envia el error por mail de acuerdo a las direcciones configuradas.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        //public static void SendMail(string source, string error)
        //{
        //    if (string.IsNullOrEmpty(MailSender) || MailRecipients.Length == 0)
        //        return;

        //    //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
        //    MailMessage wMailMessage = new MailMessage() { Body = error, Subject = source };
        //    //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
        //    wMailMessage.From = new MailAddress(MailSender);
        //    //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
        //    foreach (string recipient in MailRecipients)
        //    {
        //        wMailMessage.To.Add(new MailAddress(recipient));
        //    }
        //    //Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
        //    //obtenidas en la seccion mailSettings del archivo de configuracion.
        //    SmtpClient wSmtpClient = new SmtpClient();
        //    //Envia el correo electronico.
        //    try
        //    {
        //        wSmtpClient.Send(wMailMessage);
        //    }
        //    catch { }
        //}

        internal SecureString GetSecureString(string pwd)
        {
            SecureString wSecureString = new SecureString();

            foreach (char c in pwd.ToCharArray())
            {
                wSecureString.AppendChar(c);
            }
            return wSecureString;
        }
    }

    public class Enums
    {
        public enum Status { Arrived = 4000, SendedError = 4001, SendedOk = 4002 }
    }
    public class SocialNetworkId
    {
        public enum Status { Arrived = 4000, SendedError = 4001, SendedOk = 4002 }
    }
    public class lic
    {
        public static void chk()
        {
            DateTime expTime = new DateTime();
            string expk = "7gp6CZ+Y8BZULbjOOkT86vi8HnrtyaIQ6WiLhdY48jY=$PbUiRifcU1q8Egl96hC7tw==";
            string l = string.Empty;
            string sn = string.Empty;
            try
            {
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "lic") != null)
                    l = Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "lic").ToString();

                if (string.IsNullOrEmpty(l))
                {
                    TechnicalException te = new TechnicalException("Your pelsoft license is corrupted. Please contact your suppor or software provider");
                    te.Source = "Pelsoft Lic mannager";
                    te.ErrorId = "100";
                    throw te;
                }

                FwkSymetricAlg a = new FwkSymetricAlg(expk);

                string[] decrypted = a.Dencrypt(l).Split('$');

                string[] d = decrypted[1].Split('|');
                sn= decrypted[0];

                expTime = new DateTime(Convert.ToInt32(d[2]), Convert.ToInt32(d[1]), Convert.ToInt32(d[0]));
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException("Your pelsoft license has expired or is corrupted. Please contact your suppor or software provider", ex);
                te.Source = "Pelsoft Lic mannager";
                te.ErrorId = "100";
                throw te;
            }


            chkExp(5, expTime);
            chkAuthorization(sn);
        }

        static void chkAuthorization(string data)
        {
            if (!data.Equals(Fwk.HelperFunctions.EnvironmentFunctions.GetDriverSerealNumber()))
            {
                TechnicalException te = new TechnicalException("Your pelsoft license is corrupted. Host not authorized. Please contact your suppor or software provider");
                te.Source = "Pelsoft Lic mannager";
                te.ErrorId = "102";
                throw te;
            
            }
        }

        static void chkExp(int? alerSince, DateTime expTime)
        {
            //expTime = new DateTime(2011, 12, 5);
            DateTime today = DateTime.Now;//new DateTime(2011, 12, 2);
            //Si ya paso
            if (DateTime.Compare(today, expTime) >= 0)
            {
                TechnicalException te = new TechnicalException("Your pelsoft license has expired . Please contact your suppor software provider for renew");
                te.Source = "Pelsoft Lic mannager";
                te.ErrorId = "101";
                throw te;
            }

            TimeSpan dateDif = today - expTime;
            //Si faltan = o menos dias que aviar desde
            //alerSince >= days => 0
            if (alerSince >= (dateDif.Days * -1))
            {
                TechnicalException te = new TechnicalException(string.Format("Your pelsoft license will expire in {0} days. Please contact your suppor software provider for renew", dateDif.Days));
                te.Source = "Pelsoft Lic mannager";
                te.ErrorId = "101";
                throw te;
            }





        }
    }
}