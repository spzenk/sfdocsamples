using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WCFDirectClient.Presenters;
using WCFDirectClient.Services;

namespace WCFDirectClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainPresenter main;

        private void Application_Startup(object sender, StartupEventArgs e)
        {        
            IIntelClient client = new IntelClient(new PeerResolverService());
            main = new MainPresenter(client);
            Shell shell = new Shell();
            shell.DataContext = main;
            shell.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            main.Close();
        }
    }
}
