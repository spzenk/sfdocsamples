namespace Allus.Cnn.Common
{
    partial class DomainFilters
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
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.domainCombosFilters1 = new Allus.Cnn.Common.DomainCombosFilters();
            this.SuspendLayout();
            // 
            // btnAcept
            // 
            this.btnAcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcept.Location = new System.Drawing.Point(240, 95);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(74, 23);
            this.btnAcept.TabIndex = 2;
            this.btnAcept.Text = "Buscar";
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // domainCombosFilters1
            // 
            this.domainCombosFilters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domainCombosFilters1.Location = new System.Drawing.Point(0, 0);
            this.domainCombosFilters1.Mesh = null;
            this.domainCombosFilters1.Name = "domainCombosFilters1";
            this.domainCombosFilters1.Size = new System.Drawing.Size(319, 124);
            this.domainCombosFilters1.TabIndex = 14;
            // 
            // DomainFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.domainCombosFilters1);
            this.Name = "DomainFilters";
            this.Size = new System.Drawing.Size(319, 124);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAcept;
        private DomainCombosFilters domainCombosFilters1;
    }
}
