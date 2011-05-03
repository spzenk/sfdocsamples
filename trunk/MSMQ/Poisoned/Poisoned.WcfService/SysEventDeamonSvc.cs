using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Fwk.Logging;
using Fwk.Logging.Targets;

namespace Poisoned.WcfService
{
    partial class SysEventDaemonSvc : ServiceBase
    {
        MessageQueueProcess_MSMQ svc;
        
        public SysEventDaemonSvc()
        {
            InitializeComponent();
        }
        

        protected override void OnStart(string[] args)
        {
            try
            {
                svc = new MessageQueueProcess_MSMQ();
                svc.StartResiveMessage();
            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError_WE(ex);
            }
        }

        protected override void OnStop()
        {
            svc.StopResiveMessage();
           
        }
    }
}
