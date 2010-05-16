using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.PeerToPeer;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            PeerName myPeer = new PeerName("MyUnsecurePeer", PeerNameType.Unsecured);
            //PeerName mySecurePeer = new PeerName("MySecurePeer",PeerNameType.Secured);

            //Publishing o register the peer and associate it with a cloud
            PeerNameRegistration registeration = new PeerNameRegistration(myPeer, 3030);
            registeration.UseAutoEndPointSelection = true;
            registeration.Start();


            //Resolving :The PeerNameResolver can resolve a peer to either a PeerRecord or a cloud,

        }
    }
}
