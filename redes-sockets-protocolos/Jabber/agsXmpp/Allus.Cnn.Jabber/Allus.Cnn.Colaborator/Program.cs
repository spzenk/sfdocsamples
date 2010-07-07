using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Allus.Cnn.Common;

namespace Allus.Cnn.Colaborator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
             {
                // Me subscribo al manejador de ex no manejadas (CLR)
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(frmBase.OnUnhandledException);

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                //Redirigo las ex no manejadas a ThreadException
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(frmBase.AppThreadException);
                Application.Run(new frmColaborator());

            }
            catch (Exception e)
            {
                frmBase.HandleUnhandledException(e);
            }

            
        }
    }
}
