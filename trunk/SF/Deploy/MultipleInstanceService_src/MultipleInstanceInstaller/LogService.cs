using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.Timers;
using System.Net.Mail;
using System.Configuration;


namespace MultipleInstanceService
{
    public partial class LogService : ServiceBase
    {
       

        Timer _Timer;
       


        #region [Constructor]

        public LogService()
        {
            InitializeComponent();
            this.ServiceName = ConfigurationManager.AppSettings.Get("ServiceName");
        }

        #endregion

        #region [Events]

        protected override void OnStart(string[] args)
        {
            WriteLog("Inicio de", this.ServiceName);
            //Setea el valor del intervalo del timer en minutos de acuerdo a la configuracion.
            _Timer = new Timer(Properties.Settings.Default.TimerInterval * 1000);
            //Agrega el manejador del evento de timer.
            _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
            //Inicia el timer.
            _Timer.Start();

           
        }

        protected override void OnStop()
        {
            _Timer.Stop();
            _Timer.Dispose();

            WriteLog("Se detuvo de", this.ServiceName);
       
        }

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _Timer.Enabled = false;

            try
            {
                WriteLog("Ejecucion de", this.ServiceName);
            }
            finally
            {
                _Timer.Enabled = true;
            }
        }

        #endregion

        #region [Methods]

       

        /// <summary>
        /// Comprueba si la excepcion contiene excepciones internas y las agrega al <paramref name="error"/> recibido.
        /// </summary>
        /// <param name="ex">Excepcion a controlar.</param>
        /// <param name="error">Por referencia: detalle del error.</param>
        private void CheckInnerException(Exception ex, ref StringBuilder error)
        {
            if (ex.InnerException != null)
            {
                error.AppendLine("---[Inner Exception]---");
                error.AppendLine(ex.InnerException.Message);
                error.AppendLine(ex.InnerException.StackTrace);
                this.CheckInnerException(ex.InnerException, ref error);
            }
        }

        /// <summary>
        /// Escribe el error en el registro de sucesos.
        /// </summary>
        /// <param name="source">Origen del error</param>
        /// <param name="error">Detalle del error</param>
        private void WriteLog(string source, string error)
        {
            eventLog1.Source = string.Format("{0} - {1}", source, Properties.Settings.Default.Implementation);

            eventLog1.WriteEntry(error, EventLogEntryType.Error);
        }

     

        #endregion
    }
}