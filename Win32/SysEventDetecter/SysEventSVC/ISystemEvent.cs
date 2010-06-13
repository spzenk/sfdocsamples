using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SysEventSVC
{
   
    [ServiceContract]
    public interface ISystemEvent
    {

        [OperationContract(IsOneWay = true)]
        void SubmitMessage_Queue(Byte[] message, DateTime time);


    }

}
