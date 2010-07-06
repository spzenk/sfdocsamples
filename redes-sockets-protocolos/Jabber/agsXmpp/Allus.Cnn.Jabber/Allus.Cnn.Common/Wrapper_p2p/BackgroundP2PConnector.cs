using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common;

using System.Threading;

namespace Allus.Cnn.Common
{
    public class BackgroundP2PConnector
    {
        #region fields
        Thread wGenThread_Wrapper;
        System.Timers.Timer _Timer;
        public event ConnectorWrapperHandler Event;
        private AlertService _GlobalWrapper = null;

        public AlertService GlobalWrapper
        {
            get { return _GlobalWrapper; }
           
        }
        JoinStatusEnum status = JoinStatusEnum.OffLine; 
        #endregion

        public BackgroundP2PConnector(AlertService wrapper)
        {
            _GlobalWrapper = wrapper;

            GlobalWrapper.WrapperEvent += new ProxyEventHandler(Wrapper_ProxyEvent);

          

            _Timer = new System.Timers.Timer();
            _Timer.Interval = Allus.Cnn.Common.Common.Timer_HihgtSpeed;
            _Timer.Elapsed += new System.Timers.ElapsedEventHandler(_Timer_Elapsed);

            
        }

        void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer.Stop();

            try
            {
                if (_GlobalWrapper.ProxyNull())
                {
                    InitSession();
                    return;
                }
                _Timer.Start();
            }
            catch (Exception ex)
            {

                Event("Conectando...", ex.Message, JoinStatusEnum.Connecting);
                InitSession();
            }
            finally
            {
                //_Timer.Start(); // Reinicia el clock para reintentar conecctarce
            }
        }

        public void Start()
        {
            InitSession();
            _Timer.Start();
        }

        public void Stop()
        {
            _Timer.Stop();
            if (!_GlobalWrapper.ProxyNull())
            {
                _GlobalWrapper.DisconectToMesh();
            }
            if (wGenThread_Wrapper != null)
                wGenThread_Wrapper.Abort();
        }

        /// <summary>
        /// Inicializa la instancia del wrapper bajo patron singleton
        /// Inicializa los manejadores del wrapper.-
        /// Inicializa el colaborador .-
        /// </summary>
        void InitSession()
        {


            try
            {
                Event("Conectando... ", string.Empty, JoinStatusEnum.Connecting);
               
                wGenThread_Wrapper = new Thread(new ThreadStart(_GlobalWrapper.ConnectToMesh));

                wGenThread_Wrapper.Start();
            }
            catch (Exception ex)
            {
                Event("Error conectando...", ex.Message, JoinStatusEnum.Connecting);
            }

        }
  



        /// <summary>
        /// Eventio que lanza el wrapper solo para mostrar el estado de Conexión 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Wrapper_ProxyEvent(object sender, ProxyEventArgs e)
        {
        
                switch (e.Status)
                {
                    case JoinStatusEnum.Error:
                        {
                            _Timer.Interval = Allus.Cnn.Common.Common.Timer_HihgtSpeed;
                             if (Event != null) { Event("Intentando conectar...", e.Message, JoinStatusEnum.Error); }
                            break;
                        }
                    case JoinStatusEnum.Disconnected:
                    case JoinStatusEnum.OffLine:
                        {
                            _Timer.Interval = Allus.Cnn.Common.Common.Timer_HihgtSpeed;
                            if (Event != null) { Event("Esperando señal..", e.Message, JoinStatusEnum.Connecting); }

                            break;
                        }
                    case JoinStatusEnum.Connecting:
                        {
                            if (Event != null) { Event("Conectando...", e.Message, (JoinStatusEnum)e.Status); }
                            break;
                        }
                    case JoinStatusEnum.OnLine:
                        {
                            _Timer.Interval = Allus.Cnn.Common.Common.Timer_LowSpeed;
                            if (Event != null) { Event("Conectado", e.Message, (JoinStatusEnum)e.Status); }
                            break;
                        }
                }

            _Timer.Start();
        }
       
    }
}
