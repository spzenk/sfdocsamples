namespace Health.Front.Scheduler
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
            this.uc_ShiftsControls1 = new Health.Front.Scheduler.uc_ShiftsControls();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.dateNavigator2 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator2)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 524);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(807, 28);
            // 
            // uc_ShiftsControls1
            // 
            this.uc_ShiftsControls1.Location = new System.Drawing.Point(246, 8);
            this.uc_ShiftsControls1.Name = "uc_ShiftsControls1";
            this.uc_ShiftsControls1.Size = new System.Drawing.Size(561, 533);
            this.uc_ShiftsControls1.TabIndex = 0;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.DateTime = new System.DateTime(2012, 3, 12, 0, 0, 0, 0);
            this.dateNavigator1.HotDate = null;
            this.dateNavigator1.Location = new System.Drawing.Point(6, 24);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(216, 195);
            this.dateNavigator1.TabIndex = 19;
            this.dateNavigator1.EditDateModified += new System.EventHandler(this.dateNavigator1_EditDateModified);
            // 
            // dateNavigator2
            // 
            this.dateNavigator2.DateTime = new System.DateTime(2012, 3, 12, 0, 0, 0, 0);
            this.dateNavigator2.HotDate = null;
            this.dateNavigator2.Location = new System.Drawing.Point(6, 253);
            this.dateNavigator2.Name = "dateNavigator2";
            this.dateNavigator2.Size = new System.Drawing.Size(216, 195);
            this.dateNavigator2.TabIndex = 20;
            // 
            // frmShiftsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 557);
            this.Controls.Add(this.dateNavigator2);
            this.Controls.Add(this.dateNavigator1);
            this.Controls.Add(this.uc_ShiftsControls1);
            this.Name = "frmShiftsControls";
            this.Text = "frmShiftsControls";
            this.Controls.SetChildIndex(this.uc_ShiftsControls1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.dateNavigator1, 0);
            this.Controls.SetChildIndex(this.dateNavigator2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_ShiftsControls uc_ShiftsControls1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator2;
    }
}