using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFDirectHost.Services
{
    public interface IServiceHost
    {
        event EventHandler Opened;
        event EventHandler Closed;
        IPeerRegistration PeerRegistration { get; set; }
        bool IsOpen { get; }
        void Open(IIntelService service, string peername, int port);
        void Close();
    }
}
