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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeerClient
{
    public partial class SetupForm : Form
    {
        private int _numberOfGuests = 0;

        public SetupForm()
        {
            InitializeComponent();

            this.btnStart.Enabled = false;
            this.txtNumberOfGuests.TextChanged += new EventHandler(txtNumberOfGuests_TextChanged);
        }

        private void txtNumberOfGuests_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(this.txtNumberOfGuests.Text, out _numberOfGuests))
            {
                this.btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= _numberOfGuests; i++)
            {
                GuestForm form = new GuestForm();
                form.Show();
            }

            this.btnStart.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}