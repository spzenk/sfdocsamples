namespace Health.Front.Environment
{
    partial class frmFindHealthInst
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgTitle = new System.Windows.Forms.PictureBox();
            this.lbllTitle = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.healthInstitutionBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddresseToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSearchText = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthInstitutionBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 509);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(718, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.imgTitle);
            this.panel1.Controls.Add(this.lbllTitle);
            this.panel1.Location = new System.Drawing.Point(6, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 61);
            this.panel1.TabIndex = 451;
            // 
            // imgTitle
            // 
            this.imgTitle.Image = global::Health.Front.Properties.Resources.security_locked_24;
            this.imgTitle.Location = new System.Drawing.Point(3, 7);
            this.imgTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgTitle.Name = "imgTitle";
            this.imgTitle.Size = new System.Drawing.Size(58, 47);
            this.imgTitle.TabIndex = 450;
            this.imgTitle.TabStop = false;
            // 
            // lbllTitle
            // 
            this.lbllTitle.AutoSize = true;
            this.lbllTitle.BackColor = System.Drawing.Color.White;
            this.lbllTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbllTitle.Location = new System.Drawing.Point(58, 12);
            this.lbllTitle.Name = "lbllTitle";
            this.lbllTitle.Size = new System.Drawing.Size(342, 45);
            this.lbllTitle.TabIndex = 449;
            this.lbllTitle.Text = "Buscar instituciones";
            this.lbllTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.healthInstitutionBEBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(11, 120);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(710, 395);
            this.gridControl1.TabIndex = 452;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // healthInstitutionBEBindingSource
            // 
            this.healthInstitutionBEBindingSource.DataSource = typeof(Health.BE.HealthInstitutionBE);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRazonSocial,
            this.colAddresseToString,
            this.colDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVertLines = false;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.OptionsColumn.AllowEdit = false;
            this.colRazonSocial.OptionsColumn.ReadOnly = true;
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 0;
            // 
            // colAddresseToString
            // 
            this.colAddresseToString.Caption = "Dirección";
            this.colAddresseToString.FieldName = "AddresseToString";
            this.colAddresseToString.Name = "colAddresseToString";
            this.colAddresseToString.OptionsColumn.AllowEdit = false;
            this.colAddresseToString.OptionsColumn.ReadOnly = true;
            this.colAddresseToString.Visible = true;
            this.colAddresseToString.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Descripción";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(11, 84);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(486, 22);
            this.txtSearchText.TabIndex = 454;
            this.txtSearchText.ToolTip = "Texto para buscar instituciones relacionadas";
            this.txtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchText_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::Health.Front.Properties.Resources.summary_zoom_32;
            this.btnSearch.Location = new System.Drawing.Point(503, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 33);
            this.btnSearch.TabIndex = 455;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.ToolTip = "Haga click para buscar instituciones";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmFindHealthInst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 542);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmFindHealthInst";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Localizador de institución de salud";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.txtSearchText, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthInstitutionBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgTitle;
        private System.Windows.Forms.Label lbllTitle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource healthInstitutionBEBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colAddresseToString;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.TextEdit txtSearchText;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}