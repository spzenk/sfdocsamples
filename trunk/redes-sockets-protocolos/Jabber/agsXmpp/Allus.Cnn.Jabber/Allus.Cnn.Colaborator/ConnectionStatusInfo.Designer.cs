namespace Allus.Cnn.Colaborator
{
    partial class ConnectionStatusInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStatusInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.txtMessageLogger = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 50);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionStatus.Location = new System.Drawing.Point(117, 24);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(92, 13);
            this.lblConnectionStatus.TabIndex = 17;
            this.lblConnectionStatus.Text = "Conectando . . .";
            // 
            // txtMessageLogger
            // 
            this.txtMessageLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageLogger.BackColor = System.Drawing.Color.Ivory;
            this.txtMessageLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessageLogger.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtMessageLogger.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtMessageLogger.Location = new System.Drawing.Point(3, 65);
            this.txtMessageLogger.Multiline = true;
            this.txtMessageLogger.Name = "txtMessageLogger";
            this.txtMessageLogger.ReadOnly = true;
            this.txtMessageLogger.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMessageLogger.Size = new System.Drawing.Size(511, 218);
            this.txtMessageLogger.TabIndex = 16;
            this.txtMessageLogger.Text = "sadADadaSDASDAS";
            // 
            // ConnectionStatusInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.txtMessageLogger);
            this.Name = "ConnectionStatusInfo";
            this.Size = new System.Drawing.Size(517, 283);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblConnectionStatus;
        public System.Windows.Forms.TextBox txtMessageLogger;
    }
}
