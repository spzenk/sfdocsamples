namespace agsXMPP.Client
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
            this.rtfChat = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtfChat
            // 
            this.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfChat.Location = new System.Drawing.Point(0, 0);
            this.rtfChat.Name = "rtfChat";
            this.rtfChat.Size = new System.Drawing.Size(634, 392);
            this.rtfChat.TabIndex = 16;
            this.rtfChat.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 276);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(634, 8);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // rtfSend
            // 
            this.rtfSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtfSend.Location = new System.Drawing.Point(0, 284);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.Size = new System.Drawing.Size(634, 48);
            this.rtfSend.TabIndex = 14;
            this.rtfSend.Text = "";
            this.rtfSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfSend_KeyPress);
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSend.Location = new System.Drawing.Point(550, 344);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(72, 24);
            this.cmdSend.TabIndex = 13;
            this.cmdSend.Text = "&Send";
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 332);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 36);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 368);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(634, 24);
            this.statusBar1.TabIndex = 11;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 392);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtfSend);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.rtfChat);
            this.MinimizeBox = true;
            this.Name = "frmChat";
            this.Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfChat;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox rtfSend;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusBar statusBar1;
    }
}