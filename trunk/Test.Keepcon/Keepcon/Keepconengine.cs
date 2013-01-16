using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Timers;
using Keepcon;

namespace Allus.Keepcon
{
    public delegate void SussessHandler(string status);

    /// <summary>
    /// Componente servicio qu opera directamente con <see cref="Allus.Keepcon.KeepconSvc"/>
    /// Este componente tiene logica de negocio, conoce que metodos de <see cref="Allus.Keepcon.KeepconSvc"/> llamar y los mecanismos derreintento
    /// </summary>
    public partial class Keepconengine : Component
    {
        internal int sleepTime = 0;
        public event SussessHandler SussessEvent;
        //public event StopHandler StopEvent;
        Timer _SendContentTimer;
        Timer _CheckResultTimer;
        /// <summary>
        /// Momento en el q se detuvo el servicio
        /// </summary>
        //DateTime? serviceStopTime;
        public Keepconengine()
        {
            InitializeComponent();
        }

        public Keepconengine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

     

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            OnSussess("Iniciando llamada a web metodos ");
            double interval_SendContent = 0;
            double interval_CheckResult = 0;
            try
            {
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent") != null)
                    interval_SendContent = Convert.ToDouble(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent")) * 1000;
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult") != null)
                   interval_CheckResult = Convert.ToDouble(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult")) * 1000;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al leer configuración Engine.ClockInterval", ex);
                te.ErrorId = "1";
                throw te;

            }
            _SendContentTimer = new Timer(interval_SendContent);
            _SendContentTimer.Elapsed += new ElapsedEventHandler(_SendContentTimer_Elapsed);
            _SendContentTimer.Start();

            _CheckResultTimer = new Timer(interval_CheckResult);
            _CheckResultTimer.Elapsed += new ElapsedEventHandler(_CheckResultTimer_Elapsed);
            _CheckResultTimer.Start();

        }


        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _SendContentTimer.Stop();
            _SendContentTimer.Dispose();
            _CheckResultTimer.Stop();
            _CheckResultTimer.Dispose();

            ///OnSussess(string.Concat(Helper.ServiceName, " detenido"));
            Helper.Log(Helper.ServiceName, "Fin de llamadas a servicio web", Fwk.Logging.EventType.Information, true);

        }



        #region _SendContentTimer
        /// <summary>
        /// 
        /// </summary>
        public void Start_SendContent()
        {
            //OnSussess("Iniciando llamada a web metodos ");
            Helper.Log(Helper.ServiceName, "SendContent: Iniciando envia de post a keepcont", Fwk.Logging.EventType.Information, false);
            double interval = 0;
            try
            {
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent") != null)
                    interval = Convert.ToDouble(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent")) * 1000;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("SendContent: Error al leer configuración Engine.ClockInterval_SendContent", ex);
                te.ErrorId = "1";
                Helper.Log(Helper.ServiceName, te, true);
                throw te;

            }
            _SendContentTimer = new Timer(interval);
            _SendContentTimer.Elapsed += new ElapsedEventHandler(_SendContentTimer_Elapsed);
            _SendContentTimer.Start();



        }


        /// <summary>
        /// 
        /// </summary>
        public void Stop_SendContent()
        {
            _SendContentTimer.Stop();
            _SendContentTimer.Dispose();


            ///OnSussess(string.Concat(Helper.ServiceName, " detenido"));
            Helper.Log(Helper.ServiceName, "Fin de llamadas a servicio web", Fwk.Logging.EventType.Information, true);

        }

        private void _SendContentTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _SendContentTimer.Stop();
          
            try
            {
                this.SendContent();
            }
           
            catch (Exception ex)
            {
                Helper.Log(Helper.ServiceName, Helper.GetLogMessage(ex), Fwk.Logging.EventType.Error, true);
            }
            finally
            {
                _SendContentTimer.Start();
            }
       

        }

        /// <summary>
        /// Send_To_Keepcon 
        /// </summary>
        public void SendContent()
        {

            
            List<KeepconPost> posts = KeepconSvc.RetrivePost_To_Send(12);
            if (posts.Count != 0)
            {
                Allus.Keepcon.Import.Import wImport = new Allus.Keepcon.Import.Import(posts);
                Helper.Log(Helper.ServiceName, string.Format("SendContent: Enviando {0} post", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
                KeepconSvc.SendContent(wImport);
                Helper.Log(Helper.ServiceName, string.Format("SendContent: Envio de {0} post: FINALIZADO", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
            }
            else
            {
                Helper.Log(Helper.ServiceName, string.Format("SendContent: No hay post para enviar", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
            }
        }
        #endregion


        #region CheckResult_From_Keepcon
        /// <summary>
        /// 
        /// </summary>
        public void Start_CheckResult()
        {
            //OnSussess("CheckResult: Iniciando llamada a web metodos ");
            double interval = 0;
            try
            {
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult") != null)
                    interval = Convert.ToDouble(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult")) * 1000;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("CheckResult : Error al leer configuración Engine.ClockInterval_CheckResult", ex);
                te.ErrorId = "1";
                Helper.Log(Helper.ServiceName, te,true);
                throw te;

            }

            _CheckResultTimer = new Timer(interval);
            _CheckResultTimer.Elapsed += new ElapsedEventHandler(_CheckResultTimer_Elapsed);
            _CheckResultTimer.Start();

        }


        /// <summary>
        /// 
        /// </summary>
        public void Stop_CheckResult()
        {
            _CheckResultTimer.Stop();
            _CheckResultTimer.Dispose();

            ///OnSussess(string.Concat(Helper.ServiceName, " detenido"));
            Helper.Log(Helper.ServiceName, "CheckResult: Fin de llamadas a servicio web", Fwk.Logging.EventType.Information, true);

        }
        private void _CheckResultTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _CheckResultTimer.Stop();

            try
            {
                this.CheckResult_From_Keepcon();
            }
            catch (Exception ex)
            {
                Helper.Log(Helper.ServiceName, Helper.GetLogMessage(ex), Fwk.Logging.EventType.Error, true);
            }
            finally
            {
                _CheckResultTimer.Start();
            }
        }

        public void CheckResult_From_Keepcon()
        {
            Helper.Log(Helper.ServiceName, "CheckResult_From_Keepcon: Iicio ", Fwk.Logging.EventType.Information, false);
            Allus.Keepcon.Export.Export export = KeepconSvc.RetriveResult_2();
            if (export != null)
            {

                Helper.Log(Helper.ServiceName, string.Format("CheckResult: Guardando resultado keepcont :Cantidad {0}", export.Contents.Count), Fwk.Logging.EventType.Information, false);
                KeepconSvc.SaveResult(export);
                Helper.Log(Helper.ServiceName, string.Format("CheckResult: Se almacenaron {0} post", export.Contents.Count), Fwk.Logging.EventType.Information, false);

                KeepconSvc.SendASK(export.SetId);
            }
            else
            { Helper.Log(Helper.ServiceName, string.Format("CheckResult: Las respuesta del chequeo arrojo un reult = null", export.Contents.Count), Fwk.Logging.EventType.Information, false); }
        }

        public void SendASK(string setId)
        {
            try
            {
                KeepconSvc.SendASK(setId);
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(String.Format("CheckResult : SendASK lote {0} fallo",setId ), ex);
                te.ErrorId = "1";
                Helper.Log(Helper.ServiceName, te, false);
         
            }
            
            KeepconSvc.SaveResult_ACK(setId);
        }


        public void SaveResult(Export.Export export)
        {
            KeepconSvc.SaveResult(export);
        }

        #endregion

        void OnSussess(string status)
        {
            if (SussessEvent != null)
                SussessEvent(status);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool CheckStopTime(DateTime? t)
        {
            //TODO: Codigo de Detencion del servicio
            return true;
            //if (!t.HasValue) return true;
            //if (System.DateTime.Compare(System.DateTime.Now, t.Value) > 0)
            //{
            //    t = null;
            //    return true;
            //}
            //else { return false; }
        }


    }
}
