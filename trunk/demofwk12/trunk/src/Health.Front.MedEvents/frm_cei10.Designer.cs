namespace Health.Front
{
    partial class frm_cei10
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
            this.uc_CEI10_Tree1 = new Health.Front.uc_CEI10_Tree();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 635);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(1353, 28);
            this.aceptCancelButtonBar1.Visible = false;
            // 
            // uc_CEI10_Tree1
            // 
            this.uc_CEI10_Tree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_CEI10_Tree1.Location = new System.Drawing.Point(3, 5);
            this.uc_CEI10_Tree1.Name = "uc_CEI10_Tree1";
            this.uc_CEI10_Tree1.Size = new System.Drawing.Size(1353, 658);
            this.uc_CEI10_Tree1.TabIndex = 1;
            // 
            // frm_cei10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 668);
            this.Controls.Add(this.uc_CEI10_Tree1);
            this.Name = "frm_cei10";
            this.Text = " Clasificación internacional de enfermedades CEI 10";
            this.Load += new System.EventHandler(this.frm_cei10_Load);
            this.Controls.SetChildIndex(this.uc_CEI10_Tree1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_CEI10_Tree uc_CEI10_Tree1;
    }
}