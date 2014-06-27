namespace Health.Front.Personas
{
    partial class uc_PatientCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rndSexoM = new System.Windows.Forms.RadioButton();
            this.rndSexoF = new System.Windows.Forms.RadioButton();
            this.dtFechaNac = new DevExpress.XtraEditors.DateEdit();
            this.cmbTipoDoc = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaNac.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaNac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "";
            this.lblTitle.Visible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Health.Front.Properties.Resources.User_M;
            this.pictureEdit1.Enabled = false;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 2);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(120, 103);
            this.pictureEdit1.TabIndex = 22;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Location = new System.Drawing.Point(209, 26);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 18);
            this.labelControl2.TabIndex = 26;
            this.labelControl2.Text = "Patient:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(209, 110);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 18);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Fecha nacimiento";
            // 
            // rndSexoM
            // 
            this.rndSexoM.AutoSize = true;
            this.rndSexoM.Checked = true;
            this.rndSexoM.Enabled = false;
            this.rndSexoM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndSexoM.ForeColor = System.Drawing.Color.DimGray;
            this.rndSexoM.Location = new System.Drawing.Point(5, 109);
            this.rndSexoM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rndSexoM.Name = "rndSexoM";
            this.rndSexoM.Size = new System.Drawing.Size(89, 22);
            this.rndSexoM.TabIndex = 29;
            this.rndSexoM.TabStop = true;
            this.rndSexoM.Text = "Hombre";
            this.rndSexoM.UseVisualStyleBackColor = true;
            // 
            // rndSexoF
            // 
            this.rndSexoF.AutoSize = true;
            this.rndSexoF.Enabled = false;
            this.rndSexoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndSexoF.ForeColor = System.Drawing.Color.DimGray;
            this.rndSexoF.Location = new System.Drawing.Point(103, 109);
            this.rndSexoF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rndSexoF.Name = "rndSexoF";
            this.rndSexoF.Size = new System.Drawing.Size(71, 22);
            this.rndSexoF.TabIndex = 30;
            this.rndSexoF.Text = "Mujer";
            this.rndSexoF.UseVisualStyleBackColor = true;
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.EditValue = null;
            this.dtFechaNac.Enabled = false;
            this.dtFechaNac.EnterMoveNextControl = true;
            this.dtFechaNac.Location = new System.Drawing.Point(350, 106);
            this.dtFechaNac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaNac.Name = "dtFechaNac";
            this.dtFechaNac.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.dtFechaNac.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtFechaNac.Properties.Appearance.Options.UseBackColor = true;
            this.dtFechaNac.Properties.Appearance.Options.UseForeColor = true;
            this.dtFechaNac.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.dtFechaNac.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtFechaNac.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtFechaNac.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.dtFechaNac.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaNac.Properties.MaxValue = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            this.dtFechaNac.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFechaNac.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtFechaNac.Size = new System.Drawing.Size(196, 22);
            this.dtFechaNac.TabIndex = 31;
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.Enabled = false;
            this.cmbTipoDoc.EnterMoveNextControl = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(347, 57);
            this.cmbTipoDoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbTipoDoc.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbTipoDoc.Properties.Appearance.Options.UseBackColor = true;
            this.cmbTipoDoc.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.cmbTipoDoc.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbTipoDoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoDoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbTipoDoc.Properties.DisplayMember = "Nombre";
            this.cmbTipoDoc.Properties.NullText = "Seleccione una opcion";
            this.cmbTipoDoc.Properties.ValueMember = "IdParametro";
            this.cmbTipoDoc.Size = new System.Drawing.Size(60, 22);
            this.cmbTipoDoc.TabIndex = 2034;
            // 
            // txtDocumento
            // 
            this.txtDocumento.EditValue = "";
            this.txtDocumento.Enabled = false;
            this.txtDocumento.EnterMoveNextControl = true;
            this.txtDocumento.Location = new System.Drawing.Point(424, 57);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDocumento.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtDocumento.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDocumento.Properties.Appearance.Options.UseBackColor = true;
            this.txtDocumento.Properties.Appearance.Options.UseFont = true;
            this.txtDocumento.Properties.Appearance.Options.UseForeColor = true;
            this.txtDocumento.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtDocumento.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDocumento.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtDocumento.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtDocumento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDocumento.Properties.Mask.BeepOnError = true;
            this.txtDocumento.Properties.Mask.EditMask = "f0";
            this.txtDocumento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDocumento.Properties.MaxLength = 8;
            this.txtDocumento.Size = new System.Drawing.Size(154, 22);
            this.txtDocumento.TabIndex = 2033;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Location = new System.Drawing.Point(209, 58);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 18);
            this.labelControl4.TabIndex = 2032;
            this.labelControl4.Text = "Documento";
            // 
            // txtNombres
            // 
            this.txtNombres.EditValue = "";
            this.txtNombres.Enabled = false;
            this.txtNombres.EnterMoveNextControl = true;
            this.txtNombres.Location = new System.Drawing.Point(347, 22);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNombres.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtNombres.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombres.Properties.Appearance.Options.UseBackColor = true;
            this.txtNombres.Properties.Appearance.Options.UseFont = true;
            this.txtNombres.Properties.Appearance.Options.UseForeColor = true;
            this.txtNombres.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNombres.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtNombres.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombres.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNombres.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtNombres.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtNombres.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtNombres.Size = new System.Drawing.Size(230, 22);
            this.txtNombres.TabIndex = 2035;
            // 
            // uc_PatientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.cmbTipoDoc);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dtFechaNac);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.rndSexoM);
            this.Controls.Add(this.rndSexoF);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "uc_PatientCard";
            this.Size = new System.Drawing.Size(733, 144);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.rndSexoF, 0);
            this.Controls.SetChildIndex(this.rndSexoM, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.dtFechaNac, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.cmbTipoDoc, 0);
            this.Controls.SetChildIndex(this.txtNombres, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaNac.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaNac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton rndSexoM;
        private System.Windows.Forms.RadioButton rndSexoF;
        private DevExpress.XtraEditors.DateEdit dtFechaNac;
        private DevExpress.XtraEditors.LookUpEdit cmbTipoDoc;
        private DevExpress.XtraEditors.TextEdit txtDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNombres;
    }
}
