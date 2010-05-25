namespace UdpServer
{
    partial class UdpServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_CmdStartStop = new System.Windows.Forms.Button();
            this.m_TxtRecibido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_TxtIpServer = new System.Windows.Forms.MaskedTextBox();
            this.m_TxtPuerto = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puerto";
            // 
            // m_CmdStartStop
            // 
            this.m_CmdStartStop.Location = new System.Drawing.Point(283, 25);
            this.m_CmdStartStop.Name = "m_CmdStartStop";
            this.m_CmdStartStop.Size = new System.Drawing.Size(75, 23);
            this.m_CmdStartStop.TabIndex = 4;
            this.m_CmdStartStop.Text = "Start";
            this.m_CmdStartStop.UseVisualStyleBackColor = true;
            this.m_CmdStartStop.Click += new System.EventHandler(this.OnCmdStartStopClick);
            // 
            // m_TxtRecibido
            // 
            this.m_TxtRecibido.Location = new System.Drawing.Point(12, 75);
            this.m_TxtRecibido.Multiline = true;
            this.m_TxtRecibido.Name = "m_TxtRecibido";
            this.m_TxtRecibido.Size = new System.Drawing.Size(265, 173);
            this.m_TxtRecibido.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datos Recibidos";
            // 
            // m_TxtIpServer
            // 
            this.m_TxtIpServer.Location = new System.Drawing.Point(12, 27);
            this.m_TxtIpServer.Name = "m_TxtIpServer";
            this.m_TxtIpServer.Size = new System.Drawing.Size(174, 20);
            this.m_TxtIpServer.TabIndex = 7;
            // 
            // m_TxtPuerto
            // 
            this.m_TxtPuerto.Location = new System.Drawing.Point(192, 27);
            this.m_TxtPuerto.Mask = "99999";
            this.m_TxtPuerto.Name = "m_TxtPuerto";
            this.m_TxtPuerto.Size = new System.Drawing.Size(85, 20);
            this.m_TxtPuerto.TabIndex = 8;
            // 
            // UdpServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 260);
            this.Controls.Add(this.m_TxtPuerto);
            this.Controls.Add(this.m_TxtIpServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_TxtRecibido);
            this.Controls.Add(this.m_CmdStartStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UdpServer";
            this.Text = "UDP Server Test";
            this.Load += new System.EventHandler(this.UdpServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_CmdStartStop;
        private System.Windows.Forms.TextBox m_TxtRecibido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox m_TxtIpServer;
        private System.Windows.Forms.MaskedTextBox m_TxtPuerto;
    }
}

