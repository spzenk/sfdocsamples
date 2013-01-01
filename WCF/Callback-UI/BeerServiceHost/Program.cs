//===============================================================================
// Jeff Barnes - 02/16/2007
// WCF Callback Sample
// http://blog.jeffbarnes.net
// http://jeffbarnes.net/portal/blogs/jeff_barnes/contact.aspx
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.ServiceModel;

namespace JeffBarnes.WCF.Samples.CallbackDemo.Service
{
    /// <summary>
    /// Console Application used to host the service
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing Service...");

            // The service configuration is loaded from app.config
            using (ServiceHost host = new ServiceHost(typeof(BeerService)))
            {
                host.Open();
                
                Console.WriteLine("Service is ready for requests.  Press any key to close service.");
                Console.WriteLine();
                Console.Read();

                Console.WriteLine("Closing service...");
            }
        }
    }
}
