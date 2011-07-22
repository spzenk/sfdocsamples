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

    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false,
       TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable,
       ConcurrencyMode = ConcurrencyMode.Single)]
    public class SystemEventPoison : SvcBase, ISystemEvent
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



        #endregion




        public  void StartService()
        {

            //if (!MessageQueue.Exists(Poisoned.WcfService.Properties.Settings.Default.PoisonQueueName))
            //    MessageQueue.Create(Poisoned.WcfService.Properties.Settings.Default.PoisonQueueName, true);

            Host = new ServiceHost(typeof(SystemEventPoison));
            Host.Faulted += new EventHandler(OnServiceFaulted);
            Host.Closing += new EventHandler(serviceHost_Closing);

            Host.Open();
            
           
        }
        public void OnServiceFaulted(object sender, EventArgs e)
        {
            Log("Falla en  host service SystemEventPoison" );

            //StopService();
            //StartService();

        }

        void serviceHost_Closing(object sender, EventArgs e)
        {
            Log("Cerrando host service SystemEventPoison");
        }
        public void StopService()
        {
            if (Host.State != CommunicationState.Faulted)
                Host.Close();

        }
    }
}
