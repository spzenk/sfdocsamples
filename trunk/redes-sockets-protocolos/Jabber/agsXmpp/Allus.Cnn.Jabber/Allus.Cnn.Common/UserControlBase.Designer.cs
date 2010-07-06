using Allus.Libs.Common;
namespace Allus.Cnn.Common
{
    partial class UserControlBase
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
            this.MessageViewer = new Allus.Libs.Common.MessageViewerComponent(this.components);
            this.ExceptionViewer = new Allus.Libs.Common.ExceptionViewComponent(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.SuspendLayout();
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
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // UserControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControlBase";
            this.Size = new System.Drawing.Size(624, 459);
            this.ResumeLayout(false);

        }

        #endregion

        public MessageViewerComponent MessageViewer;
        public ExceptionViewComponent ExceptionViewer;
        public DevExpress.Utils.ToolTipController toolTipController1;
    }
}
