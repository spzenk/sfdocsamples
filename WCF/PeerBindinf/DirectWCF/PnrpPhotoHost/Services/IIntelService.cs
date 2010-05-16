using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCFDirectHost.Services
{
    [ServiceContract]
    public interface IIntelService
    {
        event EventHandler<IntelEventArgs> AgentStatusChanged;
        event EventHandler<IntelEventArgs> IntelReceived;

        [OperationContract(IsOneWay=true)]
        void Enter(AgentProfile agent);

        [OperationContract(IsOneWay = true)]
        void SendIntel(IntelData intelData);

        [OperationContract(IsOneWay = true)]
        void Leave(string agent);
    }
}
