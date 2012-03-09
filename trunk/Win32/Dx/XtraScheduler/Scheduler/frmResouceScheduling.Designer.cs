namespace Scheduler
{
    partial class frmResouceScheduling
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
            this.timeEdit_To = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit_From = new DevExpress.XtraEditors.TimeEdit();
            this.weeklyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl();
            this.durationEdit1 = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timeEdit_To
            // 
            this.timeEdit_To.EditValue = new System.DateTime(2012, 3, 6, 0, 0, 0, 0);
            this.timeEdit_To.Location = new System.Drawing.Point(210, 343);
            this.timeEdit_To.Name = "timeEdit_To";
            this.timeEdit_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_To.Properties.Mask.EditMask = "t";
            this.timeEdit_To.Size = new System.Drawing.Size(112, 22);
            this.timeEdit_To.TabIndex = 14;
            // 
            // timeEdit_From
            // 
            this.timeEdit_From.EditValue = new System.DateTime(2012, 3, 6, 0, 0, 0, 0);
            this.timeEdit_From.Location = new System.Drawing.Point(210, 305);
            this.timeEdit_From.Name = "timeEdit_From";
            this.timeEdit_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_From.Properties.Mask.EditMask = "t";
            this.timeEdit_From.Size = new System.Drawing.Size(112, 22);
            this.timeEdit_From.TabIndex = 13;
            // 
            // weeklyRecurrenceControl1
            // 
            this.weeklyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.weeklyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            this.weeklyRecurrenceControl1.Location = new System.Drawing.Point(13, 168);
            this.weeklyRecurrenceControl1.Name = "weeklyRecurrenceControl1";
            this.weeklyRecurrenceControl1.Size = new System.Drawing.Size(614, 96);
            this.weeklyRecurrenceControl1.TabIndex = 12;
            // 
            // durationEdit1
            // 
            this.durationEdit1.EditValue = "30";
            this.durationEdit1.Location = new System.Drawing.Point(195, 99);
            this.durationEdit1.Name = "durationEdit1";
            this.durationEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.durationEdit1.Size = new System.Drawing.Size(127, 22);
            this.durationEdit1.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl1.Location = new System.Drawing.Point(13, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 21);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Duración del turno";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl2.Location = new System.Drawing.Point(13, 146);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 21);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Recursividad";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl3.Location = new System.Drawing.Point(63, 304);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 21);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Hora inicio";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl4.Location = new System.Drawing.Point(63, 344);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 21);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Hora fin";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl5.Location = new System.Drawing.Point(13, 31);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(183, 21);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Descripcion del turno";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(236, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(262, 22);
            this.txtNombre.TabIndex = 20;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(386, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(132, 26);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Aceptar";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmResouceScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 470);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.timeEdit_To);
            this.Controls.Add(this.timeEdit_From);
            this.Controls.Add(this.weeklyRecurrenceControl1);
            this.Controls.Add(this.durationEdit1);
            this.Name = "frmResouceScheduling";
            this.Text = "frmResouceScheduling";
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEdit_To;
        private DevExpress.XtraEditors.TimeEdit timeEdit_From;
        private DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl weeklyRecurrenceControl1;
        private DevExpress.XtraScheduler.UI.DurationEdit durationEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}