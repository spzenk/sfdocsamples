using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;
using System.Threading;

namespace Resolve
{
    class Program
    {
        static bool isRunning = true;
        static PeerNameRecordCollection records;

        static void Main(string[] args)
        {
            Console.Write("Peer Classifier to Resolve: ");
            string classifier = Console.ReadLine();
            
            PeerNameResolver resolver = new PeerNameResolver();

            Console.Write("Please wait. Resolving...");

            try
            {
                //records = resolver.Resolve(new PeerName(classifier, PeerNameType.Unsecured));
                //DisplayResults();

                resolver.ResolveCompleted += new EventHandler<ResolveCompletedEventArgs>(resolver_ResolveCompleted);
                resolver.ResolveProgressChanged += new EventHandler<ResolveProgressChangedEventArgs>(resolver_ResolveProgressChanged);
                resolver.ResolveAsync(new PeerName(classifier, PeerNameType.Unsecured), Guid.NewGuid());

                while (isRunning)
                {
                    Thread.Sleep(1000);
                    //Console.Write(".");
                }

            }
            catch (PeerToPeerException ex)
            {
                Console.WriteLine("PeerToPeer Exception: {0}", ex.Message);
               
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();

            
        }

        static void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            Console.Write("\r{0} Resolution Progress: {1}", e.PeerNameRecord.PeerName, e.ProgressPercentage);
        }

        static void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && e.PeerNameRecordCollection != null)
            {
                records = e.PeerNameRecordCollection;
                DisplayResults();
                isRunning = false;
            }
        }

        private static void DisplayResults()
        {
            if (records.Count > 0)
            {
                UnicodeEncoding encoder = new UnicodeEncoding();

                Console.WriteLine();
                Console.WriteLine();
                foreach (var record in records)
                {
                    string data = (record.Data != null) ? encoder.GetString(record.Data) : string.Empty;
                    Console.WriteLine("***Peer: {0}\n\r\tHost: {1} \n\r\tComment: {2} \n\r\tData: {3}", record.PeerName.ToString(), record.PeerName.PeerHostName, record.Comment, data);

                    foreach (var endpoint in record.EndPointCollection)
                        Console.WriteLine("\tEndpoint: {0}, Port {1}", endpoint.Address.ToString(), endpoint.Port);
                    Console.WriteLine();
                }
            }
        }
        
    }
}
