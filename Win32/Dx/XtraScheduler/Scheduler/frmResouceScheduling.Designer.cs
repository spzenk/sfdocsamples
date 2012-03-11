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
            this.durationEdit1 = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmbTimeStart = new DevExpress.XtraEditors.LookUpEdit();
            this.timespamViewBindingSource = new System.Windows.Forms.BindingSource();
            this.cmbTimeEnd = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource();
            this.weekDaysCheckEdit1 = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekDaysCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.durationEdit1.SelectedIndexChanged += new System.EventHandler(this.durationEdit1_SelectedIndexChanged);
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
            // cmbTimeStart
            // 
            this.cmbTimeStart.Location = new System.Drawing.Point(216, 307);
            this.cmbTimeStart.Name = "cmbTimeStart";
            this.cmbTimeStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbTimeStart.Properties.Appearance.Options.UseFont = true;
            this.cmbTimeStart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmbTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTimeStart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TimeString", "Hora", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.False)});
            this.cmbTimeStart.Properties.DataSource = this.timespamViewBindingSource;
            this.cmbTimeStart.Properties.DisplayMember = "TimeString";
            this.cmbTimeStart.Properties.ValueMember = "Time";
            this.cmbTimeStart.Size = new System.Drawing.Size(149, 27);
            this.cmbTimeStart.TabIndex = 31;
            // 
            // timespamViewBindingSource
            // 
            this.timespamViewBindingSource.DataSource = typeof(Scheduler.TimespamView);
            // 
            // cmbTimeEnd
            // 
            this.cmbTimeEnd.Location = new System.Drawing.Point(216, 345);
            this.cmbTimeEnd.Name = "cmbTimeEnd";
            this.cmbTimeEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbTimeEnd.Properties.Appearance.Options.UseFont = true;
            this.cmbTimeEnd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmbTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTimeEnd.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TimeString", "Hora", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.False)});
            this.cmbTimeEnd.Properties.DataSource = this.timespamViewBindingSource;
            this.cmbTimeEnd.Properties.DisplayMember = "TimeString";
            this.cmbTimeEnd.Properties.ValueMember = "Time";
            this.cmbTimeEnd.Size = new System.Drawing.Size(149, 27);
            this.cmbTimeEnd.TabIndex = 32;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Scheduler.TimespamView);
            // 
            // weekDaysCheckEdit1
            // 
            this.weekDaysCheckEdit1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.weekDaysCheckEdit1.Appearance.Options.UseBackColor = true;
            this.weekDaysCheckEdit1.Location = new System.Drawing.Point(24, 191);
            this.weekDaysCheckEdit1.Name = "weekDaysCheckEdit1";
            this.weekDaysCheckEdit1.Size = new System.Drawing.Size(424, 69);
            this.weekDaysCheckEdit1.TabIndex = 33;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmResouceScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 470);
            this.Controls.Add(this.weekDaysCheckEdit1);
            this.Controls.Add(this.cmbTimeEnd);
            this.Controls.Add(this.cmbTimeStart);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.durationEdit1);
            this.Name = "frmResouceScheduling";
            this.Text = "Plan de turnos";
            this.Load += new System.EventHandler(this.frmResouceScheduling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekDaysCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraScheduler.UI.DurationEdit durationEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LookUpEdit cmbTimeStart;
        private System.Windows.Forms.BindingSource timespamViewBindingSource;
        private DevExpress.XtraEditors.LookUpEdit cmbTimeEnd;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit weekDaysCheckEdit1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}