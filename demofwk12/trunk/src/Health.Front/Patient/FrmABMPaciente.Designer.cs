namespace Health.Front
{
    partial class FrmABMPatient
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.uc_Persona1 = new Health.Front.Patients.uc_Persona();
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl_MutualXPatient = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDesactivar = new System.Windows.Forms.ToolStripMenuItem();
            this.miActivar = new System.Windows.Forms.ToolStripMenuItem();
            this.MutualPorPacienteBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombreMutual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroAfiliadoMutual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.mutualListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAppointmentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.uc_MedioContacto1 = new Health.Front.Personas.uc_MedioContacto();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MutualXPatient)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MutualPorPacienteBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutualListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonText = "Guardar";
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonText = "Salir";
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 575);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(772, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // colIsActive
            // 
            this.colIsActive.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colIsActive.AppearanceHeader.Options.UseFont = true;
            this.colIsActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.Caption = "Activa";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTitulo.Location = new System.Drawing.Point(3, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(772, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Alta de Paciente";
            // 
            // uc_Persona1
            // 
            this.uc_Persona1.Location = new System.Drawing.Point(17, 76);
            this.uc_Persona1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uc_Persona1.Name = "uc_Persona1";
            this.uc_Persona1.Size = new System.Drawing.Size(739, 310);
            this.uc_Persona1.TabIndex = 1;
            this.uc_Persona1.PersonaChanged += new System.EventHandler(this.uc_Persona1_PersonaChanged);
            // 
            // btnAcept
            // 
            this.btnAcept.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnAcept.Appearance.Options.UseFont = true;
            this.btnAcept.Image = global::Health.Front.Base.Properties.Resource.save_32;
            this.btnAcept.Location = new System.Drawing.Point(604, 6);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(116, 33);
            this.btnAcept.TabIndex = 68;
            this.btnAcept.Text = "Guardar";
            this.btnAcept.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 51);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(769, 517);
            this.xtraTabControl1.TabIndex = 69;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtNombres);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.uc_Persona1);
            this.xtraTabPage1.Image = global::Health.Front.Base.Properties.Resource.vcard_48;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(763, 456);
            this.xtraTabPage1.Text = "Paciente";
            // 
            // txtNombres
            // 
            this.txtNombres.EditValue = "";
            this.txtNombres.Enabled = false;
            this.txtNombres.EnterMoveNextControl = true;
            this.txtNombres.Location = new System.Drawing.Point(380, 22);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNombres.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtNombres.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombres.Properties.Appearance.Options.UseBackColor = true;
            this.txtNombres.Properties.Appearance.Options.UseFont = true;
            this.txtNombres.Properties.Appearance.Options.UseForeColor = true;
            this.txtNombres.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtNombres.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtNombres.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombres.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtNombres.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtNombres.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtNombres.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtNombres.Properties.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(337, 22);
            this.txtNombres.TabIndex = 2037;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Location = new System.Drawing.Point(17, 23);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(339, 18);
            this.labelControl2.TabIndex = 2036;
            this.labelControl2.Text = "Número de referencia obligatoriamente único";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl_MutualXPatient);
            this.xtraTabPage2.Controls.Add(this.labelControl4);
            this.xtraTabPage2.Controls.Add(this.btnAdd);
            this.xtraTabPage2.Controls.Add(this.gridControl2);
            this.xtraTabPage2.Image = global::Health.Front.Base.Properties.Resource.web_link;
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(763, 456);
            this.xtraTabPage2.Text = "Obra Social";
            // 
            // gridControl_MutualXPatient
            // 
            this.gridControl_MutualXPatient.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl_MutualXPatient.DataSource = this.MutualPorPacienteBEBindingSource;
            this.gridControl_MutualXPatient.Location = new System.Drawing.Point(442, 49);
            this.gridControl_MutualXPatient.MainView = this.gridView1;
            this.gridControl_MutualXPatient.Name = "gridControl_MutualXPatient";
            this.gridControl_MutualXPatient.Size = new System.Drawing.Size(318, 427);
            this.gridControl_MutualXPatient.TabIndex = 28;
            this.gridControl_MutualXPatient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.miDesactivar,
            this.miActivar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 80);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // miDesactivar
            // 
            this.miDesactivar.Image = global::Health.Front.Base.Properties.Resource.clock_remove_48;
            this.miDesactivar.Name = "miDesactivar";
            this.miDesactivar.Size = new System.Drawing.Size(180, 24);
            this.miDesactivar.Text = "Quitar";
            this.miDesactivar.Click += new System.EventHandler(this.miDesactivar_Click);
            // 
            // miActivar
            // 
            this.miActivar.Enabled = false;
            this.miActivar.Image = global::Health.Front.Base.Properties.Resource.close_16;
            this.miActivar.Name = "miActivar";
            this.miActivar.Size = new System.Drawing.Size(180, 24);
            this.miActivar.Text = "Volver a activar";
            this.miActivar.Visible = false;
            this.miActivar.Click += new System.EventHandler(this.miActivar_Click);
            // 
            // MutualPorPacienteBEBindingSource
            // 
            this.MutualPorPacienteBEBindingSource.DataSource = typeof(Health.BE.MutualPorPacienteBE);
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombreMutual,
            this.colNroAfiliadoMutual,
            this.colIsActive});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.LightCoral;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsActive;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[IsActive] == False";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl_MutualXPatient;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 27;
            this.gridView1.RowSeparatorHeight = 3;
            this.gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // colNombreMutual
            // 
            this.colNombreMutual.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colNombreMutual.AppearanceHeader.Options.UseFont = true;
            this.colNombreMutual.AppearanceHeader.Options.UseTextOptions = true;
            this.colNombreMutual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNombreMutual.Caption = "Mutual";
            this.colNombreMutual.FieldName = "NombreMutual";
            this.colNombreMutual.Name = "colNombreMutual";
            this.colNombreMutual.OptionsColumn.AllowEdit = false;
            this.colNombreMutual.OptionsColumn.AllowFocus = false;
            this.colNombreMutual.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreMutual.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreMutual.OptionsColumn.AllowMove = false;
            this.colNombreMutual.OptionsColumn.AllowShowHide = false;
            this.colNombreMutual.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNombreMutual.OptionsColumn.ReadOnly = true;
            this.colNombreMutual.OptionsFilter.AllowAutoFilter = false;
            this.colNombreMutual.OptionsFilter.AllowFilter = false;
            this.colNombreMutual.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.colNombreMutual.Visible = true;
            this.colNombreMutual.VisibleIndex = 0;
            this.colNombreMutual.Width = 150;
            // 
            // colNroAfiliadoMutual
            // 
            this.colNroAfiliadoMutual.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colNroAfiliadoMutual.AppearanceCell.ForeColor = System.Drawing.Color.SlateGray;
            this.colNroAfiliadoMutual.AppearanceCell.Options.UseFont = true;
            this.colNroAfiliadoMutual.AppearanceCell.Options.UseForeColor = true;
            this.colNroAfiliadoMutual.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colNroAfiliadoMutual.AppearanceHeader.Options.UseFont = true;
            this.colNroAfiliadoMutual.AppearanceHeader.Options.UseTextOptions = true;
            this.colNroAfiliadoMutual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNroAfiliadoMutual.Caption = "Nro Afiliado";
            this.colNroAfiliadoMutual.FieldName = "NroAfiliadoMutual";
            this.colNroAfiliadoMutual.Name = "colNroAfiliadoMutual";
            this.colNroAfiliadoMutual.Visible = true;
            this.colNroAfiliadoMutual.VisibleIndex = 1;
            this.colNroAfiliadoMutual.Width = 100;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Location = new System.Drawing.Point(475, 14);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(163, 18);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "Mutuales del paciente";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Health.Front.Base.Properties.Resource.sendMail_24;
            this.btnAdd.Location = new System.Drawing.Point(337, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 40);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.mutualListBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(6, 16);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl2.Size = new System.Drawing.Size(325, 457);
            this.gridControl2.TabIndex = 13;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // mutualListBindingSource
            // 
            this.mutualListBindingSource.DataSource = typeof(Health.BE.MutualList);
            // 
            // gridView2
            // 
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAppointmentStatus,
            this.colNombre});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.GridControl = this.gridControl2;
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
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowColumnHeaders = false;
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
            this.colAppointmentStatus.Caption = "Id";
            this.colAppointmentStatus.FieldName = "IdMutual";
            this.colAppointmentStatus.Name = "colAppointmentStatus";
            this.colAppointmentStatus.OptionsColumn.AllowEdit = false;
            this.colAppointmentStatus.OptionsColumn.AllowFocus = false;
            this.colAppointmentStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.AllowMove = false;
            this.colAppointmentStatus.OptionsColumn.AllowShowHide = false;
            this.colAppointmentStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colAppointmentStatus.OptionsColumn.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.AllowFocus = false;
            this.colNombre.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNombre.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNombre.OptionsColumn.AllowMove = false;
            this.colNombre.OptionsColumn.AllowShowHide = false;
            this.colNombre.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.OptionsFilter.AllowAutoFilter = false;
            this.colNombre.OptionsFilter.AllowFilter = false;
            this.colNombre.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            this.colNombre.Width = 300;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cerrado", 632, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("En espera", 630, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("En atención", 631, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelado", 633, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Libre", 636, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 637, 4)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.uc_MedioContacto1);
            this.xtraTabPage3.Image = global::Health.Front.Base.Properties.Resource.mail_32;
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(763, 456);
            this.xtraTabPage3.Text = "Medio de contacto";
            // 
            // uc_MedioContacto1
            // 
            this.uc_MedioContacto1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_MedioContacto1.Location = new System.Drawing.Point(0, 0);
            this.uc_MedioContacto1.Name = "uc_MedioContacto1";
            this.uc_MedioContacto1.Size = new System.Drawing.Size(763, 476);
            this.uc_MedioContacto1.TabIndex = 0;
            // 
            // FrmABMPatient
            // 
            this.AcceptButton = this.btnAcept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 608);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmABMPatient";
            this.Text = "Paciente";
            this.Load += new System.EventHandler(this.FrmABMPatient_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnAcept, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MutualXPatient)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MutualPorPacienteBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutualListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private Patients.uc_Persona uc_Persona1;
        private DevExpress.XtraEditors.SimpleButton btnAcept;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colAppointmentStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private System.Windows.Forms.BindingSource mutualListBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private Personas.uc_MedioContacto uc_MedioContacto1;
        private DevExpress.XtraGrid.GridControl gridControl_MutualXPatient;
        private System.Windows.Forms.BindingSource MutualPorPacienteBEBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreMutual;
        private DevExpress.XtraGrid.Columns.GridColumn colNroAfiliadoMutual;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDesactivar;
        private System.Windows.Forms.ToolStripMenuItem miActivar;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.TextEdit txtNombres;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}