using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SecureWcf;

namespace WCFHostConsole
{
    class Program
    {
        static ServiceHost serviceHost = null;
        static void Main(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            //Uri ur = new Uri("net.tcp://localhost:9000/CoreSecurity.svc");
            serviceHost = new ServiceHost(typeof(CoreSecurity));

            

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
            Console.WriteLine("The server is ready and listen on tcp port 9000");
            Console.ReadLine();
        }
    }
}
