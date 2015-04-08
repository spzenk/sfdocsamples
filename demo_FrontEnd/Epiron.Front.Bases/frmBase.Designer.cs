namespace Epiron.Front.Bases
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.ExceptionViewer = new Epiron.Front.Bases.ExceptionViewComponent(this.components);
            this.MessageViewer = new Epiron.Front.Bases.MessageViewerComponent(this.components);
            this.MultilanguageSetting = new Epiron.Front.Bases.MultilanguageSetting(this.components);
            this.SuspendLayout();
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "";
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.Gray;
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Medium;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Epiron gestion";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 345);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBase";
            this.Text = "frmBase";
            this.ResumeLayout(false);

        }

        #endregion

        public Epiron.Front.Bases.ExceptionViewComponent ExceptionViewer;
        public Epiron.Front.Bases.MessageViewerComponent MessageViewer;
        private MultilanguageSetting MultilanguageSetting;
        
    }
}