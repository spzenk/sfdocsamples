using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace WCFDirectClient.Services
{
    public class PeerNameResult
    {
        public string Uri { get; set; }
        public int Port { get; set; }

        public PeerNameResult(string uri, int port)
        {
            this.Uri = uri;
            this.Port = port;     
        }
    }

    public interface IPeerResolver
    {
        PeerNameResult ResolveHostName(string peerName);
    }
}
