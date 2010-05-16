using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCFDirectHost.Services
{
    public class IntelServiceHost : IServiceHost
    {
        ServiceHost _serviceHost;

        //public IntelServiceHost()
        //{ }

        public IntelServiceHost(IPeerRegistration peerRegistration)
        {
            this.PeerRegistration = peerRegistration;
        }

        //public IntelServiceHost(string uri, int port)
        //{
        //    _uri = uri;
        //    _port = port;
        //}

        #region IServiceHost Members

        public event EventHandler Opened;

        public event EventHandler Closed;

        private IPeerRegistration _peerRegistration;
        public IPeerRegistration PeerRegistration {
            get { return _peerRegistration; }
            set
            {
                if (value == null)
                    throw new ArgumentException("PeerRegistration cannot be null");

                _peerRegistration = value;
            }
        }

        public bool IsOpen { get; private set; }

        public void Open(IIntelService service, string peerClassifier, int port)
        {
            if (this.PeerRegistration == null)
                throw new InvalidOperationException("Cannot Open Service without a PeerRegistrationService");

            this.PeerRegistration.Start(peerClassifier, port);
            Uri tcpUri = new Uri(string.Format("net.tcp://{0}:{1}/IntelService", this.PeerRegistration.PeerUri, port));
            _serviceHost = new ServiceHost(service, tcpUri);
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);
            _serviceHost.AddServiceEndpoint(typeof(IIntelService), tcpBinding, "");

            _serviceHost.Opened += new EventHandler(_serviceHost_Opened);
            _serviceHost.Closed += new EventHandler(_serviceHost_Closed);

            _serviceHost.Open();
        }

        void _serviceHost_Closed(object sender, EventArgs e)
        {
            this.IsOpen = false;
            if (Closed != null)
                Closed(this, e);
        }

        void _serviceHost_Opened(object sender, EventArgs e)
        {
            this.IsOpen = true;
            if (Opened != null)
                Opened(this, e);
        }

        public void Close()
        {
            if (_serviceHost != null)
                _serviceHost.Close();
            this.PeerRegistration.Stop();
        }

        #endregion
    }
}
