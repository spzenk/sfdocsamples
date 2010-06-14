using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysEvent.Deamon;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (ServiceHost serviceHost = new ServiceHost(typeof(SystemEvent)))
            //{
            //    serviceHost.Open();
            //}
            MessageQueueProcess_MSMQ svc = new MessageQueueProcess_MSMQ();
            svc.StartResiveMessage();
            // The service can now be accessed.
            Console.WriteLine("The service is ready.");

            Console.WriteLine("enter to stop the service");
            Console.ReadLine();

            svc.StopResiveMessage();
        }
    }
}
