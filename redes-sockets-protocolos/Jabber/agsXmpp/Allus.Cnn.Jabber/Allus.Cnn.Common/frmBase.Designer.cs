namespace Allus.Cnn.Common
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
            this.ctlLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.MessageViewer = new Allus.Libs.Common.MessageViewerComponent(this.components);
            this.ExceptionViewer = new Allus.Libs.Common.ExceptionViewComponent(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.fwkMailAgent1 = new Fwk.Mail.FwkMailAgent(this.components);
            this.SuspendLayout();
            // 
            // ctlLookAndFeel
            // 
            this.ctlLookAndFeel.LookAndFeel.SkinName = "Money Twins";
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.MessageViewer.IconSize = Allus.Libs.Common.IconSize.Small;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Allus.Libs.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Message";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // fwkMailAgent1
            // 
            this.fwkMailAgent1.Provider = null;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 124);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "frmBase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel ctlLookAndFeel;
        public Allus.Libs.Common.MessageViewerComponent MessageViewer;
        public Allus.Libs.Common.ExceptionViewComponent ExceptionViewer;
        public DevExpress.Utils.ToolTipController toolTipController1;
        public Fwk.Mail.FwkMailAgent fwkMailAgent1;
       
     
    }
}