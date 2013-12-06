namespace Health.Front.Patients
{
    partial class uc_Vacunas
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
            this.colFechaPlaneada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.planVacunacionFullViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGrupoVacuna = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreVacuna = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaColocación = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colNombreProfesionalQueColoco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planVacunacionFullViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(1204, 41);
            this.lblTitle.Text = "Plan de vacunacion";
            // 
            // colFechaPlaneada
            // 
            this.colFechaPlaneada.AppearanceCell.BackColor = System.Drawing.Color.OldLace;
            this.colFechaPlaneada.AppearanceCell.Options.UseBackColor = true;
            this.colFechaPlaneada.FieldName = "FechaPlaneada";
            this.colFechaPlaneada.Name = "colFechaPlaneada";
            this.colFechaPlaneada.OptionsColumn.AllowEdit = false;
            this.colFechaPlaneada.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFechaPlaneada.OptionsColumn.AllowMove = false;
            this.colFechaPlaneada.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFechaPlaneada.OptionsColumn.ReadOnly = true;
            this.colFechaPlaneada.Visible = true;
            this.colFechaPlaneada.VisibleIndex = 2;
            this.colFechaPlaneada.Width = 205;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.planVacunacionFullViewListBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(3, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemMemoEdit1,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1182, 592);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // planVacunacionFullViewListBindingSource
            // 
            this.planVacunacionFullViewListBindingSource.DataSource = typeof(Health.BE.PlanVacunacion_FullViewList);
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
            this.colGrupoVacuna,
            this.colNombreVacuna,
            this.colFechaPlaneada,
            this.colFechaColocación,
            this.gridColumn1,
            this.colNombreProfesionalQueColoco});
            this.gridView1.DetailVerticalIndent = 5;
            this.gridView1.FixedLineWidth = 1;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.Column = this.colFechaPlaneada;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FechaPlaneada_Alterada]== 1";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupFormat = "[#image]{1} {2}";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsDetail.SmartDetailHeight = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            this.gridView1.RowHeight = 50;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // colGrupoVacuna
            // 
            this.colGrupoVacuna.AppearanceCell.BackColor = System.Drawing.Color.OldLace;
            this.colGrupoVacuna.AppearanceCell.Options.UseBackColor = true;
            this.colGrupoVacuna.Caption = "Agrupación";
            this.colGrupoVacuna.FieldName = "Grupo";
            this.colGrupoVacuna.Name = "colGrupoVacuna";
            this.colGrupoVacuna.OptionsColumn.AllowEdit = false;
            this.colGrupoVacuna.OptionsColumn.AllowMove = false;
            this.colGrupoVacuna.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGrupoVacuna.OptionsColumn.ReadOnly = true;
            this.colGrupoVacuna.Visible = true;
            this.colGrupoVacuna.VisibleIndex = 0;
            // 
            // colNombreVacuna
            // 
            this.colNombreVacuna.AppearanceCell.BackColor = System.Drawing.Color.OldLace;
            this.colNombreVacuna.AppearanceCell.Options.UseBackColor = true;
            this.colNombreVacuna.FieldName = "Nombre";
            this.colNombreVacuna.Name = "colNombreVacuna";
            this.colNombreVacuna.OptionsColumn.AllowEdit = false;
            this.colNombreVacuna.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreVacuna.OptionsColumn.AllowMove = false;
            this.colNombreVacuna.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreVacuna.OptionsColumn.ReadOnly = true;
            this.colNombreVacuna.Visible = true;
            this.colNombreVacuna.VisibleIndex = 1;
            this.colNombreVacuna.Width = 275;
            // 
            // colFechaColocación
            // 
            this.colFechaColocación.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colFechaColocación.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colFechaColocación.AppearanceCell.Options.UseBackColor = true;
            this.colFechaColocación.AppearanceCell.Options.UseFont = true;
            this.colFechaColocación.ColumnEdit = this.repositoryItemDateEdit1;
            this.colFechaColocación.FieldName = "FechaColocacion";
            this.colFechaColocación.Name = "colFechaColocación";
            this.colFechaColocación.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFechaColocación.OptionsColumn.AllowMove = false;
            this.colFechaColocación.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFechaColocación.Visible = true;
            this.colFechaColocación.VisibleIndex = 3;
            this.colFechaColocación.Width = 205;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Nº de Lote";
            this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn1.FieldName = "Lote";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 205;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colNombreProfesionalQueColoco
            // 
            this.colNombreProfesionalQueColoco.Caption = "Vacunador";
            this.colNombreProfesionalQueColoco.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNombreProfesionalQueColoco.FieldName = "NombreProfesionalQueColoco";
            this.colNombreProfesionalQueColoco.Name = "colNombreProfesionalQueColoco";
            this.colNombreProfesionalQueColoco.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreProfesionalQueColoco.Visible = true;
            this.colNombreProfesionalQueColoco.VisibleIndex = 5;
            this.colNombreProfesionalQueColoco.Width = 212;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(246, 63);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // uc_Vacunas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "uc_Vacunas";
            this.Size = new System.Drawing.Size(1204, 643);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planVacunacionFullViewListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource planVacunacionFullViewListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreVacuna;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoVacuna;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPlaneada;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaColocacion;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colLote;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreProfesionalQueColoco;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaColocación;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
