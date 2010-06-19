using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;
using Fwk.Remoting;

namespace TestServicePerformance
{
    public delegate void CheckEven(string msg, int threadNumber, double average, double totalTime);
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public delegate void FinalizeHandler(string msg);
    public delegate void CallHandler();
    
    internal class RemotingWrapper_config
    {
        #region members & properties
        bool stop = false;
        private Object thisLock = new Object();
        public event CheckEven MessageEvent;
        public event FinalizeHandler FinalizeEvent;
        public event CallHandler CallEvent;
        public ManualResetEvent[] doneEvents;

        FwkRemoteObjectTest _RemoteObj;

        internal Fwk.Remoting.FwkRemoteObjectTest RemoteObj
        {
            get { return _RemoteObj; }
        }

        Fwk.Bases.IServiceContract isvcReq;
        Fwk.Bases.IServiceContract isvcRes;
        #endregion

        #region Init -->


        internal void Init()
        {

            _RemoteObj = CreateRemoteObject();

        }
        /// <summary>
        /// Crea en este caso SimpleFacaddeRemoteObject .-
        /// </summary>
        /// <returns>Instancia de SimpleFacaddeRemoteObject</returns>
        FwkRemoteObjectTest CreateRemoteObject()
        {
            LoadRemotingConfigSettings();
            if (_RemoteObj == null)
                _RemoteObj = new FwkRemoteObjectTest();
            return _RemoteObj;
        }

        /// <summary>
        /// Carga la configuracion de remoting en el archivo indicado por RemotingConfigFile_2
        /// </summary>
        void LoadRemotingConfigSettings()
        {
            if (!IsConfigured())
            {
                RemotingConfiguration.Configure("RemotingConfigFile_2.config", false);
            }
        }

        bool IsConfigured()
        {

            bool wResult = false;

            foreach (WellKnownClientTypeEntry wEntry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (wEntry.TypeName == typeof(FwkRemoteObject).FullName)
                {
                    wResult = true;
                    break;
                }
            }

            return wResult;

        }
        #endregion




    }
}

