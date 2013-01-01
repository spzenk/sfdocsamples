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

namespace BeerClient
{
    partial class GuestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGuestName = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.btnJoinParty = new System.Windows.Forms.Button();
            this.btnLeaveParty = new System.Windows.Forms.Button();
            this.btnBeerRun = new System.Windows.Forms.Button();
            this.txtPartyLog = new System.Windows.Forms.TextBox();
            this.btnDrinkBeer = new System.Windows.Forms.Button();
            this.lblBeersRemainingHeader = new System.Windows.Forms.Label();
            this.lblBeersRemaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Location = new System.Drawing.Point(14, 9);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(69, 13);
            this.lblGuestName.TabIndex = 0;
            this.lblGuestName.Text = "Guest Name:";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(84, 6);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(239, 21);
            this.txtGuestName.TabIndex = 1;
            // 
            // btnJoinParty
            // 
            this.btnJoinParty.Location = new System.Drawing.Point(156, 33);
            this.btnJoinParty.Name = "btnJoinParty";
            this.btnJoinParty.Size = new System.Drawing.Size(75, 23);
            this.btnJoinParty.TabIndex = 2;
            this.btnJoinParty.Text = "Join Party";
            this.btnJoinParty.UseVisualStyleBackColor = true;
            this.btnJoinParty.Click += new System.EventHandler(this.btnJoinParty_Click);
            // 
            // btnLeaveParty
            // 
            this.btnLeaveParty.Location = new System.Drawing.Point(237, 33);
            this.btnLeaveParty.Name = "btnLeaveParty";
            this.btnLeaveParty.Size = new System.Drawing.Size(86, 23);
            this.btnLeaveParty.TabIndex = 3;
            this.btnLeaveParty.Text = "Leave Party";
            this.btnLeaveParty.UseVisualStyleBackColor = true;
            this.btnLeaveParty.Click += new System.EventHandler(this.btnLeaveParty_Click);
            // 
            // btnBeerRun
            // 
            this.btnBeerRun.Location = new System.Drawing.Point(7, 67);
            this.btnBeerRun.Name = "btnBeerRun";
            this.btnBeerRun.Size = new System.Drawing.Size(316, 23);
            this.btnBeerRun.TabIndex = 6;
            this.btnBeerRun.Text = "MAKE A BEER RUN!";
            this.btnBeerRun.UseVisualStyleBackColor = true;
            this.btnBeerRun.Click += new System.EventHandler(this.btnBeerRun_Click);
            // 
            // txtPartyLog
            // 
            this.txtPartyLog.BackColor = System.Drawing.Color.White;
            this.txtPartyLog.Location = new System.Drawing.Point(7, 125);
            this.txtPartyLog.Multiline = true;
            this.txtPartyLog.Name = "txtPartyLog";
            this.txtPartyLog.ReadOnly = true;
            this.txtPartyLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPartyLog.Size = new System.Drawing.Size(316, 211);
            this.txtPartyLog.TabIndex = 7;
            // 
            // btnDrinkBeer
            // 
            this.btnDrinkBeer.Location = new System.Drawing.Point(7, 96);
            this.btnDrinkBeer.Name = "btnDrinkBeer";
            this.btnDrinkBeer.Size = new System.Drawing.Size(316, 23);
            this.btnDrinkBeer.TabIndex = 8;
            this.btnDrinkBeer.Text = "CHUG A BEER!";
            this.btnDrinkBeer.UseVisualStyleBackColor = true;
            this.btnDrinkBeer.Click += new System.EventHandler(this.btnDrinkBeer_Click);
            // 
            // lblBeersRemainingHeader
            // 
            this.lblBeersRemainingHeader.AutoSize = true;
            this.lblBeersRemainingHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeersRemainingHeader.Location = new System.Drawing.Point(71, 343);
            this.lblBeersRemainingHeader.Name = "lblBeersRemainingHeader";
            this.lblBeersRemainingHeader.Size = new System.Drawing.Size(105, 13);
            this.lblBeersRemainingHeader.TabIndex = 9;
            this.lblBeersRemainingHeader.Text = "Beers Remaining:";
            // 
            // lblBeersRemaining
            // 
            this.lblBeersRemaining.AutoSize = true;
            this.lblBeersRemaining.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeersRemaining.Location = new System.Drawing.Point(182, 343);
            this.lblBeersRemaining.Name = "lblBeersRemaining";
            this.lblBeersRemaining.Size = new System.Drawing.Size(59, 13);
            this.lblBeersRemaining.TabIndex = 10;
            this.lblBeersRemaining.Text = "Unknown";
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 365);
            this.Controls.Add(this.lblBeersRemaining);
            this.Controls.Add(this.lblBeersRemainingHeader);
            this.Controls.Add(this.btnDrinkBeer);
            this.Controls.Add(this.txtPartyLog);
            this.Controls.Add(this.btnBeerRun);
            this.Controls.Add(this.btnLeaveParty);
            this.Controls.Add(this.btnJoinParty);
            this.Controls.Add(this.txtGuestName);
            this.Controls.Add(this.lblGuestName);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GuestForm";
            this.Text = "Beer Information";
            this.Load += new System.EventHandler(this.GuestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Button btnJoinParty;
        private System.Windows.Forms.Button btnLeaveParty;
        private System.Windows.Forms.Button btnBeerRun;
        private System.Windows.Forms.TextBox txtPartyLog;
        private System.Windows.Forms.Button btnDrinkBeer;
        private System.Windows.Forms.Label lblBeersRemainingHeader;
        private System.Windows.Forms.Label lblBeersRemaining;
    }
}

