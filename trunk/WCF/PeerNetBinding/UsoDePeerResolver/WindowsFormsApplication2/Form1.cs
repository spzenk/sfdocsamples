using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.PeerToPeer;
using System.Net;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void Init()
        {
            StringBuilder str = new StringBuilder();
            PeerName myPeer = new PeerName("MySecurePeer", PeerNameType.Secured);
            PeerNameResolver resolver = new PeerNameResolver();
            PeerName peerName = new PeerName(classifier, PeerNameType.Secured);
            PeerNameRecordCollection results = resolver.Resolve(myPeer);

            str.AppendLine(string.Format("{0} Peers Found:", results.Count.ToString()));
            int i = 1;
       
            foreach (PeerNameRecord peer in results)
            {
                str.AppendLine(string.Format("{0} Peer:{1}", i++, peer.PeerName.ToString()));
                
                foreach (IPEndPoint ip in peer.EndPointCollection)
                {
                    str.AppendLine(string.Format("\t Endpoint: {0}, port {1}", ip.Address.ToString(),ip.Port.ToString()));
                    
                }
            }
            textBox1.Text = str.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
              Init();


        }
    }
}
