using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace WCFDirectHost.Services
{
    public class PeerRegistrationService : IPeerRegistration
    {
        PeerNameRegistration _peerNameRegistration = null;

        public PeerRegistrationService()
        {
            
        }      

        #region IPeerRegistration Members

        public bool IsRegistered {
            get {
                if (_peerNameRegistration != null)
                    return _peerNameRegistration.IsRegistered();

                return false;
            }
        }

        public string PeerUri { 
            get 
            {
                if (_peerNameRegistration == null)
                     return string.Empty;
                return _peerNameRegistration.PeerName.PeerHostName;
            }
        }

        public void Start(string peerClassifier, int port)
        {
            PeerName peerName = new PeerName(peerClassifier, PeerNameType.Unsecured);
            _peerNameRegistration = new PeerNameRegistration(peerName, port, Cloud.Global);
            _peerNameRegistration.Start();
        }

        public void Stop()
        {
            if (_peerNameRegistration != null)
                _peerNameRegistration.Stop();
            _peerNameRegistration = null;
        }

        #endregion
    }
}
