using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Allus.Cnn.Common
{
    public partial class frmBaseNotify : frmBase
    {
        
        bool _OnInit = true;
        private bool _InitFormVisible;
        string mail;
        bool mailInit = true;

        [CategoryAttribute("Allus.Factory"), Description("Determina si el formulario se inicia de manera visible o no")]
        public bool InitFormVisible
        {
            get { return _InitFormVisible; }
            set { _InitFormVisible = value; }
        }

        [CategoryAttribute("Allus.Factory"), Description("Texto del notificador de aplicacion")]
        public string NotifyText
        {
            get { return notifyIcon1.Text; }
            set { notifyIcon1.Text = value; }
        }

        private System.Windows.Forms.ContextMenuStrip _ContextMenu = null;
        [Browsable(true)]
        public System.Windows.Forms.ContextMenuStrip IconContextMenu
        {
            get { return _ContextMenu; }
            set { _ContextMenu = value; }
        }


        public frmBaseNotify()
        {
            InitializeComponent();
        }

        private void frmBaseNotify_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // se inicia minimizado
                MinimizeInTray();
                notifyIcon1.Visible = true;
                if (_ContextMenu != null)
                    notifyIcon1.ContextMenuStrip = _ContextMenu;

                this.fwkMailAgent1.LoginResponse += new EventHandler<Fwk.Mail.LoginEventArgs>(fwkMailAgent1_LoginResponse);
                this.fwkMailAgent1.RequireAuthentication += new EventHandler<EventArgs>(fwkMailAgent1_RequireAuthentication);
                this.fwkMailAgent1.Start();
            }

        }

        void fwkMailAgent1_RequireAuthentication(object sender, EventArgs e)
        {
            using (MailConfig frm = new MailConfig(mailInit))
            {
                if (!mailInit) frm.UserName = mail;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mailInit = false;
                    mail = frm.UserName;
                    this.fwkMailAgent1.Start(frm.UserName, frm.Password);
                }
            }
        }

        void fwkMailAgent1_LoginResponse(object sender, Fwk.Mail.LoginEventArgs e)
        {
            using (MailConfig frm = new MailConfig(mailInit))
            {
                if (!mailInit) frm.UserName = mail;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    mailInit = false;
                    mail = frm.UserName;
                    this.fwkMailAgent1.Start(frm.UserName, frm.Password);
                }
            }
        }
        
        private void frmBaseNotify_Activated(object sender, EventArgs e)
        {
            if (_OnInit)
            {
                _OnInit = false;
                this.Visible = _InitFormVisible;


            }
        }

        private void frmBaseNotify_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }
        
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Activate();

            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;

        }

        public void ForceClose()
        {
            // Cuando se va a cerrar el formulario...
            // eliminar el objeto de la barra de tareas
            this.notifyIcon1.Visible = false;
            // esto es necesario, para que no se quede el icono en la barra de tareas
            // (el cual se quita al pasar el ratón por encima)
            this.notifyIcon1 = null;
            // de paso eliminamos el menú contextual
            _ContextMenu = null;
            this.Close();
            // finaliza todos los mensjaes de la aplicacion
            Application.Exit();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (endSessionPending)
            {
                // The session is ending.
                e.Cancel = false;
            }
            else
            {
                // The window must only be minimized in tray
                e.Cancel = true;
                MinimizeInTray();
            }

            base.OnClosing(e);

        }

        // funcion que minimiza el formulario al systemTray (al lado de la hora)
        private void MinimizeInTray()
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        int startMailCount = 0;
        string mailUrl = string.Empty;

        private void fwkMailAgent1_NewReceivedMail(object sender, Fwk.Mail.NewReceivedMailEventArgs e)
        {
            string msg = string.Empty;
            bool x = fwkMailAgent1.IsConnected;
            if (startMailCount - e.NewMailCount < 0)
            {
                startMailCount = e.NewMailCount;
                msg = string.Concat("Tiene ", e.NewMailCount.ToString(), " e-mails en su bandeja de entrada de correo electrónico");
            }
            else
            {
                msg = string.Concat("Ha recibido ", (e.NewMailCount - startMailCount).ToString(), " e-mails en su bandeja de entrada de correo electrónico");

            }
            mailUrl = e.InboxUrl;
            alertControl1.Show(null, "Darwin mail", msg);
        }

        private void alertControl1_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(mailUrl.Trim()))
                System.Diagnostics.Process.Start("IExplore", mailUrl);

            
        }

        /// <summary>
        /// Elimina los resultados de los servicios almacenados en la cache
        /// </summary>
        protected  void ClearCache()
        {
            
            SettingStorage.ClearServiceCache();
            //Vuelve a cargar los datos del usuario logueado dado que se eliminaron de la cache
            Controller.ReloadColaboratorDataInstance();
        }

    }
}
