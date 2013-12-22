namespace Health.Front.Events
{
    partial class frmAddMedicament
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
            this.txtMedicamet = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkPermanent = new System.Windows.Forms.CheckBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblPatient = new DevExpress.XtraEditors.LabelControl();
            this.txtPresentation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDaysCount = new DevExpress.XtraEditors.SpinEdit();
            this.txtPeriodicity_hours = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmdbMeasures = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtDosis = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicamet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodicity_hours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdbMeasures.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 300);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(622, 28);
            this.aceptCancelButtonBar1.TabIndex = 10;
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // txtMedicamet
            // 
            this.txtMedicamet.EditValue = "";
            this.txtMedicamet.EnterMoveNextControl = true;
            this.txtMedicamet.Location = new System.Drawing.Point(210, 55);
            this.txtMedicamet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMedicamet.Name = "txtMedicamet";
            this.txtMedicamet.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtMedicamet.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtMedicamet.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMedicamet.Properties.Appearance.Options.UseBackColor = true;
            this.txtMedicamet.Properties.Appearance.Options.UseFont = true;
            this.txtMedicamet.Properties.Appearance.Options.UseForeColor = true;
            this.txtMedicamet.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtMedicamet.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtMedicamet.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMedicamet.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtMedicamet.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtMedicamet.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtMedicamet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMedicamet.Size = new System.Drawing.Size(333, 22);
            this.txtMedicamet.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Location = new System.Drawing.Point(71, 56);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 18);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Medicamento";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(74, 151);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 18);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Por";
            // 
            // chkPermanent
            // 
            this.chkPermanent.AutoSize = true;
            this.chkPermanent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPermanent.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.chkPermanent.ForeColor = System.Drawing.Color.DimGray;
            this.chkPermanent.Location = new System.Drawing.Point(302, 148);
            this.chkPermanent.Name = "chkPermanent";
            this.chkPermanent.Size = new System.Drawing.Size(193, 21);
            this.chkPermanent.TabIndex = 5;
            this.chkPermanent.Text = "Medicacion permanente";
            this.chkPermanent.UseVisualStyleBackColor = true;
            this.chkPermanent.CheckedChanged += new System.EventHandler(this.chkPermanent_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Location = new System.Drawing.Point(74, 240);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 18);
            this.labelControl3.TabIndex = 2038;
            this.labelControl3.Text = "Cada";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Location = new System.Drawing.Point(220, 237);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 18);
            this.labelControl4.TabIndex = 2040;
            this.labelControl4.Text = "horas";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl6.Location = new System.Drawing.Point(6, 16);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 18);
            this.labelControl6.TabIndex = 2042;
            this.labelControl6.Text = "Paciente";
            // 
            // lblPatient
            // 
            this.lblPatient.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblPatient.Location = new System.Drawing.Point(107, 16);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(0, 18);
            this.lblPatient.TabIndex = 2043;
            // 
            // txtPresentation
            // 
            this.txtPresentation.EditValue = "";
            this.txtPresentation.EnterMoveNextControl = true;
            this.txtPresentation.Location = new System.Drawing.Point(210, 94);
            this.txtPresentation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPresentation.Name = "txtPresentation";
            this.txtPresentation.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPresentation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPresentation.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPresentation.Properties.Appearance.Options.UseBackColor = true;
            this.txtPresentation.Properties.Appearance.Options.UseFont = true;
            this.txtPresentation.Properties.Appearance.Options.UseForeColor = true;
            this.txtPresentation.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtPresentation.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPresentation.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPresentation.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPresentation.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtPresentation.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPresentation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPresentation.Size = new System.Drawing.Size(333, 22);
            this.txtPresentation.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Location = new System.Drawing.Point(71, 97);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(99, 18);
            this.labelControl7.TabIndex = 2045;
            this.labelControl7.Text = "Presentación";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl5.Location = new System.Drawing.Point(223, 151);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 18);
            this.labelControl5.TabIndex = 2041;
            this.labelControl5.Text = "dìas";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl9.Location = new System.Drawing.Point(74, 199);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(44, 18);
            this.labelControl9.TabIndex = 2061;
            this.labelControl9.Text = "Dosis";
            // 
            // txtDaysCount
            // 
            this.txtDaysCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDaysCount.Location = new System.Drawing.Point(132, 150);
            this.txtDaysCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDaysCount.Name = "txtDaysCount";
            this.txtDaysCount.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDaysCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDaysCount.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDaysCount.Properties.Appearance.Options.UseBackColor = true;
            this.txtDaysCount.Properties.Appearance.Options.UseFont = true;
            this.txtDaysCount.Properties.Appearance.Options.UseForeColor = true;
            this.txtDaysCount.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtDaysCount.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDaysCount.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDaysCount.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDaysCount.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtDaysCount.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDaysCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDaysCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDaysCount.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDaysCount.Properties.Mask.EditMask = "d";
            this.txtDaysCount.Size = new System.Drawing.Size(70, 22);
            this.txtDaysCount.TabIndex = 2;
            // 
            // txtPeriodicity_hours
            // 
            this.txtPeriodicity_hours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPeriodicity_hours.Location = new System.Drawing.Point(132, 236);
            this.txtPeriodicity_hours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPeriodicity_hours.Name = "txtPeriodicity_hours";
            this.txtPeriodicity_hours.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPeriodicity_hours.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPeriodicity_hours.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPeriodicity_hours.Properties.Appearance.Options.UseBackColor = true;
            this.txtPeriodicity_hours.Properties.Appearance.Options.UseFont = true;
            this.txtPeriodicity_hours.Properties.Appearance.Options.UseForeColor = true;
            this.txtPeriodicity_hours.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtPeriodicity_hours.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtPeriodicity_hours.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPeriodicity_hours.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPeriodicity_hours.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtPeriodicity_hours.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtPeriodicity_hours.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPeriodicity_hours.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPeriodicity_hours.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtPeriodicity_hours.Properties.Mask.EditMask = "d";
            this.txtPeriodicity_hours.Size = new System.Drawing.Size(70, 22);
            this.txtPeriodicity_hours.TabIndex = 4;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl8.Location = new System.Drawing.Point(352, 201);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 18);
            this.labelControl8.TabIndex = 2062;
            this.labelControl8.Text = "x toma";
            // 
            // cmdbMeasures
            // 
            this.cmdbMeasures.EditValue = "";
            this.cmdbMeasures.Location = new System.Drawing.Point(220, 200);
            this.cmdbMeasures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdbMeasures.Name = "cmdbMeasures";
            this.cmdbMeasures.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmdbMeasures.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.cmdbMeasures.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdbMeasures.Properties.Appearance.Options.UseBackColor = true;
            this.cmdbMeasures.Properties.Appearance.Options.UseFont = true;
            this.cmdbMeasures.Properties.Appearance.Options.UseForeColor = true;
            this.cmdbMeasures.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.cmdbMeasures.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.cmdbMeasures.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdbMeasures.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmdbMeasures.Properties.AppearanceFocused.Options.UseFont = true;
            this.cmdbMeasures.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.cmdbMeasures.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cmdbMeasures.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdbMeasures.Properties.Items.AddRange(new object[] {
            "mgr.",
            "c.c.",
            "comp.",
            "gotas",
            "ampollas",
            "aplicación"});
            this.cmdbMeasures.Properties.PopupSizeable = true;
            this.cmdbMeasures.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmdbMeasures.Size = new System.Drawing.Size(123, 22);
            this.cmdbMeasures.TabIndex = 2063;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // txtDosis
            // 
            this.txtDosis.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDosis.Location = new System.Drawing.Point(132, 197);
            this.txtDosis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDosis.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDosis.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDosis.Properties.Appearance.Options.UseBackColor = true;
            this.txtDosis.Properties.Appearance.Options.UseFont = true;
            this.txtDosis.Properties.Appearance.Options.UseForeColor = true;
            this.txtDosis.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtDosis.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDosis.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDosis.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDosis.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtDosis.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDosis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDosis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDosis.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDosis.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtDosis.Size = new System.Drawing.Size(61, 22);
            this.txtDosis.TabIndex = 2067;
            // 
            // frmAddMedicament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 333);
            this.Controls.Add(this.txtDosis);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtPresentation);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.chkPermanent);
            this.Controls.Add(this.txtMedicamet);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtDaysCount);
            this.Controls.Add(this.txtPeriodicity_hours);
            this.Controls.Add(this.cmdbMeasures);
            this.Name = "frmAddMedicament";
            this.Text = "Medicamento resetado";
            this.Load += new System.EventHandler(this.frmAddMedicament_Load);
            this.Controls.SetChildIndex(this.cmdbMeasures, 0);
            this.Controls.SetChildIndex(this.txtPeriodicity_hours, 0);
            this.Controls.SetChildIndex(this.txtDaysCount, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.txtMedicamet, 0);
            this.Controls.SetChildIndex(this.chkPermanent, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.labelControl6, 0);
            this.Controls.SetChildIndex(this.lblPatient, 0);
            this.Controls.SetChildIndex(this.txtPresentation, 0);
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.labelControl9, 0);
            this.Controls.SetChildIndex(this.labelControl8, 0);
            this.Controls.SetChildIndex(this.txtDosis, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtMedicamet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodicity_hours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdbMeasures.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosis.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtMedicamet;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.CheckBox chkPermanent;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblPatient;
        private DevExpress.XtraEditors.TextEdit txtPresentation;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit txtDaysCount;
        private DevExpress.XtraEditors.SpinEdit txtPeriodicity_hours;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cmdbMeasures;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SpinEdit txtDosis;
    }
}