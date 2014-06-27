namespace Health.Front
{
    partial class frmFindPersons
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdPersonas = new DevExpress.XtraGrid.GridControl();
            this.personaListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSexo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaNacimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 561);
            this.aceptCancelButtonBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(848, 28);
            // 
            // grdPersonas
            // 
            this.grdPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPersonas.DataSource = this.personaListBindingSource;
            this.grdPersonas.Location = new System.Drawing.Point(6, 7);
            this.grdPersonas.MainView = this.gridView1;
            this.grdPersonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPersonas.Name = "grdPersonas";
            this.grdPersonas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdPersonas.Size = new System.Drawing.Size(852, 543);
            this.grdPersonas.TabIndex = 66;
            this.grdPersonas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // personaListBindingSource
            // 
            this.personaListBindingSource.DataSource = typeof(Health.BE.PersonaBE);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNroDocumento,
            this.colApellido,
            this.colNombre,
            this.colSexo,
            this.colFechaNacimiento});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[IsAuthorized] == False";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.grdPersonas;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.ClearFindOnClose = false;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colNroDocumento
            // 
            this.colNroDocumento.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colNroDocumento.AppearanceHeader.Options.UseFont = true;
            this.colNroDocumento.AppearanceHeader.Options.UseTextOptions = true;
            this.colNroDocumento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNroDocumento.FieldName = "NroDocumento";
            this.colNroDocumento.Name = "colNroDocumento";
            this.colNroDocumento.OptionsColumn.AllowEdit = false;
            this.colNroDocumento.OptionsColumn.AllowShowHide = false;
            this.colNroDocumento.Visible = true;
            this.colNroDocumento.VisibleIndex = 2;
            // 
            // colApellido
            // 
            this.colApellido.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colApellido.AppearanceHeader.Options.UseFont = true;
            this.colApellido.AppearanceHeader.Options.UseTextOptions = true;
            this.colApellido.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colApellido.FieldName = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.OptionsColumn.AllowEdit = false;
            this.colApellido.OptionsColumn.AllowShowHide = false;
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 0;
            // 
            // colNombre
            // 
            this.colNombre.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colNombre.AppearanceHeader.Options.UseFont = true;
            this.colNombre.AppearanceHeader.Options.UseTextOptions = true;
            this.colNombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.AllowShowHide = false;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colSexo
            // 
            this.colSexo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colSexo.AppearanceHeader.Options.UseFont = true;
            this.colSexo.AppearanceHeader.Options.UseTextOptions = true;
            this.colSexo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSexo.FieldName = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.OptionsColumn.AllowEdit = false;
            this.colSexo.OptionsColumn.AllowShowHide = false;
            this.colSexo.Visible = true;
            this.colSexo.VisibleIndex = 3;
            // 
            // colFechaNacimiento
            // 
            this.colFechaNacimiento.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.colFechaNacimiento.AppearanceHeader.Options.UseFont = true;
            this.colFechaNacimiento.AppearanceHeader.Options.UseTextOptions = true;
            this.colFechaNacimiento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFechaNacimiento.FieldName = "FechaNacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.OptionsColumn.AllowEdit = false;
            this.colFechaNacimiento.OptionsColumn.AllowShowHide = false;
            this.colFechaNacimiento.Visible = true;
            this.colFechaNacimiento.VisibleIndex = 4;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            serializableAppearanceObject1.Options.UseImage = true;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "Estado", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No activo", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Activo", true, 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // frmFindPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 593);
            this.Controls.Add(this.grdPersonas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmFindPersons";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "Buscar persona ";
            this.Controls.SetChildIndex(this.grdPersonas, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPersonas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.BindingSource personaListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colSexo;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaNacimiento;
    }
}