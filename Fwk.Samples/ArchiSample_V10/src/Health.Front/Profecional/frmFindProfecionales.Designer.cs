namespace Health.Front
{
    partial class frmFindProfesionales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindProfesionales));
            this.uc_Profesionales_Grid1 = new Health.Front.profesional.uc_Profesionales_Grid();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 585);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(1026, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uc_Profesionales_Grid1
            // 
            this.uc_Profesionales_Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Profesionales_Grid1.Location = new System.Drawing.Point(3, 5);
            this.uc_Profesionales_Grid1.Name = "uc_Profesionales_Grid1";
            this.uc_Profesionales_Grid1.SelectedProfesionalBE = null;
            this.uc_Profesionales_Grid1.Size = new System.Drawing.Size(1026, 608);
            this.uc_Profesionales_Grid1.TabIndex = 1;
            this.uc_Profesionales_Grid1.uc_ProfesionalesGrid_DoubleClick += new System.EventHandler(this.uc_Profesionales_Grid1_uc_ProfesionalesGrid_DoubleClick);
            // 
            // frmFindProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 618);
            this.Controls.Add(this.uc_Profesionales_Grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFindProfesionales";
            this.Text = "Buscar profesional";
            this.Controls.SetChildIndex(this.uc_Profesionales_Grid1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private profesional.uc_Profesionales_Grid uc_Profesionales_Grid1;

    }
}