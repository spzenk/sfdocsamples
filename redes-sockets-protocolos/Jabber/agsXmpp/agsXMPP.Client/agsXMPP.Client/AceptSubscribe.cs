using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP.protocol.client;

namespace agsXMPP.Client
{
    public partial class AceptSubscribe : frmDialogBase
    {
        	private XmppClientConnection	_connection;
		private Jid						_from;

        public AceptSubscribe(XmppClientConnection con, Jid jid)
		{
			InitializeComponent();
            
			_connection = con;
			_from		= jid;

			lblFrom.Text	= jid.ToString();
		}
        public AceptSubscribe()
        {
            InitializeComponent();
        }

        private void cmdApprove_Click(object sender, EventArgs e)
        {
            PresenceManager pm = new PresenceManager(_connection);
            pm.ApproveSubscriptionRequest(_from);

            this.Close();
        }

        private void cmdRefuse_Click(object sender, EventArgs e)
        {
            PresenceManager pm = new PresenceManager(_connection);
            pm.RefuseSubscriptionRequest(_from);

            this.Close();
        }
    }
}
