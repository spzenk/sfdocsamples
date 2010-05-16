using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.PeerToPeer;

namespace Register
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Cloud c in Cloud.GetAvailableClouds())
                Console.WriteLine("Cloud: {0}", c.Name);

            Console.WriteLine();
            Console.Write("Enter Peer Name Classifier: ");
            string classifier = Console.ReadLine();

            PeerName peerName = new PeerName(classifier, PeerNameType.Unsecured);

            using (PeerNameRegistration registration = new PeerNameRegistration(peerName, 8080))
            {
                string timestamp = string.Format("Peer Created at: {0}", DateTime.Now.ToShortTimeString());
                registration.Comment = timestamp;

                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] data = encoding.GetBytes(timestamp);
                registration.Data = data;
                
                try
                {
                    registration.Start();

                    Console.WriteLine("Peer Registration Successful.");
                    Console.WriteLine("Peer Host Name: {0}", registration.PeerName.PeerHostName);

                    Console.WriteLine("Press Enter to Exit...");
                    Console.ReadLine();

                    registration.Stop();
                }
                catch (PeerToPeerException ex)
                {
                    Console.WriteLine("PeerToPeer Exception: {0}", ex.Message);
                }
            }
        }
    }
}
