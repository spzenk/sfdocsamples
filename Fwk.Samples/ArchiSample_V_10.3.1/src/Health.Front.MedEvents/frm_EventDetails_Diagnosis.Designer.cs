namespace Health.Front.Events
{
    partial class frm_EventDetails_Diagnosis
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EventDetails_Diagnosis));
            this.cmbAlertDiagnosis = new DevExpress.XtraEditors.LookUpEdit();
            this.parametroBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cEI10ComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCEI10 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_Details = new DevExpress.XtraGrid.GridControl();
            this.medicalEventDetailViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_Details = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicamentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellidoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservación = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnQuitarDiag = new DevExpress.XtraEditors.SimpleButton();
            this.colColEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlertDiagnosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametroBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEI10ComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCEI10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventDetailViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservación.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 454);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(839, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // cmbAlertDiagnosis
            // 
            this.cmbAlertDiagnosis.EnterMoveNextControl = true;
            this.cmbAlertDiagnosis.Location = new System.Drawing.Point(113, 88);
            this.cmbAlertDiagnosis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAlertDiagnosis.Name = "cmbAlertDiagnosis";
            this.cmbAlertDiagnosis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cmbAlertDiagnosis.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbAlertDiagnosis.Properties.Appearance.Options.UseBackColor = true;
            this.cmbAlertDiagnosis.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.cmbAlertDiagnosis.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cmbAlertDiagnosis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAlertDiagnosis.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbAlertDiagnosis.Properties.DataSource = this.parametroBEBindingSource;
            this.cmbAlertDiagnosis.Properties.DisplayMember = "Nombre";
            this.cmbAlertDiagnosis.Properties.NullText = "Seleccione una opcion";
            this.cmbAlertDiagnosis.Properties.ValueMember = "IdParametro";
            this.cmbAlertDiagnosis.Size = new System.Drawing.Size(209, 22);
            this.cmbAlertDiagnosis.TabIndex = 2044;
            // 
            // parametroBEBindingSource
            // 
            this.parametroBEBindingSource.DataSource = typeof(Health.BE.ParametroBE);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Location = new System.Drawing.Point(5, 39);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 18);
            this.labelControl3.TabIndex = 2045;
            this.labelControl3.Text = "Diagnostico";
            // 
            // cEI10ComboBindingSource
            // 
            this.cEI10ComboBindingSource.DataSource = typeof(Health.BE.CEI10Combo);
            // 
            // txtCEI10
            // 
            this.txtCEI10.EditValue = "";
            this.txtCEI10.Location = new System.Drawing.Point(113, 26);
            this.txtCEI10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCEI10.Name = "txtCEI10";
            this.txtCEI10.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtCEI10.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCEI10.Properties.Appearance.Options.UseBackColor = true;
            this.txtCEI10.Properties.Appearance.Options.UseForeColor = true;
            this.txtCEI10.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtCEI10.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtCEI10.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCEI10.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCEI10.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtCEI10.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtCEI10.Properties.AutoHeight = false;
            this.txtCEI10.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCEI10.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCEI10.Properties.DataSource = this.cEI10ComboBindingSource;
            this.txtCEI10.Properties.DisplayMember = "Description";
            this.txtCEI10.Properties.NullText = "";
            this.txtCEI10.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtCEI10.Properties.ShowFooter = false;
            this.txtCEI10.Properties.ValueMember = "Code";
            this.txtCEI10.Properties.View = this.searchLookUpEdit1View;
            this.txtCEI10.Size = new System.Drawing.Size(688, 47);
            this.txtCEI10.TabIndex = 2046;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colDescription});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 334;
            // 
            // gridControl_Details
            // 
            this.gridControl_Details.DataSource = this.medicalEventDetailViewListBindingSource;
            this.gridControl_Details.Location = new System.Drawing.Point(11, 261);
            this.gridControl_Details.MainView = this.gridView_Details;
            this.gridControl_Details.Name = "gridControl_Details";
            this.gridControl_Details.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl_Details.Size = new System.Drawing.Size(817, 189);
            this.gridControl_Details.TabIndex = 2047;
            this.gridControl_Details.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Details});
            // 
            // medicalEventDetailViewListBindingSource
            // 
            this.medicalEventDetailViewListBindingSource.DataSource = typeof(Health.BE.MedicalEventDetail_ViewList);
            // 
            // gridView_Details
            // 
            this.gridView_Details.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView_Details.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedDate,
            this.colStatusDescription,
            this.colMedicamentName,
            this.colApellidoNombre,
            this.colColEnabled});
            this.gridView_Details.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.SeaShell;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Brown;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[Enabled]  == False";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[Status] == 660";
            this.gridView_Details.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView_Details.GridControl = this.gridControl_Details;
            this.gridView_Details.Name = "gridView_Details";
            this.gridView_Details.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Details.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Details.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Details.OptionsBehavior.Editable = false;
            this.gridView_Details.OptionsBehavior.ReadOnly = true;
            this.gridView_Details.OptionsCustomization.AllowColumnMoving = false;
            this.gridView_Details.OptionsCustomization.AllowColumnResizing = false;
            this.gridView_Details.OptionsCustomization.AllowGroup = false;
            this.gridView_Details.OptionsCustomization.AllowSort = false;
            this.gridView_Details.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_Details.OptionsView.ColumnAutoWidth = false;
            this.gridView_Details.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView_Details.OptionsView.ShowGroupPanel = false;
            this.gridView_Details.OptionsView.ShowIndicator = false;
            this.gridView_Details.OptionsView.ShowVertLines = false;
            this.gridView_Details.RowHeight = 27;
            this.gridView_Details.RowSeparatorHeight = 3;
            this.gridView_Details.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.gridView_Details.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_Details_MouseDown);
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Fecha";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 0;
            // 
            // colStatusDescription
            // 
            this.colStatusDescription.Caption = "Relevancia";
            this.colStatusDescription.FieldName = "RelevanceTypeName";
            this.colStatusDescription.Name = "colStatusDescription";
            this.colStatusDescription.Visible = true;
            this.colStatusDescription.VisibleIndex = 2;
            this.colStatusDescription.Width = 100;
            // 
            // colMedicamentName
            // 
            this.colMedicamentName.Caption = "Descripción";
            this.colMedicamentName.FieldName = "Desc";
            this.colMedicamentName.Name = "colMedicamentName";
            this.colMedicamentName.Visible = true;
            this.colMedicamentName.VisibleIndex = 1;
            this.colMedicamentName.Width = 440;
            // 
            // colApellidoNombre
            // 
            this.colApellidoNombre.Caption = "Profesional";
            this.colApellidoNombre.FieldName = "Profesional";
            this.colApellidoNombre.Name = "colApellidoNombre";
            this.colApellidoNombre.OptionsColumn.AllowEdit = false;
            this.colApellidoNombre.Visible = true;
            this.colApellidoNombre.VisibleIndex = 3;
            this.colApellidoNombre.Width = 200;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Permanente", true, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupControl1.Appearance.BorderColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtObservación);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtCEI10);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cmbAlertDiagnosis);
            this.groupControl1.Location = new System.Drawing.Point(6, 8);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(822, 199);
            this.groupControl1.TabIndex = 2048;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Location = new System.Drawing.Point(5, 143);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 18);
            this.labelControl2.TabIndex = 2049;
            this.labelControl2.Text = "Observación";
            // 
            // txtObservación
            // 
            this.txtObservación.EditValue = "";
            this.txtObservación.Location = new System.Drawing.Point(113, 124);
            this.txtObservación.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservación.Name = "txtObservación";
            this.txtObservación.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtObservación.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservación.Properties.Appearance.Options.UseBackColor = true;
            this.txtObservación.Properties.Appearance.Options.UseForeColor = true;
            this.txtObservación.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtObservación.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtObservación.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservación.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtObservación.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtObservación.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtObservación.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtObservación.Size = new System.Drawing.Size(688, 59);
            this.txtObservación.TabIndex = 2048;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(5, 89);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 18);
            this.labelControl1.TabIndex = 2047;
            this.labelControl1.Text = "importancia";
            // 
            // btnQuitarDiag
            // 
            this.btnQuitarDiag.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarDiag.Image")));
            this.btnQuitarDiag.Location = new System.Drawing.Point(11, 230);
            this.btnQuitarDiag.Name = "btnQuitarDiag";
            this.btnQuitarDiag.Size = new System.Drawing.Size(151, 25);
            this.btnQuitarDiag.TabIndex = 2049;
            this.btnQuitarDiag.Text = "Quitar diagnóstico";
            this.btnQuitarDiag.Click += new System.EventHandler(this.btnQuitarDiag_Click);
            // 
            // colColEnabled
            // 
            this.colColEnabled.FieldName = "ColEnabled";
            this.colColEnabled.Name = "colColEnabled";
            // 
            // frm_EventDetails_Diagnosis
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 487);
            this.Controls.Add(this.btnQuitarDiag);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl_Details);
            this.Name = "frm_EventDetails_Diagnosis";
            this.Text = "Diagnóstico";
            this.Load += new System.EventHandler(this.frm_EventDetails_Load);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.gridControl_Details, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.btnQuitarDiag, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlertDiagnosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametroBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cEI10ComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCEI10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventDetailViewListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservación.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cmbAlertDiagnosis;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.BindingSource parametroBEBindingSource;
        private System.Windows.Forms.BindingSource cEI10ComboBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit txtCEI10;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.GridControl gridControl_Details;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Details;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicamentName;
        private DevExpress.XtraGrid.Columns.GridColumn colApellidoNombre;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtObservación;
        private System.Windows.Forms.BindingSource medicalEventDetailViewListBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnQuitarDiag;
        private DevExpress.XtraGrid.Columns.GridColumn colColEnabled;
    }
}