namespace Health.Front.profesional
{
    partial class frmProfesionalCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfesionalCard));
            this.uc_Profesionales_Card1 = new Health.Front.profesional.uc_Profesionales_Card();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonText = "Salir";
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 571);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(1122, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uc_Profesionales_Card1
            // 
            this.uc_Profesionales_Card1.AcceptButton = null;
            this.uc_Profesionales_Card1.Appearance.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_Profesionales_Card1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.uc_Profesionales_Card1.Appearance.Options.UseFont = true;
            this.uc_Profesionales_Card1.Appearance.Options.UseForeColor = true;
            this.uc_Profesionales_Card1.CancelButton = null;
            this.uc_Profesionales_Card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Profesionales_Card1.Location = new System.Drawing.Point(3, 5);
            this.uc_Profesionales_Card1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_Profesionales_Card1.Name = "uc_Profesionales_Card1";
            this.uc_Profesionales_Card1.Size = new System.Drawing.Size(1122, 594);
            this.uc_Profesionales_Card1.TabIndex = 1;
            // 
            // frmProfesionalCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 604);
            this.Controls.Add(this.uc_Profesionales_Card1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfesionalCard";
            this.Text = "Perfil profesional";
            this.Load += new System.EventHandler(this.frmProfesionalCard_Load);
            this.Controls.SetChildIndex(this.uc_Profesionales_Card1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_Profesionales_Card uc_Profesionales_Card1;
    }
}