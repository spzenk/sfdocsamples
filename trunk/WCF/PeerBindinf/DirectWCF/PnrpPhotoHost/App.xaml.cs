using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WCFDirectHost.Presenters;
using System.Threading;

namespace WCFDirectHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainPresenter main = new MainPresenter(SynchronizationContext.Current);
            Shell shell = new Shell();
            shell.DataContext = main;
            shell.Show();

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}
