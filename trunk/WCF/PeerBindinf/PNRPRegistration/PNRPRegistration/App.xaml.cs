using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using PNRPRegistration.Presenters;
using PNRPRegistration.Core;
using PNRPRegistration.Services;
using Slickthought.MVP.Services;

namespace PNRPRegistration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        PnrpManager _pnrpManager = new PnrpManager();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceManager.Instance.Add(typeof(IDialogService), new PnrpDialogService());
            ServiceManager.Instance.Add(typeof(IMessageBoxService), new MessageBoxService());
            //ServiceLocator.Add<IDialogService>(new DialogService());

            PNRPRegistration.MainWindow main = new MainWindow();
            main.DataContext = new MainWorkspacePresenter(_pnrpManager);
            main.Show();
        }
    }
}
