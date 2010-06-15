using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Messaging;

using System.ServiceModel;

namespace SysEvent.Deamon
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceivedInfoProc.LogError("asasdsadsdasds");
            //using (ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent)))
            //{
            //    serviceHost.Open();
            //}
            MessageQueueProcess_MSMQ svc = new MessageQueueProcess_MSMQ();
            svc.StartResiveMessage();
            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
    
            Console.WriteLine();
            Console.ReadLine();
        }
    }

//    public class Program
//    {
//        public static void Main(string[] args)
//        {

//            //using (ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent)))
//            //{
//            //    serviceHost.Open();
//            //}
//            MessageQueueProcess_MSMQ svc = new MessageQueueProcess_MSMQ();
//            svc.StartResiveMessage();
//            // The service can now be accessed.
//            Console.WriteLine("The service is ready.");

//            Console.WriteLine();
//            Console.ReadLine();
//        }
//    }
}
