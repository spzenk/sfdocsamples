using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Fwk.Exceptions;
using Epiron.Front.Bases;

namespace Epiron.Front.Bases
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        public Fwk.Bases.EntityUpdateEnum State = Fwk.Bases.EntityUpdateEnum.NEW;
        public frmBase(bool pHandleUnmanagedException)
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Black");
            if (pHandleUnmanagedException)
            {
                try
                {
                    // Me subscribo al manejador de ex no manejadas (CLR)
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

                    //Redirigo las ex no manejadas a ThreadException
                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppThreadException);
                }
                catch (Exception e)
                {
                    HandleUnhandledException(e);
                }
            }
        }
        public frmBase()
        {
            InitializeComponent();
            try
            {
                // Me subscribo al manejador de ex no manejadas (CLR)
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

                //Redirigo las ex no manejadas a ThreadException
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppThreadException);
            }
            catch (Exception e)
            {
                HandleUnhandledException(e);
            }
        }

        /// <summary>
        /// CLR ex no manejada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject);
        }

        /// <summary>
        /// Displays dialog with information about exceptions that occur in the application. 
        /// </summary>
        private static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }

        /// <summary>
        /// metodo que resuelve el msg a mostrar para ex no manejadas
        /// </summary>
        /// <param name="o"></param>
        public static void HandleUnhandledException(Object o)
        {
            string wError=String.Empty;
            ExceptionViewComponent wExceptionViewer = new ExceptionViewComponent();
            wExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            wExceptionViewer.Title = "Error no manejado";
            Exception wException = o as Exception;


            if (wException != null)
            {
                wExceptionViewer.Title = wException.Source;
                if (wException.GetType().IsAssignableFrom(typeof(TechnicalException)))
                {
                    wError = wException.Message;
                      
                }
                if (wException.GetType().IsAssignableFrom(typeof(FunctionalException)))
                    wError = wException.Message;

                if (String.IsNullOrEmpty(wError))
                    wError = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(wException);
            }
            else
                wError = o.ToString();

            System.Text.StringBuilder wStringBuilder = new System.Text.StringBuilder(5000);
            //wStringBuilder.Append(@"Se detectaron anomalías en la aplicacion por favor chequee los siguientes errores: ");
            //wStringBuilder.Append(Environment.NewLine);
            //wStringBuilder.Append(Environment.NewLine);
            wStringBuilder.Append(@"{0}");
            wStringBuilder.Append(Environment.NewLine);
            wStringBuilder.Append("¿Desea salir de la aplicación?");

            wError = string.Format(wStringBuilder.ToString(), wError);

           
           
            #region Log del error en la base de datos o dicha configuracion
            //bool wLogError = logError;

            //if (logError)
            //{
            //    //Si el error es del propio frqmework de logging no intentar loguear y evitaar asi la recursividad del error
            //    if (Fwk.Exceptions.ExceptionHelper.GetFwkExceptionTypes(wException) == Fwk.Exceptions.FwkExceptionTypes.TechnicalException)
            //        if (((Fwk.Exceptions.TechnicalException)wException).ErrorId == "9004")
            //            wLogError = false;
            //}

            #endregion
            DialogResult wResult = wExceptionViewer.Show(wExceptionViewer.Title, wError, string.Empty, false);

            if (wResult == DialogResult.OK)
                Application.Exit();
        }
        internal void SetDialogsToDefault()
        {
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
        }


        public void AdjustCulture()
        {
            MultilanguageSetting.AdjustCulture(this.Controls);
        }
        public void ShowWaitForm()
        {
            Common.ShowWaitForm();
 
        }
        public void CloseWaitForm()
        {
            Common.CloseWaitForm();
        }
    }
}