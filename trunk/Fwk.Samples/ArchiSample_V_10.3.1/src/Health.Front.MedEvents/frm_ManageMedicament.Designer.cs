namespace Health.Front.Events
{
    partial class frm_ManageMedicament
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
            this.colEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuitarMedicamento = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Medicaments = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_quitar = new System.Windows.Forms.ToolStripMenuItem();
            this.patientMedicamentViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_Medicaments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicamentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicamentPresentation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellidoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnAddMedicamento = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medicaments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientMedicamentViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medicaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 541);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(857, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // colEnabled
            // 
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            // 
            // btnQuitarMedicamento
            // 
            this.btnQuitarMedicamento.Image = global::Health.Front.Base.Properties.Resources.close_16;
            this.btnQuitarMedicamento.Location = new System.Drawing.Point(225, 44);
            this.btnQuitarMedicamento.Name = "btnQuitarMedicamento";
            this.btnQuitarMedicamento.Size = new System.Drawing.Size(151, 27);
            this.btnQuitarMedicamento.TabIndex = 2039;
            this.btnQuitarMedicamento.Text = "Quitar medicamento";
            this.btnQuitarMedicamento.Click += new System.EventHandler(this.btnQuitarMedicamento_Click);
            // 
            // gridControl_Medicaments
            // 
            this.gridControl_Medicaments.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl_Medicaments.DataSource = this.patientMedicamentViewListBindingSource;
            this.gridControl_Medicaments.Location = new System.Drawing.Point(12, 88);
            this.gridControl_Medicaments.MainView = this.gridView_Medicaments;
            this.gridControl_Medicaments.Name = "gridControl_Medicaments";
            this.gridControl_Medicaments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl_Medicaments.Size = new System.Drawing.Size(843, 465);
            this.gridControl_Medicaments.TabIndex = 2038;
            this.gridControl_Medicaments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Medicaments});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.m_quitar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 34);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // m_quitar
            // 
            this.m_quitar.Enabled = false;
            this.m_quitar.Image = global::Health.Front.Base.Properties.Resources.close_16;
            this.m_quitar.Name = "m_quitar";
            this.m_quitar.Size = new System.Drawing.Size(215, 24);
            this.m_quitar.Text = "Quitar Medicamento";
            // 
            // patientMedicamentViewListBindingSource
            // 
            this.patientMedicamentViewListBindingSource.DataSource = typeof(Health.BE.PatientMedicament_ViewList);
            // 
            // gridView_Medicaments
            // 
            this.gridView_Medicaments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView_Medicaments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCreatedDate,
            this.colStatusDescription,
            this.colMedicamentName,
            this.colMedicamentPresentation,
            this.colApellidoNombre,
            this.colEnabled});
            this.gridView_Medicaments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.SeaShell;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Brown;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colEnabled;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[Enabled]  == False";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[Status] == 660";
            this.gridView_Medicaments.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView_Medicaments.GridControl = this.gridControl_Medicaments;
            this.gridView_Medicaments.Name = "gridView_Medicaments";
            this.gridView_Medicaments.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Medicaments.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Medicaments.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView_Medicaments.OptionsBehavior.Editable = false;
            this.gridView_Medicaments.OptionsBehavior.ReadOnly = true;
            this.gridView_Medicaments.OptionsCustomization.AllowColumnMoving = false;
            this.gridView_Medicaments.OptionsCustomization.AllowColumnResizing = false;
            this.gridView_Medicaments.OptionsCustomization.AllowGroup = false;
            this.gridView_Medicaments.OptionsCustomization.AllowSort = false;
            this.gridView_Medicaments.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_Medicaments.OptionsView.ColumnAutoWidth = false;
            this.gridView_Medicaments.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView_Medicaments.OptionsView.ShowGroupPanel = false;
            this.gridView_Medicaments.OptionsView.ShowIndicator = false;
            this.gridView_Medicaments.OptionsView.ShowVertLines = false;
            this.gridView_Medicaments.RowHeight = 27;
            this.gridView_Medicaments.RowSeparatorHeight = 3;
            this.gridView_Medicaments.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.gridView_Medicaments.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView_Medicaments_MouseDown);
            this.gridView_Medicaments.DoubleClick += new System.EventHandler(this.gridView_Medicaments_DoubleClick);
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
            this.colStatusDescription.Caption = "Estado";
            this.colStatusDescription.FieldName = "StatusDescription";
            this.colStatusDescription.Name = "colStatusDescription";
            this.colStatusDescription.Visible = true;
            this.colStatusDescription.VisibleIndex = 3;
            // 
            // colMedicamentName
            // 
            this.colMedicamentName.Caption = "Nombre Med";
            this.colMedicamentName.FieldName = "MedicamentName";
            this.colMedicamentName.Name = "colMedicamentName";
            this.colMedicamentName.Visible = true;
            this.colMedicamentName.VisibleIndex = 1;
            this.colMedicamentName.Width = 140;
            // 
            // colMedicamentPresentation
            // 
            this.colMedicamentPresentation.Caption = "Presentación";
            this.colMedicamentPresentation.FieldName = "MedicamentPresentation";
            this.colMedicamentPresentation.Name = "colMedicamentPresentation";
            this.colMedicamentPresentation.Visible = true;
            this.colMedicamentPresentation.VisibleIndex = 2;
            this.colMedicamentPresentation.Width = 200;
            // 
            // colApellidoNombre
            // 
            this.colApellidoNombre.Caption = "Profesional";
            this.colApellidoNombre.FieldName = "ApellidoNombre";
            this.colApellidoNombre.Name = "colApellidoNombre";
            this.colApellidoNombre.OptionsColumn.AllowEdit = false;
            this.colApellidoNombre.Visible = true;
            this.colApellidoNombre.VisibleIndex = 4;
            this.colApellidoNombre.Width = 150;
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
            // btnAddMedicamento
            // 
            this.btnAddMedicamento.Image = global::Health.Front.Base.Properties.Resources.add;
            this.btnAddMedicamento.Location = new System.Drawing.Point(20, 44);
            this.btnAddMedicamento.Name = "btnAddMedicamento";
            this.btnAddMedicamento.Size = new System.Drawing.Size(181, 27);
            this.btnAddMedicamento.TabIndex = 2037;
            this.btnAddMedicamento.Text = "Agregar medicamento";
            this.btnAddMedicamento.Click += new System.EventHandler(this.btnAddMedicamento_Click);
            // 
            // frm_ManageMedicament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 574);
            this.Controls.Add(this.btnQuitarMedicamento);
            this.Controls.Add(this.gridControl_Medicaments);
            this.Controls.Add(this.btnAddMedicamento);
            this.Name = "frm_ManageMedicament";
            this.Text = "Gestionar medicamentos del paciente";
            this.Load += new System.EventHandler(this.frm_ManageMedicament_Load);
            this.Controls.SetChildIndex(this.btnAddMedicamento, 0);
            this.Controls.SetChildIndex(this.gridControl_Medicaments, 0);
            this.Controls.SetChildIndex(this.btnQuitarMedicamento, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medicaments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientMedicamentViewListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medicaments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnQuitarMedicamento;
        private DevExpress.XtraGrid.GridControl gridControl_Medicaments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Medicaments;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicamentName;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicamentPresentation;
        private DevExpress.XtraGrid.Columns.GridColumn colApellidoNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colEnabled;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.SimpleButton btnAddMedicamento;
        private System.Windows.Forms.BindingSource patientMedicamentViewListBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_quitar;
    }
}