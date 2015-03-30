namespace Health.Front.Scheduler
{
    partial class frmMain_ShiftsMannager
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
            this.uc_shedule_profesional_timeline1 = new Health.Front.Scheduler.uc_shedule_profesional_timeline();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.profesionalFullViewBEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombreProfecion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreEspecialidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfesional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.iFindPatients = new DevExpress.XtraNavBar.NavBarItem();
            this.iTurnosPorPatient = new DevExpress.XtraNavBar.NavBarItem();
            this.iTodos = new DevExpress.XtraNavBar.NavBarItem();
            this.iCalendario = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesionalFullViewBEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // uc_shedule_Profesional_timeline1
            // 
            this.uc_shedule_profesional_timeline1.AcceptButton = null;
            this.uc_shedule_profesional_timeline1.CancelButton = null;
            this.uc_shedule_profesional_timeline1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_shedule_profesional_timeline1.Key = null;
            this.uc_shedule_profesional_timeline1.Location = new System.Drawing.Point(0, 0);
            this.uc_shedule_profesional_timeline1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_shedule_profesional_timeline1.Name = "uc_shedule_profesional_timeline1";
            this.uc_shedule_profesional_timeline1.ShowClose = false;
            this.uc_shedule_profesional_timeline1.Size = new System.Drawing.Size(729, 728);
            this.uc_shedule_profesional_timeline1.TabIndex = 0;
            this.uc_shedule_profesional_timeline1.Load += new System.EventHandler(this.uc_shedule_profesional_timeline1_Load);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.monthCalendar1);
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.uc_shedule_profesional_timeline1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1061, 728);
            this.splitContainerControl1.SplitterPosition = 327;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(21, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 45;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.iTurnosPorPatient,
            this.iTodos,
            this.iCalendario,
            this.iFindPatients});
            this.navBarControl1.Location = new System.Drawing.Point(-1, 212);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 223;
            this.navBarControl1.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl1.Size = new System.Drawing.Size(326, 516);
            this.navBarControl1.TabIndex = 46;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Blue");
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Lista de Profesionales";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 208;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = global::Health.Front.Base.Properties.Resource.diagnostic_clock_48;
            this.navBarGroup1.ItemChanged += new System.EventHandler(this.navBarGroup1_ItemChanged);
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.gridControl2);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(324, 311);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.profesionalFullViewBEBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(324, 311);
            this.gridControl2.TabIndex = 46;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // profesionalFullViewBEBindingSource
            // 
            this.profesionalFullViewBEBindingSource.DataSource = typeof(Health.BE.Profesional_FullViewBE);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView2.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.gridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView2.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.gridView2.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.SteelBlue;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.DarkGray;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView2.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView2.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.SteelBlue;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.White;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Gray;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.gridView2.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.Preview.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.Preview.Options.UseBackColor = true;
            this.gridView2.Appearance.Preview.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.Row.Options.UseForeColor = true;
            this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gray;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Gray;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombreProfecion,
            this.colNombreEspecialidad,
            this.colProfesional});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupCount = 1;
            this.gridView2.GroupFormat = "{1} {2}";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFind.AlwaysVisible = true;
            this.gridView2.OptionsFind.ClearFindOnClose = false;
            this.gridView2.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView2.OptionsFind.ShowCloseButton = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsSelection.InvertSelection = true;
            this.gridView2.OptionsView.ShowColumnHeaders = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 30;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNombreProfecion, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView2.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView2_CustomUnboundColumnData);
            this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView2_MouseDown);
            // 
            // colNombreProfecion
            // 
            this.colNombreProfecion.Caption = "Profesión";
            this.colNombreProfecion.FieldName = "NombreProfecion";
            this.colNombreProfecion.GroupFormat.FormatString = "{0}";
            this.colNombreProfecion.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colNombreProfecion.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colNombreProfecion.Name = "colNombreProfecion";
            this.colNombreProfecion.OptionsColumn.AllowEdit = false;
            this.colNombreProfecion.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colNombreProfecion.OptionsColumn.AllowMove = false;
            this.colNombreProfecion.OptionsColumn.AllowSize = false;
            this.colNombreProfecion.OptionsColumn.ReadOnly = true;
            this.colNombreProfecion.OptionsColumn.ShowCaption = false;
            this.colNombreProfecion.Visible = true;
            this.colNombreProfecion.VisibleIndex = 2;
            // 
            // colNombreEspecialidad
            // 
            this.colNombreEspecialidad.FieldName = "NombreEspecialidad";
            this.colNombreEspecialidad.Name = "colNombreEspecialidad";
            this.colNombreEspecialidad.OptionsColumn.AllowEdit = false;
            this.colNombreEspecialidad.OptionsColumn.AllowMove = false;
            this.colNombreEspecialidad.OptionsColumn.AllowShowHide = false;
            this.colNombreEspecialidad.OptionsColumn.ReadOnly = true;
            this.colNombreEspecialidad.OptionsColumn.ShowCaption = false;
            this.colNombreEspecialidad.Visible = true;
            this.colNombreEspecialidad.VisibleIndex = 1;
            this.colNombreEspecialidad.Width = 159;
            // 
            // colProfesional
            // 
            this.colProfesional.Caption = "profesional";
            this.colProfesional.FieldName = "ApellidoNombre";
            this.colProfesional.Name = "colProfesional";
            this.colProfesional.OptionsColumn.AllowEdit = false;
            this.colProfesional.OptionsColumn.AllowMove = false;
            this.colProfesional.OptionsColumn.AllowShowHide = false;
            this.colProfesional.OptionsColumn.ReadOnly = true;
            this.colProfesional.OptionsColumn.ShowCaption = false;
            this.colProfesional.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colProfesional.Visible = true;
            this.colProfesional.VisibleIndex = 0;
            this.colProfesional.Width = 236;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Patients";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.iFindPatients),
            new DevExpress.XtraNavBar.NavBarItemLink(this.iTurnosPorPatient),
            new DevExpress.XtraNavBar.NavBarItemLink(this.iTodos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.iCalendario)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImage = global::Health.Front.Base.Properties.Resource.group_32;
            // 
            // iFindPatients
            // 
            this.iFindPatients.Caption = "Patients";
            this.iFindPatients.Name = "iFindPatients";
            this.iFindPatients.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.iFindPatients_LinkClicked);
            // 
            // iTurnosPorPatient
            // 
            this.iTurnosPorPatient.Caption = "Turnos por Patients";
            this.iTurnosPorPatient.Name = "iTurnosPorPatient";
            this.iTurnosPorPatient.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.iTurnosPorPatient_LinkClicked);
            // 
            // iTodos
            // 
            this.iTodos.Caption = "Todos los turnos";
            this.iTodos.Name = "iTodos";
            // 
            // iCalendario
            // 
            this.iCalendario.Caption = "Calendario general";
            this.iCalendario.Name = "iCalendario";
            // 
            // frmMain_ShiftsMannager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmMain_ShiftsMannager";
            this.Text = "Gestion de turnos";
            this.Load += new System.EventHandler(this.frmShiftsMannager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesionalFullViewBEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_shedule_profesional_timeline uc_shedule_profesional_timeline1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private System.Windows.Forms.BindingSource profesionalFullViewBEBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreEspecialidad;
        private DevExpress.XtraGrid.Columns.GridColumn colProfesional;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem iTurnosPorPatient;
        private DevExpress.XtraNavBar.NavBarItem iTodos;
        private DevExpress.XtraNavBar.NavBarItem iCalendario;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreProfecion;
        private DevExpress.XtraNavBar.NavBarItem iFindPatients;

    }
}