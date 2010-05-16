using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fabrikam;

namespace TradeRecordingService
{
    [ServiceContract]
    [DeliveryRequirements(QueuedDeliveryRequirements = QueuedDeliveryRequirementsMode.Required)]
    public interface ITradeRecorder
    {
        [OperationContract(IsOneWay = true)]
        void RecordTrades(Trade[] trades);
    }


  
}
