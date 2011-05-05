using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace Poisoned.WcfService
{
    [RunInstaller(true)]
    public partial class SysEventDaemonSvcInstaller : Installer
    {
        public SysEventDaemonSvcInstaller()
        {
            InitializeComponent();
        }
    }
}
