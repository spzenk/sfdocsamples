namespace Allus.Cnn.Common
{
    partial class MessageGridFind
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
            this.grdMessages = new DevExpress.XtraGrid.GridControl();
            this.messagesBECollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMessageId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessageText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeshId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayMessageType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.textFindPopUp1 = new Allus.Libs.Controls.TextFindPopUp();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.domainCombosFilters1 = new Allus.Cnn.Common.DomainCombosFilters();
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesBECollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMessages
            // 
            this.grdMessages.DataSource = this.messagesBECollectionBindingSource;
            this.grdMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMessages.Location = new System.Drawing.Point(3, 3);
            this.grdMessages.MainView = this.gridView1;
            this.grdMessages.Name = "grdMessages";
            this.grdMessages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grdMessages.Size = new System.Drawing.Size(416, 501);
            this.grdMessages.TabIndex = 0;
            this.grdMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdMessages.Load += new System.EventHandler(this.grdMessages_Load);
            this.grdMessages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdMessages_MouseDown);
            this.grdMessages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdMessages_KeyUp);
            this.grdMessages.Click += new System.EventHandler(this.grdMessages_Click);
            // 
            // messagesBECollectionBindingSource
            // 
            this.messagesBECollectionBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.MessagesBECollection);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMessageId,
            this.colTitle,
            this.colMessageText,
            this.colDate,
            this.colMeshId,
            this.colDisplayMessageType});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.grdMessages;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMessageId
            // 
            this.colMessageId.FieldName = "MessageId";
            this.colMessageId.Name = "colMessageId";
            this.colMessageId.Width = 113;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Asunto";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 171;
            // 
            // colMessageText
            // 
            this.colMessageText.Caption = "Mensaje";
            this.colMessageText.FieldName = "MessageText";
            this.colMessageText.Name = "colMessageText";
            this.colMessageText.Width = 181;
            // 
            // colDate
            // 
            this.colDate.Caption = "Fecha";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 96;
            // 
            // colMeshId
            // 
            this.colMeshId.FieldName = "MeshId";
            this.colMeshId.Name = "colMeshId";
            // 
            // colDisplayMessageType
            // 
            this.colDisplayMessageType.Caption = "Tipo Mensaje";
            this.colDisplayMessageType.FieldName = "DisplayMessageType";
            this.colDisplayMessageType.Name = "colDisplayMessageType";
            this.colDisplayMessageType.Visible = true;
            this.colDisplayMessageType.VisibleIndex = 2;
            this.colDisplayMessageType.Width = 128;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // textFindPopUp1
            // 
            this.textFindPopUp1.AllowAdvancedSearch = true;
            this.textFindPopUp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textFindPopUp1.Location = new System.Drawing.Point(0, 0);
            this.textFindPopUp1.Name = "textFindPopUp1";
            this.textFindPopUp1.PopupControl = this.popupContainerControl1;
            this.textFindPopUp1.Size = new System.Drawing.Size(422, 30);
            this.textFindPopUp1.TabIndex = 1;
            this.textFindPopUp1.OnFindTextBoxEnter += new System.EventHandler(this.textFindPopUp1_OnFindTextBoxEnter);
            this.textFindPopUp1.OnFindClick += new System.EventHandler(this.textFindPopUp1_OnFindClick);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.groupControl1);
            this.popupContainerControl1.Location = new System.Drawing.Point(22, 407);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(467, 239);
            this.popupContainerControl1.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.domainCombosFilters1);
            this.groupControl1.Controls.Add(this.chkUseDate);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(467, 239);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Parametros de busqueda";
            // 
            // domainCombosFilters1
            // 
            this.domainCombosFilters1.Location = new System.Drawing.Point(6, 97);
            this.domainCombosFilters1.Mesh = null;
            this.domainCombosFilters1.Name = "domainCombosFilters1";
            this.domainCombosFilters1.Size = new System.Drawing.Size(440, 128);
            this.domainCombosFilters1.TabIndex = 8;
            // 
            // chkUseDate
            // 
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Location = new System.Drawing.Point(5, 22);
            this.chkUseDate.Name = "chkUseDate";
            this.chkUseDate.Size = new System.Drawing.Size(83, 17);
            this.chkUseDate.TabIndex = 3;
            this.chkUseDate.Text = "Usar fechas";
            this.chkUseDate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateEnd);
            this.groupBox1.Controls.Add(this.dtpDateStart);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha desde";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(244, 29);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(200, 21);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Location = new System.Drawing.Point(5, 29);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(200, 21);
            this.dtpDateStart.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.grdMessages);
            this.panelControl1.Location = new System.Drawing.Point(0, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(422, 507);
            this.panelControl1.TabIndex = 3;
            // 
            // MessageGridFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.textFindPopUp1);
            this.Name = "MessageGridFind";
            this.Size = new System.Drawing.Size(422, 540);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messagesBECollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMessages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Allus.Libs.Controls.TextFindPopUp textFindPopUp1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.CheckBox chkUseDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private DomainCombosFilters domainCombosFilters1;
        private System.Windows.Forms.BindingSource messagesBECollectionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMessageId;
        private DevExpress.XtraGrid.Columns.GridColumn colMessageText;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colMeshId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayMessageType;
    }
}
