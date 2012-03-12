namespace Scheduler
{
    partial class frmShiftsControls
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
            this.uc_ShiftsControls1 = new Scheduler.uc_ShiftsControls();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // uc_ShiftsControls1
            // 
            this.uc_ShiftsControls1.Location = new System.Drawing.Point(114, 12);
            this.uc_ShiftsControls1.Name = "uc_ShiftsControls1";
            this.uc_ShiftsControls1.Size = new System.Drawing.Size(792, 533);
            this.uc_ShiftsControls1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(13, 37);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmShiftsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 557);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.uc_ShiftsControls1);
            this.Name = "frmShiftsControls";
            this.Text = "frmShiftsControls";
            this.ResumeLayout(false);

        }

        #endregion

        private uc_ShiftsControls uc_ShiftsControls1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}