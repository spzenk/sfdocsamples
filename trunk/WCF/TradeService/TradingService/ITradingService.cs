using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace Fabrikam
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    [DeliveryRequirements(RequireOrderedDelivery = true)]
    public interface ITradingService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        string BeginDeal();
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void AddTrade(Trade trade);
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = true)]
        void AddFunction(string function);

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        decimal Calculate();
        [OperationContract(IsInitiating = false, IsTerminating = false, IsOneWay = false)]
        void Purchase();
        [OperationContract(IsInitiating = false, IsTerminating = true, IsOneWay = true)]
        void EndDeal();
    }
}
