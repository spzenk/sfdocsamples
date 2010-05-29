
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.Configuration;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Transactions;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Microsoft.ServiceModel.Samples
{

    // Define a service contract. 
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true)]
        void SubmitPurchaseOrder(PurchaseOrder po);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false, 
        TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable, 
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine("Processing {0} ", po);
            Orders.Add(po);
        }


        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from app settings in configuration
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);


            // Get the base address that is used to listen for WS-MetaDataExchange requests
            // This is useful to generate a proxy for the client
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Create a ServiceHost for the OrderProcessorService type.
            ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService));

            /*  ServiceThrottlingBehavior throttle = new ServiceThrottlingBehavior();
              throttle.MaxConcurrentCalls = 5;
              serviceHost.Description.Behaviors.Add(throttle);*/

            // Hook on to the service host faulted events
            serviceHost.Faulted += new EventHandler(OnServiceFaulted);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            try
            {
                serviceHost.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                Console.WriteLine(" Service cannot be closed...it already faulted");
            }
        }

        public static void OnServiceFaulted(object sender, EventArgs e)
        {
            Console.WriteLine("Service Faulted ");
        }
        
    }
}
