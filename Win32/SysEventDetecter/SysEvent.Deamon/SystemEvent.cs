using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fwk.Exceptions;
using Fwk.Logging;

namespace SysEvent.Deamon
{
    /// <summary>
    /// Este servicio procesa la cola de MSMQ por lotes
    /// Aqui van llegando lotes de mensages.-
    /// </summary>
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false,
       TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
       ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SystemEvent : ISystemEvent
    {

        #region ISystemEvent Members
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitMessage_Queue(byte[] message, DateTime time)
        {
            try
            {
                ReceivedInfoProc.Process(message, time);
            }
            catch (Exception ex)
            {
                ReceivedInfoProc.LogError(ex);
            }
        }
        //public static void Main()
        //{
        //    //string queueName = ConfigurationManager.AppSettings["queueName"];
        //    //string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

        //    //if (!MessageQueue.Exists(queueName))
        //    //    MessageQueue.Create(queueName, true);

        //    ////using (ServiceHost host = new ServiceHost(serviceType, new Uri(baseAddress)))
        //    //using (ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent)))
        //    //{
        //    //    serviceHost.Open();
        //    //}
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
