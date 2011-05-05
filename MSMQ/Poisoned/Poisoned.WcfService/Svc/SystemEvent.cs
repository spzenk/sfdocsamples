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
        public static string QueueName;
        public static string PoisonQueueName;

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
            
            try
            {
                ReceivedInfoProc.Process(message, time);
               
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


        public static void StartThreadProc(object stateInfo)
        {
            StartService();
        }

        public static void StartService()
        {
            // Get MSMQ queue name from app settings in configuration
            QueueName = Poisoned.WcfService.Properties.Settings.Default.QueueName;

            // Get MSMQ queue name for the final poison queue
            PoisonQueueName = Poisoned.WcfService.Properties.Settings.Default.PoisonQueueName;

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(QueueName))
                MessageQueue.Create(QueueName, true);

            // Create the transacted poison message MSMQ queue if necessary.
            if (!MessageQueue.Exists(PoisonQueueName))
                MessageQueue.Create(PoisonQueueName, true);


            // Get the base address that is used to listen for WS-MetaDataExchange requests
            // This is useful to generate a proxy for the client
            //string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the OrderProcessorService type.
            ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent));

            // Hook on to the service host faulted events
            serviceHost.Faulted += new EventHandler(OnServiceFaulted);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

        }


        public static void OnServiceFaulted(object sender, EventArgs e)
        {
            Console.WriteLine("Service Faulted");
        }
        

    }
}
