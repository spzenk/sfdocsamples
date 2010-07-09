using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP.protocol.iq.disco;

namespace agsXMPP.Client
{
    public partial class frmAuthenticate : frmDialogBase
    {
        // indica si ya se paso por este metodo o no.-
        bool firsTime = true;

        public event OnLogHandler OnLog;
        public frmAuthenticate()
        {
            InitializeComponent();
        }
        public frmAuthenticate(agsXMPP.ui.roster.RosterControl rosterControl)
        {
            InitializeComponent();
            Util.XmppServices.RosterControl = rosterControl;
        }
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Connect();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void Connect()
        {
            //Util.XmppServices.XmppCon = new XmppClientConnection();
            Util.XmppServices.XmppCon.SocketConnectionType = agsXMPP.net.SocketConnectionType.Direct;

            Util.XmppServices.XmppCon.Server = txtServer.Text;
            Util.XmppServices.XmppCon.Username = txtJid.Text;
            Util.XmppServices.XmppCon.Password = txtPassword.Text;
            Util.XmppServices.XmppCon.Resource = txtResource.Text;
            Util.XmppServices.XmppCon.Priority = (int)numPriority.Value;
            Util.XmppServices.XmppCon.Port = int.Parse(txtPort.Text);
            Util.XmppServices.XmppCon.UseSSL = Util.storage.StorageObject.UseSSL;






            if (firsTime)
            {
                firsTime = false;
                Util.XmppServices.XmppCon.AutoResolveConnectServer = true;
                Util.XmppServices.XmppCon.UseCompression = false;
                //Util.XmppServices.XmppCon.SocketConnectionType    = agsXMPP.net.SocketConnectionType.Bosh;
                //Util.XmppServices.XmppCon.ConnectServer = "http://vm-2k:8080/http-bind/";        

                Util.XmppServices.XmppCon.RegisterAccount = false;

                // Capabilities
                Util.XmppServices.XmppCon.EnableCapabilities = true;
                Util.XmppServices.XmppCon.ClientVersion = "1.0";
                Util.XmppServices.XmppCon.Capabilities.Node = "http://www.ag-software.de/miniclient/caps";


                // overwrite some settings for debugging
                //_connection.UseStartTLS     = false;
                //_connection.UseSSL          = false;

                // overwrite some settings for Polling Test
                //_connection.SocketConnectionType	      = agsXMPP.net.SocketConnectionType.HttpPolling;
                //Util.XmppServices.XmppCon.UseCompression              = false;
                //Util.XmppServices.XmppCon.UseStartTLS	              = false;
                //Util.XmppServices.XmppCon.UseSSL                      = false;
                //_connecXmppContion.AutoResolveConnectServer    = false;
                //XmppCon.ConnectServer               = "http://vm-2000:5280/http-poll";

                agsXMPP.Factory.ElementFactory.AddElementType("command", "fwk.jabber:command", typeof(Comand));
                Util.XmppServices.DiscoManager = new DiscoManager(Util.XmppServices.XmppCon);

                SetDiscoInfo();

                Util.XmppServices.XmppCon.OnLogin += new ObjectHandler(XmppCon_OnLogin);
                Util.XmppServices.XmppCon.OnAuthError += new XmppElementHandler(XmppCon_OnAuthError);
               
            }
            Util.XmppServices.XmppCon.Open();
        }

        void Disconnect()
        {
            Util.XmppServices.XmppCon.OnLogin -= new ObjectHandler(XmppCon_OnLogin);
            Util.XmppServices.XmppCon.OnAuthError -= new XmppElementHandler(XmppCon_OnAuthError);

            if (Util.XmppServices.XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
                Util.XmppServices.XmppCon.Close();
           
            //No se rrealiza mas esta accion aqui: Dado que otro formulario padre pudiera haber creado eventos de XmppCon y
            //tenga que cerrarlos
            //Util.XmppServices.RosterControl.Clear();
            //Util.XmppServices.XmppCon = null;
        }
       
        void XmppCon_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {

            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new XmppElementHandler(XmppCon_OnAuthError), new object[] { sender, e });
                return;
            }
            MessageBox.Show("Error al autenticar! " + Environment.NewLine + "  password o nombre de usurio incorrecto.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

            //Disconnect();

            //if (OnAuthError != null)
            //{
            //    OnAuthError(this, new EventArgs());
            //}
        }

        void XmppCon_OnLogin(object sender)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ObjectHandler(XmppCon_OnLogin), new object[] { sender });
                return;
            }
            Util.XmppServices.DiscoServer();
            Util.XmppServices.XmppCon.OnLogin -= new ObjectHandler(XmppCon_OnLogin);
            Util.XmppServices.XmppCon.OnAuthError -= new XmppElementHandler(XmppCon_OnAuthError);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void frmAuthenticate_Load(object sender, EventArgs e)
        {
            Util.storage.Load();
            txtJid.Text = Util.storage.StorageObject.User;
            txtPassword.Text = Util.storage.StorageObject.Password;

            if (!string.IsNullOrEmpty(Util.storage.StorageObject.Server))
                txtServer.Text = Util.storage.StorageObject.Server;

            if (!string.IsNullOrEmpty(Util.storage.StorageObject.Port))
                txtPort.Text = Util.storage.StorageObject.Port;

            if (!string.IsNullOrEmpty(Util.storage.StorageObject.Resource))
                txtResource.Text = Util.storage.StorageObject.Resource;
        }

        private void frmAuthenticate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.XmppServices.XmppCon.OnLogin -= new ObjectHandler(XmppCon_OnLogin);
            Util.XmppServices.XmppCon.OnAuthError -= new XmppElementHandler(XmppCon_OnAuthError);
            SaveSettings();
        }

        private void SetDiscoInfo()
        {
            Util.XmppServices.XmppCon.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "MiniClient", "client"));

            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_INFO));
            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_ITEMS));
            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.MUC));

            // for testing to bypass disco caches
            //_connection.DiscoInfo.AddFeature(new DiscoFeature(Guid.NewGuid().ToString())); 
        }
        void SaveSettings()
        {
            Util.storage.StorageObject.User = txtJid.Text;
            Util.storage.StorageObject.Password = txtPassword.Text;
            Util.storage.StorageObject.Server = txtServer.Text;
            Util.storage.StorageObject.Port = txtPort.Text;
            Util.storage.StorageObject.Resource = txtResource.Text;
            Util.storage.Save();
        }
        void AddLog(string msg)
        {
            if (OnLog != null)
            {
                OnLog(msg);
            }
        }
    }
}
