namespace Scheduler
{
    partial class MyAppointmentForm
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
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.txSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtPaciente = new DevExpress.XtraEditors.TextEdit();
            this.bt_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.btCanel = new DevExpress.XtraEditors.SimpleButton();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.txtProfecional = new DevExpress.XtraEditors.TextEdit();
            this.lblAsunto = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.edLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edStatus = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaciente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfecional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2012, 3, 6, 0, 0, 0, 0);
            this.timeEnd.Location = new System.Drawing.Point(270, 238);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEnd.Properties.Mask.EditMask = "t";
            this.timeEnd.Size = new System.Drawing.Size(100, 22);
            this.timeEnd.TabIndex = 12;
            this.timeEnd.EditValueChanged += new System.EventHandler(this.timeEnd_EditValueChanged_1);
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2012, 3, 6, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(270, 210);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStart.Properties.Mask.EditMask = "t";
            this.timeStart.Size = new System.Drawing.Size(100, 22);
            this.timeStart.TabIndex = 11;
            this.timeStart.EditValueChanged += new System.EventHandler(this.timeStart_EditValueChanged);
            // 
            // txSubject
            // 
            this.txSubject.Location = new System.Drawing.Point(134, 12);
            this.txSubject.Name = "txSubject";
            this.txSubject.Size = new System.Drawing.Size(222, 22);
            this.txSubject.TabIndex = 13;
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(134, 86);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(213, 22);
            this.txtPaciente.TabIndex = 14;
            // 
            // bt_Ok
            // 
            this.bt_Ok.Location = new System.Drawing.Point(295, 273);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(75, 23);
            this.bt_Ok.TabIndex = 15;
            this.bt_Ok.Text = "Aceptar";
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // btCanel
            // 
            this.btCanel.Location = new System.Drawing.Point(396, 273);
            this.btCanel.Name = "btCanel";
            this.btCanel.Size = new System.Drawing.Size(75, 23);
            this.btCanel.TabIndex = 16;
            this.btCanel.Text = "Cancelar";
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Location = new System.Drawing.Point(109, 210);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(153, 22);
            this.dtStart.TabIndex = 17;
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_EditValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.Location = new System.Drawing.Point(109, 238);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(153, 22);
            this.dtEnd.TabIndex = 18;
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_EditValueChanged);
            // 
            // txtProfecional
            // 
            this.txtProfecional.Location = new System.Drawing.Point(134, 58);
            this.txtProfecional.Name = "txtProfecional";
            this.txtProfecional.Size = new System.Drawing.Size(213, 22);
            this.txtProfecional.TabIndex = 19;
            // 
            // lblAsunto
            // 
            this.lblAsunto.Location = new System.Drawing.Point(26, 15);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(39, 16);
            this.lblAsunto.TabIndex = 20;
            this.lblAsunto.Text = "Asunto";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Profecional";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 16);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Paciente";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 132);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 21);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Estado";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(25, 239);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(57, 21);
            this.lblEnd.TabIndex = 26;
            this.lblEnd.Text = "End:";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(25, 212);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(67, 20);
            this.lblStart.TabIndex = 25;
            this.lblStart.Text = "Start:";
            // 
            // lblLabel
            // 
            this.lblLabel.Location = new System.Drawing.Point(20, 160);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(57, 22);
            this.lblLabel.TabIndex = 28;
            this.lblLabel.Text = "Label:";
            this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
            // 
            // edLabel
            // 
            this.edLabel.Location = new System.Drawing.Point(125, 160);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(231, 22);
            this.edLabel.TabIndex = 27;
            // 
            // edStatus
            // 
            this.edStatus.Location = new System.Drawing.Point(116, 131);
            this.edStatus.Name = "edStatus";
            this.edStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStatus.Size = new System.Drawing.Size(231, 22);
            this.edStatus.TabIndex = 29;
            // 
            // MyAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 336);
            this.Controls.Add(this.edStatus);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.edLabel);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.txtProfecional);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.btCanel);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.txSubject);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Name = "MyAppointmentForm";
            this.Text = "Turnos";
            this.Activated += new System.EventHandler(this.MyAppointmentForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaciente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfecional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private DevExpress.XtraEditors.TextEdit txSubject;
        private DevExpress.XtraEditors.TextEdit txtPaciente;
        private DevExpress.XtraEditors.SimpleButton bt_Ok;
        private DevExpress.XtraEditors.SimpleButton btCanel;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.TextEdit txtProfecional;
        private DevExpress.XtraEditors.LabelControl lblAsunto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblLabel;
        private DevExpress.XtraScheduler.UI.AppointmentLabelEdit edLabel;
        private DevExpress.XtraScheduler.UI.AppointmentStatusEdit edStatus;
    }
}