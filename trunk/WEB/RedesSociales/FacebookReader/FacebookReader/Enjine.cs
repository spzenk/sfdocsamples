using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Configuration;
using System.Net.Mail;

namespace Fwk.SocialNetworks.Twitter
{
    public partial class Enjine : Component
    {

        Timer _Timer; 

        public Enjine()
        {
            InitializeComponent();
        }

        public Enjine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Start()
        {
            int interval = 0;
            if (ConfigurationManager.AppSettings["ClockInterval"] != null)
             interval = Convert.ToInt32(ConfigurationManager.AppSettings["ClockInterval"]);

            _Timer = new Timer(interval * 1000 * 60);
            //Agrega el manejador del evento de timer.
            _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
            //Inicia el timer.
            _Timer.Start();

            
        }

        public void Stop()
        {
            _Timer.Stop();
           // _Timer.Elapsed -=       
        }


        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _Timer.Enabled = false;

            try
            {
                this.LogFacebook();

                this.LogTwitter();
            }
            finally
            {
                _Timer.Enabled = true;
            }
        }

        #region [Methods]

        /// <summary>
        /// Loguea los post y los mensajes de Facebook en la DB.
        /// </summary>
        private void LogFacebook()
        {
            FacebookProcessor wFacebookFactory = new FacebookProcessor();

            try
            {
                wFacebookFactory.StoreNewStream();
            }
            catch (Exception ex)
            {
                this.HandleException("SocialNetworkLogService - Facebook Posts", ex);
            }

            try
            {
                //wFacebookFactory.StoreNewMessages();
            }
            catch (Exception ex)
            {
                this.HandleException("SocialNetworkLogService - Facebook Messages", ex);
            }
        }

        /// <summary>
        /// Loguea los tweets y los directmessages de twitter en la DB.
        /// </summary>
        private void LogTwitter()
        {
            TwitterProcessor wTwitterFactory = new TwitterProcessor();

            try
            {
                
                
                    wTwitterFactory.LogStatuses();
                
            }
            catch (Exception ex)
            {
                this.HandleException("SocialNetworkLogService - Twitter Statuses", ex);
            }

            try
            {
              
                    wTwitterFactory.LogMessages();
               
            }
            catch (Exception ex)
            {
                this.HandleException("SocialNetworkLogService - Twitter Messages", ex);
            }
        }

        /// <summary>
        /// Obtiene el detalle del error, escribe una entrada en registro de sucesoa y lo envia por mail.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="ex">Excepcion producida</param>
        private void HandleException(string source, Exception ex)
        {
            StringBuilder wError;

            wError = new StringBuilder();
            wError.AppendLine("Error message:");
            wError.AppendLine(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            wError.AppendLine("StackTrace:");
            wError.AppendLine(ex.StackTrace);

            //this.CheckInnerException(ex, ref wError);

            this.WriteLog(source, wError.ToString());

            this.SendMail(source, wError.ToString());
        }

        ///// <summary>
        ///// Comprueba si la excepcion contiene excepciones internas y las agrega al <paramref name="error"/> recibido.
        ///// </summary>
        ///// <param name="ex">Excepcion a controlar.</param>
        ///// <param name="error">Por referencia: detalle del error.</param>
        //private void CheckInnerException(Exception ex, ref StringBuilder error)
        //{
        //    if (ex.InnerException != null)
        //    {
        //        error.AppendLine("---[Inner Exception]---");
        //        error.AppendLine(ex.InnerException.Message);
        //        error.AppendLine(ex.InnerException.StackTrace);
        //        this.CheckInnerException(ex.InnerException, ref error);
        //    }
        //}

        /// <summary>
        /// Escribe el error en el registro de sucesos.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        private void WriteLog(string source, string error)
        {
            //eventLog1.Source = string.Format("{0} - {1}", source, Properties.Settings.Default.Implementation);

            //eventLog1.WriteEntry(error, EventLogEntryType.Error);
        }

        /// <summary>
        /// Envia el error por mail de acuerdo a las direcciones configuradas.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        private void SendMail(string source, string error)
        {
            ////Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            //MailMessage wMailMessage = new MailMessage() { Body = error, Subject = source };
            ////Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            //wMailMessage.From = new MailAddress(Properties.Settings.Default.MailSender);
            ////Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            //foreach (string recipient in Properties.Settings.Default.MailRecipients)
            //{
            //    wMailMessage.To.Add(new MailAddress(recipient));
            //}
            ////Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
            ////obtenidas en la seccion mailSettings del archivo de configuracion.
            //SmtpClient wSmtpClient = new SmtpClient();
            //Envia el correo electronico.
            //wSmtpClient.Send(wMailMessage);
        }

        #endregion
    }
}
