namespace Health.Front.Scheduler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResouceScheduling));
            this.durationEdit1 = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTimeStart = new DevExpress.XtraEditors.LookUpEdit();
            this.timespamViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTimeEnd = new DevExpress.XtraEditors.LookUpEdit();
            this.weekDaysCheckEdit1 = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chboxEveryWeek = new System.Windows.Forms.CheckBox();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekDaysCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 390);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(566, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // durationEdit1
            // 
            this.durationEdit1.EditValue = "30";
            this.durationEdit1.Location = new System.Drawing.Point(206, 101);
            this.durationEdit1.Name = "durationEdit1";
            this.durationEdit1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AntiqueWhite;
            this.durationEdit1.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.durationEdit1.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.durationEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.durationEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            this.durationEdit1.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.durationEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.durationEdit1.Size = new System.Drawing.Size(111, 22);
            this.durationEdit1.TabIndex = 1;
            this.durationEdit1.SelectedIndexChanged += new System.EventHandler(this.durationEdit1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl1.Location = new System.Drawing.Point(11, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 21);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Duración del turno";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl2.Location = new System.Drawing.Point(11, 146);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(154, 21);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Días de la semana";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl3.Location = new System.Drawing.Point(37, 282);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 21);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Hora inicio";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl4.Location = new System.Drawing.Point(37, 322);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 21);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Hora fin";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelControl5.Location = new System.Drawing.Point(11, 31);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(183, 21);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Descripcion del turno";
            // 
            // cmbTimeStart
            // 
            this.cmbTimeStart.Location = new System.Drawing.Point(171, 285);
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
            this.cmbTimeStart.Size = new System.Drawing.Size(130, 27);
            this.cmbTimeStart.TabIndex = 4;
            // 
            // timespamViewBindingSource
            // 
            this.timespamViewBindingSource.DataSource = typeof(Health.BE.TimespamView);
            // 
            // cmbTimeEnd
            // 
            this.cmbTimeEnd.Location = new System.Drawing.Point(171, 323);
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
            this.cmbTimeEnd.Size = new System.Drawing.Size(130, 27);
            this.cmbTimeEnd.TabIndex = 5;
            // 
            // weekDaysCheckEdit1
            // 
            this.weekDaysCheckEdit1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.weekDaysCheckEdit1.Appearance.Options.UseBackColor = true;
            this.weekDaysCheckEdit1.Location = new System.Drawing.Point(11, 184);
            this.weekDaysCheckEdit1.Name = "weekDaysCheckEdit1";
            this.weekDaysCheckEdit1.Size = new System.Drawing.Size(526, 69);
            this.weekDaysCheckEdit1.TabIndex = 3;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Health.BE.TimespamView);
            // 
            // chboxEveryWeek
            // 
            this.chboxEveryWeek.AutoSize = true;
            this.chboxEveryWeek.Location = new System.Drawing.Point(206, 146);
            this.chboxEveryWeek.Name = "chboxEveryWeek";
            this.chboxEveryWeek.Size = new System.Drawing.Size(68, 21);
            this.chboxEveryWeek.TabIndex = 2;
            this.chboxEveryWeek.Text = "Todos";
            this.chboxEveryWeek.UseVisualStyleBackColor = true;
            this.chboxEveryWeek.CheckedChanged += new System.EventHandler(this.chboxEveryWeek_CheckedChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.EditValue = "";
            this.txtNombre.EnterMoveNextControl = true;
            this.txtNombre.Location = new System.Drawing.Point(206, 32);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNombre.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Properties.Appearance.Options.UseBackColor = true;
            this.txtNombre.Properties.Appearance.Options.UseForeColor = true;
            this.txtNombre.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNombre.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtNombre.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNombre.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtNombre.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtNombre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNombre.Size = new System.Drawing.Size(294, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // frmResouceScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 423);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.chboxEveryWeek);
            this.Controls.Add(this.cmbTimeEnd);
            this.Controls.Add(this.weekDaysCheckEdit1);
            this.Controls.Add(this.cmbTimeStart);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.durationEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmResouceScheduling";
            this.Text = "Plan de turnos";
            this.Load += new System.EventHandler(this.frmResouceScheduling_Load);
            this.Controls.SetChildIndex(this.durationEdit1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.cmbTimeStart, 0);
            this.Controls.SetChildIndex(this.weekDaysCheckEdit1, 0);
            this.Controls.SetChildIndex(this.cmbTimeEnd, 0);
            this.Controls.SetChildIndex(this.chboxEveryWeek, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            ((System.ComponentModel.ISupportInitialize)(this.durationEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weekDaysCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit cmbTimeStart;
        private System.Windows.Forms.BindingSource timespamViewBindingSource;
        private DevExpress.XtraEditors.LookUpEdit cmbTimeEnd;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit weekDaysCheckEdit1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.CheckBox chboxEveryWeek;
        private DevExpress.XtraEditors.TextEdit txtNombre;
    }
}