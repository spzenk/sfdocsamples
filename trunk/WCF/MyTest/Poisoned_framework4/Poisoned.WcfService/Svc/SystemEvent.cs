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
    public class SystemEvent : SvcBase, ISystemEvent
    {
       
       
        static Random r = new Random(137);

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
            int randomNumber = r.Next(10);

            if (randomNumber % 2 == 0)
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
            else
            {
                SysEventMessage m = ReceivedInfoProc.GetSysEventMessage(message);
                Log("Abortando transaccion, Evento con problema : " + m.IdEvent);

                throw new Exception("No se puede procesar el evento: " + m.IdEvent);
            }
        }

   

        #endregion


        public  void StartThreadProc(object stateInfo)
        {
            StartService();
        }

        public  void StartService()
        {
            
            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(Poisoned.WcfService.Properties.Settings.Default.QueueName))
                MessageQueue.Create(Poisoned.WcfService.Properties.Settings.Default.QueueName, true);


            // Create a ServiceHost for the OrderProcessorService type.
             Host = new ServiceHost(typeof(SystemEvent));

            // Hook on to the service host faulted events
             Host.Faulted += new EventHandler(OnServiceFaulted);
             Host.Closing += new EventHandler(serviceHost_Closing);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            Host.Open();


        }
        public  void StopService()
        {
            if (Host.State != CommunicationState.Faulted)
                Host.Close();

        }

        public  void OnServiceFaulted(object sender, EventArgs e)
        {
            Log("Falla en host service SystemEvent");
        
            StopService();
           StartService();
           
        }

        void serviceHost_Closing(object sender, EventArgs e)
        {
            Log("cerrando host service SystemEvent");
        }

    }
}
