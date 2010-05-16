using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WCFDirectHost.Services;
using System.Drawing;

namespace WCFDirectClient.Services
{


    public interface IIntelClient : INotifyPropertyChanged
    {
        event EventHandler Started;
        event EventHandler Stopped;
        string Agent { get; set; }
        Bitmap AgentImage { get; set; }
        bool IsConnected { get; }
        string HostUri { get; }
        void Start(string hostPeerName);
        void Stop();
        void SendIntel(IntelData intelData);
    }
}
