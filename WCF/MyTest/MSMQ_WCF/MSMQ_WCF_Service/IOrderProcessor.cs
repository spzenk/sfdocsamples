using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MSMQ_WCF_Service
{
 
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true)]
        void SubmitPurchaseOrder(PurchaseOrder po);
    }




    [ServiceContract]
    public interface IAccountEventNotification : IEventNotification<AccountEventLog>
    {
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public class AccountEventLog
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
