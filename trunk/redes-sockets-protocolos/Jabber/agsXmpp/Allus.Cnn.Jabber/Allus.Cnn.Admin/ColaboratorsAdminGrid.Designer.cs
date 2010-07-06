namespace Allus.Cnn.Admin
{
    partial class ColaboratorsAdminGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColaboratorsAdminGrid));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.colaboratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdColaboratos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineIp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConnected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colName2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colName2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colMachineIp2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMachineIp2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colUsername2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colSurname2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.barGridViews = new DevExpress.XtraBars.Bar();
            this.barBtnItem_Grid = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_Cards = new DevExpress.XtraBars.BarButtonItem();
            this.btnRereshColaborators = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblColaboratorData = new DevExpress.XtraBars.BarStaticItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.colaboratorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdColaboratos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMachineIp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colaboratorBindingSource
            // 
            this.colaboratorBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.ColaboratorData);
            // 
            // grdColaboratos
            // 
            this.grdColaboratos.DataSource = this.colaboratorBindingSource;
            this.grdColaboratos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdColaboratos.Location = new System.Drawing.Point(0, 27);
            this.grdColaboratos.MainView = this.gridView1;
            this.grdColaboratos.Name = "grdColaboratos";
            this.grdColaboratos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdColaboratos.Size = new System.Drawing.Size(766, 626);
            this.grdColaboratos.TabIndex = 1;
            this.grdColaboratos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.layoutView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colFirstname,
            this.colSurname,
            this.colMachineIp,
            this.colConnected});
            this.gridView1.GridControl = this.grdColaboratos;
            this.gridView1.GroupPanelText = "Arrastre una columna aqui para agrupar";
            this.gridView1.Images = this.imageList1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsPrint.PrintVertLines = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowVertLines = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colName
            // 
            this.colName.Caption = "Usuario";
            this.colName.FieldName = "Username";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 182;
            // 
            // colFirstname
            // 
            this.colFirstname.Caption = "Nombre";
            this.colFirstname.FieldName = "Firstname";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.Visible = true;
            this.colFirstname.VisibleIndex = 2;
            this.colFirstname.Width = 214;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Apellido";
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 3;
            this.colSurname.Width = 188;
            // 
            // colMachineIp
            // 
            this.colMachineIp.Caption = "IP";
            this.colMachineIp.FieldName = "MachineIp";
            this.colMachineIp.Name = "colMachineIp";
            this.colMachineIp.Visible = true;
            this.colMachineIp.VisibleIndex = 4;
            this.colMachineIp.Width = 130;
            // 
            // colConnected
            // 
            this.colConnected.Caption = "Estado";
            this.colConnected.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colConnected.FieldName = "Connected";
            this.colConnected.Name = "colConnected";
            this.colConnected.OptionsColumn.AllowEdit = false;
            this.colConnected.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colConnected.OptionsColumn.AllowMove = false;
            this.colConnected.OptionsColumn.AllowSize = false;
            this.colConnected.OptionsColumn.ReadOnly = true;
            this.colConnected.OptionsColumn.ShowCaption = false;
            this.colConnected.Visible = true;
            this.colConnected.VisibleIndex = 0;
            this.colConnected.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Conectado", true, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Sin conección", false, 0)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "User 4.bmp");
            this.imageList1.Images.SetKeyName(1, "User 4.bmp");
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Colaborador: {2}";
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colName2,
            this.colMachineIp2,
            this.colUsername2,
            this.colSurname2});
            this.layoutView1.GridControl = this.grdColaboratos;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.layoutView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.layoutView1.OptionsBehavior.AllowExpandCollapse = false;
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.layoutView1.OptionsSelection.MultiSelect = true;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.layoutView1_SelectionChanged);
            // 
            // colName2
            // 
            this.colName2.Caption = "Nombre";
            this.colName2.FieldName = "Firstname";
            this.colName2.LayoutViewField = this.layoutViewField_colName2;
            this.colName2.Name = "colName2";
            // 
            // layoutViewField_colName2
            // 
            this.layoutViewField_colName2.EditorPreferredWidth = 133;
            this.layoutViewField_colName2.Location = new System.Drawing.Point(0, 25);
            this.layoutViewField_colName2.Name = "layoutViewField_colName2";
            this.layoutViewField_colName2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_colName2.Size = new System.Drawing.Size(203, 25);
            this.layoutViewField_colName2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_colName2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colName2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // colMachineIp2
            // 
            this.colMachineIp2.Caption = "IP";
            this.colMachineIp2.FieldName = "MachineIp";
            this.colMachineIp2.LayoutViewField = this.layoutViewField_colMachineIp2;
            this.colMachineIp2.Name = "colMachineIp2";
            // 
            // layoutViewField_colMachineIp2
            // 
            this.layoutViewField_colMachineIp2.EditorPreferredWidth = 133;
            this.layoutViewField_colMachineIp2.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colMachineIp2.Name = "layoutViewField_colMachineIp2";
            this.layoutViewField_colMachineIp2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_colMachineIp2.Size = new System.Drawing.Size(203, 25);
            this.layoutViewField_colMachineIp2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField_colMachineIp2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colMachineIp2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // colUsername2
            // 
            this.colUsername2.Caption = "Usuario";
            this.colUsername2.FieldName = "Username";
            this.colUsername2.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.colUsername2.Name = "colUsername2";
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(0, 50);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(203, 31);
            this.layoutViewField_layoutViewColumn1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(41, 20);
            // 
            // colSurname2
            // 
            this.colSurname2.Caption = "Apellido";
            this.colSurname2.FieldName = "Surname";
            this.colSurname2.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.colSurname2.Name = "colSurname2";
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 10;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(0, 81);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(203, 35);
            this.layoutViewField_layoutViewColumn1_1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(41, 20);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewTemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colMachineIp2,
            this.layoutViewField_colName2,
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_1});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // barGridViews
            // 
            this.barGridViews.BarName = "Custom 4";
            this.barGridViews.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)(((((DevExpress.XtraBars.BarCanDockStyle.Floating | DevExpress.XtraBars.BarCanDockStyle.Top)
                        | DevExpress.XtraBars.BarCanDockStyle.Right)
                        | DevExpress.XtraBars.BarCanDockStyle.Bottom)
                        | DevExpress.XtraBars.BarCanDockStyle.Standalone)));
            this.barGridViews.DockCol = 0;
            this.barGridViews.DockRow = 0;
            this.barGridViews.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barGridViews.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_Grid, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_Cards, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRereshColaborators),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblColaboratorData)});
            this.barGridViews.OptionsBar.AllowQuickCustomization = false;
            this.barGridViews.OptionsBar.DisableCustomization = true;
            this.barGridViews.OptionsBar.DrawDragBorder = false;
            this.barGridViews.OptionsBar.MultiLine = true;
            this.barGridViews.OptionsBar.UseWholeRow = true;
            this.barGridViews.Text = "Custom 4";
            // 
            // barBtnItem_Grid
            // 
            this.barBtnItem_Grid.Caption = "&Grilla";
            this.barBtnItem_Grid.Glyph = global::Allus.Cnn.Admin.Properties.Resources.Calendar;
            this.barBtnItem_Grid.Hint = "Establece la vista de grilla";
            this.barBtnItem_Grid.Id = 7;
            this.barBtnItem_Grid.Name = "barBtnItem_Grid";
            toolTipItem1.Text = "Vista de grilla";
            superToolTip1.Items.Add(toolTipItem1);
            this.barBtnItem_Grid.SuperTip = superToolTip1;
            this.barBtnItem_Grid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_Grid_ItemClick);
            // 
            // barBtnItem_Cards
            // 
            this.barBtnItem_Cards.Caption = "&Tarjetas";
            this.barBtnItem_Cards.Glyph = global::Allus.Cnn.Admin.Properties.Resources.cascate;
            this.barBtnItem_Cards.Hint = "Establece la vista de targetas";
            this.barBtnItem_Cards.Id = 6;
            this.barBtnItem_Cards.Name = "barBtnItem_Cards";
            this.barBtnItem_Cards.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            toolTipItem2.Text = "Vista de targetas";
            superToolTip2.Items.Add(toolTipItem2);
            this.barBtnItem_Cards.SuperTip = superToolTip2;
            this.barBtnItem_Cards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_Cards_ItemClick);
            // 
            // btnRereshColaborators
            // 
            this.btnRereshColaborators.Caption = "Refrescar lista";
            this.btnRereshColaborators.Glyph = global::Allus.Cnn.Admin.Properties.Resources.ref_16;
            this.btnRereshColaborators.Id = 11;
            this.btnRereshColaborators.Name = "btnRereshColaborators";
            this.btnRereshColaborators.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            toolTipItem3.Text = "Refrescar lista de usuarios";
            superToolTip3.Items.Add(toolTipItem3);
            this.btnRereshColaborators.SuperTip = superToolTip3;
            this.btnRereshColaborators.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRereshColaborators_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = " ";
            this.barStaticItem1.Id = 13;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblColaboratorData
            // 
            this.lblColaboratorData.Glyph = global::Allus.Cnn.Admin.Properties.Resources.user_16;
            this.lblColaboratorData.Id = 12;
            this.lblColaboratorData.Name = "lblColaboratorData";
            this.lblColaboratorData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            toolTipItem4.Text = "Usuario seleccionado";
            superToolTip4.Items.Add(toolTipItem4);
            this.lblColaboratorData.SuperTip = superToolTip4;
            this.lblColaboratorData.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barGridViews});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnItem_Cards,
            this.barBtnItem_Grid,
            this.btnRereshColaborators,
            this.lblColaboratorData,
            this.barStaticItem1});
            this.barManager1.MainMenu = this.barGridViews;
            this.barManager1.MaxItemId = 14;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 4";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_Cards, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_Grid, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 4";
            // 
            // ColaboratorsAdminGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdColaboratos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ColaboratorsAdminGrid";
            this.Size = new System.Drawing.Size(766, 653);
            ((System.ComponentModel.ISupportInitialize)(this.colaboratorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdColaboratos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMachineIp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource colaboratorBindingSource;
        private DevExpress.XtraGrid.GridControl grdColaboratos;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colName2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colName2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMachineIp2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMachineIp2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineIp;
        private DevExpress.XtraBars.Bar barGridViews;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_Cards;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_Grid;
        private DevExpress.XtraBars.BarManager barManager1;
        
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnRereshColaborators;
        private DevExpress.XtraBars.BarStaticItem lblColaboratorData;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstname;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colUsername2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colSurname2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Columns.GridColumn colConnected;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}
