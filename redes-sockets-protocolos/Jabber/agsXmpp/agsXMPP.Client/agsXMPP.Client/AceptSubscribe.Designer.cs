namespace agsXMPP.Client
{
    partial class AceptSubscribe
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRefuse = new System.Windows.Forms.Button();
            this.cmdApprove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(61, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(224, 32);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "jid";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // cmdRefuse
            // 
            this.cmdRefuse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdRefuse.Location = new System.Drawing.Point(195, 107);
            this.cmdRefuse.Name = "cmdRefuse";
            this.cmdRefuse.Size = new System.Drawing.Size(72, 24);
            this.cmdRefuse.TabIndex = 5;
            this.cmdRefuse.Text = "Rechazar";
            this.cmdRefuse.Click += new System.EventHandler(this.cmdRefuse_Click);
            // 
            // cmdApprove
            // 
            this.cmdApprove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdApprove.Location = new System.Drawing.Point(84, 108);
            this.cmdApprove.Name = "cmdApprove";
            this.cmdApprove.Size = new System.Drawing.Size(72, 24);
            this.cmdApprove.TabIndex = 4;
            this.cmdApprove.Text = "Aceptar";
            this.cmdApprove.Click += new System.EventHandler(this.cmdApprove_Click);
            // 
            // AceptSubscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 143);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRefuse);
            this.Controls.Add(this.cmdApprove);
            this.Name = "AceptSubscribe";
            this.Text = "AceptSubscribe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdRefuse;
        private System.Windows.Forms.Button cmdApprove;
    }
}