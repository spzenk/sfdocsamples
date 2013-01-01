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

using BeerClient.BeerInventoryGateway;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace BeerClient
{
    // Specify for the callback to NOT use the current synchronization context
    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public partial class GuestForm : Form, BeerInventoryGateway.BeerInventoryServiceCallback
    {
        private int _beerInventory = 0;
        private SynchronizationContext _uiSyncContext = null;
        private BeerInventoryGateway.BeerInventoryServiceClient _beerInventoryService = null;

        private int BeerInventory
        {
            get { return _beerInventory; }
            set
            {
                if (value >= 0)
                {
                    this.lblBeersRemaining.Text = value.ToString();
                    _beerInventory = value;
                }

                this.btnDrinkBeer.Enabled = (_beerInventory > 0);
            }
        }

        public GuestForm()
        {
            InitializeComponent();
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            this.btnJoinParty.Enabled = false;
            this.btnLeaveParty.Enabled = false;
            this.btnBeerRun.Enabled = false;
            this.btnDrinkBeer.Enabled = false;

            this.txtGuestName.TextChanged += new EventHandler(txtGuestName_TextChanged);
            this.FormClosing += new FormClosingEventHandler(GuestForm_FormClosing);

            // Capture the UI synchronization context
            _uiSyncContext = SynchronizationContext.Current;

            // The client callback interface must be hosted for the server to invoke the callback
            // Open a connection to the beer inventory service via the proxy
            _beerInventoryService = new BeerInventoryServiceClient(new InstanceContext(this), "TcpBinding");
            _beerInventoryService.Open();
        }

        private void GuestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the connections
            _beerInventoryService.Close();
        }

        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGuestName.Text != String.Empty)
            {
                this.btnJoinParty.Enabled = true;
            }
        }

        private void btnJoinParty_Click(object sender, EventArgs e)
        {
            // Welcome to the party.  Get busy drinking beer.
            this.btnJoinParty.Enabled = false;
            
            // The service is invoked on the UI thread.
            // The callback will be handled on a different thread, but UI changes will be dispatched back to UI thread.
            this.BeerInventory = _beerInventoryService.JoinTheParty(this.txtGuestName.Text);

            this.btnBeerRun.Enabled = true;
            this.btnDrinkBeer.Enabled = true;
            this.btnLeaveParty.Enabled = true;
            
            this.txtGuestName.ReadOnly = true;
        }

        private void btnLeaveParty_Click(object sender, EventArgs e)
        {
            // Time to go home and pass out
            this.btnLeaveParty.Enabled = false;
            this.btnBeerRun.Enabled = false;
            this.btnDrinkBeer.Enabled = false;
            _beerInventoryService.LeaveTheParty(this.txtGuestName.Text);
        }

        private void btnBeerRun_Click(object sender, EventArgs e)
        {
            // Let's assume each beer run yields 12 beers
            this.btnBeerRun.Enabled = false;
            _beerInventoryService.MakeBeerRun(this.txtGuestName.Text, 12);
            this.btnBeerRun.Enabled = true;
        }

        private void btnDrinkBeer_Click(object sender, EventArgs e)
        {
            // Chug a beer
            this.btnDrinkBeer.Enabled = false;
            _beerInventoryService.DrinkBeer(this.txtGuestName.Text);
            this.btnDrinkBeer.Enabled = true;
        }

        private void WritePartyLogMessage(string message)
        {
            string format = this.txtPartyLog.Text.Length > 0 ? "{0}\r\n{1} {2}" : "{0}{1} {2}";
            this.txtPartyLog.Text = String.Format(format, this.txtPartyLog.Text, DateTime.Now.ToShortTimeString(), message);
            this.txtPartyLog.SelectionStart = this.txtPartyLog.Text.Length - 1;
            this.txtPartyLog.ScrollToCaret();
        }

        #region IBeerInventoryCallback Methods

        public void NotifyGuestJoinedParty(string guestName)
        {
            // The UI thread won't be handling the callback, but it is the only one allowed to update the controls.  
            // So, we will dispatch the UI update back to the UI sync context.
            SendOrPostCallback callback = 
                delegate (object state)
                { this.WritePartyLogMessage(String.Format("{0} has joined the party.", state.ToString())); };

            _uiSyncContext.Post(callback, guestName);
        }

        public void NotifyBeerInventoryChanged(string guestName, int numberOfBeers)
        {
            string message = null;
            if (numberOfBeers > 0)
            {
                message = String.Format("{0} made a beer run and brought back {1} beers.", guestName, numberOfBeers.ToString());
            }
            else if (numberOfBeers < 0)
            {
                message = String.Format("{0} just chugged another beer.", guestName);
            }

            // The UI thread won't be handling the callback, but it is the only one allowed to update the controls.  
            // So, we will dispatch the UI update back to the UI sync context.
            SendOrPostCallback callback =
                delegate (object state)
                {
                    string[] splitValues = state.ToString().Split('|');
                    this.BeerInventory += Convert.ToInt32(splitValues[0]);
                    this.WritePartyLogMessage(splitValues[1]);
                };

            _uiSyncContext.Post(callback, String.Concat(numberOfBeers.ToString(), "|", message));
        }

        public void NotifyGuestLeftParty(string guestName)
        {
            // The UI thread won't be handling the callback, but it is the only one allowed to update the controls.  
            // So, we will dispatch the UI update back to the UI sync context.
            SendOrPostCallback callback =
                delegate(object state)
                { this.WritePartyLogMessage(String.Format("{0} has left the party.", state.ToString())); };

            _uiSyncContext.Post(callback, guestName);
        }

        #endregion 
    }
}