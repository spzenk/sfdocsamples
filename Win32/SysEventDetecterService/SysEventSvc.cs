using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SysEventDetecterService
{
    public partial class SysEventSvc : ServiceBase
    {
        EventChecker chk = null;
        public SysEventSvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            chk = new EventChecker();
            chk.Start();
           
        }

        protected override void OnStop()
        {
            chk.Stop();
        }
    }
}
