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
    public partial class frmRegister : frmDialogBase
    {
        // indica si ya se paso por este metodo o no.-
        bool firsTime = true;
        public frmRegister()
        {
            InitializeComponent();
        }
        public frmRegister(agsXMPP.ui.roster.RosterControl rosterControl)
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

                Util.XmppServices.XmppCon.RegisterAccount = true;


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
                Util.XmppServices.XmppCon.OnError += new ErrorHandler(XmppCon_OnError);
            }
            Util.XmppServices.XmppCon.Open();
        }

        void XmppCon_OnError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ErrorHandler(XmppCon_OnError), new object[] { sender, ex });
                return;
            }
        }

        //void Disconnect()
        //{
        //    Util.XmppServices.XmppCon.OnLogin -= new ObjectHandler(XmppCon_OnLogin);
        //    Util.XmppServices.XmppCon.OnAuthError -= new XmppElementHandler(XmppCon_OnAuthError);
        //    Util.XmppServices.XmppCon.OnError -= new ErrorHandler(XmppCon_OnError);

        //    if (Util.XmppServices.XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
        //        Util.XmppServices.XmppCon.Close();


    
        //}
        void XmppCon_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {

            if (InvokeRequired)
            {	
                BeginInvoke(new XmppElementHandler(XmppCon_OnAuthError), new object[] { sender, e });
                return;
            }


            MessageBox.Show("Error al autenticar! " + Environment.NewLine + "  password or nombre de usaurio incorrecto.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);


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
            Util.XmppServices.XmppCon.OnError -= new ErrorHandler(XmppCon_OnError);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            Util.storage.Load();
            //txtJid.Text = Util.storage.StorageObject.User;
            //txtPassword.Text = Util.storage.StorageObject.Password;

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
            Util.XmppServices.XmppCon.OnError -= new ErrorHandler(XmppCon_OnError);
            SaveSettings();
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


        private void SetDiscoInfo()
        {
            Util.XmppServices.XmppCon.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "MiniClient", "client"));

            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_INFO));
            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_ITEMS));
            Util.XmppServices.XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.MUC));

            // for testing to bypass disco caches
            //_connection.DiscoInfo.AddFeature(new DiscoFeature(Guid.NewGuid().ToString())); 
        }
        
    }
}
