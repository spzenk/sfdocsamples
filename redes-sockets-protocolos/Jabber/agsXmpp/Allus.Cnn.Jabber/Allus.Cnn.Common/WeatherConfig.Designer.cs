namespace Allus.Cnn.Common
{
    partial class WeatherConfig
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLocalidad = new DevExpress.XtraEditors.LookUpEdit();
            this.getWeatherResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocalidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getWeatherResponseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Localidad";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.Location = new System.Drawing.Point(12, 40);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLocalidad.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 35, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbLocalidad.Properties.DataSource = this.getWeatherResponseBindingSource;
            this.cmbLocalidad.Properties.DisplayMember = "Name";
            this.cmbLocalidad.Properties.NullText = "";
            this.cmbLocalidad.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cmbLocalidad.Properties.ValueMember = "Code";
            this.cmbLocalidad.Size = new System.Drawing.Size(194, 20);
            this.cmbLocalidad.TabIndex = 28;
            this.cmbLocalidad.EditValueChanged += new System.EventHandler(this.cmbLocalidad_EditValueChanged);
            // 
            // getWeatherResponseBindingSource
            // 
            this.getWeatherResponseBindingSource.DataSource = typeof(Allus.Cnn.Weather.ISVC.GetWeather.GetWeatherResponse);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(52, 97);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "Aceptar";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(133, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(136, 66);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(42, 20);
            this.spinEdit1.TabIndex = 31;
            this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(118, 13);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Refrescar clima cada";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(185, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(21, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "min";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Allus.Cnn.Common.Properties.Resources._36d;
            this.pictureBox1.Location = new System.Drawing.Point(179, -25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 62);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // WeatherConfig
            // 
            this.AcceptButton = this.btnOk;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(220, 128);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MaximumSize = new System.Drawing.Size(226, 192);
            this.Name = "WeatherConfig";
            this.Text = "Configuraci�n del clima";
            this.Load += new System.EventHandler(this.WeatherConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocalidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getWeatherResponseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbLocalidad;
        private System.Windows.Forms.BindingSource getWeatherResponseBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}