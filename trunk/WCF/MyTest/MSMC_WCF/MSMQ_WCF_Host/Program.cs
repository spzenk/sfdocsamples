using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Messaging;
using MSMC_WCF_Service;
using System.ServiceModel;

namespace MSMQ_WCF_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            string queueName = ConfigurationManager.AppSettings["queueName"];
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
            
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);
           
            //using (ServiceHost host = new ServiceHost(serviceType, new Uri(baseAddress)))
            using (ServiceHost host = new ServiceHost(typeof(SendMailService)))
            {
                host.Open();
            }

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
