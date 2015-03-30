namespace Health.Front.Scheduler
{
    partial class frmDxShiftAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftAppointment));
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.edLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edStatus = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.btnFindPatient = new DevExpress.XtraEditors.SimpleButton();
            this.txtPatient = new DevExpress.XtraEditors.TextEdit();
            this.txtProfesional = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDEscription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfesional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEscription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 491);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(857, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2012, 3, 6, 0, 0, 0, 0);
            this.timeEnd.Enabled = false;
            this.timeEnd.Location = new System.Drawing.Point(225, 82);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.timeEnd.Properties.Appearance.Options.UseBackColor = true;
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
            this.timeStart.Enabled = false;
            this.timeStart.Location = new System.Drawing.Point(79, 81);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.timeStart.Properties.Appearance.Options.UseBackColor = true;
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStart.Properties.Mask.EditMask = "t";
            this.timeStart.Size = new System.Drawing.Size(100, 22);
            this.timeStart.TabIndex = 11;
            this.timeStart.EditValueChanged += new System.EventHandler(this.timeStart_EditValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.EditValue = null;
            this.dtStart.Enabled = false;
            this.dtStart.Location = new System.Drawing.Point(79, 44);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Appearance.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dtStart.Properties.Appearance.Options.UseBackColor = true;
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(246, 22);
            this.dtStart.TabIndex = 17;
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_EditValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.Location = new System.Drawing.Point(122, 437);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(153, 22);
            this.dtEnd.TabIndex = 18;
            this.dtEnd.Visible = false;
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_EditValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(346, 92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 21);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Estado";
            // 
            // lblEnd
            // 
            this.lblEnd.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEnd.Location = new System.Drawing.Point(185, 84);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(32, 21);
            this.lblEnd.TabIndex = 26;
            this.lblEnd.Text = "a";
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStart.Location = new System.Drawing.Point(6, 84);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(67, 20);
            this.lblStart.TabIndex = 25;
            this.lblStart.Text = "De";
            // 
            // lblLabel
            // 
            this.lblLabel.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLabel.Location = new System.Drawing.Point(346, 48);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(75, 22);
            this.lblLabel.TabIndex = 28;
            this.lblLabel.Text = "Etiqueta";
            this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
            // 
            // edLabel
            // 
            this.edLabel.Location = new System.Drawing.Point(430, 47);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(231, 22);
            this.edLabel.TabIndex = 27;
            // 
            // edStatus
            // 
            this.edStatus.Enabled = false;
            this.edStatus.Location = new System.Drawing.Point(430, 91);
            this.edStatus.Name = "edStatus";
            this.edStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStatus.Properties.SmallImages = this.imageList1;
            this.edStatus.Size = new System.Drawing.Size(231, 22);
            this.edStatus.TabIndex = 29;
            // 
            // btnFindPatient
            // 
            this.btnFindPatient.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnFindPatient.Image = global::Health.Front.Base.Properties.Resource.summary_zoom_32;
            this.btnFindPatient.Location = new System.Drawing.Point(446, 250);
            this.btnFindPatient.Name = "btnFindPatient";
            this.btnFindPatient.Size = new System.Drawing.Size(147, 34);
            this.btnFindPatient.TabIndex = 30;
            this.btnFindPatient.Text = "Buscar paciente";

            this.btnFindPatient.Click += new System.EventHandler(this.btnFindPatient_Click);
            // 
            // txtPatient
            // 
            this.txtPatient.EditValue = "";
            this.txtPatient.EnterMoveNextControl = true;
            this.txtPatient.Location = new System.Drawing.Point(157, 256);
            this.txtPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPatient.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatient.Properties.Appearance.Options.UseBackColor = true;
            this.txtPatient.Properties.Appearance.Options.UseForeColor = true;
            this.txtPatient.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtPatient.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatient.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtPatient.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPatient.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtPatient.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPatient.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPatient.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPatient.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtPatient.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPatient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPatient.Size = new System.Drawing.Size(263, 22);
            this.txtPatient.TabIndex = 33;
            // 
            // txtProfesional
            // 
            this.txtProfesional.EditValue = "";
            this.txtProfesional.Enabled = false;
            this.txtProfesional.EnterMoveNextControl = true;
            this.txtProfesional.Location = new System.Drawing.Point(157, 207);
            this.txtProfesional.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProfesional.Name = "txtProfesional";
            this.txtProfesional.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtProfesional.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtProfesional.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProfesional.Properties.Appearance.Options.UseBackColor = true;
            this.txtProfesional.Properties.Appearance.Options.UseFont = true;
            this.txtProfesional.Properties.Appearance.Options.UseForeColor = true;
            this.txtProfesional.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtProfesional.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProfesional.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtProfesional.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtProfesional.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtProfesional.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProfesional.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtProfesional.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtProfesional.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtProfesional.Size = new System.Drawing.Size(263, 22);
            this.txtProfesional.TabIndex = 34;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Location = new System.Drawing.Point(55, 208);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 18);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "profesional";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Location = new System.Drawing.Point(55, 257);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 18);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "Paciente";
            // 
            // txSubject
            // 
            this.txSubject.EditValue = "";
            this.txSubject.EnterMoveNextControl = true;
            this.txSubject.Location = new System.Drawing.Point(157, 303);
            this.txSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txSubject.Name = "txSubject";
            this.txSubject.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txSubject.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txSubject.Properties.Appearance.Options.UseBackColor = true;
            this.txSubject.Properties.Appearance.Options.UseForeColor = true;
            this.txSubject.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txSubject.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txSubject.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txSubject.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txSubject.Properties.AppearanceFocused.Options.UseFont = true;
            this.txSubject.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txSubject.Size = new System.Drawing.Size(559, 22);
            this.txSubject.TabIndex = 35;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(55, 304);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 18);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Asunto";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.SlateGray;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(3, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(857, 54);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Nuevo turno medico";
            // 
            // txtDEscription
            // 
            this.txtDEscription.EditValue = "";
            this.txtDEscription.Location = new System.Drawing.Point(157, 361);
            this.txtDEscription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDEscription.Name = "txtDEscription";
            this.txtDEscription.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDEscription.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDEscription.Properties.Appearance.Options.UseBackColor = true;
            this.txtDEscription.Properties.Appearance.Options.UseForeColor = true;
            this.txtDEscription.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtDEscription.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDEscription.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDEscription.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDEscription.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtDEscription.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDEscription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDEscription.Size = new System.Drawing.Size(559, 70);
            this.txtDEscription.TabIndex = 38;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl5.Location = new System.Drawing.Point(55, 353);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 18);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "Nota";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Fecha";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtStart);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.timeStart);
            this.groupControl1.Controls.Add(this.timeEnd);
            this.groupControl1.Controls.Add(this.lblStart);
            this.groupControl1.Controls.Add(this.lblEnd);
            this.groupControl1.Controls.Add(this.edStatus);
            this.groupControl1.Controls.Add(this.lblStatus);
            this.groupControl1.Controls.Add(this.edLabel);
            this.groupControl1.Controls.Add(this.lblLabel);
            this.groupControl1.Location = new System.Drawing.Point(11, 67);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(706, 127);
            this.groupControl1.TabIndex = 41;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AppoimentStatusWaiting.png");
            this.imageList1.Images.SetKeyName(1, "AppoimentStatusClosed.png");
            this.imageList1.Images.SetKeyName(2, "AppoimentStatusCanceled.png");
            this.imageList1.Images.SetKeyName(3, "AppoimentStatusCurrent.png");
            // 
            // frmShiftAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 524);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txSubject);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.txtProfesional);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnFindPatient);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.txtDEscription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShiftAppointment";
            this.Text = "Turnos";
            this.Activated += new System.EventHandler(this.MyAppointmentForm_Activated);
            this.Controls.SetChildIndex(this.txtDEscription, 0);
            this.Controls.SetChildIndex(this.dtEnd, 0);
            this.Controls.SetChildIndex(this.btnFindPatient, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.txtProfesional, 0);
            this.Controls.SetChildIndex(this.txtPatient, 0);
            this.Controls.SetChildIndex(this.txSubject, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfesional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEscription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEnd;
        private DevExpress.XtraEditors.TimeEdit timeStart;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblLabel;
        private DevExpress.XtraScheduler.UI.AppointmentLabelEdit edLabel;
        private DevExpress.XtraScheduler.UI.AppointmentStatusEdit edStatus;
        private DevExpress.XtraEditors.SimpleButton btnFindPatient;
        private DevExpress.XtraEditors.TextEdit txtPatient;
        private DevExpress.XtraEditors.TextEdit txtProfesional;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txSubject;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtDEscription;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ImageList imageList1;
    }
}