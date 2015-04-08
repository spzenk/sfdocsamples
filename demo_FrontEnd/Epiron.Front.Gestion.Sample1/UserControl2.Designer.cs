namespace Epiron.Front.Gestion.Sample1
{
    partial class UserControl2
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
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.colDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.colTypeImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colAssemblyInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblEdad = new DevExpress.XtraEditors.LabelControl();
            this.lblDNI = new DevExpress.XtraEditors.LabelControl();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colDisplayName
            // 
            this.colDisplayName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.colDisplayName.AppearanceCell.ForeColor = System.Drawing.Color.White;
            this.colDisplayName.AppearanceCell.Options.UseFont = true;
            this.colDisplayName.AppearanceCell.Options.UseForeColor = true;
            this.colDisplayName.Caption = "DisplayName";
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.MinWidth = 49;
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.AllowEdit = false;
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 0;
            this.colDisplayName.Width = 522;
            // 
            // treeList2
            // 
            this.treeList2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList2.Appearance.Row.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.treeList2.Appearance.Row.ForeColor = System.Drawing.Color.White;
            this.treeList2.Appearance.Row.Options.UseBorderColor = true;
            this.treeList2.Appearance.Row.Options.UseForeColor = true;
            this.treeList2.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White;
            this.treeList2.AppearancePrint.OddRow.Options.UseBackColor = true;
            this.treeList2.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
            this.treeList2.AppearancePrint.Row.Options.UseBackColor = true;
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDisplayName,
            this.colTypeImage,
            this.colAssemblyInfo,
            this.colParentID});
            this.treeList2.DataSource = this.treeMenuBindingSource;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.LightYellow;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.Column = this.colDisplayName;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[ParentID] == 0";
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.White;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.Column = this.colDisplayName;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[ParentID] != xxxxDesactivado";
            this.treeList2.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.treeList2.IndicatorWidth = 10;
            this.treeList2.Location = new System.Drawing.Point(4, 130);
            this.treeList2.Margin = new System.Windows.Forms.Padding(4);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsBehavior.AutoChangeParent = false;
            this.treeList2.OptionsBehavior.AutoNodeHeight = false;
            this.treeList2.OptionsBehavior.Editable = false;
            this.treeList2.OptionsLayout.AddNewColumns = false;
            this.treeList2.OptionsMenu.EnableColumnMenu = false;
            this.treeList2.OptionsMenu.EnableFooterMenu = false;
            this.treeList2.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList2.OptionsView.ShowButtons = false;
            this.treeList2.OptionsView.ShowColumns = false;
            this.treeList2.OptionsView.ShowHorzLines = false;
            this.treeList2.OptionsView.ShowIndicator = false;
            this.treeList2.OptionsView.ShowVertLines = false;
            this.treeList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.treeList2.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeList2.Size = new System.Drawing.Size(279, 528);
            this.treeList2.TabIndex = 47;
            this.treeList2.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.treeList2.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList2_FocusedNodeChanged);
            this.treeList2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeList2_MouseClick);
            // 
            // colTypeImage
            // 
            this.colTypeImage.Caption = "TypeImage";
            this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
            this.colTypeImage.FieldName = "TypeImage";
            this.colTypeImage.MinWidth = 49;
            this.colTypeImage.Name = "colTypeImage";
            this.colTypeImage.OptionsColumn.AllowMove = false;
            this.colTypeImage.OptionsColumn.AllowSize = false;
            this.colTypeImage.OptionsColumn.FixedWidth = true;
            this.colTypeImage.OptionsColumn.ReadOnly = true;
            this.colTypeImage.Width = 81;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // colAssemblyInfo
            // 
            this.colAssemblyInfo.Caption = "AssemblyInfo";
            this.colAssemblyInfo.FieldName = "AssemblyInfo";
            this.colAssemblyInfo.Name = "colAssemblyInfo";
            this.colAssemblyInfo.Width = 49;
            // 
            // colParentID
            // 
            this.colParentID.Caption = "ParentID";
            this.colParentID.FieldName = "ParentID";
            this.colParentID.Name = "colParentID";
            // 
            // treeMenuBindingSource
            // 
            this.treeMenuBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.Tree.TreeMenu);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(13, 39);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(94, 85);
            this.pictureEdit1.TabIndex = 54;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 16);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "Paciente";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEdad.Location = new System.Drawing.Point(163, 74);
            this.lblEdad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(88, 17);
            this.lblEdad.TabIndex = 52;
            this.lblEdad.Text = "....................";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDNI.Location = new System.Drawing.Point(163, 48);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(88, 16);
            this.lblDNI.TabIndex = 51;
            this.lblDNI.Text = "------------------";
            // 
            // lblNombre
            // 
            this.lblNombre.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNombre.Location = new System.Drawing.Point(73, 12);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(184, 15);
            this.lblNombre.TabIndex = 50;
            this.lblNombre.Text = "-------------- -----------";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(118, 74);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 17);
            this.labelControl3.TabIndex = 49;
            this.labelControl3.Text = "Edad:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(118, 48);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 17);
            this.labelControl2.TabIndex = 48;
            this.labelControl2.Text = "Doc:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help.png");
            this.imageList1.Images.SetKeyName(1, "remove-window.png");
            this.imageList1.Images.SetKeyName(2, "write.png");
            this.imageList1.Images.SetKeyName(3, "Antivirus-icon_24.png");
            this.imageList1.Images.SetKeyName(4, "blood_32.png");
            this.imageList1.Images.SetKeyName(5, "laboratorio_32.png");
            this.imageList1.Images.SetKeyName(6, "heart-icon_48.png");
            this.imageList1.Images.SetKeyName(7, "nurse-icon.png");
            this.imageList1.Images.SetKeyName(8, "heart-blood-icon_32.png");
            this.imageList1.Images.SetKeyName(9, "CruzRoja.png");
            this.imageList1.Images.SetKeyName(10, "Ball (Green).png");
            this.imageList1.Images.SetKeyName(11, "Ball (Yellow).png");
            this.imageList1.Images.SetKeyName(12, "Chart.png");
            this.imageList1.Images.SetKeyName(13, "docs_24.ico");
            this.imageList1.Images.SetKeyName(14, "edit_24.ico");
            this.imageList1.Images.SetKeyName(15, "fax_24.ico");
            this.imageList1.Images.SetKeyName(16, "hist_24.ico");
            this.imageList1.Images.SetKeyName(17, "image_24.ico");
            this.imageList1.Images.SetKeyName(18, "prefs_24.ico");
            this.imageList1.Images.SetKeyName(19, "confg_24.ico");
            this.imageList1.Images.SetKeyName(20, "create_contact (2).png");
            this.imageList1.Images.SetKeyName(21, "ic_btn_search (2).png");
            this.imageList1.Images.SetKeyName(22, "ic_emergency (2).png");
            this.imageList1.Images.SetKeyName(23, "ic_maps_indicator_current_position_anim1 (2).png");
            this.imageList1.Images.SetKeyName(24, "stat_sys_signal_2 (2).png");
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.treeList2);
            this.Name = "UserControl2";
            this.PanelContainer = Epiron.Front.Bases.PanelEnum.LeftPanel_1;
            this.Size = new System.Drawing.Size(287, 662);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTypeImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAssemblyInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentID;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblEdad;
        private DevExpress.XtraEditors.LabelControl lblDNI;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.BindingSource treeMenuBindingSource;
        private System.Windows.Forms.ImageList imageList1;
    }
}
