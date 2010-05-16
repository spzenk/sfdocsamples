using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Net.PeerToPeer;
using WCFDirectHost.Services;
using Slickthought.MVP;

namespace WCFDirectHost.Presenters
{
    public class ServicePresenter : PresenterBase
    {
        private int _port = 0;
        private IServiceHost _serviceHost = null;
        private IIntelService _intelService = null;

        public IIntelService IntelService { get { return _intelService; } }
        public string HostClassifier { get; set; }

        public int Port
        {
            get
            {
                if (_port == 0)
                    _port = FindFreePort();

                return _port;
            }
        }

        private bool _isOpen = false;
        public bool IsOpen {
            get { return _isOpen; }
            private set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    OnPropertyChanged("IsOpen");
                }
            }
        }

        private string _uri;
        public string Uri
        {
            get
            {
                return _uri;
                //if (_serviceHost.PeerRegistration != null)
                //    return _serviceHost.PeerRegistration.PeerUri;

                //return string.Empty;
            }
            private set
            {
                if (value != _uri)
                {
                    _uri = value;
                    OnPropertyChanged("Uri");
                }
            }
        }


        public ServicePresenter(IIntelService intelService, IServiceHost serviceHost) :base()
        {
            _intelService = intelService;
            _serviceHost = serviceHost;
            
        }

        public PresenterCommand StartCommand { get; private set; }
        public PresenterCommand StopCommand { get; private set; }

        public void StartService(string peerClassifier)
        {
            if (_serviceHost != null && this.IsOpen)
                throw new InvalidOperationException("ServiceHost is already opened");

            if (string.IsNullOrEmpty(peerClassifier))
                throw new ArgumentException("Cannot have a null or Empty peerClassifier");

            _serviceHost.Opened += new EventHandler(_serviceHost_Opened);
            _serviceHost.Closed +=new EventHandler(_serviceHost_Closed);
            _serviceHost.Open(_intelService,peerClassifier,this.Port);
            
        }

        void _serviceHost_Opened(object sender, EventArgs e)
        {
            this.IsOpen = true;
            OnPropertyChanged("Uri");
            this.Uri = _serviceHost.PeerRegistration.PeerUri;
        }

        public void StopService()
        {
            this.Uri = string.Empty;
            _serviceHost.Close();
        }

        public override void Close()
        {
            StopService();
            base.Close();
        }

        protected override void InitializeCommands()
        {
            this.StartCommand = new PresenterCommand()
            {
                CanExecuteDelegate = (x => { return (!this.IsOpen && !string.IsNullOrEmpty(this.HostClassifier)); }),
                ExecuteDelegate = (x => { StartService(x as string); })
            };

            this.StopCommand  = new PresenterCommand()
            {
                CanExecuteDelegate = (x => { return this.IsOpen; }),
                ExecuteDelegate = (x => { StopService(); })
            };
        }

        private void _serviceHost_Closed(object sender, EventArgs e)
        {
            this.IsOpen = false;
        }

        private int FindFreePort()
        {
            int port = 0;

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(endpoint);
                IPEndPoint local = (IPEndPoint)socket.LocalEndPoint;
                port = local.Port;
            }

            if (port == 0)
                throw new InvalidOperationException("Unable to find free port");

            return port;
        }

    }
}
