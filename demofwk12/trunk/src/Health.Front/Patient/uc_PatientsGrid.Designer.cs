namespace Health.Front.Patients
{
    partial class uc_PatientsGrid
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.PatientBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdPersonas = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaNacimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcolNroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PatientBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(975, 41);
            this.lblTitle.Text = "Listado de pacientes";
            // 
            // PatientBEBindingSource
            // 
            this.PatientBEBindingSource.DataSource = typeof(Health.BE.PatientBE);
            // 
            // grdPersonas
            // 
            this.grdPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPersonas.ContextMenuStrip = this.contextMenuStrip1;
            this.grdPersonas.DataSource = this.PatientBEBindingSource;
            this.grdPersonas.Location = new System.Drawing.Point(0, 38);
            this.grdPersonas.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPersonas.MainView = this.gridView1;
            this.grdPersonas.Name = "grdPersonas";
            this.grdPersonas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdPersonas.Size = new System.Drawing.Size(975, 570);
            this.grdPersonas.TabIndex = 68;
            this.grdPersonas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDatosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 28);
            // 
            // verDatosToolStripMenuItem
            // 
            this.verDatosToolStripMenuItem.Image = global::Health.Front.Base.Properties.Resource.summary_zoom_48;
            this.verDatosToolStripMenuItem.Name = "verDatosToolStripMenuItem";
            this.verDatosToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.verDatosToolStripMenuItem.Text = "Ver datos";
            this.verDatosToolStripMenuItem.Click += new System.EventHandler(this.verDatosToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colApellido,
            this.colNombre,
            this.colNroDocumento,
            this.colFechaNacimiento,
            this.colcolNroDocumento});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[IsAuthorized] == False";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.grdPersonas;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gridView1.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.ClearFindOnClose = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewLines = false;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colApellido
            // 
            this.colApellido.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colApellido.AppearanceHeader.Options.UseFont = true;
            this.colApellido.Caption = "Apellido";
            this.colApellido.FieldName = "Persona.Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.OptionsColumn.AllowEdit = false;
            this.colApellido.OptionsColumn.ReadOnly = true;
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 0;
            // 
            // colNombre
            // 
            this.colNombre.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colNombre.AppearanceHeader.Options.UseFont = true;
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Persona.Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colNroDocumento
            // 
            this.colNroDocumento.Caption = "Nº Documento";
            this.colNroDocumento.FieldName = "Persona.NroDocumento";
            this.colNroDocumento.Name = "colNroDocumento";
            this.colNroDocumento.OptionsColumn.AllowEdit = false;
            this.colNroDocumento.OptionsColumn.ReadOnly = true;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colFechaNacimiento.AppearanceHeader.Options.UseFont = true;
            this.colFechaNacimiento.Caption = "Fecha Nacimiento";
            this.colFechaNacimiento.FieldName = "Persona.FechaNacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.OptionsColumn.AllowEdit = false;
            this.colFechaNacimiento.OptionsColumn.ReadOnly = true;
            this.colFechaNacimiento.Visible = true;
            this.colFechaNacimiento.VisibleIndex = 3;
            // 
            // colcolNroDocumento
            // 
            this.colcolNroDocumento.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colcolNroDocumento.AppearanceHeader.Options.UseFont = true;
            this.colcolNroDocumento.Caption = "Nro documento";
            this.colcolNroDocumento.FieldName = "Persona.NroDocumento";
            this.colcolNroDocumento.Name = "colcolNroDocumento";
            this.colcolNroDocumento.OptionsColumn.AllowEdit = false;
            this.colcolNroDocumento.OptionsColumn.ReadOnly = true;
            this.colcolNroDocumento.Visible = true;
            this.colcolNroDocumento.VisibleIndex = 2;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            serializableAppearanceObject1.Options.UseImage = true;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "Estado", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No activo", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Activo", true, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // uc_PatientsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdPersonas);
            this.Name = "uc_PatientsGrid";
            this.Size = new System.Drawing.Size(975, 608);
            this.Controls.SetChildIndex(this.grdPersonas, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PatientBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PatientBEBindingSource;
        private DevExpress.XtraGrid.GridControl grdPersonas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colNroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaNacimiento;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verDatosToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colcolNroDocumento;
    }
}
