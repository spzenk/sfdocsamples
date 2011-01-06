namespace RichText
{
    partial class frmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.rtfChat = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox_Status = new System.Windows.Forms.PictureBox();

            this.pictureBox_Me = new System.Windows.Forms.PictureBox();
            this.pictureBox_Other = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Me)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Other)).BeginInit();
            this.SuspendLayout();
            // 
            // rtfChat
            // 
            this.rtfChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfChat.BackColor = System.Drawing.Color.White;
            this.rtfChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtfChat.Location = new System.Drawing.Point(86, 43);
            this.rtfChat.Name = "rtfChat";
            this.rtfChat.ReadOnly = true;
            this.rtfChat.Size = new System.Drawing.Size(494, 399);
            this.rtfChat.TabIndex = 16;
        
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 517);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(589, 8);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // rtfSend
            // 
            this.rtfSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtfSend.Location = new System.Drawing.Point(83, 448);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.Size = new System.Drawing.Size(416, 48);
            this.rtfSend.TabIndex = 1;
            
            this.rtfSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfSend_KeyPress);
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSend.Location = new System.Drawing.Point(505, 448);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(72, 48);
            this.cmdSend.TabIndex = 13;
            this.cmdSend.Text = "&Send";
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 525);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(589, 24);
            this.statusBar1.TabIndex = 11;
           
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.pictureBox_Status);
            
            this.flowLayoutPanel1.Location = new System.Drawing.Point(89, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(491, 29);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // pictureBox_Status
            // 
      
            this.pictureBox_Status.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Status.Name = "pictureBox_Status";
            this.pictureBox_Status.Size = new System.Drawing.Size(22, 18);
            this.pictureBox_Status.TabIndex = 20;
            this.pictureBox_Status.TabStop = false;
       


            // pictureBox_Me
            // 
            this.pictureBox_Me.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            
            this.pictureBox_Me.Location = new System.Drawing.Point(10, 439);
            this.pictureBox_Me.Name = "pictureBox_Me";
            this.pictureBox_Me.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_Me.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Me.TabIndex = 17;
            this.pictureBox_Me.TabStop = false;
            // 
            // pictureBox_Other
            // 

            this.pictureBox_Other.Location = new System.Drawing.Point(3, 41);
            this.pictureBox_Other.Name = "pictureBox_Other";
            this.pictureBox_Other.Size = new System.Drawing.Size(77, 78);
            this.pictureBox_Other.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Other.TabIndex = 12;
            this.pictureBox_Other.TabStop = false;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 549);
      
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox_Me);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtfSend);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.pictureBox_Other);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.rtfChat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          
            this.Name = "frmChat";
            this.Text = "Chat";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Me)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Other)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfChat;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox rtfSend;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.PictureBox pictureBox_Other;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.PictureBox pictureBox_Me;
        
        
        private System.Windows.Forms.PictureBox pictureBox_Status;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        
 
    }
}