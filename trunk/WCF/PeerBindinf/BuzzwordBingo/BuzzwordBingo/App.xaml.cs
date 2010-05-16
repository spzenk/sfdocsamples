using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BuzzwordBingo.Presenters;
using BuzzwordBingo.Core;
using BuzzwordBingo.Interfaces;
using BuzzwordBingo.Services;
using System.Threading;
using Slickthought.MVP.Services;

namespace BuzzwordBingo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceManager.Instance.Add(typeof(IDialogService), new BingoDialogService());
            IBingoManager client = new BingoService();
            Shell shell = new Shell();
            MainPresenter main = new MainPresenter();
            shell.DataContext = main;
            shell.Show();

        }
    }
}
