using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace WCFDirectClient.Services
{
    public class PeerResolverService : IPeerResolver
    {
        #region IPeerResolver Members

        public PeerNameResult ResolveHostName(string hostPeerName)
        {
            if (string.IsNullOrEmpty(hostPeerName))
                throw new ArgumentException("Cannot have a null or empty host peer name.");

            PeerNameResolver resolver = new PeerNameResolver();
            
            var results = resolver.Resolve(new PeerName(hostPeerName, PeerNameType.Unsecured),Cloud.Global);

            if (results == null || results.Count == 0)
                throw new PeerToPeerException(string.Format("Unable to resolve {0}", hostPeerName));

            return new PeerNameResult(results[0].PeerName.PeerHostName, results[0].EndPointCollection[0].Port);
        }

        #endregion
    }
}
