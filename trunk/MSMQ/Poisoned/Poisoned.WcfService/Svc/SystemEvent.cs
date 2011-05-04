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
    // Note: To use the TransactionIsolationLevel property, you 
    // must add a reference to the System.Transactions.dll assembly.
    /* The following service implementation:
     *   -- Processes messages on one thread at a time
     *   -- Creates one service object per session
     *   -- Releases the service object when the transaction commits
     */
    /// <summary>
    /// Este servicio procesa la cola de MSMQ por lotes
    /// Aqui van llegando lotes de mensages.-
    /// </summary>
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false,
       TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
       ConcurrencyMode = ConcurrencyMode.Single)]
    public class SystemEvent : ISystemEvent
    {

        #region ISystemEvent Members

        /*
        * The following operation-level behaviors are specified:
        *   -- Always executes under a transaction scope.
        *   -- The transaction scope is completed when the operation terminates 
        *       without an unhandled exception.
        */
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitMessage_Queue(byte[] message, DateTime time)
        {
            //MsmqMessageProperty mqProp = OperationContext.Current.IncomingMessageProperties[MsmqMessageProperty.Name] as MsmqMessageProperty
            try
            {
                ReceivedInfoProc.Process(message, time);
                throw new Exception();
            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError_WE(ex);
                ReceivedInfoProc.LogError(ex);
            }
        }

        //public static void Main()
        //{
        //    string queueName = ConfigurationManager.AppSettings["queueName"];
        //    string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

        //    if (!MessageQueue.Exists(queueName))
        //        MessageQueue.Create(queueName, true);

        //    //using (ServiceHost host = new ServiceHost(serviceType, new Uri(baseAddress)))
        //    using (ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent)))
        //    {
        //        serviceHost.Open();
        //    }
        //    MessageQueueProcess_MSMQ svc = new MessageQueueProcess_MSMQ();
        //    svc.StartResiveMessage();
        //    // The service can now be accessed.
        //    Console.WriteLine("The service is ready.");
        //    Console.WriteLine("Press <ENTER> to terminate service.");
        //    Console.WriteLine();
        //    Console.ReadLine();
        //}

        #endregion
    }
}
