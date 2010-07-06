using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common.Proxy;
using Allus.Cnn.Common;

namespace Allus.Cnn.Common
{
    
    public class BackConnector
    {
        #region fields
       
        System.Timers.Timer _Timer;
        public event ConnectorWrapperHandler Event;
        private ColaboratorWrapper _Wrapper = null;
        private Allus.Cnn.Common.BE.Colaborator _CurrentColaborator = null;
        #endregion

        public BackConnector(ColaboratorWrapper wrapper, Allus.Cnn.Common.BE.Colaborator currentColaborator)
        {
            _Wrapper = wrapper;
            _Wrapper.ProxyEvent += new ProxyEventHandler(Wrapper_ProxyEvent);
            _CurrentColaborator = currentColaborator;
            _Timer = new System.Timers.Timer();
            _Timer.Interval = Common.Timer_HihgtSpeed;
            _Timer.Elapsed += new System.Timers.ElapsedEventHandler(_Timer_Elapsed);

            
        }

        void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer.Stop();
          
            
            try
            {
                if (_Wrapper.ProxyNull())
                {
                    InitSession();
                    return;
                }
                _Wrapper.Ping();
                _Timer.Start();
            }
            catch (Exception ex)
            {
                Event("Error al hacer ping...", string.Empty, JoinStatusEnum.Connecting);
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
            _Timer.Start();
        }
        public void Stop()
        {
            _Timer.Stop();
        }
        void InitSession()
        {
            try
            {
                Event("Conectando... ", string.Empty, JoinStatusEnum.Connecting);
                _Wrapper.Connect(_CurrentColaborator);
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
            if ((JoinStatusEnum)e.Status == JoinStatusEnum.Error || (JoinStatusEnum)e.Status == JoinStatusEnum.Disconnected)
            {
                _Timer.Interval = Common.Timer_HihgtSpeed;
                if (Event != null) { Event("Error conectando...", e.Message,JoinStatusEnum.Connecting); }
            }
            //"Conectado"
            if ((JoinStatusEnum)e.Status == JoinStatusEnum.Connected || (JoinStatusEnum)e.Status == JoinStatusEnum.Exist)
            {
                _Timer.Interval = Common.Timer_LowSpeed;
                if (Event != null)     { Event("Conectado", e.Message, (JoinStatusEnum)e.Status); }
            }
          
            _Timer.Start();
        }
    }
}
