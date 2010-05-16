using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using System.ComponentModel;
using WCFDirectHost.Services;
using System.Windows.Data;
using System.ServiceModel;
using System.Drawing;

namespace WCFDirectClient.Services
{
    public class IntelClient : IIntelClient
    {

        public IIntelService IntelServiceProxy { get; set; } 

        public IPeerResolver PeerResolution { get; set; }

        public IntelClient(IPeerResolver peerResolution)
        {
            PeerResolution = peerResolution;
        }
        
        public IntelClient(IPeerResolver peerResolution, IIntelService intelService) : this(peerResolution)
        {
            IntelServiceProxy = intelService;
        }

        #region IIntelService Members

        public event EventHandler Started;
        public event EventHandler Stopped;

        private AgentProfile _agentProfile = new AgentProfile();
        public string Agent
        {
            get { return _agentProfile.Agent; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Cannot set Agent to null or emtpy string.");

                if (_agentProfile.Agent == value)
                    return;

                _agentProfile.Agent = value;
                OnPropertyChanged("Agent");
            }
        }

        public Bitmap AgentImage
        {
            get { return _agentProfile.Image; }
            set
            {
                if (_agentProfile.Image == value)
                    return;

                _agentProfile.Image = value;
                OnPropertyChanged("AgentImage");
            }
        }

        private bool _isConnected;
        public bool IsConnected {
            get { return _isConnected; }
            private set
            {
                if (value != _isConnected)
                {
                    _isConnected = value;
                    OnPropertyChanged("IsConnected");
                }
            }
        }

        private int _port;
        public int Port
        {
            get { return _port; }
            private set
            {
                if (value != _port)
                {
                    _port = value;
                    OnPropertyChanged("Port");
                }
            }
        }

        private string _hostUri;
        public string HostUri
        {
            get { return _hostUri; }
            private set
            {
                if (value != _hostUri)
                {
                    _hostUri = value;
                    OnPropertyChanged("HostUri");
                }
            }
        }



        public void Start(string hostPeerName)
        {
            if (this.IsConnected)
                throw new InvalidOperationException(string.Format("Cannot start client.  Client is already connected to {0}", this.HostUri));

            if (string.IsNullOrEmpty(hostPeerName))
                throw new ArgumentException("Cannot have a null or empty host peer name");

            PeerNameResult peerRecord = PeerResolution.ResolveHostName(hostPeerName);
            if (peerRecord != null)
            {
                this.HostUri = peerRecord.Uri;
                this.Port = peerRecord.Port;
                try
                {
                    if (this.IntelServiceProxy == null)
                    {
                        System.ServiceModel.Channels.Binding netBinding = new NetTcpBinding(SecurityMode.None);
                        EndpointAddress endpointAddress = new EndpointAddress(string.Format("net.tcp://{0}:{1}/IntelService", this.HostUri, this.Port));

                        IntelServiceProxy = new IntelProxy(netBinding, endpointAddress);
                    }

                    Enter();
                    OnStarted();
                }
                catch (ArgumentException ex)
                {
                    Stop();
                    throw ex;
                }
            }
        }


























        public void Stop()
        {
            if (this.IsConnected == false)
                return;

            try
            {
                Leave();
                this.IsConnected = false;
                this.HostUri = null;
                OnStopped();
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            
        }

        private void Enter()
        {
            if (_agentProfile == null)
                throw new ArgumentException("AgentProfile cannot be null.");

            if (string.IsNullOrEmpty(this.Agent))
                throw new ArgumentException("Agent cannot be null.");

            IntelServiceProxy.Enter(_agentProfile);

            this.IsConnected = true;
        }

        private void Leave()
        {
            if (_agentProfile == null)
                throw new ArgumentException("AgentProfile cannot be null.");

            if (string.IsNullOrEmpty(this.Agent))
                throw new ArgumentException("AgentProfile.Agent cannot be null.");

            IntelServiceProxy.Leave(this.Agent);
        }

        public void SendIntel(IntelData intelData)
        {
            if (intelData == null)
                throw new ArgumentException("IntelData cannot be null.");

            if (intelData.Image == null)
                throw new ArgumentException("IntelData.Image cannot be null.");

            intelData.Agent = this.Agent;
            IntelServiceProxy.SendIntel(intelData);
        }

        private void OnStarted()
        {
            if (Started != null)
                Started(this, new EventArgs());
        }

        private void OnStopped()
        {
            if (Stopped != null)
                Stopped(this, new EventArgs());
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
