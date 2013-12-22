namespace Health.Front.Scheduler
{
    partial class frmShiftAppointment
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.lblStatusValue = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.xtraTabControl_Patient = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMotivoConsulta = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtArancelMutual = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCoseguro = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkPresentaOrden = new DevExpress.XtraEditors.CheckEdit();
            this.cmbMutual = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNroAfiliado = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfesional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEscription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Patient)).BeginInit();
            this.xtraTabControl_Patient.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMotivoConsulta.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArancelMutual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoseguro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPresentaOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMutual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroAfiliado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 491);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(805, 28);
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
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.Location = new System.Drawing.Point(669, 65);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(153, 22);
            this.dtEnd.TabIndex = 18;
            this.dtEnd.Visible = false;
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
            // 
            // edLabel
            // 
            this.edLabel.Enabled = false;
            this.edLabel.Location = new System.Drawing.Point(430, 47);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(231, 22);
            this.edLabel.TabIndex = 27;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AppoimentStatusWaiting.png");
            this.imageList1.Images.SetKeyName(1, "AppoimentStatusClosed.png");
            this.imageList1.Images.SetKeyName(2, "AppoimentStatusCanceled.png");
            this.imageList1.Images.SetKeyName(3, "AppoimentStatusInAttention.png");
            // 
            // btnFindPatient
            // 
            this.btnFindPatient.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnFindPatient.Image = global::Health.Front.Properties.Resources.summary_zoom_32;
            this.btnFindPatient.Location = new System.Drawing.Point(385, 3);
            this.btnFindPatient.Name = "btnFindPatient";
            this.btnFindPatient.Size = new System.Drawing.Size(147, 37);
            this.btnFindPatient.TabIndex = 30;
            this.btnFindPatient.Text = "Buscar paciente";
            this.btnFindPatient.Click += new System.EventHandler(this.btnFindPatient_Click);
            // 
            // txtPatient
            // 
            this.txtPatient.EditValue = "";
            this.txtPatient.Enabled = false;
            this.txtPatient.EnterMoveNextControl = true;
            this.txtPatient.Location = new System.Drawing.Point(134, 10);
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
            this.txtPatient.Size = new System.Drawing.Size(242, 22);
            this.txtPatient.TabIndex = 33;
            // 
            // txtProfesional
            // 
            this.txtProfesional.EditValue = "";
            this.txtProfesional.Enabled = false;
            this.txtProfesional.EnterMoveNextControl = true;
            this.txtProfesional.Location = new System.Drawing.Point(115, 191);
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
            this.labelControl3.Location = new System.Drawing.Point(13, 192);
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
            this.labelControl4.Location = new System.Drawing.Point(11, 13);
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
            this.txSubject.Location = new System.Drawing.Point(134, 50);
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
            this.txSubject.Size = new System.Drawing.Size(538, 22);
            this.txSubject.TabIndex = 35;
            this.txSubject.EditValueChanged += new System.EventHandler(this.txSubject_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(11, 51);
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
            this.labelControl2.Size = new System.Drawing.Size(805, 54);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Turno medico";
            // 
            // txtDEscription
            // 
            this.txtDEscription.EditValue = "";
            this.txtDEscription.Location = new System.Drawing.Point(113, 145);
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
            this.labelControl5.Location = new System.Drawing.Point(11, 146);
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
            this.groupControl1.Controls.Add(this.lblStatusValue);
            this.groupControl1.Controls.Add(this.dtStart);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.timeStart);
            this.groupControl1.Controls.Add(this.timeEnd);
            this.groupControl1.Controls.Add(this.lblStart);
            this.groupControl1.Controls.Add(this.lblEnd);
            this.groupControl1.Controls.Add(this.lblStatus);
            this.groupControl1.Controls.Add(this.edLabel);
            this.groupControl1.Controls.Add(this.lblLabel);
            this.groupControl1.Location = new System.Drawing.Point(5, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(706, 127);
            this.groupControl1.TabIndex = 41;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatusValue.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusValue.Appearance.ImageList = this.imageList1;
            this.lblStatusValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusValue.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblStatusValue.Location = new System.Drawing.Point(430, 90);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(140, 23);
            this.lblStatusValue.TabIndex = 41;
            this.lblStatusValue.Text = "labelControl6";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // xtraTabControl_Patient
            // 
            this.xtraTabControl_Patient.Location = new System.Drawing.Point(20, 215);
            this.xtraTabControl_Patient.Name = "xtraTabControl_Patient";
            this.xtraTabControl_Patient.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl_Patient.Size = new System.Drawing.Size(766, 280);
            this.xtraTabControl_Patient.TabIndex = 42;
            this.xtraTabControl_Patient.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Controls.Add(this.cmbMotivoConsulta);
            this.xtraTabPage1.Controls.Add(this.txtPatient);
            this.xtraTabPage1.Controls.Add(this.txtDEscription);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.txSubject);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.btnFindPatient);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(760, 251);
            this.xtraTabPage1.Text = "Reserva";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl10.Location = new System.Drawing.Point(12, 91);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(101, 18);
            this.labelControl10.TabIndex = 2029;
            this.labelControl10.Text = "Tipo Consulta";
            this.labelControl10.Visible = false;
            // 
            // cmbMotivoConsulta
            // 
            this.cmbMotivoConsulta.Location = new System.Drawing.Point(137, 90);
            this.cmbMotivoConsulta.Name = "cmbMotivoConsulta";
            this.cmbMotivoConsulta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMotivoConsulta.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbMotivoConsulta.Properties.DisplayMember = "Nombre";
            this.cmbMotivoConsulta.Properties.NullText = "Seleccione una opción";
            this.cmbMotivoConsulta.Properties.ValueMember = "IdParametro";
            this.cmbMotivoConsulta.Size = new System.Drawing.Size(239, 22);
            this.cmbMotivoConsulta.TabIndex = 2028;
            this.cmbMotivoConsulta.Visible = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labelControl9);
            this.xtraTabPage2.Controls.Add(this.txtArancelMutual);
            this.xtraTabPage2.Controls.Add(this.labelControl8);
            this.xtraTabPage2.Controls.Add(this.txtCoseguro);
            this.xtraTabPage2.Controls.Add(this.groupControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(760, 251);
            this.xtraTabPage2.Text = "Cierre";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Sienna;
            this.labelControl9.Location = new System.Drawing.Point(251, 190);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(112, 18);
            this.labelControl9.TabIndex = 2037;
            this.labelControl9.Text = "Arancel Mutual";
            // 
            // txtArancelMutual
            // 
            this.txtArancelMutual.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtArancelMutual.Location = new System.Drawing.Point(369, 182);
            this.txtArancelMutual.Name = "txtArancelMutual";
            this.txtArancelMutual.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtArancelMutual.Properties.Appearance.Options.UseFont = true;
            this.txtArancelMutual.Properties.Mask.EditMask = "c";
            this.txtArancelMutual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtArancelMutual.Size = new System.Drawing.Size(106, 31);
            this.txtArancelMutual.TabIndex = 2036;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Sienna;
            this.labelControl8.Location = new System.Drawing.Point(23, 190);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(76, 18);
            this.labelControl8.TabIndex = 2035;
            this.labelControl8.Text = "Co-seguro";
            // 
            // txtCoseguro
            // 
            this.txtCoseguro.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCoseguro.Location = new System.Drawing.Point(115, 182);
            this.txtCoseguro.Name = "txtCoseguro";
            this.txtCoseguro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCoseguro.Properties.Appearance.Options.UseFont = true;
            this.txtCoseguro.Properties.Mask.EditMask = "c";
            this.txtCoseguro.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCoseguro.Size = new System.Drawing.Size(106, 31);
            this.txtCoseguro.TabIndex = 2034;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.chkPresentaOrden);
            this.groupControl2.Controls.Add(this.cmbMutual);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.txtNroAfiliado);
            this.groupControl2.Location = new System.Drawing.Point(19, 19);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(632, 137);
            this.groupControl2.TabIndex = 2026;
            this.groupControl2.Text = "Obra social";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl6.Location = new System.Drawing.Point(14, 79);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(90, 18);
            this.labelControl6.TabIndex = 2015;
            this.labelControl6.Text = "Nro Afiliado";
            // 
            // chkPresentaOrden
            // 
            this.chkPresentaOrden.Location = new System.Drawing.Point(396, 36);
            this.chkPresentaOrden.Name = "chkPresentaOrden";
            this.chkPresentaOrden.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkPresentaOrden.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.chkPresentaOrden.Properties.Appearance.Options.UseFont = true;
            this.chkPresentaOrden.Properties.Appearance.Options.UseForeColor = true;
            this.chkPresentaOrden.Properties.Caption = "Presenta orden";
            this.chkPresentaOrden.Size = new System.Drawing.Size(179, 23);
            this.chkPresentaOrden.TabIndex = 2024;
            // 
            // cmbMutual
            // 
            this.cmbMutual.Location = new System.Drawing.Point(136, 40);
            this.cmbMutual.Name = "cmbMutual";
            this.cmbMutual.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMutual.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExigeCoseguro", "ExigeCoseguro", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cmbMutual.Properties.DisplayMember = "NombreMutual";
            this.cmbMutual.Properties.NullText = "Seleccione una opción";
            this.cmbMutual.Properties.ValueMember = "IdMutual";
            this.cmbMutual.Size = new System.Drawing.Size(239, 22);
            this.cmbMutual.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Location = new System.Drawing.Point(16, 41);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(51, 18);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Mutual";
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Location = new System.Drawing.Point(136, 78);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(239, 22);
            this.txtNroAfiliado.TabIndex = 5;
            // 
            // frmShiftAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 524);
            this.Controls.Add(this.xtraTabControl_Patient);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtProfesional);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.labelControl3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShiftAppointment";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmShiftAppointment_Load);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.dtEnd, 0);
            this.Controls.SetChildIndex(this.txtProfesional, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.xtraTabControl_Patient, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPatient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfesional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDEscription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_Patient)).EndInit();
            this.xtraTabControl_Patient.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMotivoConsulta.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArancelMutual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoseguro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPresentaOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMutual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroAfiliado.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblStatusValue;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_Patient;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtArancelMutual;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtCoseguro;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chkPresentaOrden;
        private DevExpress.XtraEditors.LookUpEdit cmbMutual;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtNroAfiliado;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LookUpEdit cmbMotivoConsulta;
    }
}