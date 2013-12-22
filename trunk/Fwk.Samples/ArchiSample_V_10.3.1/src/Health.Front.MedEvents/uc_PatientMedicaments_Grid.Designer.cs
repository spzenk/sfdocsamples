namespace Health.Front.Patients
{
    partial class uc_PatientMedicaments_Grid
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
            this.gridControl_Medicaments = new DevExpress.XtraGrid.GridControl();
            this.patientMedicamentViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_Medicaments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMedicamentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellidoNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreTipoConsulta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreEspesialidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medicaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientMedicamentViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medicaments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(760, 41);
            this.lblTitle.Text = "Historial de medicación del paciente";
            // 
            // gridControl_Medicaments
            // 
            this.gridControl_Medicaments.DataSource = this.patientMedicamentViewListBindingSource;
            this.gridControl_Medicaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Medicaments.Location = new System.Drawing.Point(0, 41);
            this.gridControl_Medicaments.MainView = this.gridView_Medicaments;
            this.gridControl_Medicaments.Name = "gridControl_Medicaments";
            this.gridControl_Medicaments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl_Medicaments.Size = new System.Drawing.Size(760, 479);
            this.gridControl_Medicaments.TabIndex = 2036;
            this.gridControl_Medicaments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Medicaments});
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
            this.colInfo,
            this.colMedicamentName,
            this.colApellidoNombre,
            this.colNombreTipoConsulta,
            this.colNombreEspesialidad,
            this.colYear});
            this.gridView_Medicaments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView_Medicaments.GridControl = this.gridControl_Medicaments;
            this.gridView_Medicaments.GroupCount = 1;
            this.gridView_Medicaments.GroupFormat = "{0} {1} {2}";
            this.gridView_Medicaments.Name = "gridView_Medicaments";
            this.gridView_Medicaments.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Medicaments.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Medicaments.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_Medicaments.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView_Medicaments.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView_Medicaments.OptionsBehavior.Editable = false;
            this.gridView_Medicaments.OptionsBehavior.ReadOnly = true;
            this.gridView_Medicaments.OptionsCustomization.AllowFilter = false;
            this.gridView_Medicaments.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView_Medicaments.OptionsFilter.AllowFilterEditor = false;
            this.gridView_Medicaments.OptionsFind.ShowCloseButton = false;
            this.gridView_Medicaments.OptionsMenu.EnableColumnMenu = false;
            this.gridView_Medicaments.OptionsMenu.EnableFooterMenu = false;
            this.gridView_Medicaments.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView_Medicaments.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView_Medicaments.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView_Medicaments.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView_Medicaments.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView_Medicaments.OptionsView.ShowGroupPanel = false;
            this.gridView_Medicaments.OptionsView.ShowIndicator = false;
            this.gridView_Medicaments.OptionsView.ShowPreviewLines = false;
            this.gridView_Medicaments.OptionsView.ShowVertLines = false;
            this.gridView_Medicaments.RowHeight = 27;
            this.gridView_Medicaments.RowSeparatorHeight = 3;
            this.gridView_Medicaments.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.gridView_Medicaments.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_Medicaments.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_Medicaments_CustomUnboundColumnData);
            this.gridView_Medicaments.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView_Medicaments.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            // colInfo
            // 
            this.colInfo.Caption = "Info";
            this.colInfo.FieldName = "StatusDescription";
            this.colInfo.Name = "colInfo";
            this.colInfo.OptionsColumn.AllowEdit = false;
            this.colInfo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInfo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 2;
            this.colInfo.Width = 200;
            // 
            // colMedicamentName
            // 
            this.colMedicamentName.Caption = "Medicamento";
            this.colMedicamentName.FieldName = "MedicamentName";
            this.colMedicamentName.Name = "colMedicamentName";
            this.colMedicamentName.Visible = true;
            this.colMedicamentName.VisibleIndex = 1;
            this.colMedicamentName.Width = 200;
            // 
            // colApellidoNombre
            // 
            this.colApellidoNombre.Caption = "Profesional";
            this.colApellidoNombre.FieldName = "ApellidoNombre";
            this.colApellidoNombre.Name = "colApellidoNombre";
            this.colApellidoNombre.OptionsColumn.AllowEdit = false;
            this.colApellidoNombre.Visible = true;
            this.colApellidoNombre.VisibleIndex = 3;
            this.colApellidoNombre.Width = 150;
            // 
            // colNombreTipoConsulta
            // 
            this.colNombreTipoConsulta.FieldName = "NombreTipoConsulta";
            this.colNombreTipoConsulta.Name = "colNombreTipoConsulta";
            this.colNombreTipoConsulta.OptionsColumn.AllowEdit = false;
            this.colNombreTipoConsulta.OptionsColumn.AllowFocus = false;
            this.colNombreTipoConsulta.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colNombreTipoConsulta.OptionsColumn.ReadOnly = true;
            this.colNombreTipoConsulta.Visible = true;
            this.colNombreTipoConsulta.VisibleIndex = 4;
            this.colNombreTipoConsulta.Width = 110;
            // 
            // colNombreEspesialidad
            // 
            this.colNombreEspesialidad.FieldName = "NombreEspesialidad";
            this.colNombreEspesialidad.Name = "colNombreEspesialidad";
            this.colNombreEspesialidad.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colNombreEspesialidad.Visible = true;
            this.colNombreEspesialidad.VisibleIndex = 5;
            this.colNombreEspesialidad.Width = 213;
            // 
            // colYear
            // 
            this.colYear.Caption = "Año";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colYear.OptionsColumn.AllowSize = false;
            this.colYear.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colYear.OptionsColumn.ShowCaption = false;
            this.colYear.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 6;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Permanente", true, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Temporal", false, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            // 
            // uc_PatientMedicaments_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_Medicaments);
            this.Name = "uc_PatientMedicaments_Grid";
            this.Size = new System.Drawing.Size(760, 520);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.gridControl_Medicaments, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Medicaments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientMedicamentViewListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Medicaments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Medicaments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Medicaments;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicamentName;
        private DevExpress.XtraGrid.Columns.GridColumn colApellidoNombre;
        private System.Windows.Forms.BindingSource patientMedicamentViewListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreTipoConsulta;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreEspesialidad;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
    }
}
