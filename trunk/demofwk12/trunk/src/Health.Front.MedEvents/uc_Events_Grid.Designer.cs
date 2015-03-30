namespace Health.Front.Events
{
    partial class uc_Events_Grid
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
            this.medicalEventViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colMedicalEventId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiagnosis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colProfesional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoOEspesialidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.uc_docprontviewer_11 = new Health.Front.Events.uc_docprontviewer_1();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(1289, 41);
            this.lblTitle.Text = "Listado de atenciones del paciente";
            // 
            // medicalEventViewListBindingSource
            // 
            this.medicalEventViewListBindingSource.DataSource = typeof(Health.BE.MedicalEvent_ViewList);
            // 
            // colMedicalEventId
            // 
            this.colMedicalEventId.FieldName = "MedicalEventId";
            this.colMedicalEventId.Name = "colMedicalEventId";
            this.colMedicalEventId.Visible = true;
            this.colMedicalEventId.VisibleIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uc_docprontviewer_11);
            this.splitContainer1.Size = new System.Drawing.Size(1289, 581);
            this.splitContainer1.SplitterDistance = 582;
            this.splitContainer1.TabIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.medicalEventViewListBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(575, 575);
            this.gridControl1.TabIndex = 7;
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
            this.colDiagnosis,
            this.colProfesional,
            this.colMotivoOEspesialidad});
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
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colYear
            // 
            this.colYear.Caption = "Año";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Mes";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
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
            this.colCreatedDate.Width = 150;
            // 
            // colDiagnosis
            // 
            this.colDiagnosis.AppearanceCell.Options.UseTextOptions = true;
            this.colDiagnosis.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiagnosis.Caption = "Diagnóstico";
            this.colDiagnosis.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDiagnosis.FieldName = "Diagnosis";
            this.colDiagnosis.Name = "colDiagnosis";
            this.colDiagnosis.OptionsColumn.AllowEdit = false;
            this.colDiagnosis.OptionsColumn.AllowMove = false;
            this.colDiagnosis.OptionsColumn.ReadOnly = true;
            this.colDiagnosis.Visible = true;
            this.colDiagnosis.VisibleIndex = 2;
            this.colDiagnosis.Width = 113;
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
            this.colProfesional.Width = 42;
            // 
            // colMotivoOEspesialidad
            // 
            this.colMotivoOEspesialidad.Caption = "Espesialidad";
            this.colMotivoOEspesialidad.FieldName = "colMotivoOEspesialidad";
            this.colMotivoOEspesialidad.Name = "colMotivoOEspesialidad";
            this.colMotivoOEspesialidad.OptionsColumn.AllowEdit = false;
            this.colMotivoOEspesialidad.OptionsColumn.AllowMove = false;
            this.colMotivoOEspesialidad.OptionsColumn.AllowSize = false;
            this.colMotivoOEspesialidad.OptionsColumn.ReadOnly = true;
            this.colMotivoOEspesialidad.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMotivoOEspesialidad.Visible = true;
            this.colMotivoOEspesialidad.VisibleIndex = 1;
            this.colMotivoOEspesialidad.Width = 100;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // uc_docprontviewer_11
            // 
            this.uc_docprontviewer_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_docprontviewer_11.Location = new System.Drawing.Point(0, 0);
            this.uc_docprontviewer_11.Name = "uc_docprontviewer_11";
            this.uc_docprontviewer_11.Size = new System.Drawing.Size(703, 581);
            this.uc_docprontviewer_11.TabIndex = 0;
            // 
            // uc_Events_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uc_Events_Grid";
            this.Size = new System.Drawing.Size(1289, 622);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventViewListBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource medicalEventViewListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMedicalEventId;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDiagnosis;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProfesional;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoOEspesialidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private uc_docprontviewer_1 uc_docprontviewer_11;
        
    }
}
