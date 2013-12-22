namespace Health.Front.Scheduler
{
    partial class uc_ShiftsControls
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition6 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_ShiftsControls));
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mAsignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_atenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mEnEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSetCanceled = new System.Windows.Forms.ToolStripMenuItem();
            this.mCerrarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_sobreturnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timespamViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAppointmentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(705, 10);
            this.lblTitle.Text = "";
            this.lblTitle.Visible = false;
            // 
            // gridControl2
            // 
            this.gridControl2.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl2.DataSource = this.timespamViewBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl2.Size = new System.Drawing.Size(705, 519);
            this.gridControl2.TabIndex = 12;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAsignarToolStripMenuItem,
            this.m_atenderToolStripMenuItem,
            this.toolStripSeparator1,
            this.mEnEsperaToolStripMenuItem,
            this.mSetCanceled,
            this.mCerrarTurnoToolStripMenuItem,
            this.m_sobreturnoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 154);
            // 
            // mAsignarToolStripMenuItem
            // 
            this.mAsignarToolStripMenuItem.Enabled = false;
            this.mAsignarToolStripMenuItem.Image = global::Health.Front.Properties.Resources.clock_add_48;
            this.mAsignarToolStripMenuItem.Name = "mAsignarToolStripMenuItem";
            this.mAsignarToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.mAsignarToolStripMenuItem.Text = "Reservar";
            this.mAsignarToolStripMenuItem.Click += new System.EventHandler(this.asignarToolStripMenuItem_Click);
            // 
            // m_atenderToolStripMenuItem
            // 
            this.m_atenderToolStripMenuItem.Enabled = false;
            this.m_atenderToolStripMenuItem.Name = "m_atenderToolStripMenuItem";
            this.m_atenderToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.m_atenderToolStripMenuItem.Text = "Atender";
            this.m_atenderToolStripMenuItem.Click += new System.EventHandler(this.m_atenderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // mEnEsperaToolStripMenuItem
            // 
            this.mEnEsperaToolStripMenuItem.Enabled = false;
            this.mEnEsperaToolStripMenuItem.Image = global::Health.Front.Properties.Resources.ic_menu_recent_history__2_;
            this.mEnEsperaToolStripMenuItem.Name = "mEnEsperaToolStripMenuItem";
            this.mEnEsperaToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.mEnEsperaToolStripMenuItem.Text = "En espera";
            this.mEnEsperaToolStripMenuItem.Click += new System.EventHandler(this.enEsperaToolStripMenuItem_Click);
            // 
            // mSetCanceled
            // 
            this.mSetCanceled.Enabled = false;
            this.mSetCanceled.Image = global::Health.Front.Properties.Resources.clock_remove_48;
            this.mSetCanceled.Name = "mSetCanceled";
            this.mSetCanceled.Size = new System.Drawing.Size(157, 24);
            this.mSetCanceled.Text = "Cancelar";
            this.mSetCanceled.Click += new System.EventHandler(this.mSetCanceled_Click);
            // 
            // mCerrarTurnoToolStripMenuItem
            // 
            this.mCerrarTurnoToolStripMenuItem.Enabled = false;
            this.mCerrarTurnoToolStripMenuItem.Image = global::Health.Front.Properties.Resources.close_16;
            this.mCerrarTurnoToolStripMenuItem.Name = "mCerrarTurnoToolStripMenuItem";
            this.mCerrarTurnoToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.mCerrarTurnoToolStripMenuItem.Text = "Cerrar turno";
            this.mCerrarTurnoToolStripMenuItem.Click += new System.EventHandler(this.cerrarTurnoToolStripMenuItem_Click);
            // 
            // m_sobreturnoToolStripMenuItem
            // 
            this.m_sobreturnoToolStripMenuItem.Name = "m_sobreturnoToolStripMenuItem";
            this.m_sobreturnoToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.m_sobreturnoToolStripMenuItem.Text = "Entreturno";
            this.m_sobreturnoToolStripMenuItem.Click += new System.EventHandler(this.m_sobreturnoToolStripMenuItem_Click);
            // 
            // timespamViewBindingSource
            // 
            this.timespamViewBindingSource.DataSource = typeof(Health.BE.TimespamView);
            // 
            // gridView2
            // 
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAppointmentStatus,
            this.colTime,
            this.colDescription});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[Status] == 630";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Goldenrod;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[Status] == 635";
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "[Status] == 631";
            styleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Black;
            styleFormatCondition4.Appearance.Options.UseForeColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "[Status] == 636";
            styleFormatCondition5.Appearance.ForeColor = System.Drawing.Color.DimGray;
            styleFormatCondition5.Appearance.Options.UseForeColor = true;
            styleFormatCondition5.ApplyToRow = true;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition5.Expression = "[Status] == 637";
            styleFormatCondition6.Appearance.BackColor = System.Drawing.Color.Khaki;
            styleFormatCondition6.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            styleFormatCondition6.Appearance.Options.UseBackColor = true;
            styleFormatCondition6.Appearance.Options.UseFont = true;
            styleFormatCondition6.ApplyToRow = true;
            styleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition6.Expression = "[IsExceptional] == True";
            this.gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5,
            styleFormatCondition6});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Images = this.imageList2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowColumnResizing = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFind.AllowFindPanel = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowVertLines = false;
            this.gridView2.RowHeight = 27;
            this.gridView2.RowSeparatorHeight = 3;
            this.gridView2.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // colAppointmentStatus
            // 
            this.colAppointmentStatus.Caption = "Estado";
            this.colAppointmentStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colAppointmentStatus.FieldName = "Status";
            this.colAppointmentStatus.Name = "colAppointmentStatus";
            this.colAppointmentStatus.OptionsColumn.AllowEdit = false;
            this.colAppointmentStatus.OptionsColumn.AllowFocus = false;
            this.colAppointmentStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.AllowMove = false;
            this.colAppointmentStatus.OptionsColumn.AllowShowHide = false;
            this.colAppointmentStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.ReadOnly = true;
            this.colAppointmentStatus.Visible = true;
            this.colAppointmentStatus.VisibleIndex = 0;
            this.colAppointmentStatus.Width = 180;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Reservado", 630, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("En espera", 635, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("En atención", 631, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cerrado", 632, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelado", 633, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Libre", 636, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Expirado ", 634, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Entreturno", 638, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Sobreturno", 639, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 637, 6)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            this.repositoryItemImageComboBox1.SmallImages = this.imageList2;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "AppoimentStatus_Reserved.png");
            this.imageList2.Images.SetKeyName(1, "AppoimentStatusWaiting.png");
            this.imageList2.Images.SetKeyName(2, "AppoimentStatusInAttention.png");
            this.imageList2.Images.SetKeyName(3, "AppoimentStatusClosed.png");
            this.imageList2.Images.SetKeyName(4, "AppoimentStatusCanceled.png");
            this.imageList2.Images.SetKeyName(5, "AppoimentStatus_FreeToUse.ICO");
            this.imageList2.Images.SetKeyName(6, "AppoimentStatus_Expiro.png");
            this.imageList2.Images.SetKeyName(7, "AppoimentStatus_Sobreturno.png");
            this.imageList2.Images.SetKeyName(8, "Desktop (Alt 2).png");
            this.imageList2.Images.SetKeyName(9, "Desktop.png");
            this.imageList2.Images.SetKeyName(10, "Document.png");
            this.imageList2.Images.SetKeyName(11, "Globe.png");
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colTime.AppearanceCell.Options.UseFont = true;
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colTime.AppearanceHeader.Options.UseFont = true;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Hora";
            this.colTime.FieldName = "TimeString";
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.AllowEdit = false;
            this.colTime.OptionsColumn.AllowFocus = false;
            this.colTime.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTime.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTime.OptionsColumn.AllowMove = false;
            this.colTime.OptionsColumn.AllowShowHide = false;
            this.colTime.OptionsColumn.ReadOnly = true;
            this.colTime.OptionsFilter.AllowAutoFilter = false;
            this.colTime.OptionsFilter.AllowFilter = false;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 1;
            this.colTime.Width = 148;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Asunto";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowShowHide = false;
            this.colDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.OptionsFilter.AllowAutoFilter = false;
            this.colDescription.OptionsFilter.AllowFilter = false;
            this.colDescription.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 300;
            // 
            // uc_ShiftsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl2);
            this.Name = "uc_ShiftsControls";
            this.Size = new System.Drawing.Size(705, 519);
            this.Controls.SetChildIndex(this.gridControl2, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timespamViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private System.Windows.Forms.BindingSource timespamViewBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mSetCanceled;
        private DevExpress.XtraGrid.Columns.GridColumn colAppointmentStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ToolStripMenuItem mAsignarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mCerrarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mEnEsperaToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripMenuItem m_atenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_sobreturnoToolStripMenuItem;
    }
}
