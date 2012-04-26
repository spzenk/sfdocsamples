namespace MultiLanguage
{
    partial class Form1
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
            this.btnSaludo2 = new System.Windows.Forms.Button();
            this.btnSaludo = new DevExpress.XtraEditors.SimpleButton();
            this.rnd_Ingles = new System.Windows.Forms.RadioButton();
            this.rnd_Esp = new System.Windows.Forms.RadioButton();
            this.lblCulture = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.personsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApellido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSaludo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaludo2
            // 
            this.btnSaludo2.Location = new System.Drawing.Point(12, 156);
            this.btnSaludo2.Name = "btnSaludo2";
            this.btnSaludo2.Size = new System.Drawing.Size(175, 37);
            this.btnSaludo2.TabIndex = 0;
            this.btnSaludo2.Text = "Hola";
            this.btnSaludo2.UseVisualStyleBackColor = true;
        
            // 
            // btnSaludo
            // 
            this.btnSaludo.Location = new System.Drawing.Point(12, 109);
            this.btnSaludo.Name = "btnSaludo";
            this.btnSaludo.Size = new System.Drawing.Size(175, 41);
            this.btnSaludo.TabIndex = 1;
            this.btnSaludo.Tag = "saludo";
            this.btnSaludo.Text = "Hola";
            
            // 
            // rnd_Ingles
            // 
            this.rnd_Ingles.AutoSize = true;
            this.rnd_Ingles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rnd_Ingles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rnd_Ingles.Location = new System.Drawing.Point(22, 13);
            this.rnd_Ingles.Name = "rnd_Ingles";
            this.rnd_Ingles.Size = new System.Drawing.Size(78, 28);
            this.rnd_Ingles.TabIndex = 2;
            this.rnd_Ingles.Text = "Ingles";
            this.rnd_Ingles.UseVisualStyleBackColor = true;

            // 
            // rnd_Esp
            // 
            this.rnd_Esp.AutoSize = true;
            this.rnd_Esp.Checked = true;
            this.rnd_Esp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rnd_Esp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rnd_Esp.Location = new System.Drawing.Point(123, 14);
            this.rnd_Esp.Name = "rnd_Esp";
            this.rnd_Esp.Size = new System.Drawing.Size(97, 28);
            this.rnd_Esp.TabIndex = 3;
            this.rnd_Esp.TabStop = true;
            this.rnd_Esp.Text = "Español";
            this.rnd_Esp.UseVisualStyleBackColor = true;
            this.rnd_Esp.CheckedChanged += new System.EventHandler(this.rnd_Esp_CheckedChanged);
            // 
            // lblCulture
            // 
            this.lblCulture.AutoSize = true;
            this.lblCulture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCulture.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCulture.Location = new System.Drawing.Point(258, 16);
            this.lblCulture.Name = "lblCulture";
            this.lblCulture.Size = new System.Drawing.Size(60, 24);
            this.lblCulture.TabIndex = 4;
            this.lblCulture.Text = "label1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.personsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(262, 95);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // personsBindingSource
            // 
            this.personsBindingSource.DataSource = typeof(MultiLanguage.Persons);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre,
            this.colApellido,
            this.colDireccion});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            // 
            // colApellido
            // 
            this.colApellido.FieldName = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.Visible = true;
            this.colApellido.VisibleIndex = 1;
            // 
            // colDireccion
            // 
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 2;
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSaludo.Location = new System.Drawing.Point(40, 348);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(277, 24);
            this.lblSaludo.TabIndex = 6;
            this.lblSaludo.Text = "Prueva en diferentes lenguages";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 469);
            this.Controls.Add(this.lblSaludo);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblCulture);
            this.Controls.Add(this.rnd_Esp);
            this.Controls.Add(this.rnd_Ingles);
            this.Controls.Add(this.btnSaludo);
            this.Controls.Add(this.btnSaludo2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaludo2;
        private DevExpress.XtraEditors.SimpleButton btnSaludo;
        private System.Windows.Forms.RadioButton rnd_Ingles;
        private System.Windows.Forms.RadioButton rnd_Esp;
        private System.Windows.Forms.Label lblCulture;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource personsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colApellido;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private System.Windows.Forms.Label lblSaludo;
    }
}

