using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Fabrikam;

namespace TradingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri[] baseAddresses = new Uri[] { new Uri("net.tcp://localhost:8001/") };
            using (ServiceHost host = new ServiceHost(typeof(TradingSystem), baseAddresses))
            {
                host.Open();

                Console.WriteLine("The trading service is available.");
                Console.ReadKey();

                host.Close();
            }

        }
    }
}
