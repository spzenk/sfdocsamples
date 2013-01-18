using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace MultipleInstanceService
{
    partial class MultipleInstanceService : ServiceBase
    {
        public MultipleInstanceService()
        {
            InitializeComponent();

            this.ServiceName = ConfigurationManager.AppSettings.Get("ServiceName");
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
