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
            this.SuspendLayout();
            // 
            // uc_ShiftsControls1
            // 
            this.uc_ShiftsControls1.Location = new System.Drawing.Point(12, 26);
            this.uc_ShiftsControls1.Name = "uc_ShiftsControls1";
            this.uc_ShiftsControls1.Size = new System.Drawing.Size(832, 519);
            this.uc_ShiftsControls1.TabIndex = 0;
            // 
            // frmShiftsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 557);
            this.Controls.Add(this.uc_ShiftsControls1);
            this.Name = "frmShiftsControls";
            this.Text = "frmShiftsControls";
            this.ResumeLayout(false);

        }

        #endregion

        private uc_ShiftsControls uc_ShiftsControls1;
    }
}