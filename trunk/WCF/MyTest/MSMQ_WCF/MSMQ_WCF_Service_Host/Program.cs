using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace MSMQ_WCF_Service_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the MSMQ queue name from appSettings in configuration.
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the OrderProcessorService type.
            using (ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService)))
            {
                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHost to shut down the service.
                serviceHost.Close();
            }

        }
    }
}
