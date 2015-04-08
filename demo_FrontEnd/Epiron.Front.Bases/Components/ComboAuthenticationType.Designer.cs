namespace  Epiron.Front.Bases.Controls
{
    partial class ComboAuthenticationType
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
            this.cmbAuthenticationType = new Epiron.Front.Bases.Controls.EP_LookUpEdit();
            this.authenticationTypeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAuthenticationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authenticationTypeListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAuthenticationType
            // 
            this.cmbAuthenticationType.CheckEditingABM = false;
            this.cmbAuthenticationType.CheckEditingABMValue = false;
            this.cmbAuthenticationType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAuthenticationType.Location = new System.Drawing.Point(0, 0);
            this.cmbAuthenticationType.Name = "cmbAuthenticationType";
            this.cmbAuthenticationType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthenticationTypeName", "Authentication Type Name", 150, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthenticationTypeTag", "Authentication Type Tag", 128, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthenticationTypeGUID", "Authentication Type GUID", 135, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Guid", "Guid", 31, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbAuthenticationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAuthenticationType.Properties.DataSource = this.authenticationTypeListBindingSource;
            this.cmbAuthenticationType.Properties.DisplayMember = "AuthenticationTypeName";
            this.cmbAuthenticationType.Properties.NullText = "[Vacio]";
            this.cmbAuthenticationType.Properties.NullValuePrompt = "Seleccione una opción";
            this.cmbAuthenticationType.Properties.ShowFooter = false;
            this.cmbAuthenticationType.Properties.ShowHeader = false;
            this.cmbAuthenticationType.Properties.ShowLines = false;
            this.cmbAuthenticationType.Properties.ValueMember = "AuthenticationTypeTag";
            this.cmbAuthenticationType.Size = new System.Drawing.Size(390, 20);
            this.cmbAuthenticationType.TabIndex = 0;
            this.cmbAuthenticationType.TextUICode = null;
            this.cmbAuthenticationType.EditValueChanged += new System.EventHandler(this.cmbAuthenticationType_ComboEditValueChanged);
            // 
            // authenticationTypeListBindingSource
            // 
            this.authenticationTypeListBindingSource.DataSource = typeof(Epiron.Front.Bases.Controls.AuthenticationTypeList);
            // 
            // ComboAuthenticationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbAuthenticationType);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ComboAuthenticationType";
            this.Size = new System.Drawing.Size(390, 25);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAuthenticationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authenticationTypeListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private EP_LookUpEdit cmbAuthenticationType;
        private System.Windows.Forms.BindingSource authenticationTypeListBindingSource;


    }
}
