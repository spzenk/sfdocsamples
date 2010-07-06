namespace Allus.Cnn.Common
{
    partial class DomainCombosFilters
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.sucursalbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDominio = new DevExpress.XtraEditors.LookUpEdit();
            this.dominiobindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdCargo = new DevExpress.XtraEditors.LookUpEdit();
            this.cargobindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdSubarea = new DevExpress.XtraEditors.LookUpEdit();
            this.SubareabindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdCuenta = new DevExpress.XtraEditors.LookUpEdit();
            this.cuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dominiobindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargobindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSubarea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubareabindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(169, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Sucursal";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Location = new System.Drawing.Point(166, 57);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbSucursal.Properties.DataSource = this.sucursalbindingSource;
            this.cmbSucursal.Properties.DisplayMember = "Name";
            this.cmbSucursal.Properties.NullText = "Todos";
            this.cmbSucursal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbSucursal.Properties.ValueMember = "DomainId";
            this.cmbSucursal.Size = new System.Drawing.Size(147, 20);
            this.cmbSucursal.TabIndex = 20;
            this.cmbSucursal.EditValueChanged += new System.EventHandler(this.cmbSucursal_EditValueChanged);
            // 
            // sucursalbindingSource
            // 
            this.sucursalbindingSource.DataSource = typeof(Allus.Cnn.Common.BE.DomainList);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(169, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Dominio";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 81);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Cargo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Subarea";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Cuenta";
            // 
            // cmbDominio
            // 
            this.cmbDominio.Location = new System.Drawing.Point(166, 17);
            this.cmbDominio.Name = "cmbDominio";
            this.cmbDominio.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbDominio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDominio.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbDominio.Properties.DataSource = this.dominiobindingSource;
            this.cmbDominio.Properties.DisplayMember = "Name";
            this.cmbDominio.Properties.NullText = "Todos";
            this.cmbDominio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbDominio.Properties.ValueMember = "DomainId";
            this.cmbDominio.Size = new System.Drawing.Size(147, 20);
            this.cmbDominio.TabIndex = 15;
            this.cmbDominio.EditValueChanged += new System.EventHandler(this.cmbDominio_EditValueChanged);
            // 
            // dominiobindingSource
            // 
            this.dominiobindingSource.DataSource = typeof(Allus.Cnn.Common.BE.DomainList);
            // 
            // cmdCargo
            // 
            this.cmdCargo.Location = new System.Drawing.Point(6, 97);
            this.cmdCargo.Name = "cmdCargo";
            this.cmdCargo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmdCargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdCargo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmdCargo.Properties.DataSource = this.cargobindingSource;
            this.cmdCargo.Properties.DisplayMember = "Name";
            this.cmdCargo.Properties.NullText = "Todos";
            this.cmdCargo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmdCargo.Properties.ValueMember = "DomainId";
            this.cmdCargo.Size = new System.Drawing.Size(147, 20);
            this.cmdCargo.TabIndex = 14;
            this.cmdCargo.EditValueChanged += new System.EventHandler(this.cmdCargo_EditValueChanged);
            // 
            // cargobindingSource
            // 
            this.cargobindingSource.DataSource = typeof(Allus.Cnn.Common.BE.DomainList);
            // 
            // cmdSubarea
            // 
            this.cmdSubarea.Location = new System.Drawing.Point(5, 57);
            this.cmdSubarea.Name = "cmdSubarea";
            this.cmdSubarea.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmdSubarea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdSubarea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmdSubarea.Properties.DataSource = this.SubareabindingSource;
            this.cmdSubarea.Properties.DisplayMember = "Name";
            this.cmdSubarea.Properties.NullText = "Todos";
            this.cmdSubarea.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmdSubarea.Properties.ValueMember = "DomainId";
            this.cmdSubarea.Size = new System.Drawing.Size(147, 20);
            this.cmdSubarea.TabIndex = 13;
            this.cmdSubarea.EditValueChanged += new System.EventHandler(this.cmdSubarea_EditValueChanged);
            // 
            // SubareabindingSource
            // 
            this.SubareabindingSource.DataSource = typeof(Allus.Cnn.Common.BE.DomainList);
            // 
            // cmdCuenta
            // 
            this.cmdCuenta.Location = new System.Drawing.Point(5, 17);
            this.cmdCuenta.Name = "cmdCuenta";
            this.cmdCuenta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmdCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdCuenta.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nombre", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmdCuenta.Properties.DataSource = this.cuentaBindingSource;
            this.cmdCuenta.Properties.DisplayMember = "Name";
            this.cmdCuenta.Properties.NullText = "Todos";
            this.cmdCuenta.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmdCuenta.Properties.ValueMember = "DomainId";
            this.cmdCuenta.Size = new System.Drawing.Size(147, 20);
            this.cmdCuenta.TabIndex = 12;
            this.cmdCuenta.EditValueChanged += new System.EventHandler(this.cmdCuenta_EditValueChanged);
            // 
            // cuentaBindingSource
            // 
            this.cuentaBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.DomainList);
            // 
            // DomainCombosFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbDominio);
            this.Controls.Add(this.cmdCargo);
            this.Controls.Add(this.cmdSubarea);
            this.Controls.Add(this.cmdCuenta);
            this.Name = "DomainCombosFilters";
            this.Size = new System.Drawing.Size(319, 123);
            this.Load += new System.EventHandler(this.DomainCombosFilters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dominiobindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargobindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSubarea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubareabindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit cmbSucursal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbDominio;
        private DevExpress.XtraEditors.LookUpEdit cmdCargo;
        private DevExpress.XtraEditors.LookUpEdit cmdSubarea;
        private DevExpress.XtraEditors.LookUpEdit cmdCuenta;
        private System.Windows.Forms.BindingSource cuentaBindingSource;
        private System.Windows.Forms.BindingSource SubareabindingSource;
        private System.Windows.Forms.BindingSource cargobindingSource;
        private System.Windows.Forms.BindingSource sucursalbindingSource;
        private System.Windows.Forms.BindingSource dominiobindingSource;
    }
}
