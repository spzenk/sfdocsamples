namespace DevExpress.XtraCharts.Demos.Modules {
	partial class ChartDemoBase {
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.checkEditShowLabels = new DevExpress.XtraEditors.CheckEdit();
            this.panelRoot = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowLabels.Properties)).BeginInit();
            this.panelRoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.checkEditShowLabels);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.panel.Size = new System.Drawing.Size(700, 66);
            this.panel.TabIndex = 0;
            // 
            // checkEditShowLabels
            // 
            this.checkEditShowLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEditShowLabels.EditValue = true;
            this.checkEditShowLabels.Location = new System.Drawing.Point(606, 37);
            this.checkEditShowLabels.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.checkEditShowLabels.Name = "checkEditShowLabels";
            this.checkEditShowLabels.Properties.Caption = "Show Labels";
            this.checkEditShowLabels.Size = new System.Drawing.Size(82, 18);
            this.checkEditShowLabels.TabIndex = 1;
            this.checkEditShowLabels.CheckedChanged += new System.EventHandler(this.checkEditShowLabels_CheckedChanged);
            // 
            // panelRoot
            // 
            this.panelRoot.Controls.Add(this.panel);
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panelRoot.Size = new System.Drawing.Size(700, 74);
            this.panelRoot.TabIndex = 1;
            // 
            // ChartDemoBase
            // 
            this.Controls.Add(this.panelRoot);
            this.Name = "ChartDemoBase";
            this.Size = new System.Drawing.Size(700, 500);
            this.Load += new System.EventHandler(this.ChartDemoBase_Load);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditShowLabels.Properties)).EndInit();
            this.panelRoot.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.ComponentModel.Container components = null;
        protected System.Windows.Forms.Panel panelRoot;

	}
}
