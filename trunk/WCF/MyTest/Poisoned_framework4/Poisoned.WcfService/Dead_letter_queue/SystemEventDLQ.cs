using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fwk.Exceptions;
using Fwk.Logging;
using System.Configuration;
using System.Messaging;
using System.ServiceModel.Channels;


namespace Poisoned.WcfService
{


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class SystemEventDLQ : ISystemEventDLQ
    {

        SystemEvent _SystemEvent;
        public SystemEventDLQ()
        {
            //_SystemEvent = new SystemEvent();
        }


        #region ISystemEventDLQ Members

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitMessage_Queue(byte[] message, DateTime time)
        {
            MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty;

            // resend the message if timed out
            if (mqProp.DeliveryFailure == DeliveryFailure.ReachQueueTimeout ||
                mqProp.DeliveryFailure == DeliveryFailure.ReceiveTimeout)
            {
                // re-send
                //Console.WriteLine("Purchase order Time To Live expired");
                //Console.WriteLine("Trying to resend the message");

                // reuse the same transaction used to read the message from dlq to enqueue the message to app. queue
                //_SystemEvent.SubmitMessage_Queue(message,time);



            }

            if (mqProp.DeliveryStatus == DeliveryStatus.InDoubt ||
                mqProp.DeliveryFailure == DeliveryFailure.Unknown)
            {
                NotifyAdmin();
            }




        }

        private void NotifyAdmin()
        {

        }



        #endregion
    }
}
