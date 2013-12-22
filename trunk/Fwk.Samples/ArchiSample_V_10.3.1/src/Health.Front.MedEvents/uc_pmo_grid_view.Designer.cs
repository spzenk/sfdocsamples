namespace Health.Front.Events
{
    partial class uc_pmo_grid_view
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colProfesional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.medicalEventPMODiagListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventPMODiagListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(814, 41);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.medicalEventPMODiagListBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(811, 648);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colYear,
            this.colMonth,
            this.colCreatedDate,
            this.colValue,
            this.colProfesional,
            this.colMotivo,
            this.colRazonSocial});
            this.gridView1.DetailVerticalIndent = 5;
            this.gridView1.FixedLineWidth = 1;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FechaPlaneada_Alterada]== 1";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupFormat = "[#image]{1} {2}";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsDetail.SmartDetailHeight = true;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            this.gridView1.RowHeight = 40;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCreatedDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colYear
            // 
            this.colYear.Caption = "Año";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.OptionsColumn.ReadOnly = true;
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Mes";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.OptionsColumn.ReadOnly = true;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Fecha atención";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.MaxWidth = 150;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.OptionsColumn.AllowMove = false;
            this.colCreatedDate.OptionsColumn.AllowSize = false;
            this.colCreatedDate.OptionsColumn.ReadOnly = true;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 0;
            this.colCreatedDate.Width = 192;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colProfesional
            // 
            this.colProfesional.FieldName = "Profesional";
            this.colProfesional.MaxWidth = 200;
            this.colProfesional.Name = "colProfesional";
            this.colProfesional.OptionsColumn.AllowEdit = false;
            this.colProfesional.OptionsColumn.AllowMove = false;
            this.colProfesional.OptionsColumn.AllowSize = false;
            this.colProfesional.OptionsColumn.ReadOnly = true;
            this.colProfesional.Visible = true;
            this.colProfesional.VisibleIndex = 3;
            this.colProfesional.Width = 80;
            // 
            // colMotivo
            // 
            this.colMotivo.Caption = "Motivo";
            this.colMotivo.FieldName = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.OptionsColumn.AllowEdit = false;
            this.colMotivo.OptionsColumn.AllowMove = false;
            this.colMotivo.OptionsColumn.AllowSize = false;
            this.colMotivo.OptionsColumn.ReadOnly = true;
            this.colMotivo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMotivo.Visible = true;
            this.colMotivo.VisibleIndex = 1;
            this.colMotivo.Width = 183;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // medicalEventPMODiagListBindingSource
            // 
            this.medicalEventPMODiagListBindingSource.DataSource = typeof(Health.BE.MedicalEventPMO_Diag_List);
            // 
            // colValue
            // 
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.OptionsColumn.ReadOnly = true;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 2;
            this.colValue.Width = 200;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.OptionsColumn.AllowEdit = false;
            this.colRazonSocial.OptionsColumn.ReadOnly = true;
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 4;
            this.colRazonSocial.Width = 100;
            // 
            // uc_pmo_grid_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "uc_pmo_grid_view";
            this.Size = new System.Drawing.Size(814, 699);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventPMODiagListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProfesional;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.BindingSource medicalEventPMODiagListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
    }
}
