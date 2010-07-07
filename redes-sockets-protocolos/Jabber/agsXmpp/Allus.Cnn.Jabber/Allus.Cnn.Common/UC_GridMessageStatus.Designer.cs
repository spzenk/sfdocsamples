namespace Allus.Cnn.Common
{
    partial class UC_GridMessageStatus
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.colaboratorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUsername = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFirstname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSurname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMessageStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.exportToolBar1 = new Allus.Libs.Controls.UC_ExportToolBar();
            this.textFind1 = new Allus.Libs.Controls.UC_TextFind();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colaboratorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.colaboratorDataBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton()});
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(422, 260);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // colaboratorDataBindingSource
            // 
            this.colaboratorDataBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.ColaboratorData);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colUsername,
            this.colFirstname,
            this.colSurname,
            this.colMessageStatus});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.GroupCount = 1;
            this.bandedGridView1.GroupFormat = "{1} {2}";
            this.bandedGridView1.GroupPanelText = "Arrastre una columna aqu� para agrupar";
            this.bandedGridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MessageStatus", null, "({0})")});
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMessageStatus, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Detalle Lectura/Confirmaci�n";
            this.gridBand1.Columns.Add(this.colUsername);
            this.gridBand1.Columns.Add(this.colFirstname);
            this.gridBand1.Columns.Add(this.colSurname);
            this.gridBand1.Columns.Add(this.colMessageStatus);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.AllowMove = false;
            this.gridBand1.Width = 401;
            // 
            // colUsername
            // 
            this.colUsername.Caption = "Usuario";
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUsername.OptionsColumn.AllowShowHide = false;
            this.colUsername.Visible = true;
            this.colUsername.Width = 100;
            // 
            // colFirstname
            // 
            this.colFirstname.Caption = "Nombre";
            this.colFirstname.FieldName = "Firstname";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFirstname.OptionsColumn.AllowShowHide = false;
            this.colFirstname.Visible = true;
            this.colFirstname.Width = 93;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Apellido";
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSurname.OptionsColumn.AllowShowHide = false;
            this.colSurname.Visible = true;
            this.colSurname.Width = 102;
            // 
            // colMessageStatus
            // 
            this.colMessageStatus.Caption = "Estado Mensaje";
            this.colMessageStatus.FieldName = "MessageStatus";
            this.colMessageStatus.Name = "colMessageStatus";
            this.colMessageStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMessageStatus.OptionsColumn.AllowShowHide = false;
            this.colMessageStatus.Visible = true;
            this.colMessageStatus.Width = 106;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Visible = false;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Visible = false;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.exportToolBar1);
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(428, 266);
            this.panelControl1.TabIndex = 2;
            // 
            // exportToolBar1
            // 
            this.exportToolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exportToolBar1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.exportToolBar1.Appearance.Options.UseBackColor = true;
            this.exportToolBar1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exportToolBar1.GridViewToExport = this.bandedGridView1;
            this.exportToolBar1.Location = new System.Drawing.Point(361, 9);
            this.exportToolBar1.MaximumSize = new System.Drawing.Size(27, 21);
            this.exportToolBar1.MinimumSize = new System.Drawing.Size(27, 21);
            this.exportToolBar1.Name = "exportToolBar1";
            this.exportToolBar1.Size = new System.Drawing.Size(27, 21);
            this.exportToolBar1.TabIndex = 1;
            // 
            // textFind1
            // 
            this.textFind1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textFind1.Location = new System.Drawing.Point(0, 0);
            this.textFind1.Name = "textFind1";
            this.textFind1.Size = new System.Drawing.Size(428, 28);
            this.textFind1.TabIndex = 3;
            this.textFind1.OnFindTextBoxEnter += new System.EventHandler(this.textFind1_OnFindTextBoxEnter);
            this.textFind1.OnFindClick += new System.EventHandler(this.textFind1_OnFindClick);
            // 
            // UC_GridMessageStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textFind1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UC_GridMessageStatus";
            this.Size = new System.Drawing.Size(428, 294);
            this.Load += new System.EventHandler(this.UC_GridMessageStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colaboratorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource colaboratorDataBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUsername;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFirstname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSurname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMessageStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private Allus.Libs.Controls.UC_TextFind textFind1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private Allus.Libs.Controls.UC_ExportToolBar exportToolBar1;
    }
}
