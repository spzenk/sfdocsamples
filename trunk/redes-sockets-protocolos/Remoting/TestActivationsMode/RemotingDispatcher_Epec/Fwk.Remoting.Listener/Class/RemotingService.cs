using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;
using Fwk.Configuration;
using System.Runtime.Remoting.Channels;
using Fwk.Bases;
using Fwk.Logging;
using Fwk.Logging.Targets;

namespace Fwk.Remoting.Listener
{
    public partial class RemotingService : ServiceBase
    {
        
        #region ---[Constructor y Main]---
        public RemotingService()
        {
            InitializeComponent();

            
            
        }


        static void Main()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new RemotingService() };

            ServiceBase.Run(ServicesToRun);
        }
        #endregion

        #region ---[Metodos Privados]---
        private void Inicializar()
        {
            //try
            //{
            //        RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\" + ConfigurationManager.GetProperty("Config", "RemotingConfig").ToString(), false);
            //        RemotingHelper.WriteLog("\r\nEl servicio esta preparado para escuchar las peticiones.", EventLogEntryType.Information);
                
            //}
            //catch (Exception ex)
            //{
            //    RemotingHelper.WriteLog("\r\nSe produjo una excepción al inicializar el servicio." +
            //        "\r\n\r\n" + ex.ToString(),
            //        EventLogEntryType.Error);

            //    throw ex;
            //}
        }
        #endregion
        
        #region ---[OnStart]---
        protected override void OnStart(string[] args)
        {
            ConfigurationsHelper.HostApplicationNname = string.Concat("Fwk remoting ", this.ServiceName);
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //RemotingHelper.WriteLog("Servicio de host de Remoting iniciado.", EventLogEntryType.Information);
            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = "Servicio de host de Remoting iniciado.";
            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
        }
        #endregion

        #region ---[OnStop]---
        protected override void OnStop()
        {
            foreach (IChannel wChannel in ChannelServices.RegisteredChannels)
            {
                ChannelServices.UnregisterChannel(wChannel);
            }
            Fwk.Logging.Event ev = new Event();
            ev.LogType = EventType.Information;
            ev.Machine = Environment.MachineName;
            ev.User = Environment.UserName;
            ev.Message.Text = "Servicio de host de Remoting detenido.";
            StaticLogger.Log(TargetType.WindowsEvent, ev, null, null);
        }
        #endregion
        
    }
}
