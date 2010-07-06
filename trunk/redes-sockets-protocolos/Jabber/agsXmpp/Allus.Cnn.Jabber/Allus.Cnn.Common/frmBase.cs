using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Allus.Libs.Common;

namespace Allus.Cnn.Common
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        private const int WM_QUERYENDSESSION = 0x11;
        public bool endSessionPending;

        public frmBase()
        {
            InitializeComponent();
            //try
            //{
            //    // Me subscribo al manejador de ex no manejadas (CLR)
            //    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            //    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //    //Redirigo las ex no manejadas a ThreadException
            //    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppThreadException);
               

            //}
            //catch (Exception e)
            //{
            //    HandleUnhandledException(e);
            //}
        }
        /// <summary>
        /// Establece el MessageViewer a sus valores por defecto
        /// </summary>
        protected void SetMessageViewInfoDefault()
        {
            MessageViewer.MessageBoxIcon = Allus.Libs.Common.MessageBoxIcon.Information;
            MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;


        }
        /// <summary>
        /// CLR ex no manejada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject);
        }

        /// <summary>
        /// Displays dialog with information about exceptions that occur in the application. 
        /// </summary>
        public static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }

        /// <summary>
        /// metodo que resuelve el msg a mostrar para ex no manejadas
        /// </summary>
        /// <param name="o"></param>
        public static void HandleUnhandledException(Object o)
        {
            string error;
            Exception ex = o as Exception;
            if (ex != null)
            {
                error = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            else
            {
                error = o.ToString();

            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
            sb.Append(@"Se detectaron anomal�as en la aplicaci�n por favor chequee los siguientes errores: ");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(@"{0}");
            sb.Append(Environment.NewLine);
            sb.Append("Desea salir de la aplicacion ?");
            error = string.Format(sb.ToString(), error);
            ExceptionViewComponent wExceptionViewer = new ExceptionViewComponent();
            wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            wExceptionViewer.Title = "Unhandled error";
            DialogResult result= DialogResult.OK;
            try
            {
                 result = wExceptionViewer.Show("Unhandled error", error, string.Empty);
                 Application.Exit();
            }
            catch
            {
                try
                {
                    wExceptionViewer.Title="Fatal Windows Forms Error";
                    wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
                    wExceptionViewer.Show("Error no manejado","Fatal Windows Forms Error",String.Empty);
                }
                finally
                {
                    Application.Exit();
                    
                }
            }


            if (result == DialogResult.OK)
                Application.Exit();
        }

        
        // Se sobre escribe este metodo
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
                endSessionPending = true;

            base.WndProc(ref m);
        }

    }
}