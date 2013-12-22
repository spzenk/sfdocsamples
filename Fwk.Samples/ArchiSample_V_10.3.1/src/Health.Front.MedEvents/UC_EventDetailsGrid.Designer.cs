namespace Health.Front.Events
{
    partial class UC_EventDetailsGrid
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.medicalEventDetailViewListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl_Details = new DevExpress.XtraGrid.GridControl();
            this.gridView_Details = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventDetailViewListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(748, 41);
            this.lblTitle.Text = "Details tittle";
            // 
            // medicalEventDetailViewListBindingSource
            // 
            this.medicalEventDetailViewListBindingSource.DataSource = typeof(Health.BE.MedicalEventDetail_ViewList);
            // 
            // gridControl_Details
            // 
            this.gridControl_Details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_Details.DataSource = this.medicalEventDetailViewListBindingSource;
            this.gridControl_Details.Location = new System.Drawing.Point(3, 48);
            this.gridControl_Details.MainView = this.gridView_Details;
            this.gridControl_Details.Name = "gridControl_Details";
            this.gridControl_Details.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2});
            this.gridControl_Details.Size = new System.Drawing.Size(743, 242);
            this.gridControl_Details.TabIndex = 2049;
            this.gridControl_Details.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Details});
            // 
            // gridView_Details
            // 
            this.gridView_Details.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView_Details.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView_Details.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.SeaShell;
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Brown;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "[Enabled]  == False";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "[Status] == 660";
            this.gridView_Details.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4});
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
            this.gridView_Details.DoubleClick += new System.EventHandler(this.gridView_Details_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha";
            this.gridColumn1.FieldName = "CreatedDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Relevancia";
            this.gridColumn2.FieldName = "RelevanceTypeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Descripción";
            this.gridColumn7.FieldName = "Desc";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 440;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Profesional";
            this.gridColumn8.FieldName = "Profesional";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 200;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Permanente", true, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 0)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.ReadOnly = true;
            // 
            // UC_EventDetailsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl_Details);
            this.Name = "UC_EventDetailsGrid";
            this.Size = new System.Drawing.Size(748, 293);
            this.Controls.SetChildIndex(this.gridControl_Details, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            ((System.ComponentModel.ISupportInitialize)(this.medicalEventDetailViewListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource medicalEventDetailViewListBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl_Details;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Details;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
    }
}
