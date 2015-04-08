namespace  Epiron.Front.Bases.Controls
{
    partial class ComboDomain
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
            this.cmbDominios = new Epiron.Front.Bases.Controls.EP_LookUpEdit();
            this.domainListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDominios
            // 
            this.cmbDominios.CheckEditingABM = false;
            this.cmbDominios.CheckEditingABMValue = false;
            this.cmbDominios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDominios.Location = new System.Drawing.Point(0, 0);
            this.cmbDominios.Name = "cmbDominios";
            this.cmbDominios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDominios.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DomainName", "Domain Name", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbDominios.Properties.DataSource = this.domainListBindingSource;
            this.cmbDominios.Properties.DisplayMember = "DomainName";
            this.cmbDominios.Properties.NullText = "No hay datos";
            this.cmbDominios.Properties.ShowFooter = false;
            this.cmbDominios.Properties.ShowHeader = false;
            this.cmbDominios.Properties.ShowLines = false;
            this.cmbDominios.Properties.ValueMember = "DomainId";
            this.cmbDominios.Size = new System.Drawing.Size(381, 20);
            this.cmbDominios.TabIndex = 0;
            this.cmbDominios.TextUICode = null;
            // 
            // domainListBindingSource
            // 
            this.domainListBindingSource.DataSource = typeof(Epiron.Front.Bases.Controls.DomainList);
            // 
            // ComboDomain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDominios);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ComboDomain";
            this.Size = new System.Drawing.Size(381, 22);
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EP_LookUpEdit cmbDominios;
        private System.Windows.Forms.BindingSource domainListBindingSource;

    }
}
