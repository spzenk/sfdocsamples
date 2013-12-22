using Health.Front.Profecional;
namespace Health.Front.profesional
{
    partial class frm_Profesional_Shifts
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.uc_TimeLine1 = new Health.Front.Profecional.uc_TimeLine();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 587);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(1191, 28);
            this.aceptCancelButtonBar1.Visible = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(2, 9);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // uc_TimeLine1
            // 
            this.uc_TimeLine1.AcceptButton = null;
            this.uc_TimeLine1.CancelButton = null;
            this.uc_TimeLine1.Key = null;
            this.uc_TimeLine1.Location = new System.Drawing.Point(272, 9);
            this.uc_TimeLine1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_TimeLine1.Name = "uc_TimeLine1";
            this.uc_TimeLine1.ShowClose = false;
            this.uc_TimeLine1.Size = new System.Drawing.Size(910, 557);
            this.uc_TimeLine1.TabIndex = 1;
            this.uc_TimeLine1.OnChangeStatusEvent += new System.EventHandler(this.uc_TimeLine1_OnChangeStatusEvent);
            // 
            // frm_Profesional_Shifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 620);
            this.Controls.Add(this.uc_TimeLine1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "frm_Profesional_Shifts";
            this.Text = "Turnos ";
            this.Load += new System.EventHandler(this.frm_Profesional_Shifts_Load);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.monthCalendar1, 0);
            this.Controls.SetChildIndex(this.uc_TimeLine1, 0);
            this.ResumeLayout(false);

        }

        #endregion


        private uc_TimeLine uc_TimeLine1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;

        
    }
}