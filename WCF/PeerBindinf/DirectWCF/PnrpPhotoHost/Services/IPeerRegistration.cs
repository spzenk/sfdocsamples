using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace WCFDirectHost.Services
{
    public interface IPeerRegistration
    {
        bool IsRegistered { get; }
        string PeerUri { get; }
        void Start(string peerClassifier, int port);
        void Stop();
    }
}
