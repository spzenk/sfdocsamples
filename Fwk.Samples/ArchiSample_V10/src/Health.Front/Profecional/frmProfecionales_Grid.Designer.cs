namespace Health.Front.profesional
{
    partial class frmProfesionales_Grid
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
            this.uc_Profesionales_Grid1 = new Health.Front.profesional.uc_Profesionales_Grid();
            this.SuspendLayout();
            // 
            // uc_Profesionales_Grid1
            // 
            this.uc_Profesionales_Grid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_Profesionales_Grid1.Location = new System.Drawing.Point(3, 5);
            this.uc_Profesionales_Grid1.Name = "uc_Profesionales_Grid1";
            this.uc_Profesionales_Grid1.SelectedProfesionalBE = null;
            this.uc_Profesionales_Grid1.Size = new System.Drawing.Size(1061, 702);
            this.uc_Profesionales_Grid1.TabIndex = 0;
            this.uc_Profesionales_Grid1.uc_ProfesionalesGrid_DoubleClick += new System.EventHandler(this.uc_Profesionales_Grid1_uc_ProfesionalesGrid_DoubleClick);
            // 
            // frmProfesionales_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 737);
            this.Controls.Add(this.uc_Profesionales_Grid1);
            this.KeyPreview = true;
            this.Name = "frmProfesionales_Grid";
            this.Text = "Gestión de profesionales";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProfesionales_Grid_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_Profesionales_Grid uc_Profesionales_Grid1;
    }
}