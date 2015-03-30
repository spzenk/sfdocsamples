namespace Health.Front
{
    partial class frmGridPatients
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
            this.btnCreatePatient = new DevExpress.XtraEditors.SimpleButton();
            this.uc_PatientsGrid1 = new Health.Front.Patients.uc_PatientsGrid();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(1048, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // btnCreatePatient
            // 
            this.btnCreatePatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePatient.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCreatePatient.Appearance.Options.UseFont = true;
            this.btnCreatePatient.Image = global::Health.Front.Base.Properties.Resource.confirm_16;
            this.btnCreatePatient.Location = new System.Drawing.Point(612, 8);
            this.btnCreatePatient.Name = "btnCreatePatient";
            this.btnCreatePatient.Size = new System.Drawing.Size(143, 31);
            this.btnCreatePatient.TabIndex = 68;
            this.btnCreatePatient.Text = "Crear paciente";
            this.btnCreatePatient.Click += new System.EventHandler(this.btnCreatePatient_Click);
            // 
            // uc_PatientsGrid1
            // 
            this.uc_PatientsGrid1.AcceptButton = null;
            this.uc_PatientsGrid1.CancelButton = null;
            this.uc_PatientsGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_PatientsGrid1.Key = null;
            this.uc_PatientsGrid1.Location = new System.Drawing.Point(3, 5);
            this.uc_PatientsGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_PatientsGrid1.Name = "uc_PatientsGrid1";
            this.uc_PatientsGrid1.ShowClose = false;
            this.uc_PatientsGrid1.Size = new System.Drawing.Size(1048, 555);
            this.uc_PatientsGrid1.TabIndex = 69;
            this.uc_PatientsGrid1.Tittle = "Listado de pacientes ";
            this.uc_PatientsGrid1.OnDoubleClickEvent += new System.EventHandler(this.uc_PatientsGrid1_OnDoubleClickEvent);
            // 
            // frmGridPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 593);
            this.Controls.Add(this.btnCreatePatient);
            this.Controls.Add(this.uc_PatientsGrid1);
            this.Name = "frmGridPatients";
            this.Text = "Pacientes";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.uc_PatientsGrid1, 0);
            this.Controls.SetChildIndex(this.btnCreatePatient, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCreatePatient;
        private Patients.uc_PatientsGrid uc_PatientsGrid1;
    }
}