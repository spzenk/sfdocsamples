namespace Allus.Cnn.Common
{
    partial class UC_GridMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_GridMessage));
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageListColumnImages = new System.Windows.Forms.ImageList(this.components);
            this.alertMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdMessages = new DevExpress.XtraGrid.GridControl();
            this.grdViewMessages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriorityEnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colRead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exportToolBar1 = new Allus.Libs.Controls.ExportToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "attach.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            // 
            // imageListColumnImages
            // 
            this.imageListColumnImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListColumnImages.ImageStream")));
            this.imageListColumnImages.TransparentColor = System.Drawing.Color.Magenta;
            this.imageListColumnImages.Images.SetKeyName(0, "");
            this.imageListColumnImages.Images.SetKeyName(1, "");
            this.imageListColumnImages.Images.SetKeyName(2, "");
            this.imageListColumnImages.Images.SetKeyName(3, "");
            // 
            // alertMessageBindingSource
            // 
            this.alertMessageBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.AlertMessage);
            // 
            // grdMessages
            // 
            this.grdMessages.DataSource = this.alertMessageBindingSource;
            this.grdMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMessages.Location = new System.Drawing.Point(0, 0);
            this.grdMessages.MainView = this.grdViewMessages;
            this.grdMessages.Name = "grdMessages";
            this.grdMessages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemDateEdit1});
            this.grdMessages.Size = new System.Drawing.Size(349, 508);
            this.grdMessages.TabIndex = 8;
            this.grdMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewMessages});
            this.grdMessages.Load += new System.EventHandler(this.grdMessages_Load);
            this.grdMessages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdMessages_MouseDown);
            this.grdMessages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdMessages_KeyUp);
            this.grdMessages.Click += new System.EventHandler(this.grdMessages_Click);
            // 
            // grdViewMessages
            // 
            this.grdViewMessages.Appearance.GroupRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(104)))), ((int)(((byte)(185)))));
            this.grdViewMessages.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdViewMessages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriorityEnum,
            this.colRead,
            this.colTitle,
            this.colDate,
            this.colSender,
            this.gridColumn1});
            this.grdViewMessages.GridControl = this.grdMessages;
            this.grdViewMessages.GroupFormat = "[#image]{1} {2}";
            this.grdViewMessages.GroupPanelText = "Arrastre una columna aqu� para agrupar";
            this.grdViewMessages.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Title", this.colTitle, "({0} mensajes)")});
            this.grdViewMessages.Images = this.imageListColumnImages;
            this.grdViewMessages.Name = "grdViewMessages";
            this.grdViewMessages.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdViewMessages.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdViewMessages.OptionsCustomization.AllowFilter = false;
            this.grdViewMessages.OptionsCustomization.AllowQuickHideColumns = false;
            this.grdViewMessages.OptionsDetail.EnableMasterViewMode = false;
            this.grdViewMessages.OptionsDetail.ShowDetailTabs = false;
            this.grdViewMessages.OptionsFilter.AllowMRUFilterList = false;
            this.grdViewMessages.OptionsMenu.EnableColumnMenu = false;
            this.grdViewMessages.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdViewMessages.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.grdViewMessages.OptionsView.ShowGroupedColumns = true;
            this.grdViewMessages.OptionsView.ShowVertLines = false;
            // 
            // colPriorityEnum
            // 
            this.colPriorityEnum.Caption = "Priority";
            this.colPriorityEnum.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colPriorityEnum.FieldName = "Priority";
            this.colPriorityEnum.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colPriorityEnum.ImageIndex = 0;
            this.colPriorityEnum.Name = "colPriorityEnum";
            this.colPriorityEnum.OptionsColumn.AllowEdit = false;
            this.colPriorityEnum.OptionsColumn.AllowSize = false;
            this.colPriorityEnum.OptionsColumn.FixedWidth = true;
            this.colPriorityEnum.OptionsColumn.ShowCaption = false;
            this.colPriorityEnum.ToolTip = "Importancia";
            this.colPriorityEnum.Visible = true;
            this.colPriorityEnum.VisibleIndex = 0;
            this.colPriorityEnum.Width = 36;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", 2, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList2;
            // 
            // colRead
            // 
            this.colRead.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colRead.FieldName = "Read";
            this.colRead.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colRead.ImageIndex = 1;
            this.colRead.Name = "colRead";
            this.colRead.OptionsColumn.AllowEdit = false;
            this.colRead.OptionsColumn.AllowSize = false;
            this.colRead.OptionsColumn.FixedWidth = true;
            this.colRead.OptionsColumn.ShowCaption = false;
            this.colRead.Visible = true;
            this.colRead.VisibleIndex = 1;
            this.colRead.Width = 35;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Marcar colo leido")});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unread", false, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Read", true, 1)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.imageList3;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Asunto";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowEdit = false;
            this.colTitle.OptionsColumn.ReadOnly = true;
            this.colTitle.OptionsColumn.ShowInCustomizationForm = false;
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 3;
            this.colTitle.Width = 84;
            // 
            // colDate
            // 
            this.colDate.Caption = "Recibido";
            this.colDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colDate.FieldName = "Date";
            this.colDate.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowShowHide = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            this.colDate.Width = 99;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "g";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colSender
            // 
            this.colSender.Caption = "De";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.OptionsColumn.AllowEdit = false;
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 4;
            this.colSender.Width = 74;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MessageGuid";
            this.gridColumn1.FieldName = "MessageGuid";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // exportToolBar1
            // 
            this.exportToolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportToolBar1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.exportToolBar1.Appearance.Options.UseBackColor = true;
            this.exportToolBar1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exportToolBar1.GridViewToExport = this.grdViewMessages;
            this.exportToolBar1.Location = new System.Drawing.Point(283, 3);
            this.exportToolBar1.Name = "exportToolBar1";
            this.exportToolBar1.Size = new System.Drawing.Size(29, 23);
            this.exportToolBar1.TabIndex = 9;
            // 
            // UC_GridMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportToolBar1);
            this.Controls.Add(this.grdMessages);
            this.Name = "UC_GridMessage";
            this.Size = new System.Drawing.Size(349, 508);
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageListColumnImages;
        private System.Windows.Forms.BindingSource alertMessageBindingSource;

        private DevExpress.XtraGrid.GridControl grdMessages;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewMessages;

        private DevExpress.XtraGrid.Columns.GridColumn colPriorityEnum;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRead;
        
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private Allus.Libs.Controls.ExportToolBar exportToolBar1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;


    }
}
