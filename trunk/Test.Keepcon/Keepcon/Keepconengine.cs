using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Timers;

namespace Allus.Keepcon
{
    public delegate void SussessHandler(string status);
    public partial class Keepconengine : Component
    {
        internal int sleepTime = 0;
        public event SussessHandler SussessEvent;
        //public event StopHandler StopEvent;
        Timer _Timer;
        /// <summary>
        /// Momento en el q se detuvo el servicio
        /// </summary>
        DateTime? serviceStopTime;
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
            double interval = 0;
            try
            {
                if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval") != null)
                    interval = Convert.ToDouble(Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval")) * 1000;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al leer configuración en Helper()", ex);
                te.ErrorId = "1";
                throw te;

            }
            _Timer = new Timer(interval);
            _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
            _Timer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _Timer.Stop();
            _Timer.Dispose();
            ///OnSussess(string.Concat(Helper.ServiceName, " detenido"));
            Helper.Log(Helper.ServiceName, "Fin de llamadas a servicio web", Fwk.Logging.EventType.Information,true);

        }


        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _Timer.Stop();
            ///TODO: Codigo de Detencion del servicio
            //if (CheckStopTime(serviceStopTime))
            //{
            //serviceStopTime = null;
            try
            {
                this.Send_To_Keepcon();
            }
            //TODO: Codigo de Detencion del servicio
            //catch (TechnicalException te)
            //{
            //    if (te.ErrorId != null)
            //    {
            //        ///Detiene por problñemas con SQL Server
            //        if (te.ErrorId.Equals("2") || te.ErrorId.Equals("3"))
            //        {
            //            serviceStopTime = System.DateTime.Now.AddMinutes(sleepTime);
            //            Helper.Log(Helper.ServiceName, string.Concat("Detenido temporalmente por ", sleepTime.ToString(), " minutos. Motivos \r\n", Helper.GetLogMessage(te)), Fwk.Logging.EventType.Error);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        Helper.Log(Helper.ServiceName, Helper.GetLogMessage(te), Fwk.Logging.EventType.Error);
            //    }
            //}
            catch (Exception ex)
            {
                //TODO: Codigo de Detencion del servicio
                //Helper.Log(Helper.ServiceName, string.Concat("Detenido  por ", Helper.GetLogMessage(ex)), Fwk.Logging.EventType.Error);
                //_Timer.Stop();
                Helper.Log(Helper.ServiceName, Helper.GetLogMessage(ex), Fwk.Logging.EventType.Error,true);
            }
            finally
            {
                _Timer.Start();
            }
            //}

        }
       
        public void Send_To_Keepcon()
        {

            Helper.Log(Helper.ServiceName, "Send_To_Keepcon: Iniciando envia de post a keepcont", Fwk.Logging.EventType.Information, false);
            List<Post> posts = KeepconSvc.RetrivePost_To_Send(12);
            if (posts.Count != 0)
            {
                Allus.Keepcon.Import.Import wImport = new Allus.Keepcon.Import.Import(posts);
                Helper.Log(Helper.ServiceName, string.Format("Send_To_Keepcon: Enviando {0} post", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
                //KeepconSvc.SendContent(wImport);
                Helper.Log(Helper.ServiceName, string.Format("Send_To_Keepcon: Envio de {0} post: FINALIZADO", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
            }
            Helper.Log(Helper.ServiceName, string.Format("Send_To_Keepcon: No hay post para enviar", posts.Count.ToString()), Fwk.Logging.EventType.Information, false);
        }

        public void Check_Result_From_Keepcon()
        {
            Helper.Log(Helper.ServiceName, "Check_Result_From_Keepcon: Iicio ", Fwk.Logging.EventType.Information, false);
            Allus.Keepcon.Export.Export export = KeepconSvc.RetriveResult_2();
            if (export != null)
            {

                Helper.Log(Helper.ServiceName, string.Format("Check_Result_From_Keepcon: Guardando resultado keepcont :Cantidad {0}", export.Contents.Count), Fwk.Logging.EventType.Information, false);
                KeepconSvc.SaveResult(export);
                Helper.Log(Helper.ServiceName, string.Format("Check_Result_From_Keepcon: Se almacenaron {0} post", export.Contents.Count), Fwk.Logging.EventType.Information, false);
            }
            else
            { Helper.Log(Helper.ServiceName, string.Format("Check_Result_From_Keepcon: Las respuesta del chequeo arrojo un reult = null", export.Contents.Count), Fwk.Logging.EventType.Information, false); }
        }
        void OnSussess(string status)
        {
            if (SussessEvent != null)
                SussessEvent(status);
        }
      



        public  void SaveResult(Export.Export export)
        {
            KeepconSvc.SaveResult(export);
        }

        public string SendASK(string setId)
        {
            return KeepconSvc.SendASK(setId);
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
